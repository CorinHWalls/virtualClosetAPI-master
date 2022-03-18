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

        //Get items by userId - WORKS & in use
        [HttpGet("GetItemsByUserId/{userId}")]
        public IEnumerable<ItemModel> GetItemsByUserId(int userId)
        {
            return data.GetItemsByUserId(userId);
        }

        //Sort by Category - WORKS and in use
        [HttpGet("GetItemsByCategory/{category}/{userId}")]
        
        public IEnumerable<ItemModel> GetItemsByCategory(string category, int userId)
        {
            return data.GetItemsByCategory(category, userId);
        }

        // Sort by Season - WORKS
        [HttpGet("GetItemsBySeason/{season}/{userId}")]

         public IEnumerable<ItemModel> GetItemsBySeason(string season, int userId){
            return data.GetItemsBySeason(season, userId);
        }

        // Get specific item by id and UserId
        [HttpGet("GetItemById/{id}/{userId}")]
        public IEnumerable<ItemModel> GetItemsById(int id, int userId){
            return data.GetItemsById(id, userId);
        }
        [HttpGet("GetFavorites/{userId}/{favorite}")]
        public IEnumerable<ItemModel> GetFavorites(int userId, bool favorite){

            return data.GetFavorites(userId, favorite);
        }


    }
}