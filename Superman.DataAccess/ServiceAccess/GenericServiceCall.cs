using Superman.DataModel.BusinessModel;
using Superman.DataModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Superman.DataModel.Common;

namespace TimingApp.DataAccess.ServiceAccess
{
    public class GenericServiceCall
    {
        private string BaseUri { get; set; }

        public GenericServiceCall(string baseUri)
        {
            BaseUri = baseUri;
        }

        public async Task<string> CallPost(string request, string content)
        {
            //Check if we have no network connectivity
            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                throw new Exception(ConstantFile.ConnectivityError);
            }

            try
            {

                using (HttpClient client = (new HttpClient()))
                {
                    client.BaseAddress = new Uri(BaseUri);                    
                    client.Timeout = new TimeSpan(0, 0, 30);
                    HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(request, httpContent);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string returnValue = await response.Content.ReadAsStringAsync();
                        return returnValue;
                    }

                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return "";
                    }
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                    {
                        throw new Exception("Forbidden exception");
                    }
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new UnauthorizedAccessException("Unauthorized");
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        throw new Exception(string.Concat("Internal server error calling ", request));
                    }

                    if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new Exception(string.Concat("Internal server error calling ", request));
                    }
                }
            }
            catch (WebException webException)
            {
                if (webException.InnerException != null)
                {
                    throw new WebException(webException.InnerException.Message);
                }
                else
                {
                    throw new WebException(webException.Message);
                }
                //return null;          
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message);
                else
                    throw new Exception(ex.Message);
                // return null;
            }
            return "";
        }

        public async Task<string> CallGet(string request, params ServiceCallParameter[] parameters)
        {
            //fail if we have no network connectivity

            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {

                throw new ServiceCallFailedException("Call failed, no network connectivity");
            }

            List<ServiceCallParameter> requestParameters = new List<ServiceCallParameter>();
            StringBuilder requestBuilder = new StringBuilder();

            //Build up the request
            requestBuilder.Append(request);

            //Build up the request parameters
            if (parameters != null)
            {
                requestParameters = parameters.ToList();
            }

            try
            {
                string foobet = requestBuilder.ToString();

                using (HttpClient client = (new HttpClient()))
                {
                    client.BaseAddress = new Uri(BaseUri);

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(@"application/json"));
                    client.Timeout = new TimeSpan(0, 0, 30);

                    HttpResponseMessage response = await client.GetAsync(requestBuilder.ToString());

                    //Handle the all good scenario
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return "";
                    }
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                    {
                        throw new Exception("Forbidden exception");
                    }
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new UnauthorizedAccessException("Unauthorized");
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        throw new Exception(string.Concat("Internal server error calling ", request));
                    }

                    if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new Exception(string.Concat("Internal server error calling ", request));
                    }
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (WebException webException)
            {
                string webExceptionMessage = "";
                string responseHeaders = "";
                if (webException != null)
                {
                    webExceptionMessage = webException.Message;
                    if (webException.Response != null)
                    {
                        if (webException.Response.Headers != null)
                        {
                            responseHeaders = webException.Response.Headers.ToString();
                        }
                    }
                }
                throw webException;
            }
            catch (Exception ex)
            {
                string sdf = ex.Message;

                throw;
            }
        }
    }
}
