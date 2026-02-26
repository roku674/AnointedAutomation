// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-01-16 19:19:01
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25

// =============================================================================
// NAMING CONVENTION:
// This codebase follows a specific property naming pattern:
//   - Value types (structs): lowercase (e.g., bool success, int statusCode)
//   - Reference types (objects): PascalCase (e.g., string Message, object Data)
// =============================================================================

using BaseBill = AnointedAutomation.Objects.Billing.Bill;

namespace AnointedAutomation.Objects.API.Billing
{
    /// <summary>
    /// API-specific bill class. Inherits all properties from the base Bill class.
    /// </summary>
    public class Bill : BaseBill
    {
        public Bill()
            : base()
        { }

        public Bill(string userId, AnointedAutomation.Objects.Billing.Address addressBilling, System.Collections.Generic.List<string> orders, AnointedAutomation.Objects.Billing.PaymentCredentials paymentTypes, System.Collections.Generic.List<AnointedAutomation.Objects.Billing.Purchase> purchases, System.Collections.Generic.List<AnointedAutomation.Objects.Billing.Purchase> refunds, System.Collections.Generic.List<AnointedAutomation.Objects.Billing.Subscription> subscriptions)
            : base(userId, addressBilling, orders, paymentTypes, purchases, refunds, subscriptions)
        { }
    }
}
