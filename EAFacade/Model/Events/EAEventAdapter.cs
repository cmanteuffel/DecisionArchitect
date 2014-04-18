using System;
using EA;

namespace EAFacade.Model.Events
{
    internal interface IEAEvents : IEAAddInEvents, IEABroadcastEvents
    {
    }

    public abstract class EAEventAdapter : IEAEvents
    {
        public virtual string EA_Connect(Repository repository)
        {
            return "";
        }

        public virtual void EA_Disconnect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public virtual object EA_GetMenuItems(Repository repository, string location, string menuName)
        {
            return "";
        }

        public virtual void EA_MenuClick(Repository repository, string location, string menuName, string itemName)
        {
        }

        public virtual void EA_GetMenuState(Repository repository, string location, string menuName, string itenName,
                                            ref bool enabled,
                                            ref bool isChecked)
        {
        }

        public virtual void EA_ShowHelp(Repository repository, string location, string menuName, string itemName)
        {
        }

        public virtual void EA_OnOutputItemClicked(Repository repository, string tabName, string lineText, long id)
        {
        }

        public virtual void EA_OnOutputItemDoubleClicked(Repository repository, string tabName, string lineText, long id)
        {
        }

        public virtual void EA_FileOpen(Repository repository)
        {
        }

        public virtual void EA_FileClose(Repository repository)
        {
        }

        public virtual void EA_FileNew(Repository repository)
        {
        }

        public virtual void EA_OnPostOpenDiagram(Repository repository, int diagramId)
        {
        }

        public virtual void EA_OnPostCloseDiagram(Repository repository, int diagramId)
        {
        }

        public virtual object EA_QueryAvailableCompartments(Repository repository)
        {
            return "";
        }

        public virtual object EA_GetCompartmentData(Repository repository, string compartment, string guid,
                                                    ObjectType type)
        {
            return "";
        }

        public virtual void EA_OnPostInitialized(Repository repository)
        {
        }

        public virtual bool EA_OnPreDeleteElement(Repository repository, EventProperties properties)
        {
            return true;
        }

        public virtual bool EA_OnPreDeleteAttribute(Repository repository, EventProperties properties)
        {
            return true;
        }

        public virtual bool EA_OnPreDeleteMethod(Repository repository, EventProperties properties)
        {
            return true;
        }

        public virtual bool EA_OnPreDeleteConnector(Repository repository, EventProperties properties)
        {
            return true;
        }

        public virtual bool EA_OnPreDeleteDiagram(Repository repository, EventProperties properties)
        {
            return true;
        }

        public virtual bool EA_OnPreDeletePackage(Repository repository, EventProperties properties)
        {
            return true;
        }

        public virtual bool EA_OnPreNewElement(Repository repository, EventProperties properties)
        {
            return true;
        }

        public virtual bool EA_OnPreNewConnector(Repository repository, EventProperties properties)
        {
            return true;
        }

        public virtual bool EA_OnPreNewDiagram(Repository repository, EventProperties properties)
        {
            return true;
        }

        public virtual bool EA_OnPreNewDiagramObject(Repository repository, EventProperties properties)
        {
            return true;
        }

        public virtual bool EA_OnPreNewAttribute(Repository repository, EventProperties properties)
        {
            return true;
        }

        public virtual bool EA_OnPreNewMethod(Repository repository, EventProperties properties)
        {
            return true;
        }

        public virtual bool EA_OnPreNewPackage(Repository repository, EventProperties properties)
        {
            return true;
        }

        public virtual bool EA_OnPostNewElement(Repository repository, EventProperties properties)
        {
            return false;
        }

        public virtual bool EA_OnPostNewConnector(Repository repository, EventProperties properties)
        {
            return false;
        }

        public virtual bool EA_OnPostNewDiagramObject(Repository repository, EventProperties properties)
        {
            return false;
        }

        public virtual bool EA_OnPostNewAttribute(Repository repository, EventProperties properties)
        {
            return false;
        }

        public virtual bool EA_OnPostNewMethod(Repository repository, EventProperties properties)
        {
            return false;
        }

        public virtual bool EA_OnPostNewPackage(Repository repository, EventProperties properties)
        {
            return false;
        }

        public virtual void EA_OnContextItemChanged(Repository repository, string guid, ObjectType type)
        {
        }

        public virtual bool EA_OnContextItemDoubleClicked(Repository repository, string guid, ObjectType type)
        {
            return false;
        }

        public virtual void EA_OnNotifyContextItemModified(Repository repository, string guid, ObjectType type)
        {
        }

        public virtual object EA_OnInitializeTechnologies(Repository repository)
        {
            return "";
        }

        public virtual bool EA_OnPreActivateTechnology(Repository repository, EventProperties properties)
        {
            return true;
        }

        public virtual bool EA_OnPostActivateTechnology(Repository repository, EventProperties properties)
        {
            return false;
        }

        public virtual string EA_OnRetrieveModelTemplate(Repository repository, string location)
        {
            return "";
        }

        public virtual bool EA_OnPostTransform(Repository repository, EventProperties properties)
        {
            return true;
        }

        public virtual void EA_OnInitializeUserRules(Repository repository)
        {
        }

        public virtual void EA_OnStartValidation(Repository repository, params object[] args)
        {
        }

        public virtual void EA_OnRunElementRule(Repository repository, string ruleId, Element element)
        {
        }

        public virtual void EA_OnRunPackageRule(Repository repository, string ruleId, long packageId)
        {
        }

        public virtual void EA_OnRunDiagramRule(Repository repository, string ruleId, long diagramId)
        {
        }

        public virtual void EA_OnRunConnectorRule(Repository repository, string ruleId, int connectorId)
        {
        }

        public virtual void EA_OnRunAttributeRule(Repository repository, string ruleId, string attributeGUID,
                                                  long objectId)
        {
        }

        public virtual void EA_OnRunMethodRule(Repository repository, string ruleId, string methodGUID, long objectId)
        {
        }

        public virtual void EA_OnRunParameterRule(Repository repository, string ruleId, string parameterGUID,
                                                  string methodGUID, long objectId)
        {
        }

        public virtual void EA_OnEndValidation(Repository repository, params object[] args)
        {
        }
    }
}