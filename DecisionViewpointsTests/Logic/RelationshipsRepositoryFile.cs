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
