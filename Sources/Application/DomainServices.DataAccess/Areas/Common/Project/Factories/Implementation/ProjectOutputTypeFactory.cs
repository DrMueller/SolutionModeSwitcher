﻿using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Factories.Implementation
{
    public class ProjectOutputTypeFactory : IProjectOutputTypeFactory
    {
        public ProjectOutputType CreateFromDescription(string description)
        {
            var upperDescription = description?.ToUpperInvariant();

            switch (upperDescription)
            {
                case "LIBRARY":
                {
                    return new ProjectOutputType(".dll");
                }
                case "WINEXE":
                {
                    return new ProjectOutputType(".exe");
                }
                case "EXE":
                {
                    return new ProjectOutputType(".exe");
                }
                default:
                {
                    return new ProjectOutputType(string.Empty);
                }
            }
        }
    }
}