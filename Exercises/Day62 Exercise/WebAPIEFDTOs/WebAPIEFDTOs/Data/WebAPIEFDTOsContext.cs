using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIEFDTOs.Models;

namespace WebAPIEFDTOs.Data
{
    public class WebAPIEFDTOsContext : DbContext
    {
        public WebAPIEFDTOsContext (DbContextOptions<WebAPIEFDTOsContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPIEFDTOs.Models.Loan> Loan { get; set; } = default!;
    }
}
