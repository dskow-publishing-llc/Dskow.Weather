using System;
using System.Collections.Generic;
using RestSharp;
using Dskow.Weather.Client;
using Dskow.Weather.Model;

namespace Dskow.Weather.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDatacategoryApi
    {
        /// <summary>
        /// Data Categories represent groupings of data types. When used without optional parameters, fetches list of available datacategories. Use with optional parameters below to filter results
        /// </summary>
        /// <param name="datasetid">Optional. Accepts a valid dataset id or a chain of dataset ids separated by ampersands. Data categories returned will be supported by dataset(s) specified</param>
        /// <param name="locationid">Optional. Accepts a valid location id or a chain of location ids separated by ampersands. Data categories returned will contain data for the location(s) specified</param>
        /// <param name="stationid">Optional. Accepts a valid station id or a chain of of station ids separated by ampersands. Data categories returned will contain data for the station(s) specified</param>
        /// <param name="startdate">Optional. Accepts valid ISO formated date (yyyy-mm-dd). Data categories returned will have data after the specified date. Paramater can be use independently of enddate</param>
        /// <param name="enddate">Optional. Accepts valid ISO formated date (yyyy-mm-dd). Data categories returned will have data before the specified date. Paramater can be use independently of startdate</param>
        /// <param name="sortfield">Optional. The field to sort results by. Supports id, name, mindate, maxdate, and datacoverage fields</param>
        /// <param name="sortorder">Optional. Which order to sort by, asc or desc. Defaults to asc</param>
        /// <param name="limit">Optional. Defaults to 25, limits the number of results in the response. Maximum is 1000</param>
        /// <param name="offset">Optional. Defaults to 0, used to offset the resultlist. The example would begin with record 24</param>
        /// <returns>DatacategoryResult</returns>
        DatacategoryResult FindDatacategories(List<string> datasetid, List<string> locationid, List<string> stationid, DateTime? startdate, DateTime? enddate, string sortfield, string sortorder, long? limit, long? offset);
        /// <summary>
        /// Find datacategory by ID Returns a single datacategory
        /// </summary>
        /// <param name="datacategoryId">Used to find information about datacategory with id of {id}</param>
        /// <returns>DatacategoryResult</returns>
        DatacategoryResult GetDatacategoryById(long? datacategoryId);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DatacategoryApi : IDatacategoryApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatacategoryApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public DatacategoryApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatacategoryApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DatacategoryApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }

        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        /// Data Categories represent groupings of data types. When used without optional parameters, fetches list of available datacategories. Use with optional parameters below to filter results
        /// </summary>
        /// <param name="datasetid">Optional. Accepts a valid dataset id or a chain of dataset ids separated by ampersands. Data categories returned will be supported by dataset(s) specified</param>
        /// <param name="locationid">Optional. Accepts a valid location id or a chain of location ids separated by ampersands. Data categories returned will contain data for the location(s) specified</param>
        /// <param name="stationid">Optional. Accepts a valid station id or a chain of of station ids separated by ampersands. Data categories returned will contain data for the station(s) specified</param>
        /// <param name="startdate">Optional. Accepts valid ISO formated date (yyyy-mm-dd). Data categories returned will have data after the specified date. Paramater can be use independently of enddate</param>
        /// <param name="enddate">Optional. Accepts valid ISO formated date (yyyy-mm-dd). Data categories returned will have data before the specified date. Paramater can be use independently of startdate</param>
        /// <param name="sortfield">Optional. The field to sort results by. Supports id, name, mindate, maxdate, and datacoverage fields</param>
        /// <param name="sortorder">Optional. Which order to sort by, asc or desc. Defaults to asc</param>
        /// <param name="limit">Optional. Defaults to 25, limits the number of results in the response. Maximum is 1000</param>
        /// <param name="offset">Optional. Defaults to 0, used to offset the resultlist. The example would begin with record 24</param>
        /// <returns>DatacategoryResult</returns>
        public DatacategoryResult FindDatacategories(List<string> datasetid, List<string> locationid, List<string> stationid, DateTime? startdate, DateTime? enddate, string sortfield, string sortorder, long? limit, long? offset)
        {

            var path = "/datacategories";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (datasetid != null) queryParams.Add("datasetid", ApiClient.ParameterToString(datasetid)); // query parameter
            if (locationid != null) queryParams.Add("locationid", ApiClient.ParameterToString(locationid)); // query parameter
            if (stationid != null) queryParams.Add("stationid", ApiClient.ParameterToString(stationid)); // query parameter
            if (startdate != null) queryParams.Add("startdate", ApiClient.ParameterToString(startdate?.ToString("yyyy-MM-ddThh:mm:ss"))); // query parameter
            if (enddate != null) queryParams.Add("enddate", ApiClient.ParameterToString(enddate?.ToString("yyyy-MM-ddThh:mm:ss"))); // query parameter
            if (sortfield != null) queryParams.Add("sortfield", ApiClient.ParameterToString(sortfield)); // query parameter
            if (sortorder != null) queryParams.Add("sortorder", ApiClient.ParameterToString(sortorder)); // query parameter
            if (limit != null) queryParams.Add("limit", ApiClient.ParameterToString(limit)); // query parameter
            if (offset != null) queryParams.Add("offset", ApiClient.ParameterToString(offset)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling FindDatacategories: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling FindDatacategories: " + response.ErrorMessage, response.ErrorMessage);

            return (DatacategoryResult)ApiClient.Deserialize(response.Content, typeof(DatacategoryResult), response.Headers);
        }

        /// <summary>
        /// Find datacategory by ID Returns a single datacategory
        /// </summary>
        /// <param name="datacategoryId">Used to find information about datacategory with id of {id}</param>
        /// <returns>DatacategoryResult</returns>
        public DatacategoryResult GetDatacategoryById(long? datacategoryId)
        {
            // verify the required parameter 'datacategoryId' is set
            if (datacategoryId == null) throw new ApiException(400, "Missing required parameter 'datacategoryId' when calling GetDatacategoryById");

            var path = "/datacategories/{datacategoryId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "datacategoryId" + "}", ApiClient.ParameterToString(datacategoryId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "api_key" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling GetDatacategoryById: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling GetDatacategoryById: " + response.ErrorMessage, response.ErrorMessage);

            return (DatacategoryResult)ApiClient.Deserialize(response.Content, typeof(DatacategoryResult), response.Headers);
        }

    }
}
