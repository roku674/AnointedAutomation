// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-01-16 19:19:01
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
//Created by Alexander Fields

// =============================================================================
// NAMING CONVENTION:
// This codebase follows a specific property naming pattern:
//   - Value types (structs): lowercase (e.g., bool success, int statusCode)
//   - Reference types (objects): PascalCase (e.g., string Message, object Data)
// =============================================================================

using BasePaymentCredentials = AnointedAutomation.Objects.Billing.PaymentCredentials;

namespace AnointedAutomation.Objects.API.Billing
{
    /// <summary>
    /// API-specific payment credentials class. Inherits all properties from the base PaymentCredentials class.
    /// </summary>
    public class PaymentCredentials : BasePaymentCredentials
    {
        public PaymentCredentials()
            : base()
        { }

        public PaymentCredentials(AnointedAutomation.Enums.PaymentType paymentType)
            : base(paymentType)
        { }
    }
}
