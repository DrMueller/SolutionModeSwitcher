using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.Domain.Areas.Configuration;
using Mmu.Sms.DomainServices.Areas.Configuration.Repositories;
using Mmu.Sms.DomainServices.DataAccess.Areas.Configuration.Entities;
using Newtonsoft.Json;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Configuration.Repositories
{
    public class SolutionModeConfigurationRepository : ISolutionModeConfigurationRepository
    {
        private readonly IDirectoryProxy _directoryProxy;
        private readonly IFileProxy _fileProxy;
        private readonly IMapper _mapper;
        private readonly IPathProxy _pathProxy;
        private string _configurationDirectory;

        public SolutionModeConfigurationRepository(
            IPathProxy pathProxy,
            IFileProxy fileProxy,
            IDirectoryProxy directoryProxy,
            IMapper mapper)
        {
            _pathProxy = pathProxy;
            _fileProxy = fileProxy;
            _directoryProxy = directoryProxy;
            _mapper = mapper;
        }

        public void Delete(string id)
        {
            var filePath = CreateFilePath(id);
            _fileProxy.Delete(filePath);
        }

        public void Initialize(string configurationDirectory)
        {
            _configurationDirectory = configurationDirectory;
        }

        public SolutionModeConfiguration Load(string configurationId)
        {
            var filePath = CreateFilePath(configurationId);
            var jsonData = _fileProxy.ReadAllText(filePath);
            var result = CreateModelFromJsonData(jsonData);
            return result;
        }

        public IReadOnlyCollection<SolutionModeConfiguration> LoadAll()
        {
            var files = _directoryProxy.GetFiles(_configurationDirectory);
            var jsonDataEntries = files.Select(f => _fileProxy.ReadAllText(f)).ToList();
            var result = jsonDataEntries.Select(CreateModelFromJsonData).ToList();
            return result;
        }

        public SolutionModeConfiguration Save(SolutionModeConfiguration model)
        {
            var entity = _mapper.Map<SolutionModeConfigurationEntity>(model);
            var jsonData = JsonConvert.SerializeObject(entity);
            var filePath = CreateFilePath(model.Id);
            _fileProxy.WriteAllText(filePath, jsonData);
            return Load(model.Id);
        }

        private string CreateFilePath(string configurationId)
        {
            var fileName = _pathProxy.ChangeExtension(configurationId, ".json");
            var result = _pathProxy.Combine(_configurationDirectory, fileName);
            return result;
        }

        private SolutionModeConfiguration CreateModelFromJsonData(string jsonData)
        {
            var entity = JsonConvert.DeserializeObject<SolutionModeConfigurationEntity>(jsonData);
            var result = _mapper.Map<SolutionModeConfiguration>(entity);
            return result;
        }
    }
}