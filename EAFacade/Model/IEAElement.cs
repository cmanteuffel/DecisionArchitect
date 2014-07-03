/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Mark Hoekstra (University of Groningen)
*/

using System;
using System.Collections.Generic;

namespace EAFacade.Model
{
    public interface IEAElement : IModelObject, IEquatable<IEAElement>
    {
        string Type { get; }
        string Stereotype { get; set; }
        string MetaType { get; set; }
        IEAElement ParentElement { get; set; }
        List<IEATaggedValue> TaggedValues { get; }
        string StereotypeList { get; set; }
        IEnumerable<IEAElement> GetTracedElements();

        [Obsolete("Should be moved to topic",false)]
        IEnumerable<IEAElement> GetDecisionsForTopic();

        [Obsolete("Should be moved to appropriate domain class",false)]
        IEnumerable<IEAElement> GetConnectedConcerns(string diagramGUID);

        IEADiagram[] GetDiagrams();
        IList<IEAConnector> FindConnectors(IEAElement suppliedElement, String type, String stereotype);
        IEAConnector ConnectTo(IEAElement suppliedElement, String type, String stereotype);

        /// <summary>
        /// Removes a connector from the element
        /// </summary>
        /// <param name="connector"></param>
        void RemoveConnector(IEAConnector connector);

        bool IsDecision();
        bool IsConcern();
        bool IsTopic();
        bool IsHistoryDecision();
        bool Update();
        void Refresh();
        List<IEAElement> GetElements();
        List<IEAConnector> GetConnectors();
        string GetLinkedDocument();
        void LoadLinkedDocument(string fileName);

        /// <summary>
        /// Check if a TaggedValue exists with a certain name 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool TaggedValueExists(string name);

        /// <summary>
        /// Check if a TaggedValue exists with a certain name and data
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        bool TaggedValueExists(string name, string data);
        string GetTaggedValue(string name);

        /// <summary>
        /// Adds a TaggedValue to the element with name and data. 
        /// Multiple TaggedValues with the same name and data can exist.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        void AddTaggedValue(string name, string data);
        void UpdateTaggedValue(string name, string data);

        /// <summary>
        /// Removes a TaggedValue from the element with name and data.
        /// Only one TaggedValue will be removed. Other TaggedValues with the same name and data can still exist.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        void RemoveTaggedValue(string name, string data);
    }
}
