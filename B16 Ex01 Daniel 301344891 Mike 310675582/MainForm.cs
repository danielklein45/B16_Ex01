﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FacebookWrapper.ObjectModel;

namespace B16_Ex01_Daniel_301344891_Mike_310675582
{
    public partial class MainForm : Form
    {
        public User LoginUser { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }
    }
}
