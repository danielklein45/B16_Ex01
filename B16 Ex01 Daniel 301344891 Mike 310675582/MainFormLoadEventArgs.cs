using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookSmartView
{
    public class MainFormLoadEventArgs : EventArgs
    {
        private bool m_bfinishedLoading;
        private string m_strMessage;
        public bool FinishedLoading { get { return m_bfinishedLoading; } set { m_bfinishedLoading = value; } }
        public string Message { get { return m_strMessage; } set { m_strMessage = value; } }
    }
}
