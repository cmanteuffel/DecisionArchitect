using System.ComponentModel;
using DecisionArchitect.Model;
using DecisionArchitect.View;

namespace DecisionArchitect.Utilities
{
    public class TopicViewDelegater
    {
        private readonly TopicViewController _topicView;

        public TopicViewDelegater(TopicViewController topicView)
        {
            _topicView = topicView;
            BindListeners();
        }

        private void BindListeners()
        {
            _topicView.Topic.Decisions.RaiseListChangedEvents = true;
            _topicView.Topic.Forces.RaiseListChangedEvents = true;
            _topicView.Topic.Decisions.ListChanged += DecisionsOnListChanged;
            _topicView.Topic.Forces.ListChanged += ForcesOnListChanged;

        }

        #region Forces
        private void ForcesOnListChanged(object sender, ListChangedEventArgs listChangedEventArgs)
        {
            switch (listChangedEventArgs.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    OnAddedForce(listChangedEventArgs);
                    break;
            }
        }

        private void OnAddedForce(ListChangedEventArgs listChangedEventArgs)
        {
            //var force = _topicView.Topic.Forces[listChangedEventArgs.NewIndex];
            _topicView.ForcesView.OnForceAdded();
            _topicView.UpdateForcesDgv();
        }

        #endregion

        #region Decisions
        private void DecisionsOnListChanged(object sender, ListChangedEventArgs listChangedEventArgs)
        {
            switch (listChangedEventArgs.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    OnDecisionAdded(listChangedEventArgs);
                    break;
                case ListChangedType.ItemDeleted:
                    OnDecisionDeleted(listChangedEventArgs);
                    break;
                case ListChangedType.ItemChanged:
                    OnDecisionChanged(listChangedEventArgs);
                break;
            }
        }

        private void OnDecisionAdded(ListChangedEventArgs listChangedEventArgs)
        {
            var decision = _topicView.Topic.Decisions[listChangedEventArgs.NewIndex];
            _topicView.UpdateDecisionsDgv();
            _topicView.ForcesView.OnDecisionAdded(decision);
        }

        private void OnDecisionDeleted(ListChangedEventArgs listChangedEventArgs)
        {
            //this shouldn't happen actually.
        }

        private void OnDecisionChanged(ListChangedEventArgs listChangedEventArgs)
        {
            var decision = _topicView.Topic.Decisions[listChangedEventArgs.NewIndex];
            _topicView.UpdateDecisionsDgv();
            if (listChangedEventArgs.PropertyDescriptor != null &&
                listChangedEventArgs.PropertyDescriptor.Name.Equals("DoDelete"))
                DeleteDecision(decision);
            else
            {
                _topicView.ForcesView.OnDecisionChanged(listChangedEventArgs.OldIndex, decision);
                _topicView.StakeholdersView.OnDecisionChanged();
            }
    }
        #endregion

        public void RevertAllChanges()
        {
            _topicView.StakeholdersView.Show(_topicView, _topicView.Topic.Decisions);
            _topicView.ForcesView.OnRevertedChanges(_topicView.Topic);
            _topicView.UpdateForcesDgv();
            _topicView.UpdateDecisionsDgv();

            BindListeners();
        }

        private void DeleteDecision(IDecision decision)
        {
            _topicView.ForcesView.OnDecisionDeleted();
            _topicView.StakeholdersView.OnDecisionDeleted(decision);
            _topicView.ChronologyView.OnDecisionDeleted();
        }
    }
}
