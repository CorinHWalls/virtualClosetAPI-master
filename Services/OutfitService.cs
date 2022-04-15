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

        //check if outfitName Exists

        public bool DoesOutfitExist(string? outfitName)
        {
            return _context.OutfitInfo.SingleOrDefault(outfit => outfit.OutfitName.ToLower() == outfitName.ToLower()) != null;
        }

        //Add - WORKS
        public bool AddOutfit(OutfitModel outfitToAdd)
        {
            var result = false;
            if (!DoesOutfitExist(outfitToAdd.OutfitName))
            {
                _context.Add(outfitToAdd);
                result = _context.SaveChanges() != null;

            }
            return result;
        }

        //Remove single item from Outfit - WORKS
        public bool RemoveItemFromOutfit(int id)
        {
            var outfit = _context.OutfitInfo.SingleOrDefault(outfit => outfit.Id == id);

            _context.Remove(outfit);
            //saves changes then returns true or false based on success
            return _context.SaveChanges() != null;
        }


        //Get all outfits by userId - WORKS
        public IEnumerable<OutfitModel> GetOutfitByUserId(int UserId)
        {
            return _context.OutfitInfo.Where(outfit => outfit.UserId == UserId);
        }
        //Get Outfits by userId & OutfitName - WORKS
        public IEnumerable<OutfitModel> GetOutFits(int UserId, string? outfitName)
        {
            return _context.OutfitInfo.Where(fit => fit.UserId == UserId && fit.OutfitName == outfitName);
        }

        // Remove all items with same outfitname - WORKS
        public bool RemoveOutfit(int userId, string? outfitName)
        {
            //find data first
            var foundItem = _context.OutfitInfo.Where(outfit => outfit.UserId == userId && outfit.OutfitName == outfitName);

            foreach (Object i in foundItem)
            {
                //remove found data
                _context.Remove(i);

            }
            return _context.SaveChanges() != null;
        }

    }
}
