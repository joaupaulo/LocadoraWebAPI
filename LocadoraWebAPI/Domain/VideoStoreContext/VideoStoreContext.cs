using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LocadoraWebAPI.Domain.VideoStoreContext
{
    public class VideoStoreDbContext : DbContext
    {
        public VideoStoreDbContext(DbContextOptions<VideoStoreDbContext> options) : base(options)
        {

        }

        public DbSet<VideoStoreItens> VideoStoreItens {get; set;}
        public DbSet<DashboardMovie> DashboardMovie { get; set; }
        public DbSet<Category> MovieCategory { get; set; }



    }
}
