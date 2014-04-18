using System.Collections.Generic;
using System.IO;

namespace EAFacade.Model
{
    public interface IEADiagram : IModelObject
    {
        IEAElement ParentElement { get; set; }
        string Metatype { get; }
        void AddToDiagram(IEAElement newElement);
        void OpenAndSelectElement(IEAElement element);
        List<IEADiagramObject> GetElements();
        void HideConnectors(string[] stereotypes);
        bool IsForcesView();
        bool IsChronologicalView();
        bool IsRelationshipView();
        bool IsStakeholderInvolvementView();
        bool Contains(IEAElement element);
        FileStream DiagramToStream();
    }
}