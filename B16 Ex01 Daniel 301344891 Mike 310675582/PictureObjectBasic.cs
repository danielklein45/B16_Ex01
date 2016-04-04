using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookSmartView
{
    class PictureObjectBasic
    {
        // General Information
        private int m_NummberOfLikes;
        private int m_NumberOfComments;
        private int m_Score;
        private string m_ObjectId;
        private string m_PictureUrl;
        private string m_PostedDate;

        public PictureObjectBasic(string i_ObjectId, int i_NumberOfLikes, int i_NumberOfComments, int i_Score, string i_PictureUrl, string i_PostedDate)
        {
            this.m_NumberOfComments = i_NumberOfComments;
            this.m_NummberOfLikes = i_NumberOfLikes;
            this.m_Score = i_Score;
            this.m_ObjectId = i_ObjectId;
            this.m_PictureUrl = i_PictureUrl;
            this.m_PostedDate = i_PostedDate;
        }

     
        // Public Prop
        public int NumberOfLikes
        {
            get { return m_NummberOfLikes; }
            set { m_NummberOfLikes = value; }
        }

        public string PostedDate
        {
            get { return m_PostedDate; }
            set { m_PostedDate = value; }
        }

        public int NumberOfComment
        {
            get { return m_NumberOfComments; }
            set { m_NumberOfComments = value; }
        }

        public string PictureUrl
        {
            get { return m_PictureUrl; }
            set { m_PictureUrl = value; }
        }
        
        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }

        public string ObjectId
        {
            get
            {
                return this.m_ObjectId;
            }
            set
            {
                this.m_ObjectId = value;
            }
        }
        
    }
}
