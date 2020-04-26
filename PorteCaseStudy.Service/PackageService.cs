namespace PorteCaseStudy.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using PorteCaseStudy.Common;
    using PorteCaseStudy.Common.Contracts;
    using PorteCaseStudy.Common.ViewModels;
    using PorteCaseStudy.Data;

    public class PackageService : IPackageService
    {
        private readonly IDataContext dataContext;

        public PackageService(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void CalculatePartCount()
        {
            List<PackageEntity> packageEntities = dataContext.GetDbSet<PackageEntity>().OrderBy(x => x.Weight).ToList();

            int partCount = 2;

            foreach (var packageEntity in packageEntities)
            {
                packageEntity.PartCount = partCount++;
            }

            dataContext.SaveChanges();
        }

        public List<PackageViewModel> GetPackages()
        {
            var packageEntities = dataContext.GetDbSet<PackageEntity>().ToList();
            List<PackageViewModel> packageViewModelList = new List<PackageViewModel>();
            int remain = 0;
            foreach (var package in packageEntities)
            {
                remain = package.Weight % package.PartCount;

                for (int i = 1; i < package.PartCount + 1; i++)
                {
                    PackageViewModel packageViewModel = new PackageViewModel();
                    packageViewModel.BoxId = package.BoxId;
                    packageViewModel.PartWeight = (i <= remain) ? (package.Weight / package.PartCount) + 1 : package.Weight / package.PartCount;
                    packageViewModel.PartNumber = i;
                    packageViewModel.PartCost = PartCostHelper.CalculatePartCost(package.PartCount, packageViewModel.PartWeight);
                    packageViewModelList.Add(packageViewModel);
                }
            }

            return packageViewModelList;
        }
    }
}
