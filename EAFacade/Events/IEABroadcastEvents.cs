/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Marc Holterman (University of Groningen)
*/

using EA;

namespace EAFacade.Events
{
    internal interface IEABroadcastEvents : IEAFileEvents, IEACompartmentEvents, IEAInitEvents, IEAModelEvents,
                                            IEATechnologyEvent, IEATemplateEvents, IEATransformationEvents,
                                            IEAValidationEvents
    {
    }

    public interface IEAFileEvents
    {
        void EA_FileOpen(Repository repository);
        void EA_FileClose(Repository repository);
        void EA_FileNew(Repository repository);
        void EA_OnPostOpenDiagram(Repository repository, int diagramId);
        void EA_OnPostCloseDiagram(Repository repository, int diagramId);
    }

    internal interface IEAInitEvents
    {
        void EA_OnPostInitialized(Repository repository);
    }

    internal interface IEAModelEvents
    {
        bool EA_OnPreDeleteElement(Repository repository, EventProperties properties);
        bool EA_OnPreDeleteAttribute(Repository repository, EventProperties properties);
        bool EA_OnPreDeleteMethod(Repository repository, EventProperties properties);
        bool EA_OnPreDeleteConnector(Repository repository, EventProperties properties);
        bool EA_OnPreDeleteDiagram(Repository repository, EventProperties properties);
        bool EA_OnPreDeletePackage(Repository repository, EventProperties properties);

        bool EA_OnPreNewElement(Repository repository, EventProperties properties);
        bool EA_OnPreNewConnector(Repository repository, EventProperties properties);
        bool EA_OnPreNewDiagram(Repository repository, EventProperties properties);
        bool EA_OnPreNewDiagramObject(Repository repository, EventProperties properties);
        bool EA_OnPreNewAttribute(Repository repository, EventProperties properties);
        bool EA_OnPreNewMethod(Repository repository, EventProperties properties);
        bool EA_OnPreNewPackage(Repository repository, EventProperties properties);

        bool EA_OnPostNewElement(Repository repository, EventProperties properties);
        bool EA_OnPostNewConnector(Repository repository, EventProperties properties);
        bool EA_OnPostNewDiagramObject(Repository repository, EventProperties properties);
        bool EA_OnPostNewAttribute(Repository repository, EventProperties properties);
        bool EA_OnPostNewMethod(Repository repository, EventProperties properties);
        bool EA_OnPostNewPackage(Repository repository, EventProperties properties);

        void EA_OnContextItemChanged(Repository repository, string guid, ObjectType type);
        bool EA_OnContextItemDoubleClicked(Repository repository, string guid, ObjectType type);
        void EA_OnNotifyContextItemModified(Repository repository, string guid, ObjectType type);

        // TODO: Marc: Dunno if belongs here
        void EA_OnTabChanged(Repository repository, string tabname, int diagramID);
    }

    internal interface IEATemplateEvents
    {
        string EA_OnRetrieveModelTemplate(Repository repository, string location);
    }

    internal interface IEATransformationEvents
    {
        bool EA_OnPostTransform(Repository repository, EventProperties properties);
    }

    internal interface IEACompartmentEvents
    {
        object EA_QueryAvailableCompartments(Repository repository);
        object EA_GetCompartmentData(Repository repository, string compartment, string guid, ObjectType type);
    }

    internal interface IEATechnologyEvent
    {
        object EA_OnInitializeTechnologies(Repository repository);
        bool EA_OnPreActivateTechnology(Repository repository, EventProperties properties);
        bool EA_OnPostActivateTechnology(Repository repository, EventProperties properties);
    }

    internal interface IEAValidationEvents
    {
        void EA_OnInitializeUserRules(Repository repository);
        void EA_OnStartValidation(Repository repository, params object[] args);
        void EA_OnRunElementRule(Repository repository, string ruleId, Element element);
        void EA_OnRunPackageRule(Repository repository, string ruleId, long packageId);
        void EA_OnRunDiagramRule(Repository repository, string ruleId, long diagramId);
        void EA_OnRunConnectorRule(Repository repository, string ruleId, int connectorId);
        void EA_OnRunAttributeRule(Repository repository, string ruleId, string attributeGUID, long objectId);
        void EA_OnRunMethodRule(Repository repository, string ruleId, string methodGUID, long objectId);

        void EA_OnRunParameterRule(Repository repository, string ruleId, string parameterGUID, string methodGUID,
                                   long objectId);

        void EA_OnEndValidation(Repository repository, params object[] args);
    }
}