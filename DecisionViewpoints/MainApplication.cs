using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DecisionViewpoints.Logic;
using DecisionViewpoints.Logic.Rules;
using DecisionViewpoints.Model;
using DecisionViewpoints.Model.Events;
using EA;

namespace DecisionViewpoints
{
    public class MainApplication : EAEventAdapter
    {
        private ModelValidator _modelValidator;
        private BaselineOptions _baselineOptions = new BaselineOptions();

        public override object EA_OnInitializeTechnologies(Repository repository)
        {
            string technology;
            using (var stream = Assembly.GetExecutingAssembly()
                                        .GetManifestResourceStream("DecisionViewpoints." + "DecisionViewpoints.xml"))
            {
                using (var reader = new StreamReader(stream))
                {

                   technology = reader.ReadToEnd();
                }
            }
            return technology;
        }

        public override object EA_GetMenuItems(Repository repository, string location, string menuName)
        {
            return AddinEventHandler.GetMenuItems(repository, location, menuName);
        }

        public override void EA_GetMenuState(Repository repository, string location, string menuName,
                                             string itemName, ref bool isEnabled, ref bool isChecked)
        {
            AddinEventHandler.GetMenuState(repository, location, menuName, itemName, ref isEnabled, ref isChecked, _baselineOptions);
        }

        public override void EA_MenuClick(Repository repository, string location, string menuName, string itemName)
        {
            AddinEventHandler.MenuClick(repository, location, menuName, itemName, _baselineOptions);
        }

        public override bool EA_OnPreNewElement(Repository repository, EventProperties info)
        {
            return BroadcastEventHandler.OnPreNewElement(repository, info);
        }

        public override bool EA_OnPreNewConnector(Repository repository, EventProperties info)
        {
            return BroadcastEventHandler.OnPreNewConnector(repository, info);
        }

        public override string EA_OnPostOpenDiagram(Repository repository, int diagramId)
        {
            return BroadcastEventHandler.OnPostOpenDiagram(repository, diagramId);
        }

        public override void EA_OnContextItemChanged(Repository repository, string guid, ObjectType type)
        {
            BroadcastEventHandler.OnContextItemChanged(repository, guid, type);
        }

        public override void EA_OnNotifyContextItemModified(Repository repository, string guid, ObjectType ot)
        {
            BroadcastEventHandler.OnNotifyContextItemModified(repository, guid, ot, _baselineOptions);
        }

        public override void EA_OnInitializeUserRules(Repository repository)
        {
            _modelValidator = ModelValidator.Initialize(repository);
        }

        public override void EA_OnStartValidation(Repository repository, params object[] args)
        {
            _modelValidator.OnStart(repository, args);
        }

        public override void EA_OnRunConnectorRule(Repository repository, string ruleId, int connectorId)
        {
            var connector = EAConnectorWrapper.Wrap(repository, connectorId);
            _modelValidator.ValidateConectorUsingRuleID(repository, ruleId, connector);
        }

        public override void EA_OnRunElementRule(Repository repository, string ruleId, Element element)
        {
            var wrappedElement = EAElementWrapper.Wrap(repository, element);
           _modelValidator.ValidateElementUsingRuleID(repository, ruleId, wrappedElement);
        }

        public override void EA_FileClose(Repository repository)
        {
            BroadcastEventHandler.FileClose(repository, _baselineOptions);
        }
    }
}