﻿namespace Mmu.Sms.Domain.Areas.Common.Project.PostSharp
{
    public class PostSharpConfiguration
    {
        public PostSharpConfiguration(string postSharpHostConfigurationFile)
        {
            PostSharpHostConfigurationFile = postSharpHostConfigurationFile;
        }

        public string PostSharpHostConfigurationFile { get; }
    }
}