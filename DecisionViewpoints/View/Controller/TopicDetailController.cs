/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Antonis Gkortzis (University of Groningen)  
    Marc Holterman (University of Groningen)
*/

using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using DecisionViewpoints.Model;


namespace DecisionViewpoints.View.Controller
{
    public class TopicDetailController : ITopicDetailController
    {
        private ITopic _topic;
        //private ITopicDetailView _view;

        public TopicDetailController(ITopic topic)
        {
            //_topic = topic;
            //_view = view;
            //_view.SetController(this);
        }


        public ITopic Topic
        {
            get { return _topic; }
            set
            {
                _topic = value;
            }
        }

        //public ITopicDetailView View
        //{
        //    get { return _view; }
        //    set
        //    {
        //        _view = value;
        //       // _view.SetController(this);
        //    }
        //}

        public void Update()
        {
           // _view.TopicName = _topic.Name;
          //  _view.TopicDescription = _topic.Description;
          //  _view.TopicId = _topic.ID.ToString();
        }

        public void ShowDetailView()
        {
            Update();
           // _view.ShowAsDialog();
        }

        public void Save()
        {
            //_topic.Name = _view.TopicName;
            //_topic.Description = _view.TopicDescription;

            //_topic.Save();
        }
    }
}
