using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace FacebookSmartView
{
    class PictureObject : PictureObjectBasic
    {
        // Private Properties

        private PictureBox m_PictureBox;
        private Label m_BottomLable;
        


        public PictureObject(string i_ObjectId, int i_NumberOfLikes, int i_NumberOfComments, int i_Score, string i_PictureUrl,
                            PictureBox i_PictureBox, Label i_InfoLableBottom)
                            :base(i_ObjectId, i_NumberOfLikes, i_NumberOfComments, i_Score, i_PictureUrl)
        {
            this.m_PictureBox = i_PictureBox;
            this.m_BottomLable = i_InfoLableBottom;
        }

        public void loadInformation()
        {
            this.m_PictureBox.LoadAsync(this.PictureUrl);
            this.m_BottomLable.Text = String.Format("{0} L + {1} C = {2} Score", this.NumberOfLikes, this.NumberOfComment, this.Score);
        }

        public void makeProfilePicture()
        {

        }

       

        public void calcScore()
        {

        }
        
        
    }
}
