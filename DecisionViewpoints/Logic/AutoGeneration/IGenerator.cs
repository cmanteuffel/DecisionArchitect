using System.Collections.Generic;
using System.Xml;
using DecisionViewpoints.Model;
using EA;

namespace DecisionViewpoints.Logic.AutoGeneration
{
    public interface IGenerator
    {
        void Generate();
        void Update();
    }
}