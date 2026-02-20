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

namespace AnointedAutomation.Objects.API.Account
{
    public class IPInfo
    {
        public IPInfo()
        {
        }

        public IPInfo(System.DateTime firstLogin, string ipAddress, System.DateTime lastLogin, ulong loginCount, System.TimeSpan timeOnline)
        {
            this.firstLogin = firstLogin;
            this.IpAddress = ipAddress;
            this.lastLogin = lastLogin;
            this.loginCount = loginCount;
            this.timeOnline = default;
        }

        [DataMember]
        public System.DateTime firstLogin { get; set; }

        [DataMember]
        public string IpAddress { get; set; }

        [DataMember]
        public System.DateTime lastLogin { get; set; }

        /// <summary>
        /// amount of times the ip as logged in
        /// </summary>
        [DataMember]
        public ulong loginCount { get; set; }

        [DataMember]
        public System.TimeSpan timeOnline { get; set; }
    }
}
