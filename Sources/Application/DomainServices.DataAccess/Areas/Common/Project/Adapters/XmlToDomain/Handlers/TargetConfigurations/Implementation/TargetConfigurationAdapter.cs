using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Project.Targets;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.TargetConfigurations.Implementation
{
    public class TargetConfigurationAdapter : ITargetConfigurationAdapter
    {
        public TargetConfiguration Adapt(XDocument document)
        {
            var aspnetConfig = AdaptAspNetCompilerConfiguration(document);
            var transformXmlConfig = AdaptTransformXmlConfiguration(document);
            var deploymentConfig = AdaptDeploymentConfiguration(document);
            var postSharpImportConfig = AdaptPostSharpImportConfiguration(document);
            var nugetPackageConfig = AdaptNugetPackageConfiguration(document);

            var result = new TargetConfiguration(
                aspnetConfig,
                deploymentConfig,
                postSharpImportConfig,
                transformXmlConfig,
                nugetPackageConfig);

            return result;
        }

        private static Maybe<AspNetCompilerConfiguration> AdaptAspNetCompilerConfiguration(XDocument document)
        {
            var element = document.Descendants().FirstOrDefault(f => f.Name.LocalName == "AspNetCompiler");

            if (element == null)
            {
                return MaybeFactory.CreateNone<AspNetCompilerConfiguration>();
            }

            var virtualPath = element.Attributes().FirstOrDefault(f => f.Name.LocalName == "VirtualPath")?.Value ?? string.Empty;
            var physicalPath = element.Attributes().FirstOrDefault(f => f.Name.LocalName == "VirtualPath")?.Value ?? string.Empty;

            var config = new AspNetCompilerConfiguration(virtualPath, physicalPath);
            return MaybeFactory.CreateSome(config);
        }

        private static Maybe<DeploymentConfiguration> AdaptDeploymentConfiguration(XDocument document)
        {
            var targetElement = document.Descendants().FirstOrDefault(
                f =>
                    f.Name.LocalName == "Target" &&
                    f.Attributes().Any(a => a.Name.LocalName == "Name" && a.Value == "AfterPublish"));

            if (targetElement == null)
            {
                return MaybeFactory.CreateNone<DeploymentConfiguration>();
            }

            var copyElement = targetElement.Descendants().First(f => f.Name.LocalName == "Copy");

            var condition = copyElement.Attributes().FirstOrDefault(f => f.Name.LocalName == "Transform")?.Value ?? string.Empty;
            var sourceFiles = copyElement.Attributes().FirstOrDefault(f => f.Name.LocalName == "SourceFiles")?.Value ?? string.Empty;
            var destinationFiles = copyElement.Attributes().FirstOrDefault(f => f.Name.LocalName == "DestinationFiles")?.Value ?? string.Empty;
            var deployedConfig = targetElement.Descendants().First(f => f.Name.LocalName == "DeployedConfig").Value;

            var config = new DeploymentConfiguration(deployedConfig, condition, sourceFiles, destinationFiles);
            return MaybeFactory.CreateSome(config);
        }

        private Maybe<EnsureNuGetPackageBuildImportsConfiguration> AdaptNugetPackageConfiguration(XDocument document)
        {
            var targetElement = document.Descendants().FirstOrDefault(
                f =>
                    f.Name.LocalName == "Target" &&
                    f.Attributes().Any(a => a.Name.LocalName == "Name" && a.Value == "EnsureNuGetPackageBuildImports"));

            if (targetElement == null)
            {
                return MaybeFactory.CreateNone<EnsureNuGetPackageBuildImportsConfiguration>();
            }

            var beforeTargets = targetElement.Attributes().First(f => f.Name.LocalName == "BeforeTargets").Value;
            var errorText = targetElement.Descendants().First(f => f.Name.LocalName == "ErrorText").Value;
            var targetErrors = targetElement.Descendants().Where(f => f.Name.LocalName == "Error").Select(AdaptTargetError).ToList();

            var config = new EnsureNuGetPackageBuildImportsConfiguration(beforeTargets, errorText, targetErrors);
            return MaybeFactory.CreateSome(config);
        }

        private static Maybe<EnsurePostSharpImportedConfiguration> AdaptPostSharpImportConfiguration(XDocument document)
        {
            var targetElement = document.Descendants().FirstOrDefault(
                f =>
                    f.Name.LocalName == "Target" &&
                    f.Attributes().Any(a => a.Name.LocalName == "Name" && a.Value == "EnsurePostSharpImported"));

            if (targetElement == null)
            {
                return MaybeFactory.CreateNone<EnsurePostSharpImportedConfiguration>();
            }

            var beforeTargets = targetElement.Attributes().First(f => f.Name.LocalName == "BeforeTargets").Value;
            var condition = targetElement.Attributes().First(f => f.Name.LocalName == "Condition").Value;
            var targetErrors = targetElement.Descendants().Where(f => f.Name.LocalName == "Error").Select(AdaptTargetError).ToList();

            var config = new EnsurePostSharpImportedConfiguration(beforeTargets, condition, targetErrors);
            return MaybeFactory.CreateSome(config);
        }

        private static TargetError AdaptTargetError(XElement element)
        {
            var condition = element.Attributes().FirstOrDefault(f => f.Name.LocalName == "Condition")?.Value ?? string.Empty;
            var text = element.Attributes().FirstOrDefault(f => f.Name.LocalName == "Text")?.Value ?? string.Empty;

            var result = new TargetError(condition, text);
            return result;
        }

        private static Maybe<TransformXmlConfiguration> AdaptTransformXmlConfiguration(XDocument document)
        {
            var element = document.Descendants().FirstOrDefault(f => f.Name.LocalName == "TransformXml");

            if (element == null)
            {
                return MaybeFactory.CreateNone<TransformXmlConfiguration>();
            }

            var source = element.Attributes().FirstOrDefault(f => f.Name.LocalName == "Source")?.Value ?? string.Empty;
            var destination = element.Attributes().FirstOrDefault(f => f.Name.LocalName == "Destination")?.Value ?? string.Empty;
            var transform = element.Attributes().FirstOrDefault(f => f.Name.LocalName == "Transform")?.Value ?? string.Empty;

            var config = new TransformXmlConfiguration(source, destination, transform);
            return MaybeFactory.CreateSome(config);
        }
    }
}