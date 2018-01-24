using System.Text;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.Global
{
    public interface IGlobalEntryToStringAdapter
    {
        void Adapt(SolutionConfigurationFile solutionConfigFile, IExtendedStringBuilder sb);
    }
}