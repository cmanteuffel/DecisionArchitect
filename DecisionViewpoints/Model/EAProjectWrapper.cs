using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using EA;

namespace DecisionViewpoints.Model
{
    public class EAProjectWrapper
    {
        private readonly Project _project;
        private Dictionary<string, XmlNodeList> _comparisonResults = new Dictionary<string, XmlNodeList>();

        public EAProjectWrapper(IDualRepository repository)
        {
            _project = repository.GetProjectInterface();
        }

        public Project Get()
        {
            return _project;
        }

        public string GetPackageXml(EAPackageWrapper package)
        {
            return _project.GUIDtoXML(package.GUID());
        }

        public Dictionary<string, XmlNodeList> GetComparisonResults()
        {
            return _comparisonResults;
        }

        public XmlNodeList ReadPackageBaselines(IDualRepository repository, EAPackageWrapper package)
        {
            var xmlBaselines = _project.GetBaselines(GetPackageXml(package), "");
            var xml = new XmlDocument();
            xml.LoadXml(xmlBaselines);
            return xml.SelectNodes("//@guid");
        }

        public void ComparePackageBaselines(IDualRepository repository, EAPackageWrapper package, XmlNodeList baselines)
        {
            //var results = new Dictionary<string, XmlNodeList>();
            foreach (XmlNode baseline in baselines)
            {
                // here baseline is the guid (node element) of each baseline
                var xmlCompare = _project.DoBaselineCompare(GetPackageXml(package), baseline.Value, "");
                var compare = new XmlDocument();
                compare.LoadXml(xmlCompare);
                _comparisonResults.Add(baseline.Value, compare.SelectNodes("//CompareItem[@status='Changed' and @type='Action']"));
            }
            //return results;
        }
    }
}
