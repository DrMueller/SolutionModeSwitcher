using System;
using System.Collections.Generic;

namespace Mmu.Sms.Common.Ioc
{
    public interface IProvisioningService
    {
        IReadOnlyCollection<T> GetAllServices<T>();

        T GetService<T>();

        object GetService(Type pluginType);
    }
}