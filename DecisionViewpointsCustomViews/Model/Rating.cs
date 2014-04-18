using System;
using System.Windows.Forms;
using EAFacade.Model;

namespace DecisionViewpointsCustomViews.Model
{
    public class Rating
    {
        private string _value;
        private string _requirementGUID;

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (_value.Length <= 255) return;
                var repository = EARepository.Instance;
                var decision = repository.GetElementByGUID(DecisionGUID);
                var requirement = repository.GetElementByGUID(RequirementGUID.Split(':')[1]);
                MessageBox.Show(
                    String.Format(
                        "The length  of the rating '{0}' of decision '{1}' and requirement '{2}' is too large. It must be less than 256 characters.",
                        _value, decision.Name, requirement.Name));
                _value = "";
            }
        }

        public string DecisionGUID { get; set; }

        public string RequirementGUID
        {
            get { return _requirementGUID; }
            set { _requirementGUID = value.Split(':')[0].Equals("r") ? value : String.Format("r:{0}", value); }
        }
    }
}