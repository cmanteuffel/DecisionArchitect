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

using System.Collections.Generic;
using System.IO;

namespace EAFacade.Model
{
    public interface IEADiagram: IModelObject
    {
        IEAElement ParentElement { get; set; }
        string Metatype { get; }

        /// <summary>
        /// Adds an element to the diagram. Will not be added if element already exists
        /// </summary>
        /// <param name="element">Element to be added</param>
        void AddElement(IEAElement element);

        /// <summary>
        /// Removes an element from the diagram
        /// </summary>
        /// <param name="element">element to be removed</param>
        void RemoveElement(IEAElement element);

        void OpenAndSelectElement(IEAElement element);
        List<IEADiagramObject> GetElements();
        void HideConnectors(string[] stereotypes);
        bool IsForcesView();
        bool IsChronologicalView();
        bool IsRelationshipView();
        bool IsStakeholderInvolvementView();
        bool Contains(IEAElement element);
        FileStream DiagramToStream();
    }
}
