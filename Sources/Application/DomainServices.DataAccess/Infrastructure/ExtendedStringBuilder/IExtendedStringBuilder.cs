namespace Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder
{
    public interface IExtendedStringBuilder
    {
        void AppendLine(string value, int amountOfTabs = 0);

        string Build();

        void Initialize();
    }
}