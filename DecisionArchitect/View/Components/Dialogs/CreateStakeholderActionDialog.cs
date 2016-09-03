using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DecisionArchitect.Model;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.View.Dialogs
{
    public partial class CreateStakeholderActionDialog : Form
    {
        private IList<IEAElement> _stakeholderElements;
        private IList<IDecision> _decisions; 

        private static readonly string[] StakeholderActions = {
            "formulate",
            "propose",
            "discard",
            "validate",
            "confirm",
            "challenge",
            "reject"
        };

        public IStakeholder Stakeholder { get; private set; }
        public IDecision Decision { get; private set; }
        public string Action { get; private set; }

        public CreateStakeholderActionDialog(IList<IDecision> decisions)
        {
            InitializeComponent();

            _decisions = decisions;
            // ReSharper disable once CoVariantArrayConversion
            object[] decisionNames = (from x in decisions select x.Name).ToArray();

            
            cmboDecision.Items.AddRange(decisionNames);
            LoadStakeholders();
            cmboAction.SelectedIndex = 0;
            cmboDecision.SelectedIndex = 0;
            cmboStakeholder.SelectedIndex = 0;
            cmboStakeholder.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Action = StakeholderActions[cmboAction.SelectedIndex];
            Decision = _decisions[cmboDecision.SelectedIndex];
            Stakeholder = Model.Stakeholder.Load(_stakeholderElements[cmboStakeholder.SelectedIndex]);

            DialogResult = DialogResult.OK;


            Close();
        }

        private void LoadStakeholders()
        {
            _stakeholderElements =
                (from x in EAMain.Repository.GetAllElements() where EAMain.IsStakeholder(x) select x).ToList();
            var stakeholderNames = (from stakeholder in _stakeholderElements select stakeholder.Name).ToArray();
            // ReSharper disable once CoVariantArrayConversion
            cmboStakeholder.Items.AddRange(stakeholderNames);

        }
    }
}
