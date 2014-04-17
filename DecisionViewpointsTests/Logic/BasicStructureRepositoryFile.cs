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
