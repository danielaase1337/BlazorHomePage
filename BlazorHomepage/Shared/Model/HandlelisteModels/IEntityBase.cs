using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Model.HandlelisteModels
{
    public interface IEntityBase
    {
        string Id { get; set; }
        string Name { get; set; }
        string CssComleteEditClassName { get; }
        bool EditClicked { get; set; }
    }
}
