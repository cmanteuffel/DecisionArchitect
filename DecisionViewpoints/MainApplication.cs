using System.Collections.Generic;
using System.Windows.Forms;
using DecisionViewpoints.Logic;
using DecisionViewpoints.Logic.Menu;
using DecisionViewpoints.Logic.Rules;
using DecisionViewpoints.Model;
using DecisionViewpoints.Model.Events;
using EA;

namespace DecisionViewpoints
{
    public class MainApplication : EAEventAdapter
    {
        private ModelValidator _modelValidator;
        private IList<IRepositoryListener> listener = new List<IRepositoryListener>();

        public MainApplication()
        {
            listener.Add(new BroadcastEventHandler());
        }

        public override object EA_OnInitializeTechnologies(Repository repository)
        {
            EARepository.UpdateRepository(repository);
            string resource = "DecisionViewpoints." + "DecisionViewpoints.xml";
            return Utilities.GetResourceContents(resource);
        }

        public override string EA_OnRetrieveModelTemplate(Repository repository, string location)
        {
            EARepository.UpdateRepository(repository);
            string resource = "DecisionViewpoints." + location;
            return Utilities.GetResourceContents(resource);
        }

        public override object EA_GetMenuItems(Repository repository, string location, string menuName)
        {
            EARepository.UpdateRepository(repository);
            return MenuEventHandler.GetMenuItems(location, menuName);
        }

        public override void EA_GetMenuState(Repository repository, string location, string menuName,
                                             string itemName, ref bool isEnabled, ref bool isChecked)
        {
            EARepository.UpdateRepository(repository);
            MenuEventHandler.GetMenuState(location, menuName, itemName, ref isEnabled, ref isChecked);
        }

        public override void EA_MenuClick(Repository repository, string location, string menuName, string itemName)
        {
            EARepository.UpdateRepository(repository);
            MenuEventHandler.MenuClick(location, menuName, itemName);
        }

        public override bool EA_OnPreNewElement(Repository repository, EventProperties info)
        {
            EARepository.UpdateRepository(repository);
            var element = EAVolatileElement.Wrap(info);

            foreach (var l in listener)
            {
                if (! l.OnPreNewElement(element))
                {
                    return false;
                }
            }
            return true;
        }

        public override bool EA_OnPreNewConnector(Repository repository, EventProperties info)
        {
            EARepository.UpdateRepository(repository);
            var connectorWrapper = EAConnectorWrapper.Wrap(info);
            foreach (var l in listener)
            {
                if (!l.OnPreNewConnector(connectorWrapper))
                {
                    return false;
                }
            }
            return true;
        }

        public override void EA_OnNotifyContextItemModified(Repository repository, string guid, ObjectType ot)
        {
            EARepository.UpdateRepository(repository);
            foreach (var l in listener)
            {
                l.OnNotifyContextItemModified(guid, ot);

            }
        }

        public override void EA_FileClose(Repository repository)
        {
            EARepository.UpdateRepository(repository);
            foreach (var l in listener)
            {
                l.OnFileClose();
            }
        }

        public override void EA_OnInitializeUserRules(Repository repository)
        {
            EARepository.UpdateRepository(repository);
            _modelValidator = ModelValidator.Initialize(repository);
        }

        public override void EA_OnStartValidation(Repository repository, params object[] args)
        {
            EARepository.UpdateRepository(repository);
            _modelValidator.OnStart(repository, args);
        }

        public override void EA_OnRunConnectorRule(Repository repository, string ruleId, int connectorId)
        {
            EARepository.UpdateRepository(repository);
            var connector = EAConnectorWrapper.Wrap(connectorId);
            _modelValidator.ValidateConectorUsingRuleID(repository, ruleId, connector);
        }

        public override void EA_OnRunElementRule(Repository repository, string ruleId, Element element)
        {
            EARepository.UpdateRepository(repository);
            var wrappedElement = EAElement.Wrap(element);
           _modelValidator.ValidateElementUsingRuleID(repository, ruleId, wrappedElement);
        }


    }
}