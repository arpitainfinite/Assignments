using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CodebaseTest_Question2.Models
{
    public class MoviesContext:DbContext
    {
        public MoviesContext() : base("abc")
        {

        }

    }
}