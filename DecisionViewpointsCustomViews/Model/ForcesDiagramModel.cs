using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EAWrapper.Model;

namespace DecisionViewpointsCustomViews.Model
{
    public class ForcesDiagramModel : ICustomViewModel
    {
        private readonly List<ICustomViewModelListener> _listeners = new List<ICustomViewModelListener>();
        public string Name { get; set; }

        public string DiagramGUID
        {
            get { return _diagram.GUID; }
        }

        private EADiagram _diagram;

        public EADiagram DiagramModel
        {
            get { return _diagram; }
            set
            {
                _diagram = value;
                Notify();
            }
        }

        public void AddListener(ICustomViewModelListener listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(ICustomViewModelListener listener)
        {
            _listeners.Remove(listener);
        }

        public void Notify()
        {
            foreach (var listener in _listeners)
            {
                listener.Update(this);
            }
        }

        public List<string> GetDecisions()
        {
            var repository = EARepository.Instance;
            return (from diagramObject in _diagram.GetElements()
                    select repository.GetElementByID(diagramObject.ElementID)
                    into element where element.IsDecision() select element.Name).ToList();
        }

        public List<string> GetRequirements()
        {
            var repository = EARepository.Instance;
            return (from diagramObject in _diagram.GetElements()
                    select repository.GetElementByID(diagramObject.ElementID)
                    into element where element.Type.Equals("Requirement") select element.Name).ToList();
        }

        public void SaveRatings()
        {
            MessageBox.Show("saving ratings...");
        }
    }
}