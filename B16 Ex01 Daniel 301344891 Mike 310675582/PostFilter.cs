using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using FacebookWrapper.ObjectModel;
using System.IO;

namespace FacebookSmartView
{
    public class PostFilter
    {
        public IList<FilterGroup> FilterGroups { get; set; }

        public PostFilter()
        {
            load();
        }

        public void AddGroup(FilterGroup i_GroupToAdd)
        {
            FilterGroups.Add(i_GroupToAdd);
        }

        public void RemoveGroup(FilterGroup i_GroupToDelete)
        {
            FilterGroups.Remove(i_GroupToDelete);
        }

        public bool IsMatch(Post i_Post)
        {
            return FilterGroups.Any(postFilter => postFilter.IsMatch(i_Post));
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<FilterGroup>));

            using (TextWriter writer = new StreamWriter("filter.xml"))
            {
                serializer.Serialize(writer, FilterGroups);
            }
        }
        private void load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<FilterGroup>));
            if (File.Exists("filter.xml"))
            {
                using (TextReader reader = new StreamReader("filter.xml"))
                {
                    FilterGroups = (List<FilterGroup>)serializer.Deserialize(reader);
                }
            }
            else
            {
                FilterGroups = new List<FilterGroup>();
            }
        }
    }
}
