using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DecisionViewpoints.Model
{
    public class EABaselineWrapper
    {
        private readonly XmlNode _baseline;

        public EABaselineWrapper(XmlNode baseline)
        {
            _baseline = baseline;
        }

        public string Guid()
        {
            return _baseline.Value;
        }

        public XmlNode GetElement(XmlNode parent, string xpath)
        {
            return parent.SelectSingleNode(xpath);
        }

        public XmlNodeList GetElements(XmlNode parent, string xpath)
        {
            return parent.SelectNodes(xpath);
        }
    }
}
