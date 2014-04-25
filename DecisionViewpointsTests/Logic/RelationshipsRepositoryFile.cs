/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
*/

using System.Diagnostics;
using DecisionViewpointsTests.Model.RepositoryFile;
using EA;

namespace DecisionViewpointsTests.Logic
{
    class RelationshipsRepositoryFile : RepositoryFile
    {
        public RelationshipsRepositoryFile(Repository repo) : base(repo)
        {
        }

        public override void Open()
        {
            Repo.OpenFile(GetDirectory() + RepositoryFiles.Relationships);
        }

        public override void Reset()
        {
            Package root = Repo.Models.GetAt(0);
            Package view = root.Packages.GetAt(0);
            for (var elemIndex = (short)(view.Elements.Count - 1); elemIndex != -1; elemIndex--)
            {
                Element e = view.Elements.GetAt(elemIndex);
                for (var conIndex = (short)(e.Connectors.Count - 1); conIndex != -1; conIndex--)
                {
                    e.Connectors.Delete(conIndex);
                }
            }
        }
    }
}
