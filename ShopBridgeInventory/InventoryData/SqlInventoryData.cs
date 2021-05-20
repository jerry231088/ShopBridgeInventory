using ShopBridgeInventory.Abstraction;
using ShopBridgeInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopBridgeInventory.InventoryData
{
    public class SqlInventoryData : IInventoryData
    {
        private InventoryContext _inventoryCtx;
        public SqlInventoryData(InventoryContext inventoryCtx)
        {
            _inventoryCtx = inventoryCtx;
        }
        Inventory IInventoryData.AddInventoryItem(Inventory item)
        {
            item.ItemId = Guid.NewGuid();
            _inventoryCtx.Inventories.Add(item);
            _inventoryCtx.SaveChanges();
            return item;
        }

        void IInventoryData.DeleteInventoryItem(Inventory item)
        {
            _inventoryCtx.Inventories.Remove(item);
            _inventoryCtx.SaveChanges();
        }

        List<Inventory> IInventoryData.GetAllInventoryItems()
        {
            List<Inventory> inventoryList = new List<Inventory>();
            if (_inventoryCtx.Inventories != null && _inventoryCtx.Inventories.Count() > 0)
                inventoryList.AddRange(_inventoryCtx.Inventories.ToList());
            return inventoryList;
        }

        Inventory IInventoryData.GetInventoryItem(Guid itemId)
        {
            Inventory inventoryItem = _inventoryCtx.Inventories.Find(itemId);
            return inventoryItem;
        }

        Inventory IInventoryData.UpdateInventoryItem(Inventory item)
        {
            _inventoryCtx.Inventories.Update(item);
            _inventoryCtx.SaveChanges();
            return item;
        }
    }
}
