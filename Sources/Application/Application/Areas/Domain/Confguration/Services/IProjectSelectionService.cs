using System.Collections.Generic;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;

namespace Mmu.Sms.Application.Areas.Domain.Confguration.Services
{
    public interface IProjectSelectionService
    {
        IReadOnlyCollection<ProjectReferenceConfigurationDto> LoadProjects(string solutionFilePath);
    }
}