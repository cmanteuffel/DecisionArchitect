/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
*/

using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using DecisionViewpoints.Model;

//angor task157

namespace DecisionViewpoints.View.Controller
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
                string fileName = tempFiles.AddExtension("rtf");
                using (var file = new StreamWriter(fileName))
                {
                    file.WriteLine(extraData.ToString());
                }
                _topic.LoadLinkedDocument(fileName);
            }
            _topic.Save(extraData.ToString());
        }
    }
}
