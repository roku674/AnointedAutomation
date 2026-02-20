// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me

using AnointedAutomation.Objects.Account;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace AnointedAutomation.Objects.Mongo.Account
{
    /// <summary>
    /// MongoDB-specific user class that adds BSON serialization attributes.
    /// Inherits from <see cref="User"/> and marks <see cref="UserId"/> as the BSON document ID.
    /// </summary>
    [BsonIgnoreExtraElements]
    [System.Serializable]
    public class MongoUser : User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoUser"/> class.
        /// </summary>
        public MongoUser()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoUser"/> class with specified properties.
        /// </summary>
        /// <param name="banned">Date when the ban is lifted.</param>
        /// <param name="createdDate">Date when the user account was created.</param>
        /// <param name="email">User's email address used for login.</param>
        /// <param name="emailConfirmed">Whether the email has been confirmed.</param>
        /// <param name="ipAddresses">List of IP addresses associated with this user.</param>
        /// <param name="lastActiveDate">Date of last user activity.</param>
        /// <param name="password">User's password.</param>
        /// <param name="profile">User's profile information.</param>
        /// <param name="role">User's role in the system.</param>
        /// <param name="timeOnline">Total time user has spent online.</param>
        /// <param name="userId">Unique identifier for the user.</param>
        /// <param name="username">User's display name.</param>
        /// <param name="token">Authentication token.</param>
        /// <param name="tokenExpiration">Expiration date of the authentication token.</param>
        public MongoUser(
            System.DateTime banned,
            System.DateTime createdDate,
            string email,
            bool emailConfirmed,
            List<IPInfo> ipAddresses,
            System.DateTime lastActiveDate,
            string password,
            Profile profile,
            string role,
            System.TimeSpan timeOnline,
            string userId,
            string username,
            string token,
            System.DateTime tokenExpiration
        )
            : base(banned, createdDate, email, emailConfirmed, ipAddresses, lastActiveDate, password, profile, role, timeOnline, userId, username, token, tokenExpiration)
        { }

        /// <summary>
        /// Unique identifier for the user. Marked as the BSON document ID.
        /// </summary>
        [BsonId]
        public new string UserId
        {
            get { return base.UserId; }
            set { base.UserId = value; }
        }
    }
}
