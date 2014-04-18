using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using DecisionViewpoints.Model;
using DecisionViewpoints.Properties;
using DecisionViewpointsCustomViews.Controller;
using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;
using EA;

namespace DecisionViewpoints.Logic.Forces
{
    public class ForcesHandler : RepositoryAdapter
    {
        public override bool OnContextItemDoubleClicked(string guid, ObjectType type)
        {
            if (ObjectType.otDiagram != type) return false;
            var repository = EARepository.Instance;
            var diagram = repository.GetDiagramByGuid(guid);
            if (!diagram.Metatype.Equals(Settings.Default["ForcesDiagramMetatype"])) return false;
            if (repository.IsTabOpen(diagram.Name) > 0)
            {
                repository.ActivateTab(diagram.Name);
                return true;
            }
            repository.AddTab(diagram.Name, "DecisionViewpointsCustomViews.CustomViewControl");
            return false;
        }

        public override void OnNotifyContextItemModified(string guid, ObjectType type)
        {
            if (ObjectType.otDiagram != type) return;
            var repository = EARepository.Instance;
            var diagram = repository.GetDiagramByGuid(guid);
            // TODO: Update the corresponding table of the modified Forces view
            var forcesModel = new ForcesModel();
            foreach (var o in diagram.GetElements())
            {
                var element = repository.GetElementByID(o.ElementID);
                // TODO: check for requirement, decision, (concern)
                forcesModel.Requirements.Add(new ForcesRequirement{Name = element.Name});
            }
            // TODO: maybe find out if there is an existing force view
            var forcesView =
                    (ICustomView)repository.AddTab(diagram.Name, "DecisionViewpointsCustomViews.CustomViewControl");
            var forcesController = new ForcesController(forcesView);
            forcesController.UpdateTable(forcesModel);
        }

        /*public static T DeserializeFromString<T>(string data) where T : new()
        {
            if (data == null) return new T();
            if (data.Equals("")) return new T();
            var byteArray = Convert.FromBase64String(data);
            using (var stream = new MemoryStream(byteArray))
            {
                var bf = new BinaryFormatter {Binder = new BindChanger()};
                return (T) bf.Deserialize(stream);
            }
        }

        public static string SerializeToString<T>(T data)
        {
            if (data == null) return string.Empty;
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, data);
                return Convert.ToBase64String(ms.GetBuffer());
            }
        }*/
    }

    /*sealed class BindChanger : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            // In this case we are always using the current assembly
            assemblyName = Assembly.GetExecutingAssembly().FullName;

            // Get the type using the typeName and assemblyName
            var typeToDeserialize = Type.GetType(String.Format("{0}, {1}",
                                                                typeName, assemblyName));

            return typeToDeserialize;
        }
    }*/
}