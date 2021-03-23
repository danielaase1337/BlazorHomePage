using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BlazorHomepage.Shared.Repository;

namespace BlazorHomepage.Shared.CovidHandlerData.Entities
{
    public class OneCovidContact : EntityBase
    {
        public DateTime ContactDate { get; set; }
        public string Sted { get; set; }
        public string CategoryId { get; set; }
        public string OwnerId { get; set; }
    }
}
