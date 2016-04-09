using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacebookSmartView
{
    public partial class FormLoader : Form

    {
        delegate void SetTextCallBack(string i_Text);
        delegate void CloseCallBack();

        public FormLoader()
        {
            InitializeComponent();
        }

        private void setText(string i_Text)
        {
            if (lblLoading.InvokeRequired)
            {
                SetTextCallBack callBack = new SetTextCallBack(setText);
                Invoke(callBack, new object[] { i_Text });
            }
            else
            {
                lblLoading.Text = i_Text;
            }
        }

        public void FinishLoading()
        {
            if (this.InvokeRequired)
            {
                CloseCallBack callBack = new CloseCallBack(FinishLoading);
                Invoke(callBack, new object[] { });
            }
            else
            {
                this.Close();
            }
        }
        
        public string LoadingLabel 
        { 
            get 
            { 
                return lblLoading.Text; 
            } 
            set 
            {
                setText(value);
            } 
        }
    }
}
