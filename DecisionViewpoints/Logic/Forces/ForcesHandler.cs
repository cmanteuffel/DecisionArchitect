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
            var forcesModel = new ForcesModel { Name = String.Format("{0} (Forces)", diagram.Name) };
            forcesModel.Columns.Add("Concerns");
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
                // if the element is a concern?
            }
            if (repository.IsTabOpen(forcesModel.Name) > 0)
            {
                repository.ActivateTab(forcesModel.Name);
                return true;
            }
            ICustomView forcesView = repository.AddTab(forcesModel.Name, "DecisionViewpointsCustomViews.CustomViewControl");
            forcesView.DiagramGUID = diagram.GUID;
            var forcesController = new ForcesController(forcesView, forcesModel);
            forcesController.UpdateTable();
            forcesView.AddListener(this);
            return true;
        }

        public void Save(ICustomView view)
        {
            MessageBox.Show("Saving...");
            // What is the user modify diagram, save it, but then do not update the table and start
            // modifying values and try to save?
        }

        public void Configure(ICustomView view)
        {
            var repository = EARepository.Instance;
            var diagram = repository.GetDiagramByGuid(view.DiagramGUID);
            repository.OpenDiagram(diagram.ID);
        }

        public void Update(ICustomView view)
        {
            var repository = EARepository.Instance;
            var diagram = repository.GetDiagramByGuid(view.DiagramGUID);
            if (!diagram.IsForces()) return;
            var forcesModel = new ForcesModel();
            forcesModel.Columns.Add("Concerns");
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