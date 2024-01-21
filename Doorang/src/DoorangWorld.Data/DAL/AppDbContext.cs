using DoorangWorld.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Data.DAL
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options){}
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ExploreWorld> ExploreWorlds { get; set; }
        public DbSet<Setting> Settings { get; set; }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    var datas = ChangeTracker.Entries<BaseEntity>();
        //    foreach (var data in datas)
        //    {
        //        var entity= data.Entity;
                
                
        //    }
        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}
