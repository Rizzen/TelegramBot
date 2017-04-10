using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TelegramBot.Util
{

    public class ThrottleFilter : IThrottleFilter
    {
        public TimeSpan? Frequency { get; set; }
        public DateTime LastExecution { get; private set; } = DateTime.MinValue;

        public void Start(TimeSpan frequency)
        {
            Frequency = frequency;
        }

        public void Stop()
        {
            Frequency = null;
        }

        public bool CanExecute()
        {
            if (Frequency == null) return true;
            return (Now - LastExecution) > Frequency;
        }

        public void Executed()
        {
            LastExecution = Now;
        }

        
        private DateTime Now => DateTime.Now;


    }

}
