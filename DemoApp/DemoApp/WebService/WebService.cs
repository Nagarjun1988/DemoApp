using DemoApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.WebService
{
    public static class WebService
    {
        public static string encoding = "application/json";
        public static async Task<Rest_Response> GetRestData(string methodUrl)
        {
            Rest_Response resp = new Rest_Response();
            try
            {
                //JObject json = null;

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = null;

                response = await httpClient.GetAsync(methodUrl);

                var response_text = await response.Content.ReadAsStringAsync();
                httpClient.Dispose();

                //json = JObject.Parse(await response.Content.ReadAsStringAsync());

                #region Build-Response-Object

                if (!string.IsNullOrEmpty(response_text))
                {
                    resp.content_length = response_text.Length;
                }
                else
                {
                    resp.content_length = 0;
                }

                resp.content_type = encoding;
                resp.response_body = response_text;
                resp.status_code = (int)response.StatusCode;

                #endregion

                #region Enumerate-Response
                bool rest_enumerate = true;
                if (rest_enumerate)
                {
                    Debug.WriteLine("rest_client response status_code " + resp.status_code + ": " + resp.content_length + "B for " + "POST" + " " + methodUrl);
                    Debug.WriteLine(resp.response_body);
                }

                #endregion

                // httpClient.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return resp;
        }
    }
}
