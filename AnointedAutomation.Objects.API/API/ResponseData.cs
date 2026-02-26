// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-10-12 14:24:21
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
//Created by Alexander Fields

// =============================================================================
// NAMING CONVENTION:
// This codebase follows a specific property naming pattern:
//   - Value types (structs): lowercase (e.g., bool success, int statusCode)
//   - Reference types (objects): PascalCase (e.g., string Message, object Data)
// =============================================================================

using BaseResponseData = AnointedAutomation.Objects.ResponseData;

namespace AnointedAutomation.Objects.API
{
    /// <summary>
    /// API-specific response class. Inherits all properties from the base ResponseData class.
    /// </summary>
    public class ResponseData : BaseResponseData
    {
        public ResponseData()
            : base()
        { }

        public ResponseData(string message, object data, object error)
            : base(message, data, error)
        { }
    }

    /// <summary>
    /// API-specific generic response class. Inherits all properties from the base ResponseData&lt;T&gt; class.
    /// </summary>
    /// <typeparam name="T">The type of data being returned.</typeparam>
    public class ResponseData<T> : AnointedAutomation.Objects.ResponseData<T>
    {
    }
}
