using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EAWrapper.Model;

namespace DecisionViewpointsCustomViews.Model
{
    public class ForcesDiagramModel : ICustomViewModel
    {
        private readonly List<ICustomViewModelObserver> _observers = new List<ICustomViewModelObserver>();
        private EADiagram _diagram;
        public string Name { get; set; }

        public string DiagramGUID
        {
            get { return _diagram.GUID; }
        }

        public EADiagram DiagramModel
        {
            set
            {
                _diagram = value;
                Notify();
            }
        }

        public void AddObserver(ICustomViewModelObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(ICustomViewModelObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
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