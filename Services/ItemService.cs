using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using virtualClosetApi.Services.Context;
using virtualClosetAPI.Models;

namespace virtualClosetAPI.Services
{
    public class ItemService
    {

        private readonly DataContext _context;

        public ItemService(DataContext dataFromContext)
        {
            _context = dataFromContext;
        }

        //Add Item - WORKS
        public bool AddItem(ItemModel itemToAdd)
        {
            _context.Add(itemToAdd);
            return _context.SaveChanges() != null;
        }

        //Delete Item by Id - WORKS
        public bool RemoveItem(ItemModel itemToDelete)
        {
           _context.Remove(itemToDelete);
           return _context.SaveChanges() != null;
           
        }

        //Update Item by Id - WORKS
         public bool UpdateItemById(ItemModel updatedItem)
        {
            
            _context.Update<ItemModel>(updatedItem);

            return _context.SaveChanges() != null;

        }
    

        // get / display all items by userId - WORKS
        public IEnumerable<ItemModel> GetItemsByUserId(int userId)
        {
            return _context.ItemInfo.Where(item => item.UserId == userId);
        }

         public IEnumerable<ItemModel> GetFavorites(int userId, bool favorite){

            return _context.ItemInfo.Where(item => item.UserId == userId && item.Favorite == favorite);
        }

        //Get items by category/userId - WORKS
        public IEnumerable<ItemModel> GetItemsByCategory(string category, int userId)
        {
            return _context.ItemInfo.Where(item => item.Category == category && item.UserId == userId);
        }
        // Get specific item by id and UserId
        public IEnumerable<ItemModel> GetItemsById(int id, int userId){
            return _context.ItemInfo.Where(item => item.Id == id && item.UserId == userId);
        }
        //Get items by Season/UserId - WORKS
        public IEnumerable<ItemModel> GetItemsBySeason(string season, int userId)
        {
            return _context.ItemInfo.Where(item => item.Season == season && item.UserId == userId);
        }

        
    }
}