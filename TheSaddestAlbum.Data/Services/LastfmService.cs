using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TheSaddestAlbum.Data.Entities;

namespace TheSaddestAlbum.Data.Services
{
    public class LastfmService
    {
        private readonly string URL_BASE = "http://ws.audioscrobbler.com/2.0/?method=album.getinfo&api_key={0}&artist=${1}&album=${2}&format=json";

        private readonly Configuration _configuration;
        public LastfmService(IOptions<Configuration> configurationAccessor)
        {
            this._configuration = configurationAccessor.Value;
        }

        public async void FetchAlbumInfo(string artist, string album)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(string.Format(URL_BASE, _configuration.LastfmKey, artist, album));
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
