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
        private Panel m_BoxPanel;
        private Label m_BotLabel;
        private PictureObject m_PoPictureObjectID;

        private static readonly Size sr_PictureBoxTopPhotosSize = new Size(175, 165);

        private const int k_LabelHeight = 20;
        private const int k_LabelSpacer = 3;

        private const String k_PictureName = "_PicBox";
        private const String k_GeneralPanelName = "_Panel";
        private const String k_PanelName = "_Label";

        private readonly Size r_PanelSize = new Size(sr_PictureBoxTopPhotosSize.Width, k_LabelHeight);
        private readonly Point r_PanelStartLoc = new Point(0, sr_PictureBoxTopPhotosSize.Height - k_LabelHeight);
        private readonly Size r_PictureSize = new Size(sr_PictureBoxTopPhotosSize.Width, sr_PictureBoxTopPhotosSize.Height - k_LabelHeight);
        private readonly Point r_PictureStartLoc = new Point(0, 0);

        public SpecialPictureBox(Panel i_FatherPanel)
        {
            m_FatherPanel = i_FatherPanel;

            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Size = r_PictureSize;
            this.Location = new Point(0, 0);
            this.Click += SpecialPictureBoxOnClick;

            m_BotLabel = new Label();
            m_BotLabel.Size = r_PanelSize;
            m_BotLabel.Location = r_PanelStartLoc;
            m_BotLabel.AutoSize = false;
            m_BotLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.Visible = true;

            m_BoxPanel = new Panel();
            m_BoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            m_BoxPanel.Size = sr_PictureBoxTopPhotosSize;
            m_BoxPanel.Controls.Add(this);
            m_BoxPanel.Controls.Add(m_BotLabel);

            m_FatherPanel.Controls.Add(m_BoxPanel);
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
                PopularPanelMgt.Instance.CurrentObjectID = string.Empty;
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
            m_BotLabel.Name = m_FatherPanel.Name.ToString() + k_PanelName.ToString() + "_" + i_Id.ToString();
            m_BoxPanel.Name = m_FatherPanel.Name.ToString() + k_GeneralPanelName.ToString() + "_" + i_Id.ToString();
        }

        public void RemoveObjectFromPanel()
        {
            foreach (Control currControl in m_BoxPanel.Controls)
            {
                m_BoxPanel.Controls.Remove(currControl);
            }

            m_FatherPanel.Controls.Remove(m_BoxPanel);
        }
       
        protected override void OnMouseHover(EventArgs e)
        {
            m_BotLabel.BackColor = Color.LightSkyBlue;
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            m_BotLabel.BackColor = SystemColors.ButtonHighlight;
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
                this.m_BoxPanel.Location = value;
            } 
        }

        public static Size PictureBoxTopPhotosSize
        {
            get
            { 
                return sr_PictureBoxTopPhotosSize;
            } 
        }

        public PictureObject PictureObject 
        { 
            get
            { 
                return this.m_PoPictureObjectID;
            } 
            set 
            { 
                this.m_PoPictureObjectID = value;
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
                return m_BotLabel;
            } 
        }
    }
}
