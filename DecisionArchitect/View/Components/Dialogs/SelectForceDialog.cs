using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DecisionArchitect.Model;
using EAFacade;
using log4net;

namespace DecisionArchitect.View.Dialogs
{
    public partial class SelectForceDialog : Form
    {
        private Dictionary<string, string> _concernMap;
        private Dictionary<string, string> _forcesMap; 
        public IConcern Concern { get; private set; }
        public IForce Force { get; private set; }
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IList<ITopicForceEvaluation> _forces; 

        public SelectForceDialog(IList<ITopicForceEvaluation> forces )
        {
            InitializeComponent();
            _forces = forces;
            Log.Debug("Loading Concerns for autocompletion");
            txtConcern.AutoCompleteCustomSource = LoadAutoCompleteConcerns();
            Log.Debug("Finished loading Concerns for autocompletion");
            Log.Debug("Loading Forces  for autocompletion");
            txtForce.AutoCompleteCustomSource = LoadAutoCompleteForces();
            Log.Debug("Finished loading Forces for autocompletion");
        }

        [Obsolete("Debt: Weak key in map. Map does not support concerns with the same name. Quick fix applied")]
        private AutoCompleteStringCollection LoadAutoCompleteConcerns()
        {
            _concernMap = new Dictionary<string, string>();
            var collection = new AutoCompleteStringCollection();
            var concerns = (from x in EAMain.Repository.GetAllElements() where EAMain.IsConcern(x) select x);
            foreach (var concern in concerns)
            {
                if (!_concernMap.ContainsKey(concern.Name)) { 
                _concernMap.Add(concern.Name, concern.GUID);
                collection.Add(concern.Name);
                }
            }
            return collection;
        }

        private AutoCompleteStringCollection LoadAutoCompleteForces()
        {
            _forcesMap = new Dictionary<string, string>();
            var collection = new AutoCompleteStringCollection();
            var elements = (from x in EAMain.Repository.GetAllElements() where !string.IsNullOrEmpty(x.Name) select x);
            foreach (var element in elements)
            {
                
                var fullName = element.Name + " (" + element.GetProjectPath() + ")";
                //TODO: What to do with multiple with same name?
                if (_forcesMap.ContainsKey(fullName ))
                    continue; 
                _forcesMap.Add(fullName, element.GUID);
                collection.Add(fullName);
            }
            return collection;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConcern.Text) || !_concernMap.ContainsKey(txtConcern.Text))
            {
                txtConcern.Select(0, txtConcern.TextLength);
                MessageBox.Show(string.Format(Messages.SelectForceDialogConcernDoesNotExist,txtConcern.Text));
                return;
            }
            if (string.IsNullOrEmpty(txtForce.Text) || !_forcesMap.ContainsKey(txtForce.Text))
            {
                txtConcern.Select(0, txtForce.TextLength);
                MessageBox.Show(string.Format(Messages.SelectForceDialogForceDoesNotExist,txtForce.Text));
                return;
            }

            Force = new Force(_forcesMap[txtForce.Text]);
            Concern = new Concern(_concernMap[txtConcern.Text]);
            var forceExists = (from x in _forces
                where x.Force.ForceGUID.Equals(Force.ForceGUID) && x.Concern.ConcernGUID.Equals(Concern.ConcernGUID)
                select x).Any();
            if (forceExists)
            {
                MessageBox.Show(string.Format(Messages.ForcesViewForceExists, Force.Name, Concern.Name));
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
