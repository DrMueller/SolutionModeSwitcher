using Mmu.Sms.Domain.Areas.Common.Project;
using NUnit.Framework;

namespace Mmu.Sms.Domain.UnitTests.Areas.Project
{
    [TestFixture]
    public class ProjectReferenceUnitTests
    {
        [Test]
        public void CreatingProjectReference_WithAllNullParameters_CreatesProjectReference()
        {
            // Act
            var actualProjectReference = new ProjectReference(null, null, null);

            // Assert
            Assert.That(actualProjectReference, Is.Not.Null);
        }
    }
}