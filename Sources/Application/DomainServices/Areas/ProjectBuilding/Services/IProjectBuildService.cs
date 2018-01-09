using System.Threading.Tasks;

namespace Mmu.Sms.DomainServices.Areas.ProjectBuilding.Services
{
    public interface IProjectBuildService
    {
        Task BuildProjectAsync(string filePath);
    }
}