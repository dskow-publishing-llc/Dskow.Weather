using System;
using System.Collections.Generic;
using System.Diagnostics;
using RestSharp;
using Dskow.Weather.Client;
using Dskow.Weather.Model;

namespace Dskow.Weather.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDataApi
    {
        /// <summary>
        /// The data endpoint is used for actually fetching the data. Requires exactly one dataset id. Used to fetch data.
        /// </summary>
        /// <param name="datasetid">Required. Accepts a single valid dataset id. Data returned will be from the dataset specified.</param>
        /// <param name="startdate">Required. Accepts valid ISO formated date (YYYY-MM-DD) or date time (YYYY-MM-DDThh:mm:ss). Data returned will be after the specified date. Annual and Monthly data will be limited to a ten year range while all other data will be limted to a one year range.</param>
        /// <param name="enddate">Required. Accepts valid ISO formated date (YYYY-MM-DD) or date time (YYYY-MM-DDThh:mm:ss). Data returned will be before the specified date. Annual and Monthly data will be limited to a ten year range while all other data will be limted to a one year range.</param>
        /// <param name="datatypeid">Optional. Accepts a valid data type id or a chain of data type ids separated by ampersands. Data returned will contain all of the data type(s) specified.</param>
        /// <param name="locationid">Optional. Accepts a valid location id or a chain of location ids separated by ampersands. Data returned will contain data for the location(s) specified.</param>
        /// <param name="stationid">Optional. Accepts a valid station id or a chain of of station ids separated by ampersands. Data returned will contain data for the station(s) specified.</param>
        /// <param name="units">Optional. Accepts the literal strings &#39;standard&#39; or &#39;metric&#39;. Data will be scaled and converted to the specified units. If a unit is not provided then no scaling nor conversion will take place.</param>
        /// <param name="sortfield">Optional. The field to sort results by. Supports id, name, mindate, maxdate, and datacoverage fields</param>
        /// <param name="sortorder">Optional. Which order to sort by, asc or desc. Defaults to asc</param>
        /// <param name="limit">Optional. Defaults to 25, limits the number of results in the response. Maximum is 1000</param>
        /// <param name="offset">Optional. Defaults to 0, used to offset the resultlist. The example would begin with record 24</param>
        /// <param name="includemetadata">Optional. Defaults to true, used to improve response time by preventing the calculation of result metadata.</param>
        /// <returns>DataResult</returns>
        DataResult FindData(string datasetid, DateTime? startdate, DateTime? enddate, List<string> datatypeid, List<string> locationid, List<string> stationid, string units, string sortfield, string sortorder, long? limit, long? offset, bool? includemetadata);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DataApi : IDataApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public DataApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DataApi(String basePath)
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
        /// The data endpoint is used for actually fetching the data. Requires exactly one dataset id. Used to fetch data.
        /// </summary>
        /// <param name="datasetid">Required. Accepts a single valid dataset id. Data returned will be from the dataset specified.</param> 
        /// <param name="startdate">Required. Accepts valid ISO formated date (YYYY-MM-DD) or date time (YYYY-MM-DDThh:mm:ss). Data returned will be after the specified date. Annual and Monthly data will be limited to a ten year range while all other data will be limted to a one year range.</param> 
        /// <param name="enddate">Required. Accepts valid ISO formated date (YYYY-MM-DD) or date time (YYYY-MM-DDThh:mm:ss). Data returned will be before the specified date. Annual and Monthly data will be limited to a ten year range while all other data will be limted to a one year range.</param> 
        /// <param name="datatypeid">Optional. Accepts a valid data type id or a chain of data type ids separated by ampersands. Data returned will contain all of the data type(s) specified.</param> 
        /// <param name="locationid">Optional. Accepts a valid location id or a chain of location ids separated by ampersands. Data returned will contain data for the location(s) specified.</param> 
        /// <param name="stationid">Optional. Accepts a valid station id or a chain of of station ids separated by ampersands. Data returned will contain data for the station(s) specified.</param> 
        /// <param name="units">Optional. Accepts the literal strings &#39;standard&#39; or &#39;metric&#39;. Data will be scaled and converted to the specified units. If a unit is not provided then no scaling nor conversion will take place.</param> 
        /// <param name="sortfield">Optional. The field to sort results by. Supports id, name, mindate, maxdate, and datacoverage fields</param> 
        /// <param name="sortorder">Optional. Which order to sort by, asc or desc. Defaults to asc</param> 
        /// <param name="limit">Optional. Defaults to 25, limits the number of results in the response. Maximum is 1000</param> 
        /// <param name="offset">Optional. Defaults to 0, used to offset the resultlist. The example would begin with record 24</param> 
        /// <param name="includemetadata">Optional. Defaults to true, used to improve response time by preventing the calculation of result metadata.</param> 
        /// <returns>DataResult</returns>            
        public DataResult FindData(string datasetid, DateTime? startdate, DateTime? enddate, List<string> datatypeid, List<string> locationid, List<string> stationid, string units, string sortfield, string sortorder, long? limit, long? offset, bool? includemetadata)
        {

            // verify the required parameter 'datasetid' is set
            if (datasetid == null) throw new ApiException(400, "Missing required parameter 'datasetid' when calling FindData");

            // verify the required parameter 'startdate' is set
            if (startdate == null) throw new ApiException(400, "Missing required parameter 'startdate' when calling FindData");

            // verify the required parameter 'enddate' is set
            if (enddate == null) throw new ApiException(400, "Missing required parameter 'enddate' when calling FindData");


            var path = "/data";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
            if (datasetid != null) queryParams.Add("datasetid", ApiClient.ParameterToString(datasetid)); // query parameter
            if (datatypeid != null) queryParams.Add("datatypeid", ApiClient.ParameterToString(datatypeid)); // query parameter
            if (locationid != null) queryParams.Add("locationid", ApiClient.ParameterToString(locationid)); // query parameter
            if (stationid != null) queryParams.Add("stationid", ApiClient.ParameterToString(stationid)); // query parameter
            if (startdate != null) queryParams.Add("startdate", ApiClient.ParameterToString(startdate?.ToString("yyyy-MM-dd"))); // query parameter
            if (enddate != null) queryParams.Add("enddate", ApiClient.ParameterToString(enddate?.ToString("yyyy-MM-dd"))); // query parameter
            if (units != null) queryParams.Add("units", ApiClient.ParameterToString(units)); // query parameter
            if (sortfield != null) queryParams.Add("sortfield", ApiClient.ParameterToString(sortfield)); // query parameter
            if (sortorder != null) queryParams.Add("sortorder", ApiClient.ParameterToString(sortorder)); // query parameter
            if (limit != null) queryParams.Add("limit", ApiClient.ParameterToString(limit)); // query parameter
            if (offset != null) queryParams.Add("offset", ApiClient.ParameterToString(offset)); // query parameter
            if (includemetadata != null) queryParams.Add("includemetadata", ApiClient.ParameterToString(includemetadata)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling FindData: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling FindData: " + response.ErrorMessage, response.ErrorMessage);

            return (DataResult)ApiClient.Deserialize(response.Content, typeof(DataResult), response.Headers);
        }

    }
}
