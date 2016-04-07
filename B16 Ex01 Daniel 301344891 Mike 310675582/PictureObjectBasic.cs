using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookSmartView
{
    class PictureObjectBasic
    {
        public int NumberOfLikes { get; set; }
        public int NumberOfComments { get; set; }
        public int Score { get; set; }
        public string ObjectId { get; set;}
        public string PictureUrl { get; set;}
        public string PostedDate { get; set; }

        public PictureObjectBasic(string i_ObjectId, int i_NumberOfLikes, int i_NumberOfComments, int i_Score, string i_PictureUrl, string i_PostedDate)
        {
            NumberOfComments = i_NumberOfComments;
            NumberOfLikes = i_NumberOfLikes;
            Score = i_Score;
            ObjectId = i_ObjectId;
            PictureUrl = i_PictureUrl;
            PostedDate = i_PostedDate;
        }
    }
}
