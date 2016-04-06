using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacebookSmartView
{
    class PopularPanelMgt
    {
        private const int MAX_PANEL = 4;
        private static Point m_NextFreePoint;
        private Size m_roSurface;
        private List<SpecialPictureBox> m_LstPictureBoxFromForm;
        private Label m_InformationLabel;
        private TextBox m_InformationCommentTextbox;

        private static PopularPanelMgt m_currentInstance;
        private static Object m_LockOnMgt = new Object();
        
        private string m_currentSelectedObjectId;

        public string CurrentObjectID         {            get { return m_currentSelectedObjectId; }            set { m_currentSelectedObjectId = value; }        }
        public Label InformationLabel        {            get { return m_InformationLabel; }            set { m_InformationLabel = value; }        }
        public TextBox InformationTextbox        {            get { return m_InformationCommentTextbox; }            set { m_InformationCommentTextbox = value; }
        }
        
        private PopularPanelMgt()
        {
            m_LstPictureBoxFromForm = new List<SpecialPictureBox>();
            m_NextFreePoint = new Point(GeneralVars.k_SPACER, GeneralVars.k_SPACER);
            m_currentSelectedObjectId = "";
        }

        public static PopularPanelMgt Instance
        {
            get
            {
                if(m_currentInstance == null){
                    lock (m_LockOnMgt)
                    {
                        if (m_currentInstance == null)
                        {
                            m_currentInstance = new PopularPanelMgt();
                        }
                    }
                }
                return m_currentInstance;
            }
        }

        public void setPanels(Panel i_OuterPanel, Panel i_InnerPanel)
        {
            m_roSurface = new Size(i_OuterPanel.Size.Width - GeneralVars.k_SPACER,
                                   i_OuterPanel.Size.Height - i_InnerPanel.Size.Height - GeneralVars.k_SPACER );
        }

        public List<SpecialPictureBox> PictureObjectList
        {
            get
            {
                return m_LstPictureBoxFromForm; 
            }
        }

        public bool tryAddToPanel(SpecialPictureBox i_poNew)
        {
            if (m_LstPictureBoxFromForm.Count < MAX_PANEL)
            {
                Point pNewPointForPicture;
                
                if (getNextFreeLocationInContainer(SpecialPictureBox.PictureBoxTopPhotosSize, out pNewPointForPicture))
                {
                    i_poNew.PictureObject = new PictureObject("", 0, 0, 0, "", "", i_poNew, i_poNew.PicLabel);
                    i_poNew.ObjectLocation = pNewPointForPicture;
                    i_poNew.updateNames(m_LstPictureBoxFromForm.Count);
                    m_LstPictureBoxFromForm.Add(i_poNew);
            
                    return GeneralVars.k_TRUE;
                }
            }

            i_poNew.removeObjectFromPanel();
            i_poNew = null;
            return GeneralVars.k_FALSE;
        }

        private bool getNextFreeLocationInContainer(Size i_PanelSize, out Point o_NewPoint)
        {
            if (m_NextFreePoint.X + i_PanelSize.Width < m_roSurface.Width &&
                m_NextFreePoint.Y + i_PanelSize.Height < m_roSurface.Height )
            {
                o_NewPoint = m_NextFreePoint;
                m_NextFreePoint = new Point(m_NextFreePoint.X + i_PanelSize.Width + GeneralVars.k_SPACER, m_NextFreePoint.Y);
                return GeneralVars.k_TRUE;
            }
            else
            {
                o_NewPoint = new Point(0, 0);
                return GeneralVars.k_FALSE;
            }
                
        }

    }
}
