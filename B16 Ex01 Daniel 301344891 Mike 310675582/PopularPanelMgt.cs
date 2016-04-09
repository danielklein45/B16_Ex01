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
        private const int k_MaxPanel = 4;
        private static Point s_NextFreePoint;
        private Size m_Surface;
        private List<SpecialPictureBox> m_LstPictureBoxFromForm;
        
        private static PopularPanelMgt s_CurrentInstance;
        private static Object s_LockOnMgt = new object();

        private string m_CurrentSelectedObjectId;
        private Label m_InformationLabel;
        private TextBox m_InformationCommentTextbox;
        private const int k_Spacer = 5;

        public string CurrentObjectID         
        {            
            get 
            { 
                return m_CurrentSelectedObjectId;
            }
            set 
            {
                m_CurrentSelectedObjectId = value;
            }
        }
        public Label InformationLabel        
        {            
            get 
            { 
                return m_InformationLabel;
            }   
            set 
            { 
                m_InformationLabel = value;
            }   
        }
        public TextBox InformationTextbox    
        { 
            get
            {
                return m_InformationCommentTextbox;
            }   
            set 
            {
                m_InformationCommentTextbox = value;
            }
        }
        public List<SpecialPictureBox> PictureObjectList
        {
            get
            {
                return m_LstPictureBoxFromForm;
            }
        }
        
        private PopularPanelMgt()
        {
            m_LstPictureBoxFromForm = new List<SpecialPictureBox>();
            s_NextFreePoint = new Point(k_Spacer, k_Spacer);
            m_CurrentSelectedObjectId = string.Empty;
            s_LockOnMgt = new Object();
        }

        public static PopularPanelMgt Instance
        {
            get
            {
                if(s_CurrentInstance == null)
                {
                    lock (s_LockOnMgt)
                    {
                        if (s_CurrentInstance == null)
                        {
                            s_CurrentInstance = new PopularPanelMgt();
                        }
                    }
                }

                return s_CurrentInstance;
            }
        }

        public void SetPanels(Panel i_OuterPanel, Panel i_InnerPanel)
        {
            m_Surface = new Size(i_OuterPanel.Size.Width - k_Spacer,
                                 i_OuterPanel.Size.Height - i_InnerPanel.Size.Height - k_Spacer );
        }

        public bool TryAddToPanel(SpecialPictureBox i_NewPicObject)
        {
            bool isAdded = false;
            Point pNewPointForPicture;

            if (m_LstPictureBoxFromForm.Count < k_MaxPanel)
            {
                if (getNextFreeLocationInContainer(SpecialPictureBox.PictureBoxTopPhotosSize, out pNewPointForPicture))
                {
                    i_NewPicObject.PictureObject = new PictureObject(string.Empty, 0,
                                                                     0, 0, string.Empty,
                                                                     string.Empty, i_NewPicObject, i_NewPicObject.PicLabel);
                    i_NewPicObject.ObjectLocation = pNewPointForPicture;
                    i_NewPicObject.UpdateNames(m_LstPictureBoxFromForm.Count);
                    m_LstPictureBoxFromForm.Add(i_NewPicObject);

                    isAdded = true;
                }
            }
            if (!isAdded)
            {
                i_NewPicObject.RemoveObjectFromPanel();
                i_NewPicObject = null;
            }
            
            return isAdded;
        }

        private bool getNextFreeLocationInContainer(Size i_PanelSize, out Point o_NewPoint)
        {
            bool isFree = false;

            if (s_NextFreePoint.X + i_PanelSize.Width < m_Surface.Width &&
                s_NextFreePoint.Y + i_PanelSize.Height < m_Surface.Height )
            {
                o_NewPoint = s_NextFreePoint;
                s_NextFreePoint = new Point(s_NextFreePoint.X + i_PanelSize.Width + k_Spacer, s_NextFreePoint.Y);

                isFree = true;
                return isFree;
            }

            o_NewPoint = new Point(0, 0);

            return isFree;
                
        }

    }
}
