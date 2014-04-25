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

using DecisionViewpointsTests.Model.RepositoryFile;
using EA;

namespace DecisionViewpointsTests.Logic
{
    class BasicStructureRepositoryFile : RepositoryFile
    {
        public BasicStructureRepositoryFile(Repository repo) : base(repo)
        {
        }

        public override void Open()
        {
            Repo.OpenFile(GetDirectory() + RepositoryFiles.BasicStructure);
        }
    }
}
