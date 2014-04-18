using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EAFacade.Model;

namespace EAFacade
{
    public partial class SelectDiagram : Form
    {
        class DiagramListItem
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public EADiagram Diagram { get; set; }
        }

        public SelectDiagram(IEnumerable<EADiagram> diagrams)
        {
            InitializeComponent();

            var datasource = new List<DiagramListItem>();
            diagrams.ToList().ForEach(x => datasource.Add(new DiagramListItem { Name = x.Name, ID = x.ID, Diagram = x }));
            listDiagrams.ValueMember = "ID";
            listDiagrams.DisplayMember = "Name";
            listDiagrams.DataSource = datasource;
        }

        public EADiagram GetSelectedDiagram()
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
