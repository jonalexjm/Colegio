using Colegio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Colegio.Backend.Models
{
    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<Colegio.Common.Models.Users> Users { get; set; }
    }
}