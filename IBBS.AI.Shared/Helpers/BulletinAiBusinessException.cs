// *********************************************************************************
//	<copyright file="BulletinAiBusinessException.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Bulletin ai business exception.</summary>
// *********************************************************************************

namespace IBBS.AI.Shared.Helpers
{
    /// <summary>
    /// Bulletin ai business exception.
    /// </summary>
    /// <seealso cref="Exception" />
    public class BulletinAiBusinessException : Exception
    {
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string? ExceptionMessage { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        public string? Details { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BulletinAiBusinessException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public BulletinAiBusinessException(string? message) : base(message)
        {
            this.ExceptionMessage = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BulletinAiBusinessException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="details">The details.</param>
        public BulletinAiBusinessException(string? message, int statusCode, string? details) : base(message)
        {
            this.ExceptionMessage = message;
            this.StatusCode = statusCode;
            this.Details = details;
        }
    }
}


