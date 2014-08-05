using System.Windows.Forms;
using DecisionViewpoints.Model;
using EA;

namespace DecisionViewpoints.Logic.Menu.Tracing
{
    public class CreateTraces : CompositeMenuItem
    {
        public CreateTraces()
            : base("-&Create Trace to ...")
        {
        }

        public override bool Visible()
        {
            //TODO: Check if the the context item is an element and a decision
            /*if (ObjectType.otElement == repository.GetContextItemType())
            {
                var obj = repository.GetContextObject();
                var eaelement = obj as Element;
                if (eaelement != null && !DVStereotypes.IsDecision(eaelement))
                {
                    return true;
                }
            }*/
            return true;
        }
    }
}
