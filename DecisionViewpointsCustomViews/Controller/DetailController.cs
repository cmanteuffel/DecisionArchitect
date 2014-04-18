﻿using System.Linq;
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

            foreach (var connector in _decision.GetConnectors().Where(connector => connector.IsRelationship()))
            {
                if (connector.ClientId == _decision.ID)
                    _view.AddRelatedDecision(connector.Stereotype, connector.GetSupplier().Name, true);
                else
                    _view.AddRelatedDecision(connector.Stereotype, connector.GetClient().Name, false);
            }

            _view.ShowDialog();
        }

        public void Save()
        {
            _decision.Name = _view.DecisionName;
            _decision.State = _view.DecisionState;
            var extraData = new StringBuilder();
            extraData.Append(string.Format("{0}{1}", DecisionDataTags.Issue, _view.DecisionIssue));
            extraData.Append(string.Format("{0}{1}", DecisionDataTags.DecisionText, _view.DecisionText));
            extraData.Append(string.Format("{0}{1}", DecisionDataTags.Alternatives, _view.DecisionAlternatives));
            extraData.Append(string.Format("{0}{1}", DecisionDataTags.Arguments, _view.DecisionArguments));
            extraData.Append(DecisionDataTags.End);
            _decision.Save(extraData.ToString());
            /*using (var tempFiles = new TempFileCollection())
            {
                var fileName = tempFiles.AddExtension("rtf");
                using (var file = new System.IO.StreamWriter(fileName))
                {
                    file.WriteLine(elementExtraDataBuilder.ToString());
                }
                element.LoadLinkedDocument(fileName);
            }*/
        }
    }
}