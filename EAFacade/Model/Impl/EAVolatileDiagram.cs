using EA;

namespace EAFacade.Model.Impl
{
    internal sealed class EAVolatileDiagram : IEAVolatileDiagram
    {
        private EAVolatileDiagram()
        {
        }

        public int DiagramID { get; set; }

        public static IEAVolatileDiagram Wrap(EventProperties info)
        {
            var volatileDiagram = new EAVolatileDiagram();
            var diagramID = EAUtilities.ParseToInt32(info.Get(EAEventPropertyKeys.DiagramId).Value, -1);
            if (diagramID > 0)
                volatileDiagram.DiagramID = diagramID;

            return volatileDiagram;
        }
    }
}