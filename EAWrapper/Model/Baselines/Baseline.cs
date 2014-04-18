namespace EAWrapper.Model.Baselines
{
    public class Baseline
    {
        public Baseline(string guid, string version, string notes)
        {
            Guid = guid;
            Version = version;
            Notes = notes;
        }

        public string Guid { get; private set; }
        public string Version { get; private set; }
        public string Notes { get; private set; }

        
    }
}