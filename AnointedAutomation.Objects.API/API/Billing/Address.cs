// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-01-16 19:19:01
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
//Created by Alexander Fields

// =============================================================================
// NAMING CONVENTION:
// This codebase follows a specific property naming pattern:
//   - Value types (structs): lowercase (e.g., bool success, int statusCode)
//   - Reference types (objects): PascalCase (e.g., string Message, object Data)
// =============================================================================

using BaseAddress = AnointedAutomation.Objects.Billing.Address;

namespace AnointedAutomation.Objects.API.Billing
{
    /// <summary>
    /// API-specific address class. Inherits all properties from the base Address class.
    /// </summary>
    [System.Serializable]
    public class Address : BaseAddress
    {
        public Address()
            : base()
        { }

        public Address(string city, string country, string name, AnointedAutomation.Objects.Billing.Contact contact, string state, string street, int zip)
            : base(city, country, name, contact, state, street, zip)
        { }
    }
}
