using System.Text;

namespace Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder.Implementation
{
    public class ExtendedStringBuilder : IExtendedStringBuilder
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public void AppendLine(string value, int amountOfTabs = 0)
        {
            if (amountOfTabs > 0)
            {
                value = new string('\t', amountOfTabs) + value;
            }

            _stringBuilder.AppendLine(value);
        }

        public string Build()
        {
            return _stringBuilder.ToString();
        }

        public void Initialize()
        {
            _stringBuilder.Clear();
        }
    }
}