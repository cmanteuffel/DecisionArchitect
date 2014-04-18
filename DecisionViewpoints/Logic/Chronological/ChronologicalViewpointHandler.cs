using System;
using System.Linq;
using EAFacade.Model;

namespace DecisionViewpoints.Logic.Chronological
{
    internal class ChronologicalViewpointHandler : RepositoryAdapter
    {

        public override void OnNotifyContextItemModified(string guid, NativeType type)
        {
            switch (type)
            {
                case NativeType.Diagram:
                    EADiagram diagram = EARepository.Instance.GetDiagramByGuid(guid);
                    if (!diagram.IsChronologicalView()) break;
                    diagram.HideConnectors(new[]
                        {
                            DVStereotypes.RelationAlternativeFor, DVStereotypes.RelationCausedBy,
                            DVStereotypes.RelationDependsOn,
                            DVStereotypes.RelationExcludedBy, DVStereotypes.RelationReplaces
                        });
                    break;
                case NativeType.Element:
                    EAElement element = EARepository.Instance.GetElementByGUID(guid);

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

        public override void OnPostOpenDiagram(EADiagram diagram)
        {
            if (!diagram.IsChronologicalView()) return;
            diagram.HideConnectors(new[]
                {
                    DVStereotypes.RelationAlternativeFor, DVStereotypes.RelationCausedBy,
                    DVStereotypes.RelationDependsOn,
                    DVStereotypes.RelationExcludedBy, DVStereotypes.RelationReplaces
                });
        }
        
    }
}