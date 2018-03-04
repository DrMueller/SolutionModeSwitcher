namespace Mmu.Sms.Domain.Areas.Common.Project.Targets
{
    public class TransformXml
    {
        public TransformXml(
            string source,
            string destination,
            string transform)
        {
            Source = source;
            Destination = destination;
            Transform = transform;
        }

        public string Destination { get; }
        public string Source { get; }
        public string Transform { get; }
    }
}