using System;
using System.Linq;
using EAFacade.Model;


namespace DecisionViewpoints.Logic.Chronological
{
    internal class ChronologicalViewpointHandler : RepositoryAdapter
    {
        public override void OnNotifyContextItemModified(string guid, EANativeType type)
        {
            switch (type)
            {
                case EANativeType.Diagram:
                    IEADiagram diagram = EAFacade.EA.Repository.GetDiagramByGuid(guid);
                    if (!diagram.IsChronologicalView()) break;
                    diagram.HideConnectors(new[]
                        {
                            EAConstants.RelationAlternativeFor, EAConstants.RelationCausedBy,
                            EAConstants.RelationDependsOn,
                            EAConstants.RelationExcludedBy, EAConstants.RelationReplaces
                        });
                    break;
                case EANativeType.Element:
                    IEAElement element = EAFacade.EA.Repository.GetElementByGUID(guid);

                    if (element == null) throw new Exception("element is null");

                    //save state change
                    if (element.IsDecision())
                    {
                        var newState = element.Stereotype;
                        var history = DecisionStateChange.GetHistory(element).ToList();
                        history.Sort(DecisionStateChange.CompareByDateModified);
                        if (history.Count > 0)
                        {
                            //check if there was actually a state change (current state != new state)s
                            var currentState = history.Last();
                            if (currentState.State != newState)
                            {
                               DecisionStateChange.SaveStateChange(element,newState,DateTime.Now);       
                            }
                        }
                        else
                        {
                            DecisionStateChange.SaveStateChange(element, newState, DateTime.Now); 
                        }
                        
                    }
                    break;
            }
        }

        public override void OnPostOpenDiagram(IEADiagram diagram)
        {
            if (!diagram.IsChronologicalView()) return;
            diagram.HideConnectors(new[]
                {
                    EAConstants.RelationAlternativeFor, EAConstants.RelationCausedBy,
                    EAConstants.RelationDependsOn,
                    EAConstants.RelationExcludedBy, EAConstants.RelationReplaces
                });
        }
        
    }
}