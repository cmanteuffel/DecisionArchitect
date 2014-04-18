using System.Windows.Forms;
using DecisionViewpoints.Model;
using DecisionViewpoints.Properties;
using DecisionViewpointsCustomViews;
using EA;

namespace DecisionViewpoints.Logic.Forces
{
    public class ForcesHandler : RepositoryAdapter
    {
        public override bool OnContextItemDoubleClicked(string guid, ObjectType type)
        {
            if (ObjectType.otElement != type) return false;
            var repository = EARepository.Instance;
            var element = repository.GetElementByGUID(guid);
            if (!element.MetaType.Equals(Settings.Default["ForcesElementMetatype"])) return false;
            if (repository.IsTabOpen(element.Name) > 0)
            {
                repository.ActivateTab(element.Name);
                return true;
            }
            var forces = (ICustomView)repository.AddTab(element.Name, "DecisionViewpointsCustomViews.Forces");
            MessageBox.Show(forces.GetText());
            return true;
        }
    }
}
