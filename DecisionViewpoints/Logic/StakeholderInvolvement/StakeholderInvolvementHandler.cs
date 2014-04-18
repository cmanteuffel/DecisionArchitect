using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.StakeholderInvolvement
{
    public class StakeholderInvolvementHandler : RepositoryAdapter
    {
        public override void OnPostOpenDiagram(IEADiagram diagram)
        {
            if (!diagram.IsStakeholderInvolvementView()) return;
            diagram.HideConnectors(new[]
                {
                    EAConstants.RelationAlternativeFor, EAConstants.RelationCausedBy,
                    EAConstants.RelationDependsOn, EAConstants.RelationExcludedBy,
                    EAConstants.RelationReplaces, EAConstants.RelationFollowedBy
                });
        }
    }
}