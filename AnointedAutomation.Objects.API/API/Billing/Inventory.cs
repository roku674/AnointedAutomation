// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-01-16 19:19:01
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
//Created by Alexander Fields

// =============================================================================
// NAMING CONVENTION:
// This codebase follows a specific property naming pattern:
//   - Value types (structs): lowercase (e.g., bool success, int statusCode)
//   - Reference types (objects): PascalCase (e.g., string Message, object Data)
// =============================================================================

using BaseInventory = AnointedAutomation.Objects.Billing.Inventory;

namespace AnointedAutomation.Objects.API.Billing
{
    /// <summary>
    /// API-specific inventory class. Inherits all properties from the base Inventory class.
    /// </summary>
    public class Inventory : BaseInventory
    {
        public Inventory()
            : base()
        { }

        public Inventory(string UID, string reorder, string itemNo, string name, string manufacturer, string supplier, string description, decimal costPerItem,
            int stockQuantity, string inventoryValue, int reorderLevel, int daysPerReorder, int itemReorderQuantity, bool itemDiscontinued)
            : base(UID, reorder, itemNo, name, manufacturer, supplier, description, costPerItem, stockQuantity, inventoryValue, reorderLevel, daysPerReorder, itemReorderQuantity, itemDiscontinued)
        { }
    }
}
