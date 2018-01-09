using System;
using FluentAssertions;
using Mmu.Sms.Common.LanguageExtensions.Invariance;
using Mmu.Sms.Domain.Areas.Common.Project;
using NUnit.Framework;

namespace Mmu.Sms.Domain.UnitTests.Areas.Project
{
    [TestFixture]
    public class IncludeDefinitionUnitTests
    {
        [Test]
        public void CreatingIncludeDefinition_WithAllParameters_CreatesIncludeDefinition()
        {
            // Arrange

            // Act
            var actualIncludeDefinition = new IncludeDefinition("ShortName", "Version", "Culture", "PublicKeyToken", "ProcessorArchitecture");

            // Assert
            Assert.That(actualIncludeDefinition, Is.Not.Null);
        }

        [Test]
        public void CreatingIncludeDefinition_WithEmptyShortName_ThrowsArgumentExceptionForShortName()
        {
            // Arrange
            Action action = () => new IncludeDefinition(string.Empty, "Version", "Culture", "PublicKeyToken", "ProcessorArchitecture");
            var expectedExceptionMessage = string.Format(Guard.StringNullOrEmptyExceptionMessage, "shortName");

            // Act & Assert
            action.Should().Throw<ArgumentException>().WithMessage(expectedExceptionMessage);
        }

        [Test]
        public void CreatingIncludeDefinition_WithNullShortName_ThrowsArgumentExceptionForShortName()
        {
            // Arrange
            Action action = () => new IncludeDefinition(null, "Version", "Culture", "PublicKeyToken", "ProcessorArchitecture");
            var expectedExceptionMessage = string.Format(Guard.StringNullOrEmptyExceptionMessage, "shortName");

            // Act & Assert
            action.Should().Throw<ArgumentException>().WithMessage(expectedExceptionMessage);
        }
    }
}