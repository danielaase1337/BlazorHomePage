using BlazorHomepage.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Model
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}"; 
        }
    }
}
