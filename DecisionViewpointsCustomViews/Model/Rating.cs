using System;
using System.Windows.Forms;
using EAFacade.Model;

namespace DecisionViewpointsCustomViews.Model
{
    public class Rating
    {
        private string _value;

        public string DecisionGUID { get; set; }
        public string RequirementGUID { get; set; }

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (_value.Length <= 255) return;
                var repository = EARepository.Instance;
                var decision = repository.GetElementByGUID(DecisionGUID);
                var requirement = repository.GetElementByGUID(RequirementGUID);
                MessageBox.Show(
                    String.Format(
                        "The length of rating '{0}' that belongs to decision '{1}' and requirement '{2}' is too large. It must be less than 256 characters.",
                        _value, decision.Name, requirement.Name));
                _value = "";
            }
        }
    }
}