namespace PackageServiceTest
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using PorteCaseStudy.Common.Contracts;
    using PorteCaseStudy.Data;
    using PorteCaseStudy.Service;

    [TestClass]
    public class PackageServiceTests
    {
        private IPackageService packageService;
        private Mock<IDataContext> mockDataContext;
        [TestInitialize]
        public void Init()
        {
            mockDataContext = new Mock<IDataContext>();
            mockDataContext.Setup(x => x.GetDbSet<PackageEntity>())
                .Returns(new PackageEntity[]
                {
                     new PackageEntity()
                     {
                          BoxId = 1,
                          Weight = 1,
                     },
                     new PackageEntity()
                     {
                          BoxId = 2,
                          Weight = 2,
                     }
                }.AsQueryable());
            packageService = new PackageService(mockDataContext.Object);
        }

        [TestMethod]
        public void CalculatePartCount_ShouldSavePartCount()
        {
            packageService.CalculatePartCount();
            foreach (var item in mockDataContext.Object.GetDbSet<PackageEntity>())
            {
                Assert.IsTrue(item.PartCount >= 2);
            }

            mockDataContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void CalculatePartCount_ShouldAsignPartCount()
        {
            packageService.CalculatePartCount();
            foreach (var item in mockDataContext.Object.GetDbSet<PackageEntity>())
            {
                Assert.IsTrue(item.PartCount >= 2);
            }
        }

        [TestMethod]
        public void GetPackages_ShouldReturnCorrectNumberOfElements()
        {
            foreach (var item in mockDataContext.Object.GetDbSet<PackageEntity>())
            {
                item.PartCount = 3;
            }

            var packages = packageService.GetPackages();
            Assert.AreEqual(2 * 3, packages.Count);
        }
    }
}
