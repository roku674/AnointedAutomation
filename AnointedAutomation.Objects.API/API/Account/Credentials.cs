// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-01-16 19:19:01
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
//Created by Alexander Fields

// =============================================================================
// NAMING CONVENTION:
// This codebase follows a specific property naming pattern:
//   - Value types (structs): lowercase (e.g., bool success, int statusCode)
//   - Reference types (objects): PascalCase (e.g., string Message, object Data)
// =============================================================================

namespace AnointedAutomation.Objects.API.Account
{
    public class Credentials
    {
        public Credentials()
        {
        }

        public Credentials(string email, string password, string token, string googleToken)
        {
            this.Email = email ?? throw new System.ArgumentNullException(nameof(email));
            this.Password = password ?? throw new System.ArgumentNullException(nameof(password));
            this.Token = token;
            this.GoogleToken = googleToken;
        }

        public string Email { get; set; }
        public string GoogleToken { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
