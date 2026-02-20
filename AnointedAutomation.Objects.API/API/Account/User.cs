// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-01-16 19:19:01
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
//Created by Alexander Fields

// =============================================================================
// NAMING CONVENTION:
// This codebase follows a specific property naming pattern:
//   - Value types (structs): lowercase (e.g., bool success, int statusCode)
//   - Reference types (objects): PascalCase (e.g., string Message, object Data)
// =============================================================================

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AnointedAutomation.Objects.API.Account
{
    [System.Serializable]
    public class User
    {
        public User()
        { }

        public User(
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
        {
            this.banned = banned != default ? banned : new System.DateTime(1900, 1, 1);
            this.createdDate = createdDate != default ? createdDate : System.DateTime.Now;
            this.Email = email;
            this.emailConfirmed = emailConfirmed;
            this.IPAddresses = ipAddresses ?? new List<IPInfo>();
            this.lastActiveDate = lastActiveDate != default ? lastActiveDate : System.DateTime.Now;
            this.Password = password ?? throw new System.ArgumentNullException(nameof(password));
            this.Profile = profile ?? new Profile();
            this.Role = role;
            this.timeOnline = timeOnline;
            this.UserId = userId;
            this.Username = username;
            this.Token = token;
            this.tokenExpiration = tokenExpiration;
        }

        /// <summary>
        /// Datetime in which the ban is lifted (set this in the past if they're not banned)
        /// </summary>
        [DataMember]
        public System.DateTime banned { get; set; }

        [DataMember]
        public System.DateTime createdDate { get; set; }

        /// <summary>
        /// email serves as their login name
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public bool emailConfirmed { get; set; }

        [DataMember]
        public List<IPInfo> IPAddresses { get; set; }

        [DataMember]
        public System.DateTime lastActiveDate { get; set; }

        /// <summary>
        /// This will most likely be a big json
        /// </summary>
        [DataMember]
        public string Meta { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public Profile Profile { get; set; }

        [DataMember]
        public string Role { get; set; }

        [DataMember]
        public System.TimeSpan timeOnline { get; set; }

        [DataMember]
        public string Token { get; set; }

        [DataMember]
        public System.DateTime tokenExpiration { get; set; }

        /// <summary>
        /// unique userId generated when creating account
        /// </summary>
        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string Username { get; set; }
    }
}
