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
        public string LoadingLabel { get { return lblLoading.Text; } set { lblLoading.Text = value; } }
        public FormLoader()
        {
            InitializeComponent();
            this.Opacity = 0;
            //this.pcBoxLoading.Load();
        }

        public void ImageLoadingComplete(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("sd");
            this.Opacity = 100;
        }

       
    }
}
