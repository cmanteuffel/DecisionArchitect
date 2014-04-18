using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Windows.Forms;
using DecisionViewpointsCustomViews.Model;
using DecisionViewpointsCustomViews.View;
using EA;
using EAFacade.Model; //angor task157

namespace DecisionViewpointsCustomViews.Controller
{
    public class TopicDetailController : ITopicDetailController
    {
        private readonly ITopic _topic;
        private readonly ITopicDetailView _view;

        public TopicDetailController(ITopic topic, ITopicDetailView view)
        {
            _topic = topic;
            _view = view;
            _view.SetController(this);
        }


        public void Update()
        {
            _view.TopicName = _topic.Name;
            _view.TopicDescription = _topic.Description;
        }

        public void ShowDetailView()
        {
            Update();
            _view.ShowAsDialog();
        }

        public void Save()
        {
            _topic.Name = _view.TopicName;

            var extraData = new StringBuilder();
            extraData.Append(string.Format("{0}{1}{2}", TopicDataTags.Description, _view.TopicDescription,
                                           TopicDataTags.Description));

            using (var tempFiles = new TempFileCollection())
            {
                var fileName = tempFiles.AddExtension("rtf");
                using (var file = new System.IO.StreamWriter(fileName))
                {
                    file.WriteLine(extraData.ToString());
                }
                _topic.LoadLinkedDocument(fileName);
            }
            _topic.Save(extraData.ToString());
        }
    }
}
