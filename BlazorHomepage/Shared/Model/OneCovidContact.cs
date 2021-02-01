using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorHomepage.Shared.Model
{
    public class OneCovidContact
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ContactDate { get; set; }
        
        public string Sted { get; set; }
        public string CategoryId { get; set; }
        public string OwnerId { get; set; }



    }
}
