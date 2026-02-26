// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-01-16 19:19:01
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
//Created by Alexander Fields

// =============================================================================
// NAMING CONVENTION:
// This codebase follows a specific property naming pattern:
//   - Value types (structs): lowercase (e.g., bool success, int statusCode)
//   - Reference types (objects): PascalCase (e.g., string Message, object Data)
// =============================================================================

using BaseSubscription = AnointedAutomation.Objects.Billing.Subscription;

namespace AnointedAutomation.Objects.API.Billing
{
    /// <summary>
    /// API-specific subscription class. Inherits all properties from the base Subscription class.
    /// </summary>
    [System.Serializable]
    public class Subscription : BaseSubscription
    {
        public Subscription()
            : base()
        { }

        public Subscription(AnointedAutomation.Objects.Billing.Address billing, AnointedAutomation.Objects.Billing.Address shipping, bool billedMonthly, bool billedYearly, string company, decimal donation, bool isRefund, bool isActive, bool isRecurring, AnointedAutomation.Objects.Billing.Product item,
            AnointedAutomation.Enums.PaymentType paymentType, AnointedAutomation.Objects.Billing.Contact purchaser, System.DateTime renewalTime, string taxLocation, decimal taxPercentage, System.DateTime time, decimal tip, string typeOfSubscription)
            : base(billing, shipping, billedMonthly, billedYearly, company, donation, isRefund, isActive, isRecurring, item, paymentType, purchaser, renewalTime, taxLocation, taxPercentage, time, tip, typeOfSubscription)
        { }
    }
}
