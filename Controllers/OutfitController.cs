using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using virtualClosetAPI.Models;
using virtualClosetAPI.Services;

namespace virtualClosetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OutfitController : ControllerBase
    {
        private readonly OutfitService data;
        public OutfitController(OutfitService dataFromService)
        {
            data = dataFromService;
        }

        //Add - WORKS

        [HttpPost("AddOutfit")]

       public bool AddOutfit(OutfitModel outfitToAdd)
        {
            return data.AddOutfit(outfitToAdd);
        }

       //Remove single item from outfit - WORKS
        [HttpPost("Remove/{id}")]
         public bool RemoveItemFromOutfit(int id)
        {
            return data.RemoveItemFromOutfit(id);
        }

          // Remove all items with same outfitname - WORKS
        [HttpPost("RemoveOutfit/{userId}/{outfitName}")]

         public bool RemoveOutfit(int userId, string? outfitName)
        {
            return data.RemoveOutfit(userId, outfitName);
        }


        //Get Outfit by userId - WORKS
        [HttpGet("GetOutfitByUserId/{UserId}")]

        public IEnumerable<OutfitModel> GetOutfitByUserId(int UserId)
        {
            return data.GetOutfitByUserId(UserId);
        }

        //Get Outfits by userId & OutfitName - WORKS
         [HttpGet("GetOutfits/{userId}/{outfitName}")]
         public IEnumerable<OutfitModel> GetOutfits(int userId, string? outfitName)
         {
             return data.GetOutFits(userId,outfitName);
         }

    


        
    }
}