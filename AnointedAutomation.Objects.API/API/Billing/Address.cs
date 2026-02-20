// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-01-16 19:19:01
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
//Created by Alexander Fields

// =============================================================================
// NAMING CONVENTION:
// This codebase follows a specific property naming pattern:
//   - Value types (structs): lowercase (e.g., bool success, int statusCode)
//   - Reference types (objects): PascalCase (e.g., string Message, object Data)
// =============================================================================

using System.Runtime.Serialization;

namespace AnointedAutomation.Objects.API.Billing
{
    [System.Serializable]
    public class Address
    {
        public Address()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="city">!nullable</param>
        /// <param name="country">!nullable</param>
        /// <param name="name"></param>
        /// <param name="contact">!nullable</param>
        /// <param name="state">!nullable</param>
        /// <param name="street">!nullable</param>
        /// <param name="zip"></param>
        public Address(string city, string country, string name, Contact contact, string state, string street, int zip)
        {
            this.City = city ?? throw new System.ArgumentNullException(nameof(city));
            this.Country = country ?? throw new System.ArgumentNullException(nameof(country));
            this.Name = name;
            this.Contact = contact ?? throw new System.ArgumentNullException(nameof(contact));
            this.State = state ?? throw new System.ArgumentNullException(nameof(state));
            this.Street = street ?? throw new System.ArgumentNullException(nameof(street));
            this.zip = zip;
        }

        /// <summary>
        /// Do they put on for their...
        /// </summary>
        [DataMember]
        public string City { get; set; }

        [DataMember]
        public Contact Contact { get; set; }

        /// <summary>
        /// Their Country/State (not to be confused with individual states in U.S.)
        /// </summary>
        [DataMember]
        public string Country { get; set; }

        /// <summary>
        /// This isn't required if sending to a person
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// State/Province
        /// </summary>
        [DataMember]
        public string State { get; set; }

        /// <summary>
        /// street address
        /// </summary>
        [DataMember]
        public string Street { get; set; }

        /// <summary>
        /// zip code
        /// </summary>
        [DataMember]
        public int zip { get; set; }
    }
}
