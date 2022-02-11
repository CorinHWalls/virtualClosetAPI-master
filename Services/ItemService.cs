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
        public bool AddItem(ItemModel itemToAdd)
        {
            _context.Add(itemToAdd);
            return _context.SaveChanges() != null;
        }

        //Delete Item by Id - WORKS
        public bool RemoveItem(ItemModel itemToDelete)
        {
            // find data
            // var data = _context.ItemInfo.FirstOrDefault(item => item.Id == id);

            // if(data != null) {
            //     _context.ItemInfo.Remove(data);
            //     _context.SaveChanges();
            //     return _context.SaveChanges() != null;
            // }
            // else{
            //     return false;
            // }
           _context.Remove(itemToDelete);
           return _context.SaveChanges() != null;
           
        }

        //Update Item by Id 
         public bool UpdateItemById(ItemModel updatedItem)
        {
            
            _context.Update<ItemModel>(updatedItem);

            return _context.SaveChanges() != null;

        }

        public IEnumerable<ItemModel> GetItemsByCategory(string category)
        {
            return _context.ItemInfo.Where(item => item.Category == category);
        }

        public IEnumerable<ItemModel> GetItemsBySeason(string season)
        {
            return _context.ItemInfo.Where(item => item.Season == season);
        }

        public IEnumerable<ItemModel> GetItemsByUserId(int userId)
        {
            return _context.ItemInfo.Where(item => item.UserId == userId);
        }
    }
}