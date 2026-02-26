// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-01-16 19:19:01
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
//Created by Alexander Fields

// =============================================================================
// NAMING CONVENTION:
// This codebase follows a specific property naming pattern:
//   - Value types (structs): lowercase (e.g., bool success, int statusCode)
//   - Reference types (objects): PascalCase (e.g., string Message, object Data)
// =============================================================================

using BasePurchase = AnointedAutomation.Objects.Billing.Purchase;

namespace AnointedAutomation.Objects.API.Billing
{
    /// <summary>
    /// API-specific purchase class. Inherits all properties from the base Purchase class.
    /// </summary>
    [System.Serializable]
    public class Purchase : BasePurchase
    {
        public Purchase()
            : base()
        { }

        public Purchase(AnointedAutomation.Objects.Billing.Address billing, AnointedAutomation.Objects.Billing.Address shipping, string company, decimal discount, decimal discountPerc, decimal donation, bool isRefund, AnointedAutomation.Objects.Billing.Product item,
            AnointedAutomation.Enums.PaymentType paymentType, AnointedAutomation.Objects.Billing.Contact purchaser, string taxLocation, decimal taxPercentage, System.DateTime time, decimal tip)
            : base(billing, shipping, company, discount, discountPerc, donation, isRefund, item, paymentType, purchaser, taxLocation, taxPercentage, time, tip)
        { }
    }
}
