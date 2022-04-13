using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace virtualClosetAPI.Models
{
    public class OutfitModel
    {
         public int Id { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public string? OutfitName { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public string? Brand { get; set; }
        public string? Season { get; set; }
        public string? Category { get; set; }
        public string? Image { get; set; }
        public bool Selected { get; set; }
        public bool Favorite { get; set; }

        public OutfitModel(){}
    }
}