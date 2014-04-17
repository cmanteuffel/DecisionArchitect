using System.IO;
using EA;

namespace DecisionViewpointsTests.Model.RepositoryFile
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
