using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using virtualClosetApi.Services.Context;
using virtualClosetAPI.Models;

namespace virtualClosetAPI.Services
{
    public class OutfitService
    {
        private readonly DataContext _context;

        public OutfitService(DataContext dataFromContext)
        {
            _context = dataFromContext;
        }

        //Add - WORKS
        public bool AddOutfit(OutfitModel outfitToAdd)
        {
            _context.Add(outfitToAdd);
            return _context.SaveChanges() != null;
        }
        
        //Remove - Needs testing

        public bool RemoveOutfit(string outfitName)
        {
            var outfit = _context.OutfitInfo.SingleOrDefault(outfit => outfit.OutfitName == outfitName);

           _context.Remove(outfit);
           //saves changes then returns true or false based on success
           return _context.SaveChanges() != null;
        }
        
        

         public IEnumerable<OutfitModel> GetOutfitByUserId(int userId)
        {
            return _context.OutfitInfo.Where(outfit => outfit.UserId == userId);
        }

         public bool RemoveItemFromOutfit(int userId, int itemId)
        {      
            //find data first
            var foundItem = _context.OutfitInfo.Where(outfit => outfit.UserId == userId && outfit.ItemId == itemId);

            //remove found data
            _context.Remove(foundItem);
            return _context.SaveChanges() != null;
        }
        
    }
}
