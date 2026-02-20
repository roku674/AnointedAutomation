// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me

using AnointedAutomation.Objects.Account;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Linq;

namespace AnointedAutomation.Objects.Mongo.Account
{
    /// <summary>
    /// MongoDB-specific profile class that adds BSON serialization attributes.
    /// Inherits from <see cref="Profile"/> and adds MongoDB-specific serialization for JObject properties.
    /// </summary>
    [BsonIgnoreExtraElements]
    [System.Serializable]
    public class MongoProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoProfile"/> class.
        /// </summary>
        public MongoProfile()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoProfile"/> class with specified properties.
        /// </summary>
        /// <param name="accountSetting">JSON object containing user account settings.</param>
        /// <param name="dob">Date of birth.</param>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="middleName">Middle name.</param>
        /// <param name="number">Contact number.</param>
        public MongoProfile(
            JObject accountSetting,
            System.DateTime dob,
            string firstName,
            string lastName,
            string middleName,
            ulong number
        )
            : base(accountSetting, dob, firstName, lastName, middleName, number)
        { }

        /// <summary>
        /// Gets or sets the JSON object containing user account settings.
        /// Uses a custom BSON serializer for JObject to MongoDB conversion.
        /// </summary>
        [BsonSerializer(typeof(JObjectSerializer))]
        public new JObject AccountSettings
        {
            get { return base.AccountSettings; }
            set { base.AccountSettings = value; }
        }
    }
}
