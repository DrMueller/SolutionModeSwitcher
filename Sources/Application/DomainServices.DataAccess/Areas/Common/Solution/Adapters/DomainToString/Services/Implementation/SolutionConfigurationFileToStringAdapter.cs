using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.Global;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.Heading;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.SolutionProjects;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Implementation
{
    public class SolutionConfigurationFileToStringAdapter : ISolutionConfigurationFileToStringAdapter
    {
        private readonly IExtendedStringBuilder _extendedStringBuilder;
        private readonly IGlobalEntryToStringAdapter _globalEntryAdapter;
        private readonly IHeadingToStringAdapter _headingAdapter;
        private readonly ISolutionProjectToStringAdapter _solutionProjectAdapter;

        public SolutionConfigurationFileToStringAdapter(
            IHeadingToStringAdapter headingAdapter,
            ISolutionProjectToStringAdapter solutionProjectAdapter,
            IGlobalEntryToStringAdapter globalEntryAdapter,
            IExtendedStringBuilder extendedStringBuilder)
        {
            _headingAdapter = headingAdapter;
            _solutionProjectAdapter = solutionProjectAdapter;
            _globalEntryAdapter = globalEntryAdapter;
            _extendedStringBuilder = extendedStringBuilder;
        }

        public string Adapt(SolutionConfigurationFile solutionConfigile)
        {
            _extendedStringBuilder.Initialize();
            _headingAdapter.Adapt(solutionConfigile.HeadingElement, _extendedStringBuilder);
            _solutionProjectAdapter.Adapt(solutionConfigile.SolutionProjects, _extendedStringBuilder);
            _globalEntryAdapter.Adapt(solutionConfigile, _extendedStringBuilder);

            var result = _extendedStringBuilder.Build();
            return result;
        }
    }
}