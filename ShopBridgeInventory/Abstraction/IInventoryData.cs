using ShopBridgeInventory.Models;
using System;
using System.Collections.Generic;

namespace ShopBridgeInventory.Abstraction
{
    public interface IInventoryData
    {
        Inventory AddInventoryItem(Inventory item);

        Inventory UpdateInventoryItem(Inventory item);

        void DeleteInventoryItem(Inventory item);

        List<Inventory> GetAllInventoryItems();

        Inventory GetInventoryItem(Guid itemId);
    }
}
