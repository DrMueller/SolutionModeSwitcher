using System.Threading.Tasks;

namespace Mmu.Sms.Application.Areas.Domain.ProjectBuilding.Services
{
    public interface IProjectBuildService
    {
        Task BuildProjectAsync(string filePath);
    }
}