using EA;

namespace EAFacade.Model
{
    public class EAVolatileDiagram
    {
        private EAVolatileDiagram()
        {
        }

        public int DiagramID { get; set; }

        public static EAVolatileDiagram Wrap(EventProperties info)
        {
            var volatileDiagram = new EAVolatileDiagram();
            var diagramID = Utilities.ParseToInt32(info.Get(EAEventPropertyKeys.DiagramId).Value, -1);
            if (diagramID > 0)
                volatileDiagram.DiagramID = diagramID;

            return volatileDiagram;
        }
    }
}