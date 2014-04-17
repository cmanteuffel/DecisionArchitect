using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EA;

namespace DecisionViewpoints
{
    public partial class SelectDiagram : Form
    {
        
        class DiagramListItem
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public Diagram Diagram { get; set; }
        }

        public SelectDiagram(Diagram[] diagrams)
        {
            InitializeComponent();

            var datasource = new List<DiagramListItem>();
            diagrams.ToList().ForEach(x => datasource.Add(new DiagramListItem{Name = x.Name, ID = x.DiagramID, Diagram = x}));
            listDiagrams.ValueMember = "ID";
            listDiagrams.DisplayMember = "Name";
            listDiagrams.DataSource = datasource;
        }

        public Diagram GetSelectedDiagram()
        {
            var item = listDiagrams.SelectedItem as DiagramListItem;
            if (item != null)
            {
                return item.Diagram;
            }
            return null;
        }
    }
}
