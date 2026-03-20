using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIEF.Models;

namespace WebAPIEF.Data
{
    public class WebAPIEFContext : DbContext
    {
        public WebAPIEFContext (DbContextOptions<WebAPIEFContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPIEF.Models.Loan> Loan { get; set; } = default!;
    }
}
