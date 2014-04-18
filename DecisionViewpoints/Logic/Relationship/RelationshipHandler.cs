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

        public override bool OnPostNewDiagramObject(EADiagramObject diagramObject)
        {
            var diagram = diagramObject.Diagram;
            if (!diagram.IsRelationshipView()) return true;
            diagram.HideConnectors(new[]
                {
                    DVStereotypes.RelationFollowedBy
                });
            return base.OnPostNewDiagramObject(diagramObject);
        }
    }
}
