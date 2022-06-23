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
    public interface ILocationApi
    {
        /// <summary>
        /// Locations can be a specific latitude/longitude point such as a station, or a label representing a bounding area such as a city. When used without optional parameters, fetches list of available locations. Use with optional parameters below to filter results.
        /// </summary>
        /// <param name="datasetid">Optional. Accepts a valid dataset id or a chain of dataset ids separated by ampersands. Locations returned will be supported by dataset(s) specified.</param>
        /// <param name="locationcategoryid">Optional. Accepts a valid location id or a chain of location category ids separated by ampersands. Locations returned will be in the location category(ies) specified.</param>
        /// <param name="datacategoryid">Optional. Accepts a valid data category id or an array of data category IDs. Locations returned will be associated with the data category(ies) specified.</param>
        /// <param name="startdate">Optional. Accepts valid ISO formated date (yyyy-mm-dd). Locations returned will have data after the specified date. Paramater can be use independently of enddate</param>
        /// <param name="enddate">Optional. Accepts valid ISO formated date (yyyy-mm-dd). Locations returned will have data before the specified date. Paramater can be use independently of startdate</param>
        /// <param name="sortfield">Optional. The field to sort results by. Supports id, name, mindate, maxdate, and datacoverage fields</param>
        /// <param name="sortorder">Optional. Which order to sort by, asc or desc. Defaults to asc</param>
        /// <param name="limit">Optional. Defaults to 25, limits the number of results in the response. Maximum is 1000</param>
        /// <param name="offset">Optional. Defaults to 0, used to offset the resultlist. The example would begin with record 24</param>
        /// <returns>LocationResult</returns>
        LocationResult FindLocations(List<string> datasetid, List<string> locationcategoryid, List<string> datacategoryid, DateTime? startdate, DateTime? enddate, string sortfield, string sortorder, long? limit, long? offset);
        /// <summary>
        /// Find location by ID Used to find information about the location with id of {id}.
        /// </summary>
        /// <param name="locationId">ID of location to return</param>
        /// <returns>LocationResult</returns>
        LocationResult GetLocationById(long? locationId);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class LocationApi : ILocationApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public LocationApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LocationApi(String basePath)
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
        /// Locations can be a specific latitude/longitude point such as a station, or a label representing a bounding area such as a city. When used without optional parameters, fetches list of available locations. Use with optional parameters below to filter results.
        /// </summary>
        /// <param name="datasetid">Optional. Accepts a valid dataset id or a chain of dataset ids separated by ampersands. Locations returned will be supported by dataset(s) specified.</param>
        /// <param name="locationcategoryid">Optional. Accepts a valid location id or a chain of location category ids separated by ampersands. Locations returned will be in the location category(ies) specified.</param>
        /// <param name="datacategoryid">Optional. Accepts a valid data category id or an array of data category IDs. Locations returned will be associated with the data category(ies) specified.</param>
        /// <param name="startdate">Optional. Accepts valid ISO formated date (yyyy-mm-dd). Locations returned will have data after the specified date. Paramater can be use independently of enddate</param>
        /// <param name="enddate">Optional. Accepts valid ISO formated date (yyyy-mm-dd). Locations returned will have data before the specified date. Paramater can be use independently of startdate</param>
        /// <param name="sortfield">Optional. The field to sort results by. Supports id, name, mindate, maxdate, and datacoverage fields</param>
        /// <param name="sortorder">Optional. Which order to sort by, asc or desc. Defaults to asc</param>
        /// <param name="limit">Optional. Defaults to 25, limits the number of results in the response. Maximum is 1000</param>
        /// <param name="offset">Optional. Defaults to 0, used to offset the resultlist. The example would begin with record 24</param>
        /// <returns>LocationResult</returns>
        public LocationResult FindLocations(List<string> datasetid, List<string> locationcategoryid, List<string> datacategoryid, DateTime? startdate, DateTime? enddate, string sortfield, string sortorder, long? limit, long? offset)
        {

            var path = "/locations";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (datasetid != null) queryParams.Add("datasetid", ApiClient.ParameterToString(datasetid)); // query parameter
            if (locationcategoryid != null) queryParams.Add("locationcategoryid", ApiClient.ParameterToString(locationcategoryid)); // query parameter
            if (datacategoryid != null) queryParams.Add("datacategoryid", ApiClient.ParameterToString(datacategoryid)); // query parameter
            if (startdate != null) queryParams.Add("startdate", ApiClient.ParameterToString(startdate?.ToString("yyyy-MM-dd"))); // query parameter
            if (enddate != null) queryParams.Add("enddate", ApiClient.ParameterToString(enddate?.ToString("yyyy-MM-dd"))); // query parameter
            if (sortfield != null) queryParams.Add("sortfield", ApiClient.ParameterToString(sortfield)); // query parameter
            if (sortorder != null) queryParams.Add("sortorder", ApiClient.ParameterToString(sortorder)); // query parameter
            if (limit != null) queryParams.Add("limit", ApiClient.ParameterToString(limit)); // query parameter
            if (offset != null) queryParams.Add("offset", ApiClient.ParameterToString(offset)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            RestResponse response = (RestResponse)ApiClient.CallApi(path, Method.Get, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling FindLocations: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling FindLocations: " + response.ErrorMessage, response.ErrorMessage);

            return (LocationResult)ApiClient.Deserialize(response.Content, typeof(LocationResult), (IList<Parameter>)response.Headers);
        }

        /// <summary>
        /// Find location by ID Used to find information about the location with id of {id}.
        /// </summary>
        /// <param name="locationId">ID of location to return</param>
        /// <returns>LocationResult</returns>
        public LocationResult GetLocationById(long? locationId)
        {
            // verify the required parameter 'locationId' is set
            if (locationId == null) throw new ApiException(400, "Missing required parameter 'locationId' when calling GetLocationById");

            var path = "/locations/{locationId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "locationId" + "}", ApiClient.ParameterToString(locationId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "api_key" };

            // make the HTTP request
            RestResponse response = (RestResponse)ApiClient.CallApi(path, Method.Get, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling GetLocationById: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling GetLocationById: " + response.ErrorMessage, response.ErrorMessage);

            return (LocationResult)ApiClient.Deserialize(response.Content, typeof(LocationResult), (IList<Parameter>)response.Headers);
        }

    }
}
