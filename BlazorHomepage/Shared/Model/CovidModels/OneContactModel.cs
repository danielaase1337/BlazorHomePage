using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Model.CovidModels
{
    public class OneContactModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ContactDate { get; set; }
        public string OwnerId { get; set; }

        public string Sted { get; set; }
        public string CategoryId { get; set; }

        public OneContactModel()
        {

        }
        public OneContactModel(OneContactModel exisitng)
        {
            Id = exisitng.Id;
            Name = exisitng.Name;
            ContactDate = exisitng.ContactDate;
            Sted = exisitng.Sted;
            CategoryId = exisitng.CategoryId;
            OwnerId = exisitng.OwnerId;
        }
    }
}
