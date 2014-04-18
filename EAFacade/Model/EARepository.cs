using System;
using System.Collections.Generic;
using System.Linq;
using EA;

namespace EAFacade.Model
{
    public class EARepository : IEAObject
    {
        private static EARepository _instance;

        private EARepository()
        {
        }

        public static EARepository Instance
        {
            get { return _instance ?? (_instance = new EARepository()); }
        }

        //Exception from pattern, native of repos is allowed to be exposed. Should be only used within the Model namespace
        //maybe we consider to move the model to an own assembly
        internal Repository Native { get; private set; }

        private Package Root
        {
            get { return Native.Models.GetAt(0); }
        }

        public static void UpdateRepository(Repository r)
        {
            Instance.Native = r;
        }

        public IEnumerable<EAPackage> GetAllDecisionViewPackages()
        {
            return
                Root.Packages.Cast<Package>()
                    .Select(EAPackage.Wrap)
                    .Where(eapackage => eapackage.IsDecisionViewPackage())
                    .ToList();
        }

        public EAPackage GetPackageFromRootByName(string name)
        {
            return EAPackage.Wrap(Root.Packages.GetByName(name));
        }

        public EAPackage GetPackageByID(int packageID)
        {
            return EAPackage.Wrap(Native.GetPackageByID(packageID));
        }

        public EAElement GetElementByID(int elementID)
        {
            return EAElement.Wrap(Native.GetElementByID(elementID));
        }

        public EAConnector GetConnectorByID(int connectorId)
        {
            return EAConnector.Wrap(Native.GetConnectorByID(connectorId));
        }

        public EAConnector GetConnectorByGUID(string guid)
        {
            return EAConnector.Wrap(Native.GetConnectorByGuid(guid));
        }

        public string Query(string sql)
        {
            return Native.SQLQuery(sql);
        }

        public EADiagram GetDiagramByID(int id)
        {
            return EADiagram.Wrap(Native.GetDiagramByID(id));
        }

        public EADiagram GetDiagramByGuid(string guid)
        {
            return EADiagram.Wrap(Native.GetDiagramByGuid(guid));
        }

        public EAElement GetElementByGUID(string guid)
        {
            return EAElement.Wrap(Native.GetElementByGuid(guid));
        }

        public IEnumerable<EAElement> GetAllElements()
        {
            var elements = Native.GetElementSet(null, 0);
            return (from object element in elements select EAElement.Wrap((Element) element)).ToList();
        }

        public void RefreshModelView(int packageID)
        {
            Native.RefreshModelView(packageID);
        }

        public void RefreshOpenDiagrams(bool fullReload)
        {
            Native.RefreshOpenDiagrams(fullReload);
        }

        public void AdviseElementChanged(int elementID)
        {
            Native.AdviseElementChange(elementID);
        }

        public NativeType GetContextItemType()
        {
            ObjectType nativeOt = Native.GetContextItemType();
            return Utilities.Translate(nativeOt);
        }

        public bool IsProjectOpen()
        {
            try
            {
                return null != Native.Models;
            }
            catch
            {
                return false;
            }
        }

        public int IsTabOpen(string tabName)
        {
            return Native.IsTabOpen(tabName);
        }

        public void ActivateTab(string tabName)
        {
            Native.ActivateTab(tabName);
        }

        public dynamic AddTab(string tabName, string controlID)
        {
            return Native.AddTab(tabName, controlID);
        }

        public void RemoveTab(string tabName)
        {
            Native.RemoveTab(tabName);
        }

        public void OpenDiagram(int diagramID)
        {
            Native.OpenDiagram(diagramID);
        }

        public void ReloadDiagram(int diagramID)
        {
            Native.ReloadDiagram(diagramID);
        }

        public void SuppressDefaultDialogs(bool flag)
        {
            Native.SuppressEADialogs = flag;
        }

        public T GetContextObject<T>() where T : IModelItem
        {
            dynamic obj = Native.GetContextObject();
            Type typeT = typeof (T);
            if (typeT == typeof (EAElement))
            {
                var nativeElement = obj as Element;
                if (nativeElement != null)
                {
                    dynamic element = EAElement.Wrap(nativeElement);
                    return element;
                }
                return default(T);
            }
            if (typeT == typeof (EAPackage))
            {
                var nativePackage = obj as Package;
                if (nativePackage != null)
                {
                    dynamic element = EAPackage.Wrap(nativePackage);
                    return element;
                }
                return default(T);
            }
            if (typeT == typeof (EADiagram))
            {
                var nativeDiagram = obj as Diagram;
                if (nativeDiagram != null)
                {
                    dynamic element = EADiagram.Wrap(nativeDiagram);
                    return element;
                }
                return default(T);
            }

            throw new NotSupportedException("Type (" + typeT.Name + ") not supported by GetContextObject()");
        }
    }
}