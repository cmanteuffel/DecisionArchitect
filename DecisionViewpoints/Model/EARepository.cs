using System;
using System.Collections;
using EA;
using Microsoft.VisualBasic;

namespace DecisionViewpoints.Model
{
    public class EARepository : IEAObject
    {
        private static EARepository _instance;

        [Obsolete]
        private EARepository(Repository native)
        {
        }

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

        internal static void UpdateRepository(Repository r)
        {
            Instance.Native = r;
        }

        private Package Root
        {
            get { return Native.Models.GetAt(0); }
        }


        [Obsolete]
        public EAPackage CreateView(string name, int pos)
        {
            Package view = Root.Packages.AddNew(name, "");
            // Set the icon of the view. Info can be found in ScriptingEA page 20
            view.Flags = "VICON=0;";
            view.TreePos = pos;
            view.Update();
            Root.Packages.Refresh();
            return EAPackage.Wrap(view);
        }

        [Obsolete]
        public Diagram CreateDiagram(EAPackage parent, string name, string metatype)
        {
            throw  new NotImplementedException();
            //Diagram diagram = parent.Diagrams.AddNew(name, metatype);
            //diagram.Update();
            //parent.Diagrams.Refresh();
            //Native.RefreshModelView(parent.PackageID);
            //return diagram;
            
        }

        [Obsolete]
        public EAPackage CreatePackage(EAPackage parent, string name)
        {
            throw new NotImplementedException("Create Package");
            //Package package = parent.Packages.AddNew(name, "");
            //package.Update();
            //package.Packages.Refresh();
            //Native.RefreshModelView(parent.PackageID);
            //return package;
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

        public string Query(string sql)
        {
            return Native.SQLQuery(sql);
        }

        public EADiagram GetDiagramByID(int id)
        {
            return EADiagram.Wrap(Native.GetDiagramByID(id));
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
                default:
                    return NativeType.Unspecified;
            }
        }

        public  bool IsProjectOpen()
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

        public T GetContextObject<T>() where T : IModelItem
        {
            dynamic obj = Native.GetContextObject();
            Type typeT = typeof (T);
            if (typeT == typeof (EAElement))
            {
                Element nativeElement = obj as Element;
                if (nativeElement != null)
                {
                    dynamic element = EAElement.Wrap(nativeElement);
                    return element;
                }
                return default(T);
            }

            throw new NotSupportedException("Type not yet supported");

        }

        public EAProjectWrapper GetProject()
        {
            return EAProjectWrapper.Wrap(Native.GetProjectInterface());
        }
    }
}