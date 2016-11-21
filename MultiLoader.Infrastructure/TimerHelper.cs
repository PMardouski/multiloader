using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLoader.Infrastructure
{
    public static class TimerHelper
    {
        private static int _timer;

        public static int Timer
        {
            get
            {
                if (_timer == 0)
                    return 5000;

                return _timer;
            }

            set
            {
                if (value > 0)
                    _timer = value;
            }
        }
    }
}
