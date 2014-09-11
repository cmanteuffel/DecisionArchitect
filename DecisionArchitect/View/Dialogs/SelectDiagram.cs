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
*/

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EAFacade.Model;

namespace DecisionArchitect.View
{
    public partial class SelectDiagram : Form
    {
        public SelectDiagram(IEnumerable<IEADiagram> diagrams)
        {
            InitializeComponent();

            var datasource = new List<DiagramListItem>();
            diagrams.ToList().ForEach(x => datasource.Add(new DiagramListItem {Name = x.Name, ID = x.ID, Diagram = x}));
            listDiagrams.ValueMember = "ID";
            listDiagrams.DisplayMember = "Name";
            //datasource.Add(new DiagramListItem { Name = "Open DetailView", ID = 999, Diagram = null });
            listDiagrams.DataSource = datasource;
        }


        /*
        public SelectDiagram(IEnumerable<IEADiagram> diagrams, bool isDecision)
        {
            InitializeComponent();

            var datasource = new List<DiagramListItem>();
            diagrams.ToList().ForEach(x => datasource.Add(new DiagramListItem { Name = x.Name, ID = x.ID, Diagram = x }));
            listDiagrams.ValueMember = "ID";
            listDiagrams.DisplayMember = "Name";
            datasource.Add(new DiagramListItem { Name = "Open DetailView", ID = 999, Diagram = null });
            listDiagrams.DataSource = datasource;

        }
         */

        public IEADiagram GetSelectedDiagram()
        {
            var item = listDiagrams.SelectedItem as DiagramListItem;
            if (item != null)
            {
                return item.Diagram;
            }
            return null;
        }

        private class DiagramListItem
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public IEADiagram Diagram { get; set; }
        }
    }
}