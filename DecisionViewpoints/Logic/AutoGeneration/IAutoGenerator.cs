using DecisionViewpoints.Model;
using EA;

namespace DecisionViewpoints.Logic.AutoGeneration
{
    public interface IAutoGenerator
    {
        void Generate();
        void Update(EAElementWrapper element);
    }
}
