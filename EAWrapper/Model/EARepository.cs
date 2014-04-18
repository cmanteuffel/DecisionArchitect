using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using EA;

namespace EAWrapper.Model
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
            ICollection<EAPackage> decisionViewPackages = new List<EAPackage>();
            foreach (Package package in Root.Packages)
            {
                var eapackage = EAPackage.Wrap(package);
                if (eapackage.IsDecisionViewPackge())
                {
                    decisionViewPackages.Add(eapackage);
                }
            }
            return decisionViewPackages;
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

        public EAConnectorWrapper GetConnectorByID(int connectorId)
        {
            return EAConnectorWrapper.Wrap(Native.GetConnectorByID(connectorId));
        }

        public EAConnectorWrapper GetConnectorByGUID(string guid)
        {
            return EAConnectorWrapper.Wrap(Native.GetConnectorByGuid(guid));
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

        public IEnumerable GetAllElements()
        {
            return Native.GetElementSet(null, 0);
        }

        public void RefreshModelView(int packageID)
        {
            Native.RefreshModelView(packageID);
        }

        public NativeType GetContextItemType()
        {
            ObjectType nativeOt = Native.GetContextItemType();
            switch (nativeOt)
            {
                case ObjectType.otElement:
                    return NativeType.Element;
                case ObjectType.otConnector:
                    return NativeType.Connector;
                case ObjectType.otDiagram:
                    return NativeType.Diagram;
                case ObjectType.otPackage:
                    return NativeType.Package;
                case ObjectType.otNone: 
                    //FIX: model returns for some reason otNone, translated to otModel. Might cause problems. 
                    return NativeType.Model;
                default:
                    MessageBox.Show("" + nativeOt);
                    return NativeType.Unspecified;
            }
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

        public int IsTabOpen(string name)
        {
            return Native.IsTabOpen(name);
        }

        public void ActivateTab(string name)
        {
            Native.ActivateTab(name);
        }

        public dynamic AddTab(string tabName, string controlID)
        {
            return Native.AddTab(tabName, controlID);
        }

        public void OpenDiagram(int diagramID)
        {
            Native.OpenDiagram(diagramID);
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

            throw new NotSupportedException("Type (" + typeT.Name + ") not supported by GetContextObject()");
        }
    }
}