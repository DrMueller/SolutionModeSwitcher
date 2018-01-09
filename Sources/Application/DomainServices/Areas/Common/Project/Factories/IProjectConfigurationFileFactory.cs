using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.Areas.Common.Project.Factories
{
    public interface IProjectConfigurationFileFactory
    {
        ProjectConfigurationFile Create(string filePath);
    }
}
