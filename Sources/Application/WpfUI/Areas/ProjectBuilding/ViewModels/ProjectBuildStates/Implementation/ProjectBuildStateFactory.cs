﻿using System;
using Mmu.Sms.Common.Ioc;
using Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels.ProjectBuildStates.StateImplementations;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels.ProjectBuildStates.Implementation
{
    public class ProjectBuildStateFactory : IProjectBuildStateFactory
    {
        private readonly IProvisioningService _provisioningService;

        public ProjectBuildStateFactory(IProvisioningService provisioningService)
        {
            _provisioningService = provisioningService;
        }

        public IProjectBuildState CreateBuildEnqueuedState()
        {
            return CreateState<BuildEnqueuedState>();
        }

        public IProjectBuildState CreateBuildErrorState(Exception exception)
        {
            var result = CreateState<BuildErrorState>();
            result.Initialize(exception);
            return result;
        }

        public IProjectBuildState CreateBuildInProgressState()
        {
            return CreateState<BuildInProgressState>();
        }

        public IProjectBuildState CreateReadyToBuildState()
        {
            return CreateState<ReadyToBuildState>();
        }

        private T CreateState<T>()
            where T : IProjectBuildState
        {
            var result = _provisioningService.GetService<T>();
            return result;
        }
    }
}