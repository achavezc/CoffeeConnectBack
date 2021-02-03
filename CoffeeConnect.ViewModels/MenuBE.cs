using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoffeeConnect.DTO
{
   
    public class MenuBE
    {
        public string Path { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string @Class { get; set; }
        public string Badge { get; set; }
        public bool IsExternalLink { get; set; }
        public List<MenuItemBE> Submenu { get; set; }
    }
}
