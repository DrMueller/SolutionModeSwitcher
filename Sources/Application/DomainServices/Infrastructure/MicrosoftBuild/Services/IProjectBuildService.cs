using System.Threading.Tasks;

namespace Mmu.Sms.DomainServices.Infrastructure.MicrosoftBuild.Services
{
    public interface IProjectBuildService
    {
        Task BuildProjectAsync(string filePath);
    }
}