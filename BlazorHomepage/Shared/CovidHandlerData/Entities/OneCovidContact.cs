﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorHomepage.Shared.CovidHandlerData.Entities
{
    public class OneCovidContact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ContactDate { get; set; }
        public string Sted { get; set; }
        public string CategoryId { get; set; }
        public string OwnerId { get; set; }
    }
}