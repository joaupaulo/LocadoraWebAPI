using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraWebAPI.Domain
{
    public class DashboardMovie
    {
        [Key]
        public int DashBoardMoviesId { get; set; }
        public int StockMoviesCount { get; set; }
        public List<VideoStoreItens> VideoStoreId {get; set; }
    }
}
