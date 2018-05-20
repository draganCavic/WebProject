using Microsoft.AspNetCore.Mvc.Rendering;
using NekretnineWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NekretnineWeb.ViewModels
{
    public class PropertyViewModel
    {
        public Property property { get; set; }
        public SelectList cities { get; set; }
        public SelectList categories { get; set; }
        public int city { get; set; }
        public int category { get; set; }
    }
}
