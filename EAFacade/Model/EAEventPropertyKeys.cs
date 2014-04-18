namespace EAFacade.Model
{
    public static class EAEventPropertyKeys
    {
        public const string SupplierId = "supplierID";
        public const string ClientId = "clientID"; 
        public const string DiagramId = "diagramID"; 
        public const string Stereotype = "stereotype"; 
        public const string Type = "type";
        public const string Subtype = "subtype";
        public const string ParentId = "ParentID";
        public const string ElementId = "ElementID";
        public const string DiagramObjectId = "ID"; //According to documentation this key is called ObjectID, however in practice it is just called ID
    }
}
