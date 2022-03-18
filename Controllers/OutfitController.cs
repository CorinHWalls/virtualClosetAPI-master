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

        //Add - Needs testing

        [HttpPost("AddOutfit")]

       public bool AddOutfit(OutfitModel outfitToAdd)
        {
            return data.AddOutfit(outfitToAdd);
        }

        //Remove entire outfit - Needs testing
        [HttpPost("Remove")]
         public bool RemoveOutfit(OutfitModel id)
        {
            return data.RemoveOutfit(id);
        }

        //Remove single item from Outfit - Needs testing
        [HttpPost("RemoveItemFromOutfit")]

         public bool RemoveItemFromOutfit(int userId, int itemId)
        {
            return data.RemoveItemFromOutfit(userId, itemId);
        }


        //Get Outfit by userId - Needs testing
        [HttpPost("GetOutfitByUserId/{userId}")]

        public IEnumerable<OutfitModel> GetOutfitByUserId(int userId)
        {
            return data.GetOutfitByUserId(userId);
        }

    


        
    }
}