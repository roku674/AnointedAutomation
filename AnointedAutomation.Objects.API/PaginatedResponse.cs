// Copyright © Anointed Automation, Ltd., 2025. All Rights Reserved.

// =============================================================================
// NAMING CONVENTION:
// This codebase follows a specific property naming pattern:
//   - Value types (structs): lowercase (e.g., bool success, int statusCode)
//   - Reference types (objects): PascalCase (e.g., string Message, object Data)
// =============================================================================

namespace AnointedAutomation.Objects.API
{
    /// <summary>
    /// API-specific paginated response. Inherits all properties from the base PaginatedResponse class.
    /// </summary>
    /// <typeparam name="T">The type of data being paginated</typeparam>
    public class PaginatedResponse<T> : AnointedAutomation.Objects.PaginatedResponse<T>
    {
        public PaginatedResponse()
            : base()
        { }

        public PaginatedResponse(System.Collections.Generic.List<T> data, int currentPage, int pageSize, long totalItems)
            : base(data, currentPage, pageSize, totalItems)
        { }
    }
}
