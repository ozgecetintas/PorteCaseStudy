namespace PorteCaseStudy.Common.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDataContext
    {
        IQueryable<T> GetDbSet<T>() where T : class;

        void SaveChanges();
    }
}
