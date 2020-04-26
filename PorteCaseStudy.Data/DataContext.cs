namespace PorteCaseStudy.Data
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using PorteCaseStudy.Common.Contracts;

    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<PackageEntity> Packages { get; set; }

        public IQueryable<T> GetDbSet<T>() where T : class
        {
            return this.Set<T>();
        }

        void IDataContext.SaveChanges()
        {
            this.SaveChanges();
        }
    }
}
