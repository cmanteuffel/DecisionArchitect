using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;
using EA;
using EAFacade.Model; //angor task157

namespace DecisionViewpointsCustomViews.Controller
{
    public class DetailController : IDetailViewController
    {
        private readonly IDecision _decision;
        private readonly IDetailView _view;

        public DetailController(IDecision decision, IDetailView view)
        {
            _view = view;
            _decision = decision;
            _view.SetController(this);
        }

        public void Update()
        {
            _view.DecisionName = _decision.Name;
            _view.DecisionState = _decision.State;
            _view.DecisionIssue = _decision.Issue;
            _view.DecisionText = _decision.DecisionText;
            _view.DecisionAlternatives = _decision.Alternatives;
            _view.DecisionArguments = _decision.Arguments;

            // Update Related Decisions field
            foreach (var connector in _decision.GetConnectors().Where(connector => connector.IsRelationship()))
            {
                if (!connector.Stereotype.Equals("alternative for"))//angor task 158
                {
                    if (connector.ClientId == _decision.ID)   
                        _view.AddRelatedDecision(connector.Stereotype, connector.GetSupplier().Name, true);
                    else
                        _view.AddRelatedDecision(connector.Stereotype, connector.GetClient().Name, false);        
                }
            }

           
            //angor START task156
            // Update Alternative Decisions field
            foreach (var connector in _decision.GetConnectors().Where(connector => connector.IsRelationship()))
            {
                if (connector.Stereotype.Equals("alternative for"))
                {
                    if (connector.ClientId != _decision.ID)
                        _view.AddAlternativeDecision(connector.Stereotype, connector.GetClient().Name,false);
                    else
                        _view.AddAlternativeDecision(connector.Stereotype, connector.GetSupplier().Name,true);
                }
            }
            //angor END task156
            
            //angor START task157
            // Update Traces
            var traces = from EAConnector trace in _decision.GetConnectors()
                where trace.Stereotype.Equals("trace")
                             select (trace.SupplierId == _decision.ID
                                         ? trace.GetClient()
                                         : trace.GetSupplier()
                                   );
            foreach (EAElement tracedElement in traces)
            {
                _view.AddTrace(tracedElement.Name, tracedElement.Type);
            }
            //angor END task157

            //angor END task159       
            // Update Related Requirements
            var forces =_decision.GetForces();
            foreach (var rating in forces)
            {
                var req = EARepository.Instance.GetElementByGUID(rating.RequirementGUID);
                _view.AddRelatedRequirement(req.Name, rating.Value, req.Notes); 
            }
            //angor END task159

            // Update History field
            foreach (var connector in _decision.GetConnectors().Where(connector => connector.IsAction()))
            {
                if (connector.ClientId == _decision.ID) continue;
                var stakeholder = connector.GetClient();
                _view.AddHistoryEntry(stakeholder.Name, stakeholder.Stereotype, connector.Stereotype, _decision.State);
            }

            _view.DecisionRelatedRequirements = _decision.RelatedRequirements;
        }

        public void ShowDetailView()
        {
            Update();
            _view.ShowAsDialog();
        }

        public void Save()
        {
            _decision.Name = _view.DecisionName;
            _decision.State = _view.DecisionState;
            var extraData = new StringBuilder();
            extraData.Append(string.Format("{0}{1}{2}", DecisionDataTags.Issue, _view.DecisionIssue,
                                           DecisionDataTags.Issue));
            extraData.Append(string.Format("{0}{1}{2}", DecisionDataTags.DecisionText, _view.DecisionText,
                                           DecisionDataTags.DecisionText));
            extraData.Append(string.Format("{0}{1}{2}", DecisionDataTags.Alternatives, _view.DecisionAlternatives,
                                           DecisionDataTags.Alternatives));
            extraData.Append(string.Format("{0}{1}{2}", DecisionDataTags.Arguments, _view.DecisionArguments,
                                           DecisionDataTags.Arguments));
            extraData.Append(string.Format("{0}{1}{2}", DecisionDataTags.RelatedRequirements,
                                           _view.DecisionRelatedRequirements, DecisionDataTags.RelatedRequirements));
            using (var tempFiles = new TempFileCollection())
            {
                var fileName = tempFiles.AddExtension("rtf");
                using (var file = new System.IO.StreamWriter(fileName))
                {
                    file.WriteLine(extraData.ToString());
                }
                _decision.LoadLinkedDocument(fileName);
            }
            _decision.Save(extraData.ToString());
        }
    }
}