﻿using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Xml.Linq;

// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// Extension methods for the <see cref="Exception"/> class.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Gets the exception message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="includeInnerMessage">if set to <c>true</c> [include inner message].</param>
        /// <param name="includeExceptionName">if set to <c>true</c> [include exception name].</param>
        public static string GetMessage(
            this Exception exception,
            bool includeInnerMessage = false,
            bool includeExceptionName = false)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (includeInnerMessage && exception.InnerException != null)
            {
                return $"{GetExceptionMessageLine(exception, includeExceptionName)} # {GetMessage(exception.InnerException, true, includeExceptionName)}";
            }

            return GetExceptionMessageLine(exception, includeExceptionName);
        }

        /// <summary>
        /// Gets the last inner exception message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="includeExceptionName">if set to <c>true</c> [include exception name].</param>
        public static string GetLastInnerMessage(
            this Exception exception,
            bool includeExceptionName = false)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (exception.InnerException != null && !string.IsNullOrEmpty(exception.InnerException.Message))
            {
                // ReSharper disable once TailRecursiveCall
                return GetLastInnerMessage(exception.InnerException, includeExceptionName);
            }

            return includeExceptionName
                ? GetExceptionShortName(exception)
                : exception.Message;
        }

        /// <summary>
        /// Flattens the specified exception and inner exception data.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="includeStackTrace">if set to <c>true</c> include stack trace.</param>
        /// <returns>The flatten message.</returns>
        public static string Flatten(this Exception exception, string message = "", bool includeStackTrace = false)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            var sb = new StringBuilder();
            if (!string.IsNullOrEmpty(message))
            {
                sb.AppendLine(message);
            }

            var currentException = exception;
            while (currentException != null)
            {
                sb.AppendLine(currentException.Message);
                if (includeStackTrace && exception.StackTrace != null)
                {
                    sb.Append(exception.StackTrace);
                }

                currentException = currentException.InnerException;
                if (includeStackTrace && exception.StackTrace != null)
                {
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// To the XML.
        /// </summary>
        /// <param name="exception">The exception.</param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "OK.")]
        public static XDocument ToXml(this Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            var root = new XElement(exception.GetType().ToString());

            if (!string.IsNullOrEmpty(exception.Message))
            {
                root.Add(new XElement("Message", exception.Message));
            }

            if (exception.StackTrace != null)
            {
                root.Add(
                    new XElement(
                        "StackTrace",
                        from frame
                            in exception.StackTrace.Split('\n')
                        let prettierFrame = frame.Substring(6).Trim()
                        select new XElement("Frame", prettierFrame)));
            }

            if (exception.Data.Count > 0)
            {
                root.Add(
                    new XElement(
                        "Data",
                        from entry
                            in exception.Data.Cast<DictionaryEntry>()
                        let key = entry.Key.ToString()
                        let value = entry.Value?.ToString() ?? "null"
                        select new XElement(key, value)));
            }

            // ReSharper disable once InvertIf
            if (exception.InnerException != null)
            {
                var xDocument = exception.InnerException.ToXml();
                root.Add(xDocument.Root);
            }

            return new XDocument(root);
        }

        private static string GetExceptionMessageLine(Exception exception, bool includeExceptionName)
        {
            var msg = exception.Message.Replace(Environment.NewLine, "; ", StringComparison.Ordinal);

            return includeExceptionName
                ? GetExceptionShortName(exception)
                : msg;
        }

        private static string GetExceptionShortName(Exception exception)
        {
            var exceptionName = exception.GetType().Name;
            return exceptionName.Equals("Exception", StringComparison.Ordinal)
                ? $"{exception.GetType().Name}: {exception.Message}"
                : $"{exception.GetType().Name.Replace("Exception", string.Empty, StringComparison.Ordinal)}: {exception.Message}";
        }
    }
}