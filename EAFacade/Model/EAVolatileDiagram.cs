using EA;

namespace EAFacade.Model
{
    public class EAVolatileDiagram : IEAObject
    {
        private EAVolatileDiagram()
        {
        }

        public int DiagramID { get; set; }

        public static EAVolatileDiagram Wrap(EventProperties info)
        {
            var volatileDiagram = new EAVolatileDiagram();
            var diagramID = EAUtilities.ParseToInt32(info.Get(EAEventPropertyKeys.DiagramId).Value, -1);
            if (diagramID > 0)
                volatileDiagram.DiagramID = diagramID;

            return volatileDiagram;
        }
    }
}