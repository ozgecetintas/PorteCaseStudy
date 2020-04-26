namespace PorteCaseStudy.Common.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PorteCaseStudy.Common.ViewModels;

    public interface IViewService
    {
       void PrintPackages(List<PackageViewModel> packageViewModels);
    }
}
