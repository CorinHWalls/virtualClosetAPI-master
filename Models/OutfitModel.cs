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
        public string? OutfitOccasion { get; set; }
        public string? OutfitSeason { get; set; }
        // public string? Color { get; set; }
        // public string? Size { get; set; }
        // public string? Brand { get; set; }
        // public string? Season { get; set; }
        // public string? Category { get; set; }
    }
}