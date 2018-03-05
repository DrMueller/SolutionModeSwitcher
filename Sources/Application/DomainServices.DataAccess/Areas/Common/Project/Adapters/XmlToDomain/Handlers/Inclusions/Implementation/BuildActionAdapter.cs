﻿using System;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.Inclusions.FileInclusions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Inclusions.Implementation
{
    public class BuildActionAdapter : IBuildActionAdapter
    {
        public BuildAction Adapt(XElement element)
        {
            switch (element.Name.LocalName)
            {
                case "Content":
                {
                    return BuildAction.Content;
                }
                case "Compile":
                {
                    return BuildAction.Compile;
                }

                case "EmbeddedResource":
                {
                    return BuildAction.EmbeddedResource;
                }

                case "CodeAnalysisDictionary":
                {
                    return BuildAction.CodeAnalysisDictionary;
                }

                case "None":
                {
                    return BuildAction.None;
                }

                case "Folder":
                {
                    return BuildAction.Folder;
                }

                case "Reference":
                {
                    return BuildAction.Reference;
                }

                case "Analyzer":
                {
                    return BuildAction.Analyzer;
                }

                case "ProjectReference":
                {
                    return BuildAction.ProjectReference;
                }

                case "Service":
                {
                    return BuildAction.Service;
                }

                case "AppConfigWithTargetPath":
                {
                    return BuildAction.AppConfigWithTargetPath;
                }

                case "WCFMetadata":
                {
                    return BuildAction.WcfMetadata;
                }

                case "WCFMetadataStorage":
                {
                    return BuildAction.WcfMetadataStorage;
                }

                case "EntityDeploy":
                {
                    return BuildAction.EntityDeploy;
                }

                case "BootstrapperPackage":
                {
                    return BuildAction.BootstrapperPackage;
                }

                case "ApplicationDefinition":
                {
                    return BuildAction.ApplicationDefinition;
                }

                case "Page":
                {
                    return BuildAction.Page;
                }

                case "AppDesigner":
                {
                    return BuildAction.AppDesigner;
                }

                case "TypeScriptCompile":
                {
                    return BuildAction.TypeScriptCompile;
                }

                case "NgDist":
                {
                        return BuildAction.NgDist;
                }

                default:
                {
                    throw new NotImplementedException("Build Action: " + element.Name.LocalName);
                }
            }
        }
    }
}