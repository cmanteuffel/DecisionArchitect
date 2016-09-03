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
    Mathieu Kalksma (University of Groningen)
*/

using System.Collections.Generic;

namespace EAFacade.Model
{
    public interface IEAConnector : IModelItem
    {
        string Type { get; set; }
        string Stereotype { get; set; }
        int SupplierId { get; }
        int ClientId { get; }
        string MetaType { get; set; }
        List<IEAConnectorTag> TaggedValues { get; }
        IEAElement GetSupplier();
        IEAElement GetClient();
        IEADiagram GetDiagram();
        bool IsRelationship();
        bool IsAction();

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

        void AddTaggedValue(string name, string data);

        string GetTaggedValueByName(string name);
        void UpdateTaggedValue(string name, string data);

        /// <summary>
        ///     Removes a TaggedValue from the connector with name and data.
        ///     Only one TaggedValue will be removed. Other TaggedValues with the same name and data can still exist.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        void RemoveTaggedValue(string name, string data);
    }
}