using System;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.SolutionProjects.Implementation
{
    public class SolutionProjectTypeToStringAdapter : ISolutionProjectTypeToStringAdapter
    {
        public string AdaptToGuid(SolutionProjectType solutionProjectType)
        {
            switch (solutionProjectType)
            {
                case SolutionProjectType.EtpSubProject:
                {
                    throw new NotImplementedException(nameof(solutionProjectType));
                }

                case SolutionProjectType.KnownToBeMsBuildFormat:
                {
                    return "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}";
                }

                case SolutionProjectType.SolutionFolder:
                {
                    return "{2150E333-8FDC-42A3-9474-1A3956D46DE8}";
                }

                case SolutionProjectType.Unknown:
                {
                    throw new NotImplementedException(nameof(solutionProjectType));
                }

                case SolutionProjectType.WebDeploymentProject:
                {
                    throw new NotImplementedException(nameof(solutionProjectType));
                }

                case SolutionProjectType.WebProject:
                {
                    return "{E24C65DC-7377-472B-9ABA-BC803B73C61A}";
                }

                default:
                {
                    throw new NotImplementedException(nameof(solutionProjectType));
                }
            }
        }
    }
}