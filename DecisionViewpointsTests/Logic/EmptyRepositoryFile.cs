using DecisionViewpointsTests.Model.RepositoryFile;
using EA;

namespace DecisionViewpointsTests.Logic
{
    public class EmptyRepositoryFile : RepositoryFile
    {
        public EmptyRepositoryFile(Repository repo) : base(repo)
        {
        }

        public override void Open()
        {
            Repo.OpenFile(GetDirectory() + RepositoryFiles.Empty);
        }

        public override void Reset()
        {
            Package root = Repo.Models.GetAt(0);
            for (var packageIndex = (short)(root.Packages.Count - 1); packageIndex != -1; packageIndex--)
            {
                root.Packages.Delete(packageIndex);
            }
        }
    }
}
