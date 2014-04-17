﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using EA;

namespace DecisionViewpoints.Model
{
    public class EAProjectWrapper : IEAWrapper
    {
        private readonly Project _project;
        private readonly Dictionary<string, XmlNodeList> _comparisonResults = new Dictionary<string, XmlNodeList>();

        public EAProjectWrapper(IDualRepository repository)
        {
            _project = repository.GetProjectInterface();
        }

        public string GetPackageXml(EAPackageWrapper package)
        {
            return _project.GUIDtoXML(package.GUID());
        }

        public Dictionary<string, XmlNodeList> GetComparisonResults()
        {
            return _comparisonResults;
        }

        public string GetBaselineLatestVesrion(IDualRepository repository, EAPackageWrapper package)
        {
            var xmlBaselines = _project.GetBaselines(GetPackageXml(package), "");
            var xml = new XmlDocument();
            xml.LoadXml(xmlBaselines);
            var xmlNodeList = xml.SelectNodes("//@version");
            var lv = 0.0;
            if (xmlNodeList != null)
                foreach (XmlNode version in xmlNodeList)
                {
                    var v = Convert.ToDouble(version.Value);
                    if (v > lv) lv = v;
                }
            return (lv+0.1).ToString(CultureInfo.InvariantCulture);
        }

        public bool CreateBaseline(string packageGUID, string version, string notes)
        {
            return _project.CreateBaseline(packageGUID, version, notes);
        }

        public XmlNodeList ReadPackageBaselines(IDualRepository repository, EAPackageWrapper package)
        {
            var xmlBaselines = _project.GetBaselines(GetPackageXml(package), "");
            var xml = new XmlDocument();
            xml.LoadXml(xmlBaselines);
            //MessageBox.Show(System.Text.Encoding.UTF8.GetByteCount(xml.ToString()).ToString(CultureInfo.InvariantCulture));
            return xml.SelectNodes("//@guid");
        }

        public void ComparePackageBaselines(IDualRepository repository, EAPackageWrapper package, XmlNodeList baselines)
        {
            foreach (XmlNode baseline in baselines)
            {
                // here baseline is the guid (node element) of each baseline
                var xmlCompare = _project.DoBaselineCompare(GetPackageXml(package), baseline.Value, "");
                var compare = new XmlDocument();
                compare.LoadXml(xmlCompare);
                _comparisonResults.Add(baseline.Value, compare.SelectNodes("//CompareItem[@status='Changed' and @type='Action']"));
            }
        }
    }
}