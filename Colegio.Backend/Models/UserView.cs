
namespace Colegio.Backend.Models
{
    using Colegio.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class UserView : Users
    {
        public HttpPostedFileBase PhotoFile { get; set; }
    }
}