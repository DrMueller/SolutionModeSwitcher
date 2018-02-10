using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Sms.Domain.Areas.Common.Project
{
//<ItemGroup>
//<Service Include = "{508349B6-6B84-4DF5-91F0-309BEEBAD82D}" />
//</ ItemGroup >

    public class ServiceConfiguration
    {
        public string IncludeGuid { get; }

        public ServiceConfiguration(string includeGuid)
        {
            IncludeGuid = includeGuid;
        }
    }
}
