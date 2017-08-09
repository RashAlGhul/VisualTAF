using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VisualTAF.ImageWait
{
    public class DefaultWait<T> : IWait<T>
    {
        private List<Type> ignoredExceptions = new List<Type>();
        private T input;
        private IClock clock;

        /// <summary>
        /// Gets or sets how long to wait for the evaluated condition to be true. The default timeout is 500 milliseconds.
        /// </summary>
        public TimeSpan Timeout { get; set; } = DefaultWait<T>.DefaultSleepTimeout;

        /// <summary>
        /// Gets or sets how often the condition should be evaluated. The default timeout is 500 milliseconds.
        /// </summary>
        public TimeSpan PollingInterval { get; set; } = DefaultWait<T>.DefaultSleepTimeout;

        /// <summary>
        /// Gets or sets the message to be displayed when time expires.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        private static TimeSpan DefaultSleepTimeout => TimeSpan.FromMilliseconds(500.0);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:OpenQA.Selenium.Support.UI.DefaultWait`1" /> class.
        /// </summary>
        /// <param name="input">The input value to pass to the evaluated conditions.</param>
        public DefaultWait(T input)
            : this(input, (IClock)new SystemClock())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:OpenQA.Selenium.Support.UI.DefaultWait`1" /> class.
        /// </summary>
        /// <param name="input">The input value to pass to the evaluated conditions.</param>
        /// <param name="clock">The clock to use when measuring the timeout.</param>
        public DefaultWait(T input, IClock clock)
        {
            if ((object)input == null)
                throw new ArgumentNullException("input", "input cannot be null");
            if (clock == null)
                throw new ArgumentNullException("clock", "clock cannot be null");
            this.input = input;
            this.clock = clock;
        }

        /// <summary>
        /// Configures this instance to ignore specific types of exceptions while waiting for a condition.
        /// Any exceptions not whitelisted will be allowed to propagate, terminating the wait.
        /// </summary>
        /// <param name="exceptionTypes">The types of exceptions to ignore.</param>
        public void IgnoreExceptionTypes(params Type[] exceptionTypes)
        {
            if (exceptionTypes == null)
                throw new ArgumentNullException("exceptionTypes", "exceptionTypes cannot be null");
            foreach (Type exceptionType in exceptionTypes)
            {
                if (!typeof(Exception).IsAssignableFrom(exceptionType))
                    throw new ArgumentException("All types to be ignored must derive from System.Exception", "exceptionTypes");
            }
            this.ignoredExceptions.AddRange((IEnumerable<Type>)exceptionTypes);
        }

        /// <summary>
        /// Repeatedly applies this instance's input value to the given function until one of the following
        /// occurs:
        /// <para>
        /// <list type="bullet">
        /// <item>the function returns neither null nor false</item>
        /// <item>the function throws an exception that is not in the list of ignored exception types</item>
        /// <item>the timeout expires</item>
        /// </list>
        /// </para>
        /// </summary>
        /// <typeparam name="TResult">The delegate's expected return type.</typeparam>
        /// <param name="condition">A delegate taking an object of type T as its parameter, and returning a TResult.</param>
        /// <returns>The delegate's return value.</returns>
        public TResult Until<TResult>(Func<T, TResult> condition)
        {
            if (condition == null)
                throw new ArgumentNullException("condition", "condition cannot be null");
            Type c = typeof(TResult);
            if (c.IsValueType && c != typeof(bool) || !typeof(object).IsAssignableFrom(c))
                throw new ArgumentException("Can only wait on an object or boolean response, tried to use type: " + c.ToString(), "condition");
            Exception lastException = (Exception)null;
            DateTime otherDateTime = this.clock.LaterBy(this.Timeout);
            while (true)
            {
                try
                {
                    TResult result = condition(this.input);
                    if (c == typeof(bool))
                    {
                        bool? nullable = (object)result as bool?;
                        if (nullable.HasValue)
                        {
                            if (nullable.Value)
                                return result;
                        }
                    }
                    else if ((object)result != null)
                        return result;
                }
                catch (Exception ex)
                {
                    if (!this.IsIgnoredException(ex))
                        throw;
                    else
                        lastException = ex;
                }
                if (!this.clock.IsNowBefore(otherDateTime))
                {
                    string exceptionMessage = string.Format((IFormatProvider)CultureInfo.InvariantCulture, $"Timed out after {0} seconds", new object[1]
                    {
                        (object) this.Timeout.TotalSeconds
                    });
                    if (!string.IsNullOrEmpty(this.Message))
                        exceptionMessage = exceptionMessage + ": " + this.Message;
                    this.ThrowTimeoutException(exceptionMessage, lastException);
                }
                Thread.Sleep(this.PollingInterval);
            }
        }

        protected virtual void ThrowTimeoutException(string exceptionMessage, Exception lastException)
        {
            throw new Exception(exceptionMessage, lastException);
        }

        private bool IsIgnoredException(Exception exception)
        {
            return this.ignoredExceptions.Any<Type>((Func<Type, bool>)(type => type.IsAssignableFrom(exception.GetType())));
        }
    }
}
