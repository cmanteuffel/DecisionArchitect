﻿using System.Collections.Generic;
using DecisionViewpoints.Model;
using EA;

namespace DecisionViewpoints.Logic.Rules
{
    internal class ModelValidator
    {
        private readonly string _categoryID;
        private readonly IDictionary<string, AbstractRule> _lookup = new Dictionary<string, AbstractRule>();


        private ModelValidator(string categoryID)
        {
            _categoryID = categoryID;
        }


        public static ModelValidator Initialize(Repository repository)
        {
            Project project = repository.GetProjectInterface();
            string categoryID = project.DefineRuleCategory(Messages.ModelValidationCategory);

            var mv = new ModelValidator(categoryID);

            foreach (AbstractRule rule in RuleManager.Instance.Rules)
            {
                mv.AddRule(repository, rule);
            }
            return mv;
        }

        public void OnStart(Repository repository, params object[] args)
        {
        }

        public void ValidateElementUsingRuleID(Repository repository, string ruleID, EAElementWrapper element)
        {
            Project project = repository.GetProjectInterface();
            AbstractRule rule = _lookup[ruleID];
            if (rule != null && rule.GetRuleType() == RuleType.Element)
            {
                string message;
                if (!rule.Validate(element, out message))
                {
                    string name = element.Element.Name;
                    string stereotype = element.Element.Stereotype;
                    string errorMessage = string.Format(Messages.ModelValidationElementMessage, message, stereotype,
                                                        name);
                    project.PublishResult(ruleID, EnumMVErrorType.mvError, errorMessage);
                }
            }
        }

        public void ValidateConectorUsingRuleID(Repository repository, string ruleID, EAConnectorWrapper connector)
        {
            Project project = repository.GetProjectInterface();
            AbstractRule rule = _lookup[ruleID];
            if (rule != null && rule.GetRuleType() == RuleType.Connector)
            {
                string message;
                if (!rule.Validate(connector, out message))
                {
                    string supplierStereotype = connector.GetSupplier().GetStereotypeList();
                    string clientStereotype = connector.GetClient().GetStereotypeList();
                    string errorMessage = string.Format(Messages.ModelValidationConnectorMessage, message,
                                                        clientStereotype,
                                                        supplierStereotype, connector.Stereotype);
                    project.PublishResult(ruleID, EnumMVErrorType.mvError, errorMessage);
                }
            }
        }

        public void OnEnd(Repository repository, params object[] args)
        {
        }

        private void AddRule(Repository repository, AbstractRule abstractRule)
        {
            Project project = repository.GetProjectInterface();
            string id = project.DefineRule(_categoryID, EnumMVErrorType.mvError, abstractRule.ErrorMessage);
            _lookup[id] = abstractRule;
        }
    }
}