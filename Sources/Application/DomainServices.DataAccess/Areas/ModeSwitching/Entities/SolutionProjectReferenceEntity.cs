using System.Collections.Generic;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities
{
    public class SolutionProjectReferenceEntity
    {
        public string AbsoluteProjectFilePath { get; set; }
        public string AssemblyName { get; set; }
        public string BlockText { get; set; }
        public List<SolutionProjectConfigurationEntity> Configurations { get; set; }
        public string Guid { get; set; }
        public string ParentGuid { get; set; }
    }
}