using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp23
{
    public class User
    {
       
        public int Id { get; set; }
        public string? Name { get; set; }

        public int Age { get; set; }
    }
}
