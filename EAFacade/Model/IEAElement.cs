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
    Mark Hoekstra (University of Groningen)
*/

using System;
using System.Collections.Generic;

namespace EAFacade.Model
{
    public interface IEAElement : IModelObject, IEquatable<IEAElement>
    {
        new string GUID { get; }
        string Type { get; }
        string Stereotype { get; set; }
        string MetaType { get; set; }

        string Author { get; set; }
        IEAElement ParentElement { get; set; }
        List<IEATaggedValue> TaggedValues { get; }
        string StereotypeList { get; set; }
        IEnumerable<IEAElement> GetTracedElements();

        [Obsolete("Should be moved to topic", false)]
        IEnumerable<IEAElement> GetDecisionsForTopic();

        [Obsolete("Should be moved to appropriate domain class", false)]
        IEnumerable<IEAElement> GetConnectedConcerns(string diagramGUID);

        [Obsolete("Should be moved to appropriate domain class", false)]
        IEnumerable<IEAElement> GetConnectedRequirements();

        IEADiagram[] GetDiagrams();

        IList<IEAConnector> FindConnectors(string metatype, params string[] stereotypes);

        IList<IEAConnector> FindConnectors(IEAElement connectedElement, string stereotype, string type = null,
                                           EAConnectorDirection direction = EAConnectorDirection.ClientToSupplier);

        IEAConnector ConnectTo(IEAElement suppliedElement, String type, String stereotype);

        /// <summary>
        ///     Removes a connector from the element
        /// </summary>
        /// <param name="connector"></param>
        void RemoveConnector(IEAConnector connector);

        bool Update();
        void Refresh();
        List<IEAElement> GetElements();
        List<IEAConnector> GetConnectors();
        string GetLinkedDocument();
        void LoadFileIntoLinkedDocument(string fileName);

        /// <summary>
        ///     Remove all entries of TaggedValuesWithName
        /// </summary>
        /// <param name="name"></param>
        /// <returns>the amount of entries removed</returns>
        int RemoveAllWithName(string name);

        /// <summary>
        ///     Check if a TaggedValue exists with a certain name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool TaggedValueExists(string name);

        /// <summary>
        ///     Check if a TaggedValue exists with a certain name and data
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        bool TaggedValueExists(string name, string data);

        /// <summary>
        ///     Gets a specific taggedvalue identified via the propertyguid
        /// </summary>
        /// <param name="taggedValueGUID"></param>
        /// <returns></returns>
        IEATaggedValue GetTaggedValueByGUID(string taggedValueGUID);

        /// <summary>
        ///     Returns all taggedvalue with a particular name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IList<IEATaggedValue> GetTaggedValuesByName(string name);

        /// <summary>
        ///     Returns the first taggedvalue with the specified name. (possibility that multiple taggedvalue with the same name exist)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string GetTaggedValueByName(string name);

        /// <summary>
        ///     Adds a TaggedValue to the element with name and data.
        ///     Multiple TaggedValues with the same name and data can exist.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        void AddTaggedValue(string name, string data);

        /// <summary>
        ///     Updates a specific TaggedValue idientified via the TaggesValue guid.
        ///     The name is not sufficient as identification since there can be multiple TV with the same name.
        /// </summary>
        /// <param name="guid">identification</param>
        /// <param name="name">the new name</param>
        /// <param name="data">the new value</param>
        /// <returns></returns>
        bool UpdateTaggedValue(string guid, string name, string data);

        /// <summary>
        ///     Updates first taggedvalue with the specified name. Only data is updated not the name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        void UpdateTaggedValue(string name, string data);


        // MC implementation
        bool DeleteTaggedValue(string name, string data);

        /// <summary>
        ///     Removes a TaggedValue from the element with name and data.
        ///     Only one TaggedValue will be removed. Other TaggedValues with the same name and data can still exist.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        void RemoveTaggedValue(string name, string data);

        /// <summary>
        ///     Removes a particluar taggedvalue from the element identified by GUID.
        /// </summary>
        /// <param name="tagGUID"></param>
        void RemoveTaggedValueByGUID(string tagGUID);

        /// <summary>
        ///     Provides an Add-In or automation client with the ability to advise the Enterprise Architect user interface that a particular element has changed and, if it is visible in any open diagram, to reload and refresh that element for the user.
        /// </summary>
        void AdviseElementChanged();
    }
}