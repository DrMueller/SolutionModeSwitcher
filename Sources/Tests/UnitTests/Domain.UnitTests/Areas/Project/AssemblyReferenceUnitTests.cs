using System;
using FluentAssertions;
using Mmu.Sms.Common.LanguageExtensions.Invariance;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common._LegacyProject;
using NUnit.Framework;

namespace Mmu.Sms.Domain.UnitTests.Areas.Project
{
    [TestFixture]
    public class AssemblyReferenceUnitTests
    {
        [Test]
        public void CreatingAssemblyReference_WithNullIncludeDefinition_ThrowsArgumentExceptionForIncludeDefinition()
        {
            // Arrange
            Action action = () => new ProjectAssemblyReference(null, string.Empty, null, null);
            var expectedExceptionMessage = string.Format(Guard.NullObjectExceptionMessage, "includeDefinition");

            // Act & Assert
            action.Should().Throw<ArgumentException>().WithMessage(expectedExceptionMessage);
        }
    }
}