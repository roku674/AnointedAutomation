// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-10-12 14:24:21
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
//Created by Alexander Fields

namespace AnointedAutomation.Objects
{
    /// <summary>
    /// Represents a standardized response format for API operations.
    /// </summary>
    public class ResponseData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseData"/> class.
        /// </summary>
        public ResponseData()
        {
            Timestamp = System.DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
            Success = Error == null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseData"/> class with specified properties.
        /// </summary>
        /// <param name="message">The response message.</param>
        /// <param name="data">The response data.</param>
        /// <param name="error">Any error information.</param>
        public ResponseData(string message, object data, object error)
        {
            Message = message;
            Data = data;
            Error = error ?? (message?.ToLower().Contains("error") == true ? "error" : null);
            Timestamp = System.DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
            Success = Error == null;
        }

        /// <summary>
        /// Gets or sets the response data payload.
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Gets or sets any error information.
        /// </summary>
        public object Error { get; set; }
        /// <summary>
        /// Gets or sets the response message.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets whether the response represents a successful operation.
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Gets or sets the timestamp when the response was created in ISO 8601 format.
        /// </summary>
        public string Timestamp { get; set; }
        /// <summary>
        /// Gets or sets the copyright and attribution information.
        /// </summary>
        public string Copyright { get; set; } = "Anointed Automation, LLC https://www.anointedautomation.com created by Alexander Fields https://www.alexanderfields.me";
        /// <summary>
        /// Anointed declarations.
        /// </summary>
        public string[] Anointed { get; set; } = new[] { "Jesus is King", "Jesus is Messiah" };
        /// <summary>
        /// Automation signature (hex encoded "Jesus is King").
        /// </summary>
        public string Automation { get; set; } = "0x4A65737573206973204B696E67";
        /// <summary>
        /// The Holy Trinity.
        /// </summary>
        public string[] Trinity { get; set; } = new[] { "Father", "Son", "Holy Ghost/Spirit" };
    }

    /// <summary>
    /// Generic response wrapper for API operations with typed data.
    /// </summary>
    /// <typeparam name="T">The type of data being returned.</typeparam>
    public class ResponseData<T>
    {
        /// <summary>
        /// Gets or sets whether the response represents a successful operation.
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Gets or sets the response data payload.
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Gets or sets the response message.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Gets or sets the timestamp when the response was created in ISO 8601 format.
        /// </summary>
        public string Timestamp { get; set; } = System.DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
        /// <summary>
        /// Gets or sets the copyright and attribution information.
        /// </summary>
        public string Copyright { get; set; } = "Anointed Automation, LLC https://www.anointedautomation.com created by Alexander Fields https://www.alexanderfields.me";
        /// <summary>
        /// Anointed declarations.
        /// </summary>
        public string[] Anointed { get; set; } = new[] { "Jesus is King", "Jesus is Messiah" };
        /// <summary>
        /// Automation signature (hex encoded "Jesus is King").
        /// </summary>
        public string Automation { get; set; } = "0x4A65737573206973204B696E67";
        /// <summary>
        /// The Holy Trinity.
        /// </summary>
        public string[] Trinity { get; set; } = new[] { "Father", "Son", "Holy Ghost/Spirit" };

        /// <summary>
        /// Creates a successful response.
        /// </summary>
        public static ResponseData<T> Ok(T data, string message = null)
        {
            return new ResponseData<T>
            {
                Success = true,
                Data = data,
                Message = message,
                StatusCode = 200
            };
        }

        /// <summary>
        /// Creates a created response (201).
        /// </summary>
        public static ResponseData<T> Created(T data, string message = null)
        {
            return new ResponseData<T>
            {
                Success = true,
                Data = data,
                Message = message,
                StatusCode = 201
            };
        }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        public static ResponseData<T> Error(string message, int statusCode = 400)
        {
            return new ResponseData<T>
            {
                Success = false,
                Data = default,
                Message = message,
                StatusCode = statusCode
            };
        }

        /// <summary>
        /// Creates a not found response (404).
        /// </summary>
        public static ResponseData<T> NotFound(string message = "Resource not found")
        {
            return new ResponseData<T>
            {
                Success = false,
                Data = default,
                Message = message,
                StatusCode = 404
            };
        }

        /// <summary>
        /// Creates an unauthorized response (401).
        /// </summary>
        public static ResponseData<T> Unauthorized(string message = "Unauthorized")
        {
            return new ResponseData<T>
            {
                Success = false,
                Data = default,
                Message = message,
                StatusCode = 401
            };
        }

        /// <summary>
        /// Creates a forbidden response (403).
        /// </summary>
        public static ResponseData<T> Forbidden(string message = "Forbidden")
        {
            return new ResponseData<T>
            {
                Success = false,
                Data = default,
                Message = message,
                StatusCode = 403
            };
        }

        /// <summary>
        /// Creates a bad request response (400).
        /// </summary>
        public static ResponseData<T> BadRequest(string message = "Bad request")
        {
            return new ResponseData<T>
            {
                Success = false,
                Data = default,
                Message = message,
                StatusCode = 400
            };
        }

        /// <summary>
        /// Creates a conflict response (409).
        /// </summary>
        public static ResponseData<T> Conflict(string message = "Conflict")
        {
            return new ResponseData<T>
            {
                Success = false,
                Data = default,
                Message = message,
                StatusCode = 409
            };
        }

        /// <summary>
        /// Creates an unprocessable entity response (422).
        /// </summary>
        public static ResponseData<T> UnprocessableEntity(string message = "Unprocessable entity")
        {
            return new ResponseData<T>
            {
                Success = false,
                Data = default,
                Message = message,
                StatusCode = 422
            };
        }

        /// <summary>
        /// Creates a too many requests response (429).
        /// </summary>
        public static ResponseData<T> TooManyRequests(string message = "Too many requests")
        {
            return new ResponseData<T>
            {
                Success = false,
                Data = default,
                Message = message,
                StatusCode = 429
            };
        }

        /// <summary>
        /// Creates an internal server error response (500).
        /// </summary>
        public static ResponseData<T> InternalServerError(string message = "Internal server error")
        {
            return new ResponseData<T>
            {
                Success = false,
                Data = default,
                Message = message,
                StatusCode = 500
            };
        }

        /// <summary>
        /// Creates a service unavailable response (503).
        /// </summary>
        public static ResponseData<T> ServiceUnavailable(string message = "Service unavailable")
        {
            return new ResponseData<T>
            {
                Success = false,
                Data = default,
                Message = message,
                StatusCode = 503
            };
        }

        /// <summary>
        /// Creates a no content response (204).
        /// </summary>
        public static ResponseData<T> NoContent()
        {
            return new ResponseData<T>
            {
                Success = true,
                Data = default,
                Message = null,
                StatusCode = 204
            };
        }

        /// <summary>
        /// Creates an accepted response (202).
        /// </summary>
        public static ResponseData<T> Accepted(T data = default, string message = "Accepted")
        {
            return new ResponseData<T>
            {
                Success = true,
                Data = data,
                Message = message,
                StatusCode = 202
            };
        }
    }
}
