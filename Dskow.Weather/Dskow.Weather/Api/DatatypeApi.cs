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
    public interface IDatatypeApi
    {
        /// <summary>
        /// Describes the type of data, acts as a label. If it&#x27;s 64°f out right now, then the data type is Air Temperature and the data is 64. When used without optional parameters, fetches list of available data types. Use with optional parameters below to filter results
        /// </summary>
        /// <param name="datatypeid">Optional. Accepts a valid data type id or a chain of data type ids separated by ampersands. Datatypes returned will contain all of the data type(s) specified</param>
        /// <param name="locationid">Optional. Accepts a valid location id or a chain of location ids separated by ampersands. Datatypes returned will contain data for the location(s) specified</param>
        /// <param name="datacategoryid">Optional. Accepts a valid data category id or a chain of data category ids separated by ampersands. Datatypes returned will contain data for the data category(s) specified</param>
        /// <param name="stationid">Optional. Accepts a valid station id or a chain of of station ids seperated by ampersands. Datatypes returned will contain data for the station(s) specified</param>
        /// <param name="startdate">Optional. Accepts valid ISO formated date (yyyy-mm-dd). Datatypes returned will have data after the specified date. Paramater can be use independently of enddate</param>
        /// <param name="enddate">Optional. Accepts valid ISO formated date (yyyy-mm-dd). Datatypes returned will have data before the specified date. Paramater can be use independently of startdate</param>
        /// <param name="sortfield">Optional. The field to sort results by. Supports id, name, mindate, maxdate, and datacoverage fields</param>
        /// <param name="sortorder">Optional. Which order to sort by, asc or desc. Defaults to asc</param>
        /// <param name="limit">Optional. Defaults to 25, limits the number of results in the response. Maximum is 1000</param>
        /// <param name="offset">Optional. Defaults to 0, used to offset the resultlist. The example would begin with record 24</param>
        /// <returns>DatatypeResult</returns>
        DatatypeResult FindDatatypes(List<string> datatypeid, List<string> locationid, List<string> datacategoryid, List<string> stationid, DateTime? startdate, DateTime? enddate, string sortfield, string sortorder, long? limit, long? offset);
        /// <summary>
        /// Find datatype by ID Used to find information about the data type with id of {id}
        /// </summary>
        /// <param name="datatypeId">ID of datatype to return</param>
        /// <returns>DatatypeResult</returns>
        DatatypeResult GetDatatypeById(long? datatypeId);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DatatypeApi : IDatatypeApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatatypeApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public DatatypeApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatatypeApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DatatypeApi(String basePath)
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
        /// Describes the type of data, acts as a label. If it&#x27;s 64°f out right now, then the data type is Air Temperature and the data is 64. When used without optional parameters, fetches list of available data types. Use with optional parameters below to filter results
        /// </summary>
        /// <param name="datatypeid">Optional. Accepts a valid data type id or a chain of data type ids separated by ampersands. Datatypes returned will contain all of the data type(s) specified</param>
        /// <param name="locationid">Optional. Accepts a valid location id or a chain of location ids separated by ampersands. Datatypes returned will contain data for the location(s) specified</param>
        /// <param name="datacategoryid">Optional. Accepts a valid data category id or a chain of data category ids separated by ampersands. Datatypes returned will contain data for the data category(s) specified</param>
        /// <param name="stationid">Optional. Accepts a valid station id or a chain of of station ids seperated by ampersands. Datatypes returned will contain data for the station(s) specified</param>
        /// <param name="startdate">Optional. Accepts valid ISO formated date (yyyy-mm-dd). Datatypes returned will have data after the specified date. Paramater can be use independently of enddate</param>
        /// <param name="enddate">Optional. Accepts valid ISO formated date (yyyy-mm-dd). Datatypes returned will have data before the specified date. Paramater can be use independently of startdate</param>
        /// <param name="sortfield">Optional. The field to sort results by. Supports id, name, mindate, maxdate, and datacoverage fields</param>
        /// <param name="sortorder">Optional. Which order to sort by, asc or desc. Defaults to asc</param>
        /// <param name="limit">Optional. Defaults to 25, limits the number of results in the response. Maximum is 1000</param>
        /// <param name="offset">Optional. Defaults to 0, used to offset the resultlist. The example would begin with record 24</param>
        /// <returns>DatatypeResult</returns>
        public DatatypeResult FindDatatypes(List<string> datatypeid, List<string> locationid, List<string> datacategoryid, List<string> stationid, DateTime? startdate, DateTime? enddate, string sortfield, string sortorder, long? limit, long? offset)
        {

            var path = "/datatypes";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (datatypeid != null) queryParams.Add("datatypeid", ApiClient.ParameterToString(datatypeid)); // query parameter
            if (locationid != null) queryParams.Add("locationid", ApiClient.ParameterToString(locationid)); // query parameter
            if (datacategoryid != null) queryParams.Add("datacategoryid", ApiClient.ParameterToString(datacategoryid)); // query parameter
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
                throw new ApiException((int)response.StatusCode, "Error calling FindDatatypes: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling FindDatatypes: " + response.ErrorMessage, response.ErrorMessage);

            return (DatatypeResult)ApiClient.Deserialize(response.Content, typeof(DatatypeResult), response.Headers);
        }

        /// <summary>
        /// Find datatype by ID Used to find information about the data type with id of {id}
        /// </summary>
        /// <param name="datatypeId">ID of datatype to return</param>
        /// <returns>DatatypeResult</returns>
        public DatatypeResult GetDatatypeById(long? datatypeId)
        {
            // verify the required parameter 'datatypeId' is set
            if (datatypeId == null) throw new ApiException(400, "Missing required parameter 'datatypeId' when calling GetDatatypeById");

            var path = "/datatypes/{datatypeId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "datatypeId" + "}", ApiClient.ParameterToString(datatypeId));

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
                throw new ApiException((int)response.StatusCode, "Error calling GetDatatypeById: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling GetDatatypeById: " + response.ErrorMessage, response.ErrorMessage);

            return (DatatypeResult)ApiClient.Deserialize(response.Content, typeof(DatatypeResult), response.Headers);
        }

    }
}
