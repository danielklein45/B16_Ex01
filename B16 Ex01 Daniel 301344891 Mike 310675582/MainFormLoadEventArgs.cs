using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookSmartView
{
    public class MainFormLoadEventArgs : EventArgs
    {
        public bool FinishedLoading { get; set; }
        public string Message { get; set; }
    }
}
