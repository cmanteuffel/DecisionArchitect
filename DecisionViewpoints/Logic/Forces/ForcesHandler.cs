using System;
using System.Windows.Forms;
using DecisionViewpoints.Model;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Events;
using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;
using EA;

namespace DecisionViewpoints.Logic.Forces
{
    public class ForcesHandler : RepositoryAdapter, ICustomViewListener
    {
        public override bool OnContextItemDoubleClicked(string guid, ObjectType type)
        {
            if (ObjectType.otDiagram != type) return false;
            var repository = EARepository.Instance;
            var diagram = repository.GetDiagramByGuid(guid);
            if (!diagram.IsForces()) return false;
            var forcesModel = new ForcesModel();
            foreach (var diagramObject in diagram.GetElements())
            {
                var element = repository.GetElementByID(diagramObject.ElementID);
                // if the element is a decision then add its name as column in the forces model
                if (element.IsDecision())
                    forcesModel.Columns.Add(element.Name);
                // if the element is a requirement then add a new row and a requirement in the forces model
                if (!element.Type.Equals("Requirement")) continue;
                forcesModel.Rows.Add();
                forcesModel.Requirements.Add(new ForcesRequirement { Name = element.Name });
            }
            if (repository.IsTabOpen(String.Format("{0} Forces", diagram.Name)) > 0)
            {
                repository.ActivateTab(String.Format("{0} Forces", diagram.Name));
                return true;
            }
            ICustomView forcesView = repository.AddTab(String.Format("{0} Forces", diagram.Name), "DecisionViewpointsCustomViews.CustomViewControl");
            forcesView.DiagramGUID = diagram.GUID;
            var forcesController = new ForcesController(forcesView, forcesModel);
            forcesController.UpdateTable();
            forcesView.AddListener(this);
            return true;
        }

        public void Save(ICustomView view)
        {
            MessageBox.Show("Saving...");
        }

        public void Configure(ICustomView view)
        {
            var repository = EARepository.Instance;
            var diagram = repository.GetDiagramByGuid(view.DiagramGUID);
            if (repository.IsTabOpen(diagram.Name) > 1) return;
            repository.OpenDiagram(diagram.ID);
        }

        public void Update(ICustomView view)
        {
            var repository = EARepository.Instance;
            var diagram = repository.GetDiagramByGuid(view.DiagramGUID);
            if (!diagram.IsForces()) return;
            var forcesModel = new ForcesModel();
            foreach (var diagramObject in diagram.GetElements())
            {
                var element = repository.GetElementByID(diagramObject.ElementID);
                // if the element is a decision then add its name as column in the forces model
                if (element.IsDecision())
                    forcesModel.Columns.Add(element.Name);
                // if the element is a requirement then add a new row and a requirement in the forces model
                if (!element.Type.Equals("Requirement")) continue;
                forcesModel.Rows.Add();
                forcesModel.Requirements.Add(new ForcesRequirement { Name = element.Name });
            }
            var forcesController = new ForcesController(view, forcesModel);
            forcesController.UpdateTable();
        }
    }
}