using EA;

namespace EAFacade.Model.Impl
{
    internal sealed class EATaggedValue : IEATaggedValue
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

        public EANativeType EANativeType
        {
            get { return EANativeType.Property; }
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

        public static IEATaggedValue Wrap(TaggedValue native)
        {
            return new EATaggedValue(native);
        }
    }
}
