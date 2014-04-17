using System;
using EA;
using System.Windows.Forms;

namespace TSDAD
{
    /// <summary>
    /// This class is responsible for handling all the EA events delegated
    /// from MainApplication entry point.
    /// </summary>
    public class EventHandler
    {
        public string Connect()
        {
            return "connected";
        }

        public bool OnPreNewElement(Repository repository, EventProperties info)
        {
            MessageBox.Show("to be added");
            return true;
        }

        public bool OnPreNewConnector(Repository repository, EventProperties info)
        {
            Element client = repository.GetElementByID(info.Get(3).Value);
            MessageBox.Show(String.Format("The client name is {0}", client.Name));
            return true;
        }

        public void Disconnect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
