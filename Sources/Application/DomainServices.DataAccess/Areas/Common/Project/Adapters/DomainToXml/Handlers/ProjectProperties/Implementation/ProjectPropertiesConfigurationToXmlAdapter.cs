using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.ProjectProperties.Implementation
{
    public class ProjectPropertiesConfigurationToXmlAdapter : IProjectPropertiesConfigurationToXmlAdapter
    {
        public XElement Adapt(ProjectConfigurationFile projectConfigFile)
        {


          //  <PropertyGroup>
          //  <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
          //  <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
          //  <ProductVersion>
          //  </ProductVersion>
          //  <SchemaVersion>2.0</SchemaVersion>
          //  <ProjectGuid>{FF15166B-2E4A-4726-890F-8640ACC54FD3}</ProjectGuid>
          //  <ProjectTypeGuids>{349c5851-65df-11da-9384-00065b846f21};{fae04ec0-301f-11d3-bf4b-00c04f79efbc}</ProjectTypeGuids>
          //  <OutputType>Library</OutputType>
          //  <AppDesignerFolder>Properties</AppDesignerFolder>
          //  <RootNamespace>Fifa.Ifes.WebUI</RootNamespace>
          //  <AssemblyName>Fifa.Ifes.WebUI</AssemblyName>
          //  <TargetFrameworkVersion>v4.6.2</TargetFrameworkVersion>
          //  <MvcBuildViews Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">false</MvcBuildViews>
          //  <MvcBuildViews Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">false</MvcBuildViews>
          //  <UseIISExpress>false</UseIISExpress>
          //  <IISExpressSSLPort />
          //  <IISExpressAnonymousAuthentication />
          //  <IISExpressWindowsAuthentication />
          //  <IISExpressUseClassicPipelineMode />
          //  <SccProjectName>
          //  </SccProjectName>
          //  <SccLocalPath>
          //  </SccLocalPath>
          //  <SccAuxPath>
          //  </SccAuxPath>
          //  <SccProvider>
          //  </SccProvider>
          //  <SolutionDir Condition="$(SolutionDir) == '' Or $(SolutionDir) == '*Undefined*'">..\..\..\</SolutionDir>
          //  <RestorePackages>true</RestorePackages>
          //  <WebGreaseLibPath>..\..\..\..\packages\WebGrease.1.5.2\lib</WebGreaseLibPath>
          //  <UseGlobalApplicationHostFile />
          //  <DontImportPostSharp>True</DontImportPostSharp>
          //  <TargetFrameworkProfile />
          //  <LangVersion>6</LangVersion>
          //  <NuGetPackageImportStamp>
          //  </NuGetPackageImportStamp>
          //</PropertyGroup>
        }
    }
}
