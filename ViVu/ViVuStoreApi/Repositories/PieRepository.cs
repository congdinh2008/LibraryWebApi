using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViVuStoreApi.Data;
using ViVuStoreApi.Models;

namespace ViVuStoreApi.Repositories
{
    public class PieRepository
    {
        private readonly ApplicationDbContext _context;

        public PieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPie(Pie pie)
        {
            pie.Id = Guid.NewGuid();
            _context.Pies.Add(pie);

            if(pie.)
        }
    }
}
