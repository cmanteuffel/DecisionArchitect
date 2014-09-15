using System.Windows.Forms;
using EAFacade.Model;

namespace DecisionArchitect.Logic.EventHandler
{
    public delegate void ModelChangedEventHandler(object sender, ModelChangedEventArgs args);

    public class ModelChangedEventArgs
    {
        public string GUID { get; set; }
        public ModelChangedType Type { get; set; }
        public EANativeType NativeType { get; set; }
    }

    public enum ModelChangedType
    {
        NewConnector,
        RemovedConnector,
        NewElement,
        RemovedElement,
        ModifiedElement,
        ModifiedConnector
    }

    internal class SynchronizationManager : RepositoryAdapter
    {
        private static readonly SynchronizationManager Holder = new SynchronizationManager();

        private SynchronizationManager()
        {
        }

        public static SynchronizationManager Instance
        {
            get { return Holder; }
        }

        public event ModelChangedEventHandler ModelChanged;

        private void OnModelChanged(ModelChangedEventArgs args)
        {
            if (ModelChanged != null)
            {
                ModelChanged(this, args);
            }
        }

        public override bool OnPostNewConnector(IEAConnector connector)
        {
            OnModelChanged(new ModelChangedEventArgs
                             {
                                 GUID = connector.GUID,
                                 Type = ModelChangedType.NewConnector,
                                 NativeType = EANativeType.Connector
                             });
            return true;
        }

        public override bool OnPostNewElement(IEAElement element)
        {
            OnModelChanged(new ModelChangedEventArgs
                             {
                                 GUID = element.GUID,
                                 Type = ModelChangedType.NewElement,
                                 NativeType = EANativeType.Element
                             });
            return true;
        }

        public override bool OnPreDeleteConnector(IEAConnector connector)
        {
            OnModelChanged(new ModelChangedEventArgs
                             {
                                 GUID = connector.GUID,
                                 Type = ModelChangedType.RemovedConnector,
                                 NativeType = EANativeType.Connector
                             });
            return true;
        }

        public override bool OnPreDeleteElement(IEAElement element)
        {
            OnModelChanged(new ModelChangedEventArgs
                             {
                                 GUID = element.GUID,
                                 Type = ModelChangedType.RemovedElement,
                                 NativeType = EANativeType.Element
                             });
            return true;
        }


        public override void OnNotifyContextItemModified(string guid, EANativeType type)
        {
            switch (type)
            {
                case EANativeType.Element:
                    OnModelChanged(new ModelChangedEventArgs
                                     {
                                         GUID = guid,
                                         Type = ModelChangedType.ModifiedElement,
                                         NativeType = EANativeType.Element
                                     });
                    break;
                case EANativeType.Connector:

                    OnModelChanged(new ModelChangedEventArgs
                                     {
                                         GUID = guid,
                                         Type = ModelChangedType.ModifiedConnector,
                                         NativeType = EANativeType.Connector
                                     });
                    break;
            }
        }
    }
}