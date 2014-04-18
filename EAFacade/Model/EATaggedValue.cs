using EA;

namespace EAFacade.Model
{
    public class EATaggedValue :IModelItem
    {
        private readonly TaggedValue _native;

        private EATaggedValue(TaggedValue native)
        {
            _native = native;
        }

        public string GUID
        {
            get { return _native.PropertyGUID; }
        }

        public int ID
        {
            get { return _native.PropertyID; }
        }

        public NativeType NativeType
        {
            get { return NativeType.Property; }
        }

        public string Name
        {
            get { return _native.Name; }
            set { _native.Name = value; }
        }

        public string Notes
        {
            get { return _native.Notes; }
            set { _native.Notes = value; }
        }

        public string Value
        {
            get { return _native.Value; }
            set { _native.Value = value; }
        }

        public static EATaggedValue Wrap(TaggedValue native)
        {
            return new EATaggedValue(native);
        }
    }
}
