using EAFacade.Model;

namespace DecisionViewpoints.Logic.StakeholderInvolvement
{
    public class StakeholderInvolvementHandler : RepositoryAdapter
    {
        public override void OnPostOpenDiagram(EADiagram diagram)
        {
            if (!diagram.IsStakeholderInvolvementView()) return;
            diagram.HideConnectors(new[]
                {
                    DVStereotypes.RelationAlternativeFor, DVStereotypes.RelationCausedBy,
                    DVStereotypes.RelationDependsOn, DVStereotypes.RelationExcludedBy,
                    DVStereotypes.RelationReplaces, DVStereotypes.RelationFollowedBy
                });
        }
    }
}