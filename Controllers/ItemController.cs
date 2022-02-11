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
    public class ItemController : ControllerBase
    {
        private readonly ItemService data;

        public ItemController(ItemService dataFromService)
        {
            data = dataFromService;
        }

        //Add items - WORKS
        [HttpPost("AddItem")]
        public bool AddItem(ItemModel itemToAdd)
        {
            return data.AddItem(itemToAdd);
        }
        //Remove - WORKS 
        [HttpPost("Remove")]
        public bool RemoveItem(ItemModel itemToDelete)
        {
            return data.RemoveItem(itemToDelete);
        }

        //Edit items - WORKS
        [HttpPost("UpdateItemById")]
        
        public bool UpdateItemById(ItemModel updatedItem)
        {
            return data.UpdateItemById(updatedItem);
        }

        //Get items by userId - needs testing
        [HttpPost("GetItemsByUserId")]
        public IEnumerable<ItemModel> GetItemsByUserId(int userId)
        {
            return data.GetItemsByUserId(userId);
        }

        //Sort by Category - Needs testing
        [HttpGet("GetItemsByCategory/{category}")]
        
        public IEnumerable<ItemModel> GetItemsByCategory(string category)
        {
            return data.GetItemsByCategory(category);
        }

        // Sort by Season - Needs testing
        [HttpPost("GetItemsBySeason/{season}")]

         public IEnumerable<ItemModel> GetItemsBySeason(string season){
            return data.GetItemsBySeason(season);
        }

        //get item by iD


    }
}