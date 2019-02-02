using CoreCRM.DataLayer.DbDomain.Model.Meta;
using Microsoft.EntityFrameworkCore;

namespace CoreCRM.DataLayer.DbDomain.Model
{
    public class DomainContext : DbContext
    {
        public DomainContext(DbContextOptions<DomainContext> options)
            : base(options)
        { }


        public DbSet<MetaTable> MetaTables { get; set; }
        public DbSet<MetaColumn> MetaColumns { get; set; }
    }
}
