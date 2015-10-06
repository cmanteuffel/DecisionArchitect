using System.ComponentModel;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Model
{
    public interface IDAFile : IPersistableModel, INotifyPropertyChanged
    {
        string Path { get; set; }
        bool DoDelete { get; set; }
    }

    public class DAFile : Entity, IDAFile
    {
        private string _path;
        private bool _doDelete;
        private IEAFile _file;
        private readonly string _elementGuid;
        //private string _type;

        public bool Changed { get; private set; }

        public string Path
        {
            get { return _path; }
            set { SetField(ref _path, value, "Path"); }
        }

        public string Name
        {
            get { return Path.Substring(Path.LastIndexOf(@"\") + 1); }
        }

        public bool DoDelete
        {
            get { return _doDelete; }
            set { SetField(ref _doDelete, value, "DoDelete");  }
        }

        //public string Type
        //{
        //    get { return _type; }
        //    set { SetField(ref _type, value, "Type"); }
        //}

        public DAFile(IEAFile file)
        {
            _file = file;
            Path = file.FullPath;
            PropertyChanged += OnPropertyChanged;
        }

        public DAFile(string path, string elementGuid)
        {
            _path = path;
            //_type = type;
            _elementGuid = elementGuid;
            PropertyChanged += OnPropertyChanged;
            Changed = true;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Changed")) return;
            Changed = true;
        }

        public bool SaveChanges()
        {
            if (!Changed)
                return true;

            var parentElement = EAMain.Repository.GetElementByGUID(_elementGuid);
            _file = parentElement.AddFile(Path);
            return true;
        }

        public void DiscardChanges()
        {
            _doDelete = false;
            if (_file != null)
            {
                _path = _file.FullPath;
            }
        }

        
    }
}
