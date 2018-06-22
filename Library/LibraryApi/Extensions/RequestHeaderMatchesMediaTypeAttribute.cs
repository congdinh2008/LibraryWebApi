﻿using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;

namespace Library.Api.Extensions
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public class RequestHeaderMatchesMediaTypeAttribute : Attribute, IActionConstraint
    {
        private readonly string[] _mediaTypes;
        private readonly string _requestHeaderToMatch;

        public RequestHeaderMatchesMediaTypeAttribute(
            string requestHeaderToMatch,
            string[] mediaTypes)
        {
            _mediaTypes = mediaTypes;
            _requestHeaderToMatch = requestHeaderToMatch;
        }
        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            var requestHeaders = context.RouteContext
                .HttpContext.Request.Headers;

            if (!requestHeaders.ContainsKey(_requestHeaderToMatch))
                return false;

            // If one of the media types matches, return true.
            foreach (var mediaType in _mediaTypes)
            {
                var mediaTypeMatches = string.Equals(
                    requestHeaders[_requestHeaderToMatch].ToString(),
                    mediaType, StringComparison.OrdinalIgnoreCase);

                if (mediaTypeMatches)
                    return true;
            }

            return false;
        }
    }
}
