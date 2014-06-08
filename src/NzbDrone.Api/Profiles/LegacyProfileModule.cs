﻿using System;
using System.Text;
using Nancy;
using Nancy.Responses;

namespace NzbDrone.Api.Profiles
{
    class LegacyProfileModule : NzbDroneApiModule
    {
        public LegacyProfileModule()
            : base("qualityprofile")
        {
            Get["/"] = x =>
            {
                string queryString = ConvertQueryParams(Request.Query);
                var url = String.Format("/api/profile?{0}", queryString);

                return Response.AsRedirect(url, RedirectResponse.RedirectType.Permanent);
            };
        }

        private string ConvertQueryParams(DynamicDictionary query)
        {
            var sb = new StringBuilder();

            foreach (var key in query)
            {
                var value = query[key];

                sb.AppendFormat("&{0}={1}", key, value);
            }

            return sb.ToString().Trim('&');
        }
    }
}
