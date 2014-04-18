using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionViewpointsCustomViews.Model
{
    public interface ITopic : ICustomViewModel
    {
        int ID { get; }
        string Name { get; set; }
        string Description { get;}

        void Save(string extraData);

        void LoadLinkedDocument(string fileName);
        /*
        void AddObserver(ITopicObserver observer);
        void RemoveObserver(ITopicObserver observer);
         */ 
    }
}
