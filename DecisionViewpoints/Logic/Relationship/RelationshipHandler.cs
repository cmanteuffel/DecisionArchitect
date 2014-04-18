using EAFacade.Model;

namespace DecisionViewpoints.Logic.Relationship
{
    public class RelationshipHandler : RepositoryAdapter
    {
        public override void OnPostOpenDiagram(EADiagram diagram)
        {
            if (!diagram.IsRelationshipView()) return;
            diagram.HideConnectors(new[]
                {
                    DVStereotypes.RelationFollowedBy
                });
        }
    }
}
