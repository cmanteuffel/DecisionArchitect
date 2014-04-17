using EA;

namespace DecisionViewpoints.Model
{
    public class EAElementWrapper : IEAWrapper
    {
        private readonly Repository _repository;
        private readonly string _type;
        private readonly int _parentID;
        private readonly string _stereotype;
        private readonly Element _element;

        public Repository Repository
        {
            get { return _repository; }
        }

        public string Type
        {
            get { return _type; }
        }

        public int ParentID
        {
            get { return _parentID; }
        }

        public string Stereotype
        {
            get { return _stereotype; }
        }

        public Element Element
        {
            get { return _element; }
        }

        private EAElementWrapper(Repository repository, int parentId, string stereotype, string type, Element element = null)
        {
            _repository = repository;
            _parentID = parentId;
            _stereotype = stereotype;
            _type = type;
            _element = element;
        }

        public static EAElementWrapper Wrap(Repository repository, EventProperties properties)
        {
            dynamic type = properties.Get(EAEventPropertyKeys.Type).Value;
            dynamic stereotype = properties.Get(EAEventPropertyKeys.Stereotype).Value;
            dynamic parentId = Utilities.ParseToInt32(properties.Get(EAEventPropertyKeys.ParentId).Value, -1);
            return new EAElementWrapper(repository, parentId, stereotype, type);
        }

        public static EAElementWrapper Wrap(Repository repository, Element element)
        {
            return new EAElementWrapper(repository, element.ParentID, element.Stereotype, element.Type, element);
        }

        public static EAElementWrapper Wrap(Repository repository, string guid)
        {
            Element element = repository.GetElementByGuid(guid);
            return Wrap(repository, element);
        }

        public static EAElementWrapper Wrap(Repository repository, int id)
        {
            Element element = repository.GetElementByID(id);
            return Wrap(repository, element);
        }

         public Element GetParent()
        {
            return _repository.GetElementByID(_parentID);
        }
   
    }
}