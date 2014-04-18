using System;
using System.Collections.Generic;
using DecisionViewpoints.Properties;
using EAFacade.Model;
using EAFacade.Model.Baselines;

namespace DecisionViewpoints.Logic.Chronological
{
    internal class ChronologicalViewpointHandler : RepositoryAdapter
    {
        public static void CreateDecisionSnapshot(EAPackage eapackage)
        {
            if (eapackage == null || !eapackage.IsDecisionViewPackage())
            {
                throw new BaselineException("Package needs to be a decision viewpoint packge");
            }
            string notes = String.Format(Settings.Default.BaselineIdentifier);
            eapackage.CreateBaseline(notes);
        }

        public static void CreateDecisionSnapshotForAllDecisionPackages()
        {
            EARepository rep = EARepository.Instance;
            IEnumerable<EAPackage> packages = rep.GetAllDecisionViewPackages();

            foreach (EAPackage p in packages)
            {
                CreateDecisionSnapshot(p);
            }
        }

        public override void OnNotifyContextItemModified(string guid, NativeType type)
        {
            switch (type)
            {
                case NativeType.Element:
                    EAElement element = EARepository.Instance.GetElementByGUID(guid);

                    if (element==null) throw new Exception("element is null");

                    // Create a baseline upon a modification of a decision
                    if (Settings.Default.BaselineOptionOnModification) {
                        if (element.IsDecision())
                        {
                            //find containing decision view package
                            EAPackage package = element.ParentPackage;
                            if (package==null) throw new Exception("package is null");
                            
                            while (!(package.IsModelRoot() || package.IsDecisionViewPackage()))
                            {
                                package = package.ParentPackage;
                            }

                            if (package == null || !package.IsDecisionViewPackage())
                            {
                                throw new BaselineException("Elements needs to be in a decision viewpoint packge");
                            }
                            
                            CreateDecisionSnapshot(package);
                        }
                    }
                    break;
            }
        }

        public override void OnFileClose()
        {
            if (!Settings.Default.BaselineOptionOnFileClose) return;

            CreateDecisionSnapshotForAllDecisionPackages();
        }
    }
}