﻿using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.AspNetCore.Mvc;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.147.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//
// ReSharper disable once CheckNamespace
namespace Demo.Api.Generated.Contracts.Accounts
{
    /// <summary>
    /// Results for operation request.
    /// Description: Set name of account.
    /// Operation: SetAccountName.
    /// Area: Accounts.
    /// </summary>
    [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Should not throw ArgumentNullExceptions from implicit operators.")]
    [GeneratedCode("ApiGenerator", "1.0.147.0")]
    public class SetAccountNameResult
    {
        private readonly ActionResult result;

        private SetAccountNameResult(ActionResult result)
        {
            this.result = result ?? throw new ArgumentNullException(nameof(result));
        }

        /// <summary>
        /// 200 - Ok response.
        /// </summary>
        public static SetAccountNameResult Ok(string? message = null) => new SetAccountNameResult(ResultFactory.CreateContentResult(HttpStatusCode.OK, message));

        /// <summary>
        /// Performs an implicit conversion from SetAccountNameResult to ActionResult.
        /// </summary>
        public static implicit operator ActionResult(SetAccountNameResult x) => x.result;

        /// <summary>
        /// Performs an implicit conversion from SetAccountNameResult to ActionResult.
        /// </summary>
        public static implicit operator SetAccountNameResult(string x) => Ok(x);
    }
}