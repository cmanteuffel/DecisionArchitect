using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionArchitect.Model;
using EAFacade.Model;

namespace DecisionArchitect.View.Dialogs
{
    public interface IDecisionDialogListener
    {
        void OnDecisionSelected(IEAElement decisionElement);
    }
}
