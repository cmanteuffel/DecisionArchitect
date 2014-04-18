using System.Windows.Forms;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Menu
{
    class CreateTraceMenu
    {

        public static void CreateAndTraceDecision()
        {
            EARepository repository = EARepository.Instance;
            if (repository.GetContextItemType() == NativeType.Element)
            {
                var eaelement = EARepository.Instance.GetContextObject<EAElement>();
                if (eaelement != null && !eaelement.IsDecision() && !eaelement.IsTopic())
                {

                    var nameSuggestion = string.Format(Messages.NameSuggestionDecision, eaelement.Name);
                    var createDecisionView = new CreateDecision(nameSuggestion);
                    if (createDecisionView.ShowDialog() == DialogResult.OK)
                    {

                        var dvPackage = createDecisionView.GetDecisionViewPackage();
                        var decision = dvPackage.CreateElement(createDecisionView.GetName(), createDecisionView.GetState(), DVStereotypes.ActionMetaType);
                        decision.MetaType = DVStereotypes.DecisionMetaType;

                        eaelement.ConnectTo(decision, DVStereotypes.AbstractionMetaType, DVStereotypes.TraceStereotype);
                        decision.Update();

                        dvPackage.RefreshElements();
                        repository.RefreshModelView(dvPackage.ID);
                        decision.ShowInProjectView();
                    }
                }
            }
        }

        public static void CreateAndTraceTopic()
        {
            EARepository repository = EARepository.Instance;
            if (repository.GetContextItemType() == NativeType.Element)
            {
                var eaelement = EARepository.Instance.GetContextObject<EAElement>();
                if (eaelement != null && !eaelement.IsDecision() && !eaelement.IsTopic())
                {
                    var nameSuggestion = string.Format(Messages.NameSuggestionTopic, eaelement.Name);
                    var createTopicView = new CreateTopic(nameSuggestion);
                    if (createTopicView.ShowDialog() == DialogResult.OK)
                    {
                        var dvPackage = createTopicView.GetDecisionViewPackage();
                        var topic = dvPackage.CreateElement(createTopicView.GetName(), DVStereotypes.TopicStereoType, DVStereotypes.ActivityMetaType);
                        topic.MetaType = DVStereotypes.TopicMetaType;

                        eaelement.ConnectTo(topic, DVStereotypes.AbstractionMetaType, DVStereotypes.TraceStereotype);
                        topic.Update();

                        dvPackage.RefreshElements();
                        repository.RefreshModelView(dvPackage.ID);
                        topic.ShowInProjectView();
                    }
                }
            }
        }
    }
}
