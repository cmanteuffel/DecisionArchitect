using System.Collections.Generic;
using System.Xml;
using DecisionViewpoints.Model;
using EA;

namespace DecisionViewpoints.Logic.AutoGeneration
{
    public interface IAutoGenerator
    {
        void GenerateHistory(IDualRepository repository, Dictionary<string, XmlNodeList> comparisonResults);
        void AddCurrent(EAPackageWrapper package);
    }
}
