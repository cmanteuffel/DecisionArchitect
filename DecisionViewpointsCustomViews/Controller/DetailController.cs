using System.CodeDom.Compiler;
using System.Linq;
using System.Text;
using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;

namespace DecisionViewpointsCustomViews.Controller
{
    public class DetailController
    {
        private readonly Decision _decision;
        private readonly DetailView _view;

        public DetailController(Decision decision, DetailView view)
        {
            _view = view;
            _decision = decision;
            _view.SetController(this);
        }

        public void UpdateView()
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
                if (connector.ClientId == _decision.ID)
                    _view.AddRelatedDecision(connector.Stereotype, connector.GetSupplier().Name, true);
                else
                    _view.AddRelatedDecision(connector.Stereotype, connector.GetClient().Name, false);
            }

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
            UpdateView();
            _view.ShowDialog();
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