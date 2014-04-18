using System.Windows.Forms;
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

        public override void OnNotifyContextItemModified(string guid, NativeType type)
        {
            if (NativeType.Diagram.Equals(type))
            {
                var diagram = EARepository.Instance.GetDiagramByGuid(guid);
                if (!diagram.IsRelationshipView()) return;
                diagram.HideConnectors(new[]
                {
                    DVStereotypes.RelationFollowedBy
                });
                
            }
        }

    }
}
