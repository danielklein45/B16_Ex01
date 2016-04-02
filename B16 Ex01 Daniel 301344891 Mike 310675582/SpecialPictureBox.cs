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

        public SpecialPictureBox(Panel i_FatherPanel)
        {
            //Point newPointForPanel;
            //bool bIsThereFreeSpace = false;
            m_FatherPanel = i_FatherPanel;

            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Size = new Size(180, 140);
            this.Location = new Point(0, 0);
            this.Name = m_FatherPanel.ToString() + "_PicBox";


            m_botLabel = new Label();
            m_botLabel.Size = new Size(72, 15);
            m_botLabel.Location = new Point(5, 146);
            m_botLabel.AutoSize = true;

            this.Visible = true;

            //m_boxPanel = new Panel();
            //m_boxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //m_boxPanel.Size = new Size(180, 165);
            //bIsThereFreeSpace = PopularPanelMgt.getNextFreeLocationInContainer(new Point(m_boxPanel.Size.Width, m boxPanel.Size.Height), newPointForPanel);
            //m_boxPanel.Location = new Point(newPointForPanel);


            m_FatherPanel.Controls.Add(this);
            m_FatherPanel.Controls.Add(m_botLabel);

            //m_FatherPanel.Controls.Add(m_boxPanel);
        }

        public Panel FatherPanel { get { return m_FatherPanel; } }
        public Label PicLabel { get { return m_botLabel; } }

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
        
    }
}
