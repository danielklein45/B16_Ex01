using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using FacebookWrapper.ObjectModel;

namespace FacebookSmartView
{
    public class FilterItem : IXmlSerializable
    {
        private Regex m_Regex;
        private static readonly string sr_FilterTextAttribute = "TextToFilter";


        public FilterItem() : this(string.Empty) { } 
        
        public FilterItem(string i_Item)
        {
            m_Regex = new Regex(i_Item);
        }

        public override string ToString()
        {
            return m_Regex.ToString();
        }

        public bool IsMatch(Post i_Post)
        {
            bool isMatched = GeneralVars.k_FALSE;

            if (i_Post.Message != null)
            {
                isMatched = m_Regex.Match(i_Post.Message).Success;
            }

            return isMatched;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader i_Reader)
        {
            string textToFilter = i_Reader.GetAttribute(sr_FilterTextAttribute);

            if (textToFilter != null)
            {
                m_Regex = new Regex(textToFilter);
            }
        }

        public void WriteXml(XmlWriter i_Writer)
        {
            i_Writer.WriteAttributeString(sr_FilterTextAttribute, m_Regex.ToString());
        }
    }
}
