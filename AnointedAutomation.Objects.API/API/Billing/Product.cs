// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-01-16 19:19:01
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
//Created by Alexander Fields

// =============================================================================
// NAMING CONVENTION:
// This codebase follows a specific property naming pattern:
//   - Value types (structs): lowercase (e.g., bool success, int statusCode)
//   - Reference types (objects): PascalCase (e.g., string Message, object Data)
// =============================================================================

using BaseProduct = AnointedAutomation.Objects.Billing.Product;

namespace AnointedAutomation.Objects.API.Billing
{
    /// <summary>
    /// API-specific product class. Inherits all properties from the base Product class.
    /// </summary>
    public class Product : BaseProduct
    {
        public Product()
            : base()
        { }

        public Product(string name, decimal cost, string currency, decimal price, string productId, int quantitySold)
            : base(name, cost, currency, price, productId, quantitySold)
        { }
    }
}
