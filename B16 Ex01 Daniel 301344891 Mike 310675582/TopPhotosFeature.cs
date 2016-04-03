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
        private List<PictureObject> m_PictureObejctsOnForm;

        private int intLastIndexInDic = 0;
        private int intLastIndexInDicList = 0;
        private int intCurrentIndex = 0;

        public TopPhotosFeature(AppUser i_AppUser, List<PictureObject> i_PictureBoxArray)
        {
            m_PictureObejctsOnForm = new List<PictureObject>();
            m_ListOfObjectIDSortedByFromTopScore = new List<string>();
            m_SortedDicAllPhotosByObjectID = new SortedDictionary<string, PictureObjectBasic>();
            m_PictureObejctsOnForm.AddRange(i_PictureBoxArray);
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
                                 new PictureObjectBasic(phCurrentPhoto.Id, likesCount, commentCount, currentScore, phCurrentPhoto.PictureNormalURL));
                    sdSortedScoreDic.Add(phCurrentPhoto.Id, currentScore);
                    
                                                //  TODO: MAKE AN ERROR PICTURE    phCurrentPhoto.PictureNormalURL != GeneralVars.k_NULL ? phCurrentPhoto.PictureNormalURL: ));

                    if (++coun > 10)
                        break;
                }

                if (coun > 10)
                    break;

            }

            foreach (KeyValuePair<string, int> kvpCurrent in sdSortedScoreDic.OrderByDescending(i => i.Value))
            {
                Console.WriteLine("Key {0} Value {1}", kvpCurrent.Key, kvpCurrent.Value);
                m_ListOfObjectIDSortedByFromTopScore.Insert(nIndexForOutoutDic++, kvpCurrent.Key);

            }
            
        }

        //private string getTheObjeIdByPlaceInDicAndList(int i_IndexToGetFromDic)
        //{
        //    int i = intLastIndexInDicList, j = intLastIndexInDic;
        //    bool bFound = false;
        //    List<string> lstCurr = m_SortedDicByScoreAndObjId.ElementAt(0).Value;
        //    string strReturnString = "";
            

        //    while (intCurrentIndex <= i_IndexToGetFromDic && !bFound)
        //    {
        //        for (; j < m_SortedDicByScoreAndObjId.Count && !bFound; ++j)
        //        {
        //            lstCurr = m_SortedDicByScoreAndObjId.ElementAt(j).Value;

        //            if (i_IndexToGetFromDic - intCurrentIndex <= lstCurr.Count)
        //            {
        //                for (; i < lstCurr.Count ; ++i)
        //                {
        //                    if (intCurrentIndex++ >= i_IndexToGetFromDic)
        //                    {
        //                        bFound = true;
        //                        ++i;
        //                        break;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                i = 0;
        //                intCurrentIndex += lstCurr.Count;
        //            }
        //            if (bFound)
        //            {
        //                if (i >= lstCurr.Count) { ++j; i = 0; }
                            
        //                break;
        //            }
        //        }
        //    }

        //    intLastIndexInDicList = i;
        //    intLastIndexInDic = j;

        //    try
        //    {
        //        strReturnString = lstCurr[(i == 0 ? 0 : i-1)];
        //    }
        //    catch
        //    {
        //        strReturnString = "";
        //    }

        //    return strReturnString;
        //}

        public void loadTopPhotos()
        {
            int indexForDictionary = 0;
            PictureObjectBasic pobCurrentObj;
            string strCurrentIndex = "";

            foreach (PictureObject poCurrPicObj in m_PictureObejctsOnForm)
            {
                strCurrentIndex = m_ListOfObjectIDSortedByFromTopScore.ElementAt(indexForDictionary++);

                pobCurrentObj = m_SortedDicAllPhotosByObjectID[strCurrentIndex];

                poCurrPicObj.ObjectId = pobCurrentObj.ObjectId;
                poCurrPicObj.Score = pobCurrentObj.Score;
                poCurrPicObj.NumberOfLikes = pobCurrentObj.NumberOfLikes;
                poCurrPicObj.NumberOfComment = pobCurrentObj.NumberOfComment;
                poCurrPicObj.PictureUrl = pobCurrentObj.PictureUrl;

                poCurrPicObj.loadInformation();
                ;
            }
        }

        private int calcPhotoRank(int i_PhotoLikes, int i_PhotoComments)
        {
            return Convert.ToInt32 (Math.Ceiling(0.6 * i_PhotoLikes) + (0.4 * i_PhotoComments));

        }
        private Boolean loadFromFile()
        {
            return false;
        }

        private Boolean rankPicture()
        {
            return false;
        }
    }
}
