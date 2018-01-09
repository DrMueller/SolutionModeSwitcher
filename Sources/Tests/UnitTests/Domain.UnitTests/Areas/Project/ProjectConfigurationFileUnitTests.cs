﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using Mmu.Sms.Common.LanguageExtensions.Invariance;
using Mmu.Sms.Domain.Areas.Common.Project;
using NUnit.Framework;

namespace Mmu.Sms.Domain.UnitTests.Areas.Project
{
    [TestFixture]
    public class ProjectConfigurationFileUnitTests
    {
        [Test]
        public void CreatingProjectConfig_WithAllParametersSet_CreatesProjectConfig()
        {
            // Act
            var projectPropertiesConfig = new ProjectPropertiesConfiguration("NS", "AS", ProjectOutputType.ConsoleApplication);
            var actualProjectConfig = new ProjectConfigurationFile(
                "Test",
                new List<ProjectAssemblyReference>(),
                new List<ProjectReference>(),
                projectPropertiesConfig,
                new List<ProjectBuildConfiguration>());

            // Assert
            Assert.That(actualProjectConfig, Is.Not.Null);
        }

        [Test]
        public void CreatingProjectConfig_WithNullAssemblyReferences_ThrowsArgumentExceptionForAssemblyReferences()
        {
            // Arrange
            var projectPropertiesConfig = new ProjectPropertiesConfiguration("NS", "AS", ProjectOutputType.ConsoleApplication);
            Action action = () => new ProjectConfigurationFile("Test", null, new List<ProjectReference>(), projectPropertiesConfig, new List<ProjectBuildConfiguration>());
            var expectedExceptionMessage = string.Format(Guard.NullObjectExceptionMessage, "assemblyReferences");

            // Act & Assert
            action.Should().Throw<ArgumentException>().WithMessage(expectedExceptionMessage);
        }

        [Test]
        public void CreatingProjectConfig_WithNullProjectReferences_ThrowsArgumentExceptionForProjectReferences()
        {
            // Arrange
            var projectPropertiesConfig = new ProjectPropertiesConfiguration("NS", "AS", ProjectOutputType.ConsoleApplication);
            Action action = () => new ProjectConfigurationFile("Test", new List<ProjectAssemblyReference>(), null, projectPropertiesConfig, new List<ProjectBuildConfiguration>());
            var expectedExceptionMessage = string.Format(Guard.NullObjectExceptionMessage, "projectReferences");

            // Act & Assert
            action.Should().Throw<ArgumentException>().WithMessage(expectedExceptionMessage);
        }
    }
}