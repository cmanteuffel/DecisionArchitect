using System.Windows.Forms;
using DecisionViewpoints.Model;
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
            if (!element.MetaType.Equals("Forces")) return false;
            if (repository.IsTabOpen("Forces") > 0)
            {
                repository.ActivateTab("Forces");
                return true;
            }
            var forces = (ICustomView) repository.AddTab("Forces", "DecisionViewpointsCustomViews.Forces");
            MessageBox.Show(forces.GetText());
            return true;
        }
    }
}
