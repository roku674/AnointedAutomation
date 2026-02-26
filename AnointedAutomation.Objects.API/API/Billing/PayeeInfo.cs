// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-01-16 19:19:01
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
//Created by Alexander Fields

// =============================================================================
// NAMING CONVENTION:
// This codebase follows a specific property naming pattern:
//   - Value types (structs): lowercase (e.g., bool success, int statusCode)
//   - Reference types (objects): PascalCase (e.g., string Message, object Data)
// =============================================================================

using BasePayeeInfo = AnointedAutomation.Objects.Billing.PayeeInfo;

namespace AnointedAutomation.Objects.API.Billing
{
    /// <summary>
    /// API-specific payee info class. Inherits all properties from the base PayeeInfo class.
    /// </summary>
    public class PayeeInfo : BasePayeeInfo
    {
        public PayeeInfo()
            : base()
        { }

        public PayeeInfo(string clientId, string email, string merchantId)
            : base(clientId, email, merchantId)
        { }
    }
}
