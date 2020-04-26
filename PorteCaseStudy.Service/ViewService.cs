namespace PorteCaseStudy.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PorteCaseStudy.Common.Contracts;
    using PorteCaseStudy.Common.ViewModels;

    public class ViewService : IViewService
    {
        public void PrintPackages(List<PackageViewModel> packageViewModels)
        {
            Console.WriteLine("BOX_ID\tPART_NUMBER\tPART_WEIGHT\tPART_COST");

            foreach (var package in packageViewModels)
            {
                Console.WriteLine($"{package.BoxId}\t\t{package.PartNumber}\t\t{ package.PartWeight }\t\t{ package.PartCost}");
            }
        }
    }
}
