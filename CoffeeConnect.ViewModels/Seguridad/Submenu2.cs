using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO.Seguridad
{
    public class Submenu2
    {
        public string Path { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Class { get; set; }
        public string Badge { get; set; }
        public string BadgeClass { get; set; }
        public bool IsExternalLink { get; set; }
        public List<Submenu2> Submenu { get; set; }
    }
}
