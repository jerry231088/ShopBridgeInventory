using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridgeInventory.Abstraction;
using ShopBridgeInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopBridgeInventory.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private IInventoryData _inventory;

        public InventoryController(IInventoryData inventory)
        {
            _inventory = inventory;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllInventoryItems()
        {
            List<Inventory> itemList = _inventory.GetAllInventoryItems();
            if(itemList.Count() > 0)
                return Ok(itemList);
            else return NotFound($"No inventory item found.");
        }

        [HttpGet]
        [Route("api/[controller]/{itemId}")]
        public IActionResult GetInventoryItem(Guid itemId)
        {
            Inventory inventoryItem = _inventory.GetInventoryItem(itemId);
            if (inventoryItem != null)
                return Ok(inventoryItem);
            else 
                return NotFound($"Inventory item with id: {itemId} not found.");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddInventoryItem(Inventory item)
        {
            _inventory.AddInventoryItem(item);
            return Created(HttpContext.Request.Scheme + "://" +HttpContext.Request.Host 
                + HttpContext.Request.Path + "/" + item.ItemId, item);
        }

        [HttpPatch]
        [Route("api/[controller]/{itemId}")]
        public IActionResult UpdateInventoryItem(Guid itemId, Inventory item)
        {
            Inventory existingItem = _inventory.GetInventoryItem(itemId);

            if (existingItem != null)
            {
                if(item.Name != null && existingItem.Name != item.Name)
                    existingItem.Name = item.Name;
                if (item.Price > 0 && existingItem.Price != item.Price)
                    existingItem.Price = item.Price;
                if (item.MfgDate != null && existingItem.MfgDate != item.MfgDate)
                    existingItem.MfgDate = item.MfgDate;
                if (item.ExpiryDate != null && existingItem.ExpiryDate != item.ExpiryDate)
                    existingItem.ExpiryDate = item.ExpiryDate;
                if (item.Description != null && existingItem.Description != item.Description)
                    existingItem.Description = item.Description;
                _inventory.UpdateInventoryItem(existingItem);
                return Ok(existingItem);
            }
            return NotFound($"Inventory item with id: {itemId} not found.");
        }

        [HttpDelete]
        [Route("api/[controller]/{itemId}")]
        public IActionResult DeleteInventoryItem(Guid itemId)
        {
            Inventory inventoryItem = _inventory.GetInventoryItem(itemId);

            if (inventoryItem != null)
            {
                _inventory.DeleteInventoryItem(inventoryItem);
                return Ok();
            }
            return NotFound($"Inventory item with id: {itemId} not found.");
        }
    }
}
