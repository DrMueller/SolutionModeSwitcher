namespace Mmu.Sms.Domain.Areas.Common.Project.Targets
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "XML Term")]
    public class GenericXmlAttribute
    {
        public GenericXmlAttribute(
            string name,
            string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public string Value { get; }
    }
}