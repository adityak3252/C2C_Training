using Swaad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swaad.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<FoodItem> TodaysMenu { get; set; }
    }
}
