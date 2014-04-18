using System.Windows.Forms;
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Relationship
{
    public class RelationshipHandler : RepositoryAdapter
    {
        public override void OnPostOpenDiagram(IEADiagram diagram)
        {
            if (!diagram.IsRelationshipView()) return;
            diagram.HideConnectors(new[]
                {
                    EAConstants.RelationFollowedBy
                });
        }

        public override void OnNotifyContextItemModified(string guid, EANativeType type)
        {
            if (EANativeType.Diagram.Equals(type))
            {
                var diagram = EAFacade.EA.Repository.GetDiagramByGuid(guid);
                if (!diagram.IsRelationshipView()) return;
                diagram.HideConnectors(new[]
                {
                    EAConstants.RelationFollowedBy
                });
                
            }
        }

    }
}
