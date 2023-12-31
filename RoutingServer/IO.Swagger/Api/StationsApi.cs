/* 
 * JcDecaux
 *
 * JcDecaux API
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public interface IStationsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get a station
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stationNumber"></param>
        /// <param name="contract"></param>
        /// <returns>Station</returns>
        Station GetStation (int? stationNumber, string contract);

        /// <summary>
        /// Get a station
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stationNumber"></param>
        /// <param name="contract"></param>
        /// <returns>ApiResponse of Station</returns>
        ApiResponse<Station> GetStationWithHttpInfo (int? stationNumber, string contract);
        /// <summary>
        /// Get all stations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;Station&gt;</returns>
        List<Station> GetStations ();

        /// <summary>
        /// Get all stations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;Station&gt;</returns>
        ApiResponse<List<Station>> GetStationsWithHttpInfo ();
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Get a station
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stationNumber"></param>
        /// <param name="contract"></param>
        /// <returns>Task of Station</returns>
        System.Threading.Tasks.Task<Station> GetStationAsync (int? stationNumber, string contract);

        /// <summary>
        /// Get a station
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stationNumber"></param>
        /// <param name="contract"></param>
        /// <returns>Task of ApiResponse (Station)</returns>
        System.Threading.Tasks.Task<ApiResponse<Station>> GetStationAsyncWithHttpInfo (int? stationNumber, string contract);
        /// <summary>
        /// Get all stations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;Station&gt;</returns>
        System.Threading.Tasks.Task<List<Station>> GetStationsAsync ();

        /// <summary>
        /// Get all stations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;Station&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Station>>> GetStationsAsyncWithHttpInfo ();
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public partial class StationsApi : IStationsApi
    {
        private IO.Swagger.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StationsApi(String basePath)
        {
            this.Configuration = new IO.Swagger.Client.Configuration { BasePath = basePath };

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StationsApi"/> class
        /// </summary>
        /// <returns></returns>
        public StationsApi()
        {
            this.Configuration = IO.Swagger.Client.Configuration.Default;

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StationsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public StationsApi(IO.Swagger.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = IO.Swagger.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public IO.Swagger.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public IO.Swagger.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Get a station 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stationNumber"></param>
        /// <param name="contract"></param>
        /// <returns>Station</returns>
        public Station GetStation (int? stationNumber, string contract)
        {
             ApiResponse<Station> localVarResponse = GetStationWithHttpInfo(stationNumber, contract);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get a station 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stationNumber"></param>
        /// <param name="contract"></param>
        /// <returns>ApiResponse of Station</returns>
        public ApiResponse< Station > GetStationWithHttpInfo (int? stationNumber, string contract)
        {
            // verify the required parameter 'stationNumber' is set
            if (stationNumber == null)
                throw new ApiException(400, "Missing required parameter 'stationNumber' when calling StationsApi->GetStation");
            // verify the required parameter 'contract' is set
            if (contract == null)
                throw new ApiException(400, "Missing required parameter 'contract' when calling StationsApi->GetStation");

            var localVarPath = "/stations/{station_number}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (stationNumber != null) localVarPathParams.Add("station_number", this.Configuration.ApiClient.ParameterToString(stationNumber)); // path parameter
            if (contract != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "contract", contract)); // query parameter
            // authentication (ApiKey) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("apiKey")))
            {
                localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "apiKey", this.Configuration.GetApiKeyWithPrefix("apiKey")));
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetStation", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Station>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Station) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Station)));
        }

        /// <summary>
        /// Get a station 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stationNumber"></param>
        /// <param name="contract"></param>
        /// <returns>Task of Station</returns>
        public async System.Threading.Tasks.Task<Station> GetStationAsync (int? stationNumber, string contract)
        {
             ApiResponse<Station> localVarResponse = await GetStationAsyncWithHttpInfo(stationNumber, contract);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get a station 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="stationNumber"></param>
        /// <param name="contract"></param>
        /// <returns>Task of ApiResponse (Station)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Station>> GetStationAsyncWithHttpInfo (int? stationNumber, string contract)
        {
            // verify the required parameter 'stationNumber' is set
            if (stationNumber == null)
                throw new ApiException(400, "Missing required parameter 'stationNumber' when calling StationsApi->GetStation");
            // verify the required parameter 'contract' is set
            if (contract == null)
                throw new ApiException(400, "Missing required parameter 'contract' when calling StationsApi->GetStation");

            var localVarPath = "/stations/{station_number}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (stationNumber != null) localVarPathParams.Add("station_number", this.Configuration.ApiClient.ParameterToString(stationNumber)); // path parameter
            if (contract != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "contract", contract)); // query parameter
            // authentication (ApiKey) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("apiKey")))
            {
                localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "apiKey", this.Configuration.GetApiKeyWithPrefix("apiKey")));
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetStation", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Station>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Station) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Station)));
        }

        /// <summary>
        /// Get all stations 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;Station&gt;</returns>
        public List<Station> GetStations ()
        {
             ApiResponse<List<Station>> localVarResponse = GetStationsWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get all stations 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;Station&gt;</returns>
        public ApiResponse< List<Station> > GetStationsWithHttpInfo ()
        {

            var localVarPath = "/stations";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // authentication (ApiKey) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("apiKey")))
            {
                localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "apiKey", this.Configuration.GetApiKeyWithPrefix("apiKey")));
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetStations", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Station>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<Station>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Station>)));
        }

        /// <summary>
        /// Get all stations 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;Station&gt;</returns>
        public async System.Threading.Tasks.Task<List<Station>> GetStationsAsync ()
        {
             ApiResponse<List<Station>> localVarResponse = await GetStationsAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get all stations 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;Station&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<Station>>> GetStationsAsyncWithHttpInfo ()
        {

            var localVarPath = "/stations";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // authentication (ApiKey) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("apiKey")))
            {
                localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "apiKey", this.Configuration.GetApiKeyWithPrefix("apiKey")));
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetStations", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Station>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<Station>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Station>)));
        }

    }
}
