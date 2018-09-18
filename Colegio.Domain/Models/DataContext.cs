using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Domain.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Colegio.Common.Models.Users> Users { get; set; }
    }
}
