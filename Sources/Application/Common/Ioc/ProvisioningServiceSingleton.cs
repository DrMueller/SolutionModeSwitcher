﻿namespace Mmu.Sms.Common.Ioc
{
    public static class ProvisioningServiceSingleton
    {
        public static IProvisioningService Instance { get; private set; }

        public static void Initialize(IProvisioningService instance)
        {
            Instance = instance;
        }
    }
}