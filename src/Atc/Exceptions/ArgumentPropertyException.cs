﻿using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// ArgumentPropertyException.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public sealed class ArgumentPropertyException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentPropertyException"/> class.
        /// </summary>
        public ArgumentPropertyException()
            : base("Value does not fall within the expected range.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentPropertyException"/> class.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "param", Justification = "OK.")]
        public ArgumentPropertyException(string paramName)
            : base("Value does not fall within the expected range.", paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentPropertyException"/> class.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">The message.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "param", Justification = "OK.")]
        public ArgumentPropertyException(string message, string paramName)
            : base(message, paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentPropertyException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ArgumentPropertyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        private ArgumentPropertyException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base("Value does not fall within the expected range.")
        {
        }
    }
}