using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FacebookSmartView
{
    class PopularPanelMgt
    {
        private const int MAX_PANEL = 4;
        private static Point m_lastEndOfPicture;

        private List<PictureObject> m_LstPictureBoxFromForm;
        public PopularPanelMgt()
        {
            m_LstPictureBoxFromForm = new List<PictureObject>();
            m_lastEndOfPicture = new Point(0, 0);
        }

        public List<PictureObject> PictureObjectList
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
                m_LstPictureBoxFromForm.Add(new PictureObject("", 0, 0, 0, "", i_poNew, i_poNew.PicLabel));
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool tryAddToPanel(PictureObject i_poNew)
        {
            if (m_LstPictureBoxFromForm.Count < MAX_PANEL)
            {
                m_LstPictureBoxFromForm.Add(i_poNew);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool getNextFreeLocationInContainer(Point i_MaxPoint, out Point o_NewPoint)
        {
            if (m_lastEndOfPicture.X < i_MaxPoint.X && m_lastEndOfPicture.Y < i_MaxPoint.Y)
            {
                o_NewPoint = new Point(m_lastEndOfPicture.X + 10, m_lastEndOfPicture.Y);
                return true;
            }
            else
            {
                o_NewPoint = new Point(0, 0);
                return false;
            }
                
        }
    }
}
