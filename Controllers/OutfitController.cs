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

        //Remove entire outfit - Needs testing
        [HttpPost("Remove")]
         public bool RemoveOutfit(string outfitName)
        {
            return data.RemoveOutfit(outfitName);
        }

        //Remove single item from Outfit - Needs testing
        [HttpGet("RemoveItemFromOutfit/{userId}/{itemId}")]

         public bool RemoveItemFromOutfit(int userId, int itemId)
        {
            return data.RemoveItemFromOutfit(userId, itemId);
        }


        //Get Outfit by userId - Needs testing
        [HttpGet("GetOutfitByUserId/{userId}")]

        public IEnumerable<OutfitModel> GetOutfitByUserId(int userId)
        {
            return data.GetOutfitByUserId(userId);
        }

    


        
    }
}