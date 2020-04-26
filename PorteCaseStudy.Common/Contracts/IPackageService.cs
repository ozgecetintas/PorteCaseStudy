namespace PorteCaseStudy.Common.Contracts
{
    using System.Collections.Generic;
    using PorteCaseStudy.Common.ViewModels;

    public interface IPackageService
    {
        void CalculatePartCount();

        List<PackageViewModel> GetPackages();
    }
}
