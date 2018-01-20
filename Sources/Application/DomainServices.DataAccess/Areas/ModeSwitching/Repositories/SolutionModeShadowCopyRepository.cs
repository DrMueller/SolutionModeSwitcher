using AutoMapper;
using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.Domain.Areas.ModeSwitching;
using Mmu.Sms.DomainServices.Areas.ModeSwitching.Repositories;
using Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities;
using Newtonsoft.Json;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Repositories
{
    public class SolutionModeShadowCopyRepository : ISolutionModeShadowCopyRepository
    {
        private readonly IFileProxy _fileProxy;
        private readonly IDirectoryProxy _directoryProxy;
        private readonly IMapper _mapper;
        private readonly IPathProxy _pathProxy;

        public SolutionModeShadowCopyRepository(IPathProxy pathProxy, IFileProxy fileProxy, IDirectoryProxy directoryProxy, IMapper mapper)
        {
            _pathProxy = pathProxy;
            _fileProxy = fileProxy;
            _directoryProxy = directoryProxy;
            _mapper = mapper;
        }

        public SolutionModeShadowCopy Load(string configurationId)
        {
            var filePath = CreateFilePath(configurationId);
            var jsonData = _fileProxy.ReadAllText(filePath);

            var entity = JsonConvert.DeserializeObject<SolutionModeShadowCopyEntity>(jsonData);
            var result = _mapper.Map<SolutionModeShadowCopy>(entity);
            return result;
        }

        public void Save(SolutionModeShadowCopy model)
        {
            var entity = _mapper.Map<SolutionModeShadowCopyEntity>(model);
            var jsonData = JsonConvert.SerializeObject(entity);
            var filePath = CreateFilePath(model.ConfigurationId);
            _fileProxy.WriteAllText(filePath, jsonData);
        }

        private string CreateFilePath(string configurationId)
        {
            var mlsTempPath = _pathProxy.Combine(_pathProxy.GetTempPath(), "MLS");

            if (!_directoryProxy.Exists(mlsTempPath))
            {
                _directoryProxy.CreateDirectory(mlsTempPath);   
            }

            var fileName = _pathProxy.ChangeExtension(configurationId, ".json");
            var result = _pathProxy.Combine(mlsTempPath, fileName);
            return result;
        }
    }
}