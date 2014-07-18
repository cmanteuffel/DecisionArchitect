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
    K. Eric Harper (ABB Corporate Research)
*/

using System.Collections.Generic;

namespace EAFacade.Model
{
    public interface IEAPackage : IModelObject
    {
        IList<IEAElement> Elements { get; }
        IList<IEAPackage> Packages { get; }
        string Stereotype { get; set; }

        bool IsModelRoot();


        IEAPackage CreatePackage(string name, string stereotype = "");
        void DeletePackage(IEAPackage package);
        IEAElement CreateElement(string name, string stereotype, string type);
        IEADiagram GetDiagram(string name);
        void RefreshElements();
        IEAElement AddElement(string name, string type);
        void DeleteElement(short index, bool refresh = true);
        IEnumerable<IEAElement> GetAllElementsOfSubTree();
        IEnumerable<IEAElement> GetAllDecisions();
        IEnumerable<IEAElement> GetAllTopics();
        IEnumerable<IEADiagram> GetAllDiagrams();
        IEAPackage GetSubpackageByName(string data);
        bool IsDecisionViewPackage();
        IEAPackage FindDecisionViewPackage();
        IEnumerable<IEADiagram> GetDiagrams();
    }
}
