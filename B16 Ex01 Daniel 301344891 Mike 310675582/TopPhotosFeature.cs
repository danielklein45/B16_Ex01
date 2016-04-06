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

        private int intLastIndexInDic = 0;
        private int intLastIndexInDicList = 0;
        private int intCurrentIndex = 0;

        public TopPhotosFeature(AppUser i_AppUser, ref List<SpecialPictureBox> i_PictureBoxArray)
        {
            m_PictureObejctsOnForm = i_PictureBoxArray;
            m_ListOfObjectIDSortedByFromTopScore = new List<string>();
            m_SortedDicAllPhotosByObjectID = new SortedDictionary<string, PictureObjectBasic>();
            m_AppUser = i_AppUser;
        }

        public void rankUserPhotos()
        {
            FacebookObjectCollection<Album> focUserAlbums = m_AppUser.getUserAlbums();
            Dictionary<string, int> sdSortedScoreDic = new Dictionary<string, int>();
            int likesCount = 0;
            int commentCount = 0;
            int currentScore = 0;
            int coun = 0;
            int nIndexForOutoutDic = 0;

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
                                                //  TODO: MAKE AN ERROR PICTURE    phCurrentPhoto.PictureNormalURL != GeneralVars.k_NULL ? phCurrentPhoto.PictureNormalURL: ));

                    if (++coun > 3)
                        break;
                }

                if (coun > 3)
                    break;

            }

            foreach (KeyValuePair<string, int> kvpCurrent in sdSortedScoreDic.OrderByDescending(i => i.Value))
            {
                Console.WriteLine("Key {0} Value {1}", kvpCurrent.Key, kvpCurrent.Value);
                m_ListOfObjectIDSortedByFromTopScore.Insert(nIndexForOutoutDic++, kvpCurrent.Key);

            }
            
        }

       public void loadTopPhotos()
        {
            int indexForDictionary = 0;
            PictureObjectBasic pobCurrentObj;
            string strCurrentIndex = "";

            foreach (SpecialPictureBox poCurrPicObj in m_PictureObejctsOnForm)
            {
                strCurrentIndex = m_ListOfObjectIDSortedByFromTopScore.ElementAt(indexForDictionary++);

                pobCurrentObj = m_SortedDicAllPhotosByObjectID[strCurrentIndex];

                poCurrPicObj.PictureObject.ObjectId = pobCurrentObj.ObjectId;
                poCurrPicObj.PictureObject.Score = pobCurrentObj.Score;
                poCurrPicObj.PictureObject.NumberOfLikes = pobCurrentObj.NumberOfLikes;
                poCurrPicObj.PictureObject.NumberOfComment = pobCurrentObj.NumberOfComment;
                poCurrPicObj.PictureObject.PictureUrl = pobCurrentObj.PictureUrl;
                poCurrPicObj.PictureObject.PostedDate = pobCurrentObj.PostedDate;

                poCurrPicObj.PictureObject.loadInformation();
                ;
            }
        }

        private int calcPhotoRank(int i_PhotoLikes, int i_PhotoComments)
        {
            return Convert.ToInt32 (Math.Ceiling(0.6 * i_PhotoLikes) + (0.4 * i_PhotoComments));

        }
    }
}
