using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FacebookWrapper.ObjectModel;

namespace FacebookSmartView
{
    class TopPhotosFeature
    {
        private AppUser m_AppUser;
        private List<string> m_ListOfObjectIDSortedByFromTopScore;
        private SortedDictionary<string, PictureObjectBasic> m_SortedDicAllPhotosByObjectID;
        private List<SpecialPictureBox> m_PictureObejctsOnForm;
        private const double k_PhotoLikeScore = 0.6;
        private const double k_PhotoCommentScore = 0.4;
        private const int k_MaxPhotos = 50;

        public TopPhotosFeature(AppUser i_AppUser, ref List<SpecialPictureBox> io_PictureBoxArray)
        {
            m_PictureObejctsOnForm = io_PictureBoxArray;
            m_ListOfObjectIDSortedByFromTopScore = new List<string>();
            m_SortedDicAllPhotosByObjectID = new SortedDictionary<string, PictureObjectBasic>();
            m_AppUser = i_AppUser;
        }

        public void RankUserPhotos()
        {
            FacebookObjectCollection<Album> focUserAlbums = m_AppUser.GetUserAlbums();
            Dictionary<string, int> sdSortedScoreDic = new Dictionary<string, int>();
            int likesCount = 0;
            int commentCount = 0;
            int currentScore = 0;
            int count = 0;
            int indexForOutoutDic = 0;

            foreach(Album albCurrent in focUserAlbums)
            {
                foreach (Photo phCurrentPhoto in albCurrent.Photos)
                {
                    likesCount = phCurrentPhoto.LikedBy.Count;
                    commentCount = phCurrentPhoto.Comments.Count;
                    currentScore = calcPhotoRank(likesCount, commentCount);
                    m_SortedDicAllPhotosByObjectID.Add(phCurrentPhoto.Id,
                        new PictureObjectBasic(phCurrentPhoto.Id, likesCount, commentCount, currentScore, phCurrentPhoto.PictureNormalURL,
                            phCurrentPhoto.CreatedTime.ToString()));

                    sdSortedScoreDic.Add(phCurrentPhoto.Id, currentScore);

                    if (++count > k_MaxPhotos)
                    {
                        break;
                    }
                }

                if (count > k_MaxPhotos)
                {
                    break;
                }
            }

            foreach (KeyValuePair<string, int> kvpCurrent in sdSortedScoreDic.OrderByDescending(i => i.Value))
            {
                Console.WriteLine("Key {0} Value {1}", kvpCurrent.Key, kvpCurrent.Value);
                m_ListOfObjectIDSortedByFromTopScore.Insert(indexForOutoutDic++, kvpCurrent.Key);
            }
        }

       public void LoadTopPhotos()
        {
            int indexForDictionary = 0;
            PictureObjectBasic pobCurrentObj;
            string currentIndex = string.Empty;

            foreach (SpecialPictureBox poCurrPicObj in m_PictureObejctsOnForm)
            {
                currentIndex = m_ListOfObjectIDSortedByFromTopScore.ElementAt(indexForDictionary++);
                pobCurrentObj = m_SortedDicAllPhotosByObjectID[currentIndex];

                poCurrPicObj.PictureObject.ObjectId = pobCurrentObj.ObjectId;
                poCurrPicObj.PictureObject.Score = pobCurrentObj.Score;
                poCurrPicObj.PictureObject.NumberOfLikes = pobCurrentObj.NumberOfLikes;
                poCurrPicObj.PictureObject.NumberOfComments = pobCurrentObj.NumberOfComments;
                poCurrPicObj.PictureObject.PictureUrl = pobCurrentObj.PictureUrl;
                poCurrPicObj.PictureObject.PostedDate = pobCurrentObj.PostedDate;

                poCurrPicObj.PictureObject.LoadInformation();
            }
        }

        private int calcPhotoRank(int i_PhotoLikes, int i_PhotoComments)
        {
            return Convert.ToInt32 (Math.Ceiling(k_PhotoLikeScore * i_PhotoLikes) + (k_PhotoCommentScore * i_PhotoComments));
        }
    }
}
