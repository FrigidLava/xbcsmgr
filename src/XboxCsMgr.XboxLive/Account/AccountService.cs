﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using XboxCsMgr.Helpers.Http;

namespace XboxCsMgr.XboxLive.Account
{
    public class AccountService : XboxLiveService
    {
        public AccountService(XboxLiveConfig config) : base(config, "https://accounts.xboxlive.com")
        {

            HttpHeaders = new Dictionary<string, string>()
            {
                { "Accept-Language", CultureInfo.CurrentCulture.ToString() },
                { "x-xbl-contract-version", "2" }
            };
        }

        /// <summary>
        /// Gets the current authenticated users account information
        /// </summary>
        /// <returns>AccountDetails - Contains a summary of profile information</returns>
        public async Task<AccountDetails> GetAccountDetailsAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"users/current/profile");
            request.Headers.Add(HttpHeaders);

            HttpResponseMessage response = await HttpClient.SendAsync(request);
            return await response.Content.ReadAsJsonAsync<AccountDetails>();
        }
    }
}
