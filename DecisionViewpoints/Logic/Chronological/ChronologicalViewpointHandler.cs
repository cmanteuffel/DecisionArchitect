using System;
using DecisionViewpoints.Model;
using DecisionViewpoints.Model.Baselines;
using DecisionViewpoints.Properties;
using EA;

namespace DecisionViewpoints.Logic.Chronological
{
    internal class ChronologicalViewpointHandler : RepositoryAdapter
    {
        public static void CreateDecisionSnapshot(EAPackage eapackage)
        {
            if (eapackage == null || eapackage.IsDecisionViewPackge())
            {
                throw new BaselineException("Package needs to be a decision viewpoint packge");
            }


            string notes = String.Format(Settings.Default.BaselineIdentifier);
            eapackage.CreateBaseline(notes);
        }

        public override void OnNotifyContextItemModified(string guid, ObjectType type)
        {
            switch (type)
            {
                case ObjectType.otElement:
                    EAElement element = EARepository.Instance.GetElementByGUID(guid);
                    // Create a baseline upon a modification of a decision
                    if ((bool) Settings.Default["BaselineOptionOnModification"])
                        if (element.MetaType.Equals("Decision"))
                        {
                            EARepository rep = EARepository.Instance;
                            EAPackage dvp = rep.GetPackageFromRootByName("Decision Views");
                            CreateDecisionSnapshot(dvp);
                        }
                    break;
            }
        }

        public override void OnFileClose()
        {
            if (!(bool) Settings.Default["BaselineOptionOnFileClose"]) return;

            throw new Exception("need to save baselines for ALL decision view packages");

            EARepository rep = EARepository.Instance;

            EAPackage dvp = rep.GetPackageFromRootByName("Decision Views");
            CreateDecisionSnapshot(dvp);
        }
    }
}