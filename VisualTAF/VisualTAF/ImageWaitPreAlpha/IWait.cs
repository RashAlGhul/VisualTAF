﻿using System;

namespace VisualTAF.ImageWaitPreAlpha
{
    /// <summary>
    /// Interface describing a class designed to wait for a condition.
    /// </summary>
    /// <typeparam name="T">The type of object used to detect the condition.</typeparam>
    public interface IWait<T>
    {
        /// <summary>
        /// Gets or sets how long to wait for the evaluated condition to be true.
        /// </summary>
        TimeSpan Timeout { get; set; }

        /// <summary>
        /// Gets or sets how often the condition should be evaluated.
        /// </summary>
        TimeSpan PollingInterval { get; set; }

        /// <summary>
        /// Gets or sets the message to be displayed when time expires.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Configures this instance to ignore specific types of exceptions while waiting for a condition.
        /// Any exceptions not whitelisted will be allowed to propagate, terminating the wait.
        /// </summary>
        /// <param name="exceptionTypes">The types of exceptions to ignore.</param>
        void IgnoreExceptionTypes(params Type[] exceptionTypes);

        /// <summary>Waits until a condition is true or times out.</summary>
        /// <typeparam name="TResult">The type of result to expect from the condition.</typeparam>
        /// <param name="condition">A delegate taking a TSource as its parameter, and returning a TResult.</param>
        /// <returns>If TResult is a boolean, the method returns <see langword="true" /> when the condition is true, and <see langword="false" /> otherwise.
        /// If TResult is an object, the method returns the object when the condition evaluates to a value other than <see langword="null" />.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown when TResult is not boolean or an object type.</exception>
        TResult Until<TResult>(Func<T, TResult> condition);
    }
}
