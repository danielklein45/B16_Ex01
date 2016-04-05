using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookSmartView
{
    class MainFormLoadEventArgs : EventArgs
    {
        private bool m_bfinishedLoading;
        public bool FinishedLoading { get { return m_bfinishedLoading; } set { m_bfinishedLoading = value; } }
    }
}
