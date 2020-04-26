namespace PorteCaseStudy.Controllers
{
    using PorteCaseStudy.Common.Contracts;

    public class PartCostController
    {
        private readonly IDataGeneratorService dataGeneratorService;
        private readonly IPackageService packageService;
        private readonly IViewService viewService;

        public PartCostController(IDataGeneratorService dataGeneratorService, IPackageService packageService, IViewService viewService)
        {
            this.dataGeneratorService = dataGeneratorService;
            this.packageService = packageService;
            this.viewService = viewService;
        }

        public void Index()
        {
            dataGeneratorService.Initialize();
            packageService.CalculatePartCount();
            var packages = packageService.GetPackages();
            viewService.PrintPackages(packages);
        }
    }
}
