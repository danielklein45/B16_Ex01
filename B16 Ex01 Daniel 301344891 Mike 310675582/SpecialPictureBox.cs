using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacebookSmartView
{
    partial class SpecialPictureBox : PictureBox
    {
        private Panel m_FatherPanel;
        private Panel m_boxPanel;
        private Label m_botLabel;
        private PictureObject m_poPictureObjectID;

        private static readonly Size k_PictureBoxTopPhotosSize = new Size(175, 165);

        private const int k_LabelHeight = 20;
        private const int k_LabelSpacer = 3;

        private const String k_PictureName = "_PicBox";
        private const String k_GeneralPanelName = "_Panel";
        private const String k_PanelName = "_Label";

        private readonly Size r_PanelSize = new Size(k_PictureBoxTopPhotosSize.Width, k_LabelHeight);
        private readonly Point r_PanelStartLoc = new Point(0, k_PictureBoxTopPhotosSize.Height - k_LabelHeight);
        private readonly Size r_PictureSize = new Size(k_PictureBoxTopPhotosSize.Width, k_PictureBoxTopPhotosSize.Height - k_LabelHeight);
        private readonly Point r_PictureStartLoc = new Point(0, 0);


        public SpecialPictureBox(Panel i_FatherPanel)
        {
            m_FatherPanel = i_FatherPanel;

            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Size = r_PictureSize;
            this.Location = new Point(0, 0);
            this.Click += SpecialPictureBoxOnClick;


            m_botLabel = new Label();
            m_botLabel.Size = r_PanelSize;
            m_botLabel.Location = r_PanelStartLoc;
            m_botLabel.AutoSize = GeneralVars.k_FALSE;
            m_botLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.Visible = GeneralVars.k_TRUE;

            m_boxPanel = new Panel();
            m_boxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            m_boxPanel.Size = k_PictureBoxTopPhotosSize;


            m_boxPanel.Controls.Add(this);
            m_boxPanel.Controls.Add(m_botLabel);

            m_FatherPanel.Controls.Add(m_boxPanel);
        }

        void SpecialPictureBoxOnClick(object sender, EventArgs e)
        {
            string strSelectedObjectId;
            SpecialPictureBox spbCurrent;

            try
            {
                spbCurrent = (sender as SpecialPictureBox);
                strSelectedObjectId = spbCurrent.PictureObject.ObjectId.ToString();
                PopularPanelMgt.Instance.CurrentObjectID = strSelectedObjectId;
            }
            catch (Exception)
            {
                spbCurrent = null;
                PopularPanelMgt.Instance.CurrentObjectID = GeneralVars.k_EmptyString;
            }

            if (spbCurrent != null)
            {
                PopularPanelMgt.Instance.InformationLabel.Text = "This picture was posted on " + spbCurrent.PictureObject.PostedDate;
            }
            else
            {
                PopularPanelMgt.Instance.InformationLabel.Text = "Please select a picture from the panel.";
            }


        }

        public void UpdateNames(int i_Id)
        {
            this.Name = m_FatherPanel.Name.ToString() + k_PictureName.ToString() + "_" + i_Id.ToString();
            m_botLabel.Name = m_FatherPanel.Name.ToString() + k_PanelName.ToString() + "_" + i_Id.ToString();
            m_boxPanel.Name = m_FatherPanel.Name.ToString() + k_GeneralPanelName.ToString() + "_" + i_Id.ToString();
        }

        public void RemoveObjectFromPanel()
        {
            foreach (Control currControl in m_boxPanel.Controls)
            {
                m_boxPanel.Controls.Remove(currControl);
            }

            m_FatherPanel.Controls.Remove(m_boxPanel);

        }
       
        protected override void OnMouseHover(EventArgs e)
        {
            m_botLabel.BackColor = Color.LightSkyBlue;
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            m_botLabel.BackColor = SystemColors.ButtonHighlight;
            base.OnMouseLeave(e);
        }

        public Point ObjectLocation 
        { 
            get 
            { 
                return this.Location;
            } 
            set 
            { 
                this.m_boxPanel.Location = value;
            } 
        }

        public static Size PictureBoxTopPhotosSize
        {
            get
            { 
                return k_PictureBoxTopPhotosSize;
            } 
        }

        public PictureObject PictureObject 
        { 
            get
            { 
                return this.m_poPictureObjectID;
            } 
            set 
            { 
                this.m_poPictureObjectID = value;
            } 
        }

        public Panel FatherPanel
        {
            get 
            { 
                return m_FatherPanel;
            } 
        }

        public Label PicLabel 
        { 
            get 
            { 
                return m_botLabel;
            } 
        }
    }
}
