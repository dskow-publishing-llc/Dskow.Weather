# Dskow.Weather
A .Net standard nuget library that implements NOAA's climate Data Online REST api

This was not sponsor nor maintained by NOAA. I wanted to see how much effort it was to take a REST interface and create a usable nuget package.  This turned out to take me only a day to implement the basics.

Here are some helpful links:

* [Dataset help](https://www.ncdc.noaa.gov/cdo-web/datasets#NORMAL_DLY)
* [My developer notes](Developer.md) to help explain how this nuget package was developed.
* [Main Climate Data Online (cdo) website](https://www.ncdc.noaa.gov/cdo-web/)
* [NOAA's cdo Documentation](http://www1.ncdc.noaa.gov/pub/data/cdo/documentation)
* [NOAA's cdo Api](https://www.ncdc.noaa.gov/cdo-web/webservices/v2) which is what I implemented.
* [OpenApi json file](swagger.json)
* [OpneApi yaml file](swagger.yaml)

# Usage

The date needs to be set to `yyyy-MM-dd` format for the api calls to work. The FindData api call can also take `YYYY-MM-DDThh:mm:ss` format. Optional parameters can be set to null.  

## Required parameters 
The FindData api call requires `startdate`, `enddate`, and `datasetid` parameters. Check NOAA's cdo api site for info on required parameters to REST api.

```
Configuration.DateTimeFormat = "yyyy-MM-dd";
var startdate = new DateTime(2012, 5, 1);
var enddate = new DateTime(2012, 5, 31);
List<string> stationid = null;

var apiInstance = new DatasetApi();
DatasetResult result = apiInstance.FindDatasets(datatypeid, locationid, stationid, startdate, enddate,
  sortfield, sortorder, limit, offset);

var apiInstance = new DatacategoryApi();
DatacategoryResult result = apiInstance.FindDatacategories(datasetid, locationid, stationid, startdate,
  enddate, sortfield, sortorder, limit, offset);

var apiInstance = new DatatypeApi();
DatatypeResult result = apiInstance.FindDatatypes(datasetid, locationid, datacategoryid, stationid,
  startdate, enddate, sortfield, sortorder, limit, offset);

var apiInstance = new LocationcategoryApi();
LocationcategoryResult result = apiInstance.FindLocationcategories(datasetid, startdate, enddate,
  sortfield, sortorder, limit, offset);

var apiInstance = new LocationApi();
LocationResult result = apiInstance.FindLocations(datasetid, locationcategoryid, datacategoryid,
  startdate, enddate, sortfield, sortorder, limit, offset);

var apiInstance = new StationApi();
StationResult result = apiInstance.FindStations(datasetid, locationid, datacategoryid, datatypeid,
  extent, startdate, enddate, sortfield, sortorder, limit, offset);

var apiInstance = new DataApi();
DataResult result = apiInstance.FindData(datasetid, startdate, enddate, datatypeid, locationid, stationid,
  units, sortfield, sortorder, limit, offset, includemetadata);

```

