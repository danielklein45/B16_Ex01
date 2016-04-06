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
        private const int k_MAX_PANEL = 4;
        private static Point m_NextFreePoint;
        private Size m_Surface;
        private List<SpecialPictureBox> m_LstPictureBoxFromForm;
        
        private static PopularPanelMgt s_CurrentInstance;
        private static Object s_LockOnMgt;

        private string m_CurrentSelectedObjectId;
        private Label m_InformationLabel;
        private TextBox m_InformationCommentTextbox;

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
            m_NextFreePoint = new Point(GeneralVars.k_SPACER, GeneralVars.k_SPACER);
            m_CurrentSelectedObjectId = GeneralVars.k_EmptyString;
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
            m_Surface = new Size(i_OuterPanel.Size.Width - GeneralVars.k_SPACER,
                                 i_OuterPanel.Size.Height - i_InnerPanel.Size.Height - GeneralVars.k_SPACER );
        }

        public bool TryAddToPanel(SpecialPictureBox i_NewPicObject)
        {
            Point pNewPointForPicture;

            if (m_LstPictureBoxFromForm.Count < k_MAX_PANEL)
            {
                if (getNextFreeLocationInContainer(SpecialPictureBox.PictureBoxTopPhotosSize, out pNewPointForPicture))
                {
                    i_NewPicObject.PictureObject = new PictureObject(GeneralVars.k_EmptyString, GeneralVars.k_Zero,
                                                                     GeneralVars.k_Zero, GeneralVars.k_Zero, GeneralVars.k_EmptyString,
                                                                     GeneralVars.k_EmptyString, i_NewPicObject, i_NewPicObject.PicLabel);
                    i_NewPicObject.ObjectLocation = pNewPointForPicture;
                    i_NewPicObject.UpdateNames(m_LstPictureBoxFromForm.Count);
                    m_LstPictureBoxFromForm.Add(i_NewPicObject);
            
                    return GeneralVars.k_TRUE;
                }
            }

            i_NewPicObject.RemoveObjectFromPanel();
            i_NewPicObject = null;

            return GeneralVars.k_FALSE;
        }

        private bool getNextFreeLocationInContainer(Size i_PanelSize, out Point o_NewPoint)
        {
            if (m_NextFreePoint.X + i_PanelSize.Width < m_Surface.Width &&
                m_NextFreePoint.Y + i_PanelSize.Height < m_Surface.Height )
            {
                o_NewPoint = m_NextFreePoint;
                m_NextFreePoint = new Point(m_NextFreePoint.X + i_PanelSize.Width + GeneralVars.k_SPACER, m_NextFreePoint.Y);

                return GeneralVars.k_TRUE;
            }

            o_NewPoint = new Point(GeneralVars.k_Zero, GeneralVars.k_Zero);

            return GeneralVars.k_FALSE;
                
        }

    }
}
