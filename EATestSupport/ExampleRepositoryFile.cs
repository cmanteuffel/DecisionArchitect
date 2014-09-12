/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    K. Eric Harper (ABB Corporate Research)
*/

using EA;
using EATestSupport.Model;

namespace EATestSupport
{
    public class ExampleRepositoryFile : RepositoryFile
    {
        public ExampleRepositoryFile(Repository repo) : base(repo)
        {
        }

        public override void Open()
        {
            Repo.OpenFile(GetDirectory() + RepositoryFiles.Example);
        }
    }
}