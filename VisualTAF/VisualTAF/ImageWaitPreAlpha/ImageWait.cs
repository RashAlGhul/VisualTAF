using System;
using System.Drawing;
using VisualTAF.Exceptions;

namespace VisualTAF.ImageWaitPreAlpha
{
    class ImageWait : DefaultWait<Image>
    {
        private static TimeSpan DefaultSleepTimeout => TimeSpan.FromMilliseconds(500.0);


        public ImageWait(Image image, TimeSpan timeout)
            : this((IClock) new SystemClock(), image, timeout, ImageWait.DefaultSleepTimeout)
        {
        }

        public ImageWait(IClock clock, Image image, TimeSpan timeout, TimeSpan sleepInterval)
            : base(image, clock)
        {
            this.Timeout = timeout;
            this.PollingInterval = sleepInterval;
            this.IgnoreExceptionTypes(typeof(NotFoundException));
        }
    }
}
