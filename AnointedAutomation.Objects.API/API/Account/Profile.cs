// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-01-16 19:19:01
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
//Created by Alexander Fields

// =============================================================================
// NAMING CONVENTION:
// This codebase follows a specific property naming pattern:
//   - Value types (structs): lowercase (e.g., bool success, int statusCode)
//   - Reference types (objects): PascalCase (e.g., string Message, object Data)
// =============================================================================

using AnointedAutomation.Objects.API.Billing;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Linq;

namespace AnointedAutomation.Objects.API.Account
{
    [BsonIgnoreExtraElements]
    public class Profile : Contact
    {
        public Profile()
        { }

        public Profile(
            JObject accountSettings,
            System.DateTime dob,
            string firstName,
            string lastName,
            string middleName,
            ulong number
        )
            : base(dob, firstName, lastName, middleName, number)
        {
            this.AccountSettings = accountSettings;
        }

        [BsonSerializer(typeof(JObjectSerializer))]
        public JObject AccountSettings { get; set; }
    }
}
