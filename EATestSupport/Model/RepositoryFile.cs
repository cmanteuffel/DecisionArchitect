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

using System.IO;
using EA;

namespace EATestSupport.Model.RepositoryFile
{
    public abstract class RepositoryFile : IRepositoryFile
    {
        private readonly Repository _repo;

        protected RepositoryFile(Repository repo)
        {
            _repo = repo;
        }

        public Repository Repo
        {
            get { return _repo; }
        }

        public virtual void Open()
        {
        }

        public virtual void Reset()
        {
        }

        public virtual void Close()
        {
            Repo.CloseFile();
        }

        protected string GetDirectory()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
