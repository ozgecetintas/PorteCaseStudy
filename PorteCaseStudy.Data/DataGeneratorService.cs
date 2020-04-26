namespace PorteCaseStudy.Data
{
    using System.Linq;
    using PorteCaseStudy.Common.Contracts;

    public class DataGeneratorService : IDataGeneratorService
    {
        private readonly DataContext dataContext;

        public DataGeneratorService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Initialize()
        {
            if (dataContext.Packages.Any())
            {
                return;
            }

            dataContext.Packages.AddRange(
                    new PackageEntity
                    {
                        BoxId = 123450,
                        Weight = 3
                    },
                    new PackageEntity
                    {
                        BoxId = 123461,
                        Weight = 8
                    },
                    new PackageEntity
                    {
                        BoxId = 123472,
                        Weight = 11
                    },
                    new PackageEntity
                    {
                        BoxId = 123483,
                        Weight = 3
                    },
                    new PackageEntity
                    {
                        BoxId = 123494,
                        Weight = 13
                    });

            dataContext.SaveChanges();
        }
    }
}
