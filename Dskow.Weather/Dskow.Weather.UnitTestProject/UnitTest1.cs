using Dskow.Weather.Api;
using Dskow.Weather.Model;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Dskow.Weather.UnitTestProject
{
    /// <summary>
    /// These unit tests are turned off with the Ignore tag.  I included them to show working examples.
    /// here are some possible errors
    /// Error calling FindStations: {"status" : "429", "message" : "This token has reached its temporary request limit of 5 per second."}
    /// 'Error calling FindData: {"statusCode":"400","userMessage":"There was an error with the request.","developerMessage":"The date range must be less than 1 year."}'
    /// "{\"statusCode\":\"500\",\"userMessage\":\"An error occured while servicing your request.\",\"developerMessage\":\"An error occured while servicing your request.\"}"
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        private readonly string token = "";

        IConfiguration Configuration { get; set; }

        public UnitTest1()
        {
            var builder = new ConfigurationBuilder().AddUserSecrets<UnitTest1>();

            Configuration = builder.Build();
            token = Configuration["Weather:WeatherToken"];
        }

        [Ignore]
        [TestMethod]
        public void TestFindDatasets()
        {
            List<Dataset> expected = new List<Dataset>()
            {
                new Dataset()
                {
                    Datacoverage = 1,
                    Id = "GHCND",
                    Maxdate = DateTime.Parse("7/22/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("1/1/1763 12:00:00 AM"),
                    Name = "Daily Summaries",
                    Uid = "gov.noaa.ncdc:C00861"
                },
                new Dataset()
                {
                    Datacoverage = 1,
                    Id = "GSOM",
                    Maxdate = DateTime.Parse("6/1/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("1/1/1763 12:00:00 AM"),
                    Name = "Global Summary of the Month",
                    Uid = "gov.noaa.ncdc:C00946"
                },
                new Dataset()
                {
                    Datacoverage = 1,
                    Id = "GSOY",
                    Maxdate = DateTime.Parse("1/1/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("1/1/1763 12:00:00 AM"),
                    Name = "Global Summary of the Year",
                    Uid = "gov.noaa.ncdc:C00947"
                },
                new Dataset()
                {
                    Datacoverage = 0.95f,
                    Id = "NEXRAD2",
                    Maxdate = DateTime.Parse("7/22/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("6/5/1991 12:00:00 AM"),
                    Name = "Weather Radar (Level II)",
                    Uid = "gov.noaa.ncdc:C00345"
                },
                new Dataset()
                {
                    Datacoverage = 0.95f,
                    Id = "NEXRAD3",
                    Maxdate = DateTime.Parse("7/19/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/20/1994 12:00:00 AM"),
                    Name = "Weather Radar (Level III)",
                    Uid = "gov.noaa.ncdc:C00708"
                },
                new Dataset()
                {
                    Datacoverage = 1,
                    Id = "NORMAL_ANN",
                    Maxdate = DateTime.Parse("1/1/2010 12:00:00 AM"),
                    Mindate = DateTime.Parse("1/1/2010 12:00:00 AM"),
                    Name = "Normals Annual/Seasonal",
                    Uid = "gov.noaa.ncdc:C00821"
                },
                new Dataset()
                {
                    Datacoverage = 1,
                    Id = "NORMAL_DLY",
                    Maxdate = DateTime.Parse("12/31/2010 12:00:00 AM"),
                    Mindate = DateTime.Parse("1/1/2010 12:00:00 AM"),
                    Name = "Normals Daily",
                    Uid = "gov.noaa.ncdc:C00823"
                },
                new Dataset()
                {
                    Datacoverage = 1,
                    Id = "NORMAL_HLY",
                    Maxdate = DateTime.Parse("12/31/2010 12:00:00 AM"),
                    Mindate = DateTime.Parse("1/1/2010 12:00:00 AM"),
                    Name = "Normals Hourly",
                    Uid = "gov.noaa.ncdc:C00824"
                },
                new Dataset()
                {
                    Datacoverage = 1,
                    Id = "NORMAL_MLY",
                    Maxdate = DateTime.Parse("12/1/2010 12:00:00 AM"),
                    Mindate = DateTime.Parse("1/1/2010 12:00:00 AM"),
                    Name = "Normals Monthly",
                    Uid = "gov.noaa.ncdc:C00822"
                },
                new Dataset()
                {
                    Datacoverage = 0.25f,
                    Id = "PRECIP_15",
                    Maxdate = DateTime.Parse("1/1/2014 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/12/1970 12:00:00 AM"),
                    Name = "Precipitation 15 Minute",
                    Uid = "gov.noaa.ncdc:C00505"
                },
                new Dataset()
                {
                    Datacoverage = 1,
                    Id ="PRECIP_HLY",
                    Maxdate = DateTime.Parse("1/1/2014 12:00:00 AM"),
                    Mindate = DateTime.Parse("1/1/1900 12:00:00 AM"),
                    Name = "Precipitation Hourly",
                    Uid = "gov.noaa.ncdc:C00313"
                }
            };
            var apiInstance = new DatasetApi();
            apiInstance.ApiClient.AddDefaultHeader("token", token);
            List<string> datatypeid = null;
            List<string> locationid = null;
            List<string> stationid = null;
            DateTime? startdate = DateTime.Parse("5/1/2022");
            DateTime? enddate = DateTime.Parse("5/31/2022");
            string sortfield = null;
            string sortorder = null;
            long? limit = null;
            long? offset = null;
            var response = apiInstance.FindDatasets(datatypeid, locationid, stationid, startdate, enddate, sortfield, sortorder, limit, offset);
            Assert.IsInstanceOfType(response, typeof(DatasetResult), "response is DatasetResult");
            Assert.AreEqual(expected.Count, response.Metadata.Resultset.Count, "dataset response count match");
        }

        [Ignore]
        [TestMethod]
        public void TestFindDatacategories()
        {
            List<Datacategory> expected = new List<Datacategory>()
            {
                new Datacategory()
                {
                    Id = "EVAP",
                    Name = "Evaporation"
                },
                new Datacategory()
                {
                    Id = "LAND",
                    Name = "Land"
                },
                new Datacategory()
                {
                    Id = "PRCP",
                    Name = "Precipitation"
                },
                new Datacategory()
                {
                    Id = "SUN",
                    Name = "Sunshine"
                },
                new Datacategory()
                {
                    Id = "TEMP",
                    Name = "Air Temperature"
                },
                new Datacategory()
                {
                    Id = "WIND",
                    Name = "Wind"
                }
            };
            var apiInstance = new DatacategoryApi();
            apiInstance.ApiClient.AddDefaultHeader("token", token);
            List<string> locationid = null;
            List<string> stationid = null;
            DateTime? startdate = DateTime.Parse("5/1/2022");
            DateTime? enddate = DateTime.Parse("5/31/2022");
            string sortfield = null;
            string sortorder = null;
            long? limit = null;
            long? offset = null;
            List<string> datasetid = new List<string>() { "GHCND", "GSOM" };
            var response = apiInstance.FindDatacategories(datasetid, locationid, stationid, startdate, enddate, sortfield, sortorder, limit, offset);
            Assert.IsInstanceOfType(response, typeof(DatacategoryResult), "response is DatacategoryResult");
            Assert.AreEqual(expected.Count, response.Metadata.Resultset.Count, "datacategories response count match");
        }

        [Ignore]
        [TestMethod]
        public void TestFindLocationcategories()
        {
            List<Locationcategory> expected = new List<Locationcategory>()
            {
                new Locationcategory()
                {
                    Id = "CITY",
                    Name = "City"
                },
                new Locationcategory()
                {
                    Id = "CLIM_DIV",
                    Name = "Climate Division"
                },
                new Locationcategory()
                {
                    Id = "CLIM_REG",
                    Name = "Climate Region"
                },
                new Locationcategory()
                {
                    Id = "CNTRY",
                    Name = "Country"
                },
                new Locationcategory()
                {
                    Id = "CNTY",
                    Name = "County"
                },
                new Locationcategory()
                {
                    Id = "HYD_ACC",
                    Name = "Hydrologic Accounting Unit"
                },
                new Locationcategory()
                {
                    Id = "HYD_CAT",
                    Name = "Hydrologic Cataloging Unit"
                },
                new Locationcategory()
                {
                    Id = "HYD_REG",
                    Name = "Hydrologic Region"
                },
                new Locationcategory()
                {
                    Id = "HYD_SUB",
                    Name = "Hydrologic Subregion"
                },
                new Locationcategory()
                {
                    Id = "ST",
                    Name = "State"
                },
                new Locationcategory()
                {
                    Id = "US_TERR",
                    Name = "US Territory"
                },
                new Locationcategory()
                {
                    Id = "ZIP",
                    Name = "Zip Code"
                }
            };
            var apiInstance = new LocationcategoryApi();
            apiInstance.ApiClient.AddDefaultHeader("token", token);
            DateTime? startdate = DateTime.Parse("5/1/2022");
            DateTime? enddate = DateTime.Parse("5/31/2022");
            string sortfield = null;
            string sortorder = null;
            long? limit = null;
            long? offset = null;
            List<string> datasetid = new List<string>() { "GHCND", "GSOM" };
            var response = apiInstance.FindLocationcategories(datasetid, startdate, enddate, sortfield, sortorder, limit, offset);
            Assert.IsInstanceOfType(response, typeof(LocationcategoryResult), "response is LocationcategoryResult");
            Assert.AreEqual(expected.Count, response.Metadata.Resultset.Count, "Locationcategories response count match");
        }

        [Ignore]
        [TestMethod]
        public void TestFindLocations()
        {
            List<Location> expected = new List<Location>()
            {
                new Location()
                {
                    Datacoverage = 1,
                    Id = "CITY:US370009",
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("11/1/1871 12:00:00 AM"),
                    Name = "Fort Bragg, NC US"
                },
                new Location()
                {
                    Datacoverage = 1,
                    Id = "CITY:US370010",
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("10/1/1892 12:00:00 AM"),
                    Name = "Gastonia, NC US"
                },
                new Location()
                {
                    Datacoverage = 1,
                    Id = "CITY:US370011",
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("4/15/1892 12:00:00 AM"),
                    Name = "Greensboro, NC US"
                },
                new Location()
                {
                    Datacoverage = 1,
                    Id = "CITY:US370012",
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("3/1/1875 12:00:00 AM"),
                    Name = "Greenville, NC US"
                },
                new Location()
                {
                    Datacoverage = 1,
                    Id = "CITY:US370013",
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("6/1/1898 12:00:00 AM"),
                    Name = "Hendersonville, NC US"
                },
                new Location()
                {
                    Datacoverage = 1,
                    Id = "CITY:US370014",
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("1/1/1913 12:00:00 AM"),
                    Name = "Hickory, NC US"
                },
                new Location()
                {
                    Datacoverage = 1,
                    Id = "CITY:US370015",
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("9/1/1921 12:00:00 AM"),
                    Name = "Jacksonville, NC US"
                },
                new Location()
                {
                    Datacoverage = 1,
                    Id = "CITY:US370016",
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("9/1/1890 12:00:00 AM"),
                    Name = "New Bern, NC US"
                },
                new Location()
                {
                    Datacoverage = 1,
                    Id = "CITY:US370017",
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("7/12/1911 12:00:00 AM"),
                    Name = "Raleigh, NC US"
                },
                new Location()
                {
                    Datacoverage = 1,
                    Id = "CITY:US370018",
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("1/1/1893 12:00:00 AM"),
                    Name = "Roanoke Rapids, NC US"
                }
            };
            var apiInstance = new LocationApi();
            apiInstance.ApiClient.AddDefaultHeader("token", token);
            DateTime? startdate = DateTime.Parse("7/01/2019");
            DateTime? enddate = DateTime.Parse("7/18/2019");
            string sortfield = null;
            string sortorder = null;
            int limit = 10;
            int offset = 1380;
            List<string> datasetid = new List<string>() { "GHCND" };
            List<string> locationcategoryid = new List<string>() { "CITY" };
            List<string> datacategoryid = null;
            var response = apiInstance.FindLocations(datasetid, locationcategoryid, datacategoryid, startdate, enddate, sortfield, sortorder, limit, offset);
            Assert.IsInstanceOfType(response, typeof(LocationResult), "response is LocationResult");
            Assert.AreEqual(expected.Count, response.Results.Count, "Locations response count match");
        }

        [Ignore]
        [TestMethod]
        public void TestFindStations()
        {
            List<Station> expected = new List<Station>()
            {
                new Station()
                {
                    Datacoverage = 0.636f,
                    Elevation = 95.1f,
                    ElevationUnit = "METERS",
                    Id = "GHCND:US1NCJH0005",
                    Latitude = 35.6544f,
                    Longitude = -78.5093f,
                    Maxdate = DateTime.Parse("7/12/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("9/1/2007 12:00:00 AM"),
                    Name = "CLAYTON 2.9 W, NC US"
                },
                new Station()
                {
                    Datacoverage = 0.9492f,
                    Elevation = 91.1f,
                    ElevationUnit = "METERS",
                    Id = "GHCND:US1NCJH0014",
                    Latitude = 35.6317f,
                    Longitude = -78.4702f,
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("9/16/2007 12:00:00 AM"),
                    Name = "CLAYTON 1.3 SSW, NC US"
                },
                new Station()
                {
                    Datacoverage = 0.9202f,
                    Elevation = 81.1f,
                    ElevationUnit = "METERS",
                    Id = "GHCND:US1NCJH0063",
                    Latitude = 35.6726f,
                    Longitude = -78.4097f,
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("10/4/2014 12:00:00 AM"),
                    Name = "CLAYTON 3.3 ENE, NC US"
                },
                new Station()
                {
                    Datacoverage = 0.8704f,
                    Elevation = 105.5f,
                    ElevationUnit = "METERS",
                    Id = "GHCND:US1NCJH0082",
                    Latitude = 35.6743f,
                    Longitude = -78.4601f,
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("3/25/2018 12:00:00 AM"),
                    Name = "CLAYTON 1.9 N, NC US"
                },
                new Station()
                {
                    Datacoverage = 0.7631f,
                    Elevation = 113.1f,
                    ElevationUnit = "METERS",
                    Id = "GHCND:US1NCWK0001",
                    Latitude = 35.9696f,
                    Longitude = -78.6887f,
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("8/28/2007 12:00:00 AM"),
                    Name = "RALEIGH 10.3 N, NC US"
                },
                new Station()
                {
                    Datacoverage = 0.9321f,
                    Elevation = 110f,
                    ElevationUnit = "METERS",
                    Id = "GHCND:US1NCWK0002",
                    Latitude = 35.8057f,
                    Longitude = -78.6759f,
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("9/18/2007 12:00:00 AM"),
                    Name = "RALEIGH 1.5 SW, NC US"
                },
                new Station()
                {
                    Datacoverage = 0.9513f,
                    Elevation = 95.1f,
                    ElevationUnit = "METERS",
                    Id = "GHCND:US1NCWK0003",
                    Latitude = 35.8143f,
                    Longitude = -78.5478f,
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("8/25/2007 12:00:00 AM"),
                    Name = "RALEIGH 6.2 E, NC US"
                },
                new Station()
                {
                    Datacoverage = 0.8709f,
                    Elevation = 125f,
                    ElevationUnit = "METERS",
                    Id = "GHCND:US1NCWK0004",
                    Latitude = 35.7133f,
                    Longitude = -78.7854f,
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("8/30/2007 12:00:00 AM"),
                    Name = "APEX 3.4 ESE, NC US"
                },
                new Station()
                {
                    Datacoverage = 0.8784f,
                    Elevation = 123.1f,
                    ElevationUnit = "METERS",
                    Id ="GHCND:US1NCWK0006",
                    Latitude = 35.6489f,
                    Longitude = -78.8171f,
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("9/4/2007 12:00:00 AM"),
                    Name = "HOLLY SPRINGS 1.1 ESE, NC US"
                },
                new Station()
                {
                    Datacoverage = 1,
                    Elevation = 103.9f,
                    ElevationUnit = "METERS",
                    Id = "GHCND:US1NCWK0013",
                    Latitude = 35.8624f,
                    Longitude = -78.5665f,
                    Maxdate = DateTime.Parse("7/22/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("10/8/2007 12:00:00 AM"),
                    Name = "RALEIGH 5.9 ENE, NC US"
                }
            };
            var apiInstance = new StationApi();
            apiInstance.ApiClient.AddDefaultHeader("token", token);
            DateTime? startdate = DateTime.Parse("7/01/2019");
            DateTime? enddate = DateTime.Parse("7/18/2019");
            string sortfield = null;
            string sortorder = null;
            int limit = 10;
            int offset = 0;
            List<string> datasetid = new List<string>() { "GHCND" };
            List<string> locationid = new List<string>() { "CITY:US370017" };
            List<string> datacategoryid = null;
            List<string> datatypeid = null;
            List<string> extent = null;
            var response = apiInstance.FindStations(datasetid, locationid, datacategoryid, datatypeid, extent, startdate, enddate, sortfield, sortorder, limit, offset);
            Assert.IsInstanceOfType(response, typeof(StationResult), "response is StationResult");
            Assert.AreEqual(expected.Count, response.Results.Count, "Stations response count match");
        }

        /// <summary>
        /// This test finds up to the first 10 data for 
        /// city US370017 (Raleigh, NC US)
        /// station US1NCWK0013 (RALEIGH 5.9 ENE, NC US),
        /// between July 1, 2019 and July 22, 2019,
        /// in the GHCND (Daily Summaries) dataset
        /// </summary>
        [Ignore]
        [TestMethod]
        public void TestFindData()
        {
            List<Data> expected = new List<Data>()
            {
                new Data()
                {
                    Attributes = ",,N,",
                    Datatype= "PRCP",
                    Date = DateTime.Parse("7/1/2019 12:00:00 AM"),
                    Station = "GHCND:US1NCWK0013",
                    Value = "0"
                },
                new Data()
                {
                    Attributes = ",,N,",
                    Datatype="SNOW",
                    Date = DateTime.Parse("7/1/2019 12:00:00 AM"),
                    Station = "GHCND:US1NCWK0013",
                    Value = "0"
                },
                new Data()
                {
                    Attributes = ",,N,",
                    Datatype= "PRCP",
                    Date = DateTime.Parse("7/2/2019 12:00:00 AM"),
                    Station = "GHCND:US1NCWK0013",
                    Value = "0"
                },
                new Data()
                {
                    Attributes = ",,N,",
                    Datatype= "SNOW",
                    Date = DateTime.Parse("7/2/2019 12:00:00 AM"),
                    Station = "GHCND:US1NCWK0013",
                    Value = "0"
                },
                new Data()
                {
                    Attributes = ",,N,",
                    Datatype= "PRCP",
                    Date = DateTime.Parse("7/3/2019 12:00:00 AM"),
                    Station = "GHCND:US1NCWK0013",
                    Value = "0"
                },
                new Data()
                {
                    Attributes = ",,N,",
                    Datatype= "SNOW",
                    Date = DateTime.Parse("7/3/2019 12:00:00 AM"),
                    Station = "GHCND:US1NCWK0013",
                    Value = "0"
                },
                new Data()
                {
                    Attributes = ",,N,",
                    Datatype= "PRCP",
                    Date = DateTime.Parse("7/4/2019 12:00:00 AM"),
                    Station = "GHCND:US1NCWK0013",
                    Value = "0"
                },
                new Data()
                {
                    Attributes = ",,N,",
                    Datatype= "SNOW",
                    Date = DateTime.Parse("7/4/2019 12:00:00 AM"),
                    Station = "GHCND:US1NCWK0013",
                    Value = "0"
                },
                new Data()
                {
                    Attributes = "T,,N,",
                    Datatype= "PRCP",
                    Date = DateTime.Parse("7/5/2019 12:00:00 AM"),
                    Station = "GHCND:US1NCWK0013",
                    Value = "0"
                },
                new Data()
                {
                    Attributes = ",,N,",
                    Datatype= "PRCP",
                    Date = DateTime.Parse("7/6/2019 12:00:00 AM"),
                    Station = "GHCND:US1NCWK0013",
                    Value = "28"
                }
            };
            var apiInstance = new DataApi();
            apiInstance.ApiClient.AddDefaultHeader("token", token);
            DateTime? startdate = DateTime.Parse("7/01/2019");
            DateTime? enddate = DateTime.Parse("7/22/2019");
            string sortfield = null;
            string sortorder = null;
            int limit = 10;
            int offset = 0;
            string datasetid = "GHCND";
            List<string> locationid = new List<string>() { "CITY:US370017" };
            List<string> stationid = new List<string>() { "GHCND:US1NCWK0013" };
            List<string> datatypeid = null;
            string units = null;
            bool? includemetadata = false;
            var response = apiInstance.FindData(datasetid, startdate, enddate, datatypeid, locationid, stationid, units, sortfield, sortorder, limit, offset, includemetadata);
            Assert.IsInstanceOfType(response, typeof(DataResult), "response is DataResult");
            Assert.AreEqual(expected.Count, response.Results.Count, "Data response count match");
        }

        /// <summary>
        /// This test finds up to the first 10 available data types for
        /// station US1NCWK0013 (RALEIGH 5.9 ENE, NC US)
        /// any time range
        /// PRCP (Precipitation) data category
        /// in either the GHCND (Daily Summaries) or GSOM (Global Summary of the Month) dataset
        /// when date range is added only 4 of the 8 are found.
        /// </summary>
        [Ignore]
        [TestMethod]
        public void TestFindDatatypes()
        {
            List<Datatype> expected = new List<Datatype>()
            {
                //new Datatype()
                //{
                //    Datacoverage = 1,
                //    Id = "DAPR",
                //    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                //    Mindate = DateTime.Parse("5/11/1832 12:00:00 AM"),
                //    Name = "Number of days included in the multiday precipitation total (MDPR)"
                //},
                new Datatype()
                {
                    Datacoverage = 1,
                    Id = "DSNW",
                    Maxdate = DateTime.Parse("6/1/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/1/1840 12:00:00 AM"),
                    Name = "Number days with snow depth > 1 inch."
                },
                new Datatype()
                {
                    Datacoverage = 1,
                    Id = "EMSN",
                    Maxdate = DateTime.Parse("6/1/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/1/1840 12:00:00 AM"),
                    Name = "Extreme maximum snowfall for the period."
                },
                //new Datatype()
                //{
                //    Datacoverage = 1,
                //    Id = "MDPR",
                //    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                //    Mindate = DateTime.Parse("5/11/1832 12:00:00 AM"),
                //    Name = "Multiday precipitation total (use with DAPR and DWPR, if available)"
                //},
                //new Datatype()
                //{
                //    Datacoverage = 1,
                //    Id = "MXSD",
                //    Maxdate = DateTime.Parse("3/1/2016 12:00:00 AM"),
                //    Mindate = DateTime.Parse("1/1/1857 12:00:00 AM"),
                //    Name = "Maximum snow depth"
                //},
                //new Datatype()
                //{
                //    Datacoverage = 1,
                //    Id = "SNWD",
                //    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                //    Mindate = DateTime.Parse("1/18/1857 12:00:00 AM"),
                //    Name = "Snow depth"
                //},
                new Datatype()
                {
                    Datacoverage = 1,
                    Id = "TPCP",
                    Maxdate = DateTime.Parse("3/1/2016 12:00:00 AM"),
                    Mindate = DateTime.Parse("1/1/1781 12:00:00 AM"),
                    Name = "Total precipitation"
                },
                new Datatype()
                {
                    Datacoverage = 1,
                    Id = "TSNW",
                    Maxdate = DateTime.Parse("3/1/2016 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/1/1840 12:00:00 AM"),
                    Name = "Total snow fall"
                }
            };
            var apiInstance = new DatatypeApi();
            apiInstance.ApiClient.AddDefaultHeader("token", token);
            List<string> locationid = null;
            List<string> stationid = new List<string>() { "GHCND:US1NCWK0013" };
            DateTime? startdate = DateTime.Parse("5/1/2022");
            DateTime? enddate = DateTime.Parse("5/31/2022");
            string sortfield = null;
            string sortorder = null;
            long? limit = 10;
            long? offset = 0;
            List<string> datasetid = new List<string>() { "GHCND", "GSOM" };
            List<string> datacategoryid = new List<string>() { "PRCP" };
            var response = apiInstance.FindDatatypes(datasetid, locationid, datacategoryid, stationid, startdate, enddate, sortfield, sortorder, limit, offset);
            Assert.IsInstanceOfType(response, typeof(DatatypeResult), "response is DatatypeResult");
            Assert.AreEqual(expected.Count, response.Metadata.Resultset.Count, "datatype response count match");
        }

        /// <summary>
        /// This test finds up to the first 10 data for 
        /// city US370017 (Raleigh, NC US)
        /// station US1NCWK0013 (RALEIGH 5.9 ENE, NC US),
        /// between August 1, 2010 and June 22, 2011,
        /// in the GSOM (Global Summary of the Month) dataset
        /// 'Error calling FindData: {"statusCode":"400","userMessage":"There was an error with the request.","developerMessage":"The date range must be less than 1 year."}'
        /// </summary>
        [Ignore]
        [TestMethod]
        public void TestFindEtremeSnowData()
        {
            List<Data> expected = new List<Data>()
            {
                new Data()
                {
                    Attributes = "5,,N,30,+",
                    Datatype= "EMSN",
                    Date = DateTime.Parse("9/1/2010 12:00:00 AM"),
                    Station = "GHCND:US1NCWK0013",
                    Value = "0"
                },
                new Data()
                {
                    Attributes = "3,,N,26,",
                    Datatype= "EMSN",
                    Date = DateTime.Parse("12/1/2010 12:00:00 AM"),
                    Station = "GHCND:US1NCWK0013",
                    Value = "127"
                }
            };
            var apiInstance = new DataApi();
            apiInstance.ApiClient.AddDefaultHeader("token", token);
            DateTime? startdate = DateTime.Parse("8/01/2010");
            DateTime? enddate = DateTime.Parse("6/22/2011");
            string sortfield = null;
            string sortorder = null;
            int limit = 10;
            int offset = 0;
            string datasetid = "GSOM";
            List<string> locationid = new List<string>() { "CITY:US370017" };
            List<string> stationid = new List<string>() { "GHCND:US1NCWK0013" };
            List<string> datatypeid = new List<string>() { "EMSN" };
            string units = null;
            bool? includemetadata = false;
            var response = apiInstance.FindData(datasetid, startdate, enddate, datatypeid, locationid, stationid, units, sortfield, sortorder, limit, offset, includemetadata);
            Assert.IsInstanceOfType(response, typeof(DataResult), "response is DataResult");
            Assert.AreEqual(expected.Count, response.Results.Count, "Data response count match");
        }

        /// <summary>
        /// This test finds up to the first 10 available data types for
        /// station US1NCWK0013 (RALEIGH 5.9 ENE, NC US)
        /// any time range
        /// PRCP (Precipitation) data category
        /// in either the GHCND (Daily Summaries) or GSOM (Global Summary of the Month) dataset
        /// </summary>
        [Ignore]
        [TestMethod]
        public void TestNEXRAD3FindDatatypes()
        {
            List<Datatype> expected = new List<Datatype>()
            {
                new Datatype()
                {
                    Datacoverage = 1,
                    Id = "DAPR",
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/11/1832 12:00:00 AM"),
                    Name = "Number of days included in the multiday precipitation total (MDPR)"
                },
                new Datatype()
                {
                    Datacoverage = 1,
                    Id = "DP05",
                    Maxdate = DateTime.Parse("2/1/2017 12:00:00 AM"),
                    Mindate = DateTime.Parse("1/1/1781 12:00:00 AM"),
                    Name = "Number of days with greater than or equal to 0.5 inch of precipitation"
                },
                new Datatype()
                {
                    Datacoverage = 1,
                    Id = "DSNW",
                    Maxdate = DateTime.Parse("6/1/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/1/1840 12:00:00 AM"),
                    Name = "Number days with snow depth > 1 inch."
                },
                new Datatype()
                {
                    Datacoverage = 1,
                    Id = "EMSN",
                    Maxdate = DateTime.Parse("6/1/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/1/1840 12:00:00 AM"),
                    Name = "Extreme maximum snowfall for the period."
                },
                new Datatype()
                {
                    Datacoverage = 1,
                    Id = "MDPR",
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/11/1832 12:00:00 AM"),
                    Name = "Multiday precipitation total (use with DAPR and DWPR, if available)"
                },
                new Datatype()
                {
                    Datacoverage = 1,
                    Id = "MXSD",
                    Maxdate = DateTime.Parse("3/1/2016 12:00:00 AM"),
                    Mindate = DateTime.Parse("1/1/1857 12:00:00 AM"),
                    Name = "Maximum snow depth"
                },
                new Datatype()
                {
                    Datacoverage = 1,
                    Id = "SNWD",
                    Maxdate = DateTime.Parse("7/23/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("1/18/1857 12:00:00 AM"),
                    Name = "Snow depth"
                },
                new Datatype()
                {
                    Datacoverage = 1,
                    Id = "TPCP",
                    Maxdate = DateTime.Parse("3/1/2016 12:00:00 AM"),
                    Mindate = DateTime.Parse("1/1/1781 12:00:00 AM"),
                    Name = "Total precipitation"
                },
                new Datatype()
                {
                    Datacoverage = 1,
                    Id = "TSNW",
                    Maxdate = DateTime.Parse("3/1/2016 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/1/1840 12:00:00 AM"),
                    Name = "Total snow fall"
                }
            };
            var apiInstance = new DatatypeApi();
            apiInstance.ApiClient.AddDefaultHeader("token", token);
            List<string> locationid = null;
            List<string> stationid = new List<string>() { "GHCND:US1NCWK0013" };
            DateTime? startdate = null;
            DateTime? enddate = null;
            string sortfield = null;
            string sortorder = null;
            long? limit = 10;
            long? offset = 0;
            List<string> datasetid = new List<string>() { "NEXRAD3" };
            List<string> datacategoryid = null;
            var response = apiInstance.FindDatatypes(datasetid, locationid, datacategoryid, stationid, startdate, enddate, sortfield, sortorder, limit, offset);
            Assert.IsInstanceOfType(response, typeof(DatatypeResult), "response is DatatypeResult");
            Assert.AreEqual(expected.Count, response.Metadata.Resultset.Count, "datatype response count match");
        }

        /// <summary>
        /// Find up to the first stations for
        /// city US370017 (Raleigh, NC US)
        /// between July 1, 2019 and July 22, 2019,
        /// in the NEXRAD3 (Weather Radar (Level III)) dataset
        /// </summary>
        [Ignore]
        [TestMethod]
        public void TestNEXRAD3FindStations()
        {
            List<Station> expected = new List<Station>()
            {
                new Station()
                {
                    Datacoverage = 0.95f,
                    Elevation = 34.1f,
                    ElevationUnit = "METERS",
                    Id = "NEXRAD:KAKQ",
                    Latitude = 36.98389f,
                    Longitude = -77.0075f,
                    Maxdate = DateTime.Parse("7/19/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("1/1/1995 12:00:00 AM"),
                    Name = "NORFOLK RICH, VA US"
                },
                new Station()
                {
                    Datacoverage = 0.95f,
                    Elevation = 874.2f,
                    ElevationUnit = "METERS",
                    Id = "NEXRAD:KFCX",
                    Latitude = 37.02417f,
                    Longitude = -80.27417f,
                    Maxdate = DateTime.Parse("7/19/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("2/13/1995 12:00:00 AM"),
                    Name = "WILMINGTON, NC US"
                },
                new Station()
                {
                    Datacoverage = 0.95f,
                    Elevation = 9.4f,
                    ElevationUnit = "METERS",
                    Id = "NEXRAD:KMHX",
                    Latitude = 34.77583f,
                    Longitude = -76.87639f,
                    Maxdate = DateTime.Parse("7/19/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("6/17/1994 12:00:00 AM"),
                    Name = "MOREHEAD CITY, NC US"
                },
                new Station()
                {
                    Datacoverage = 0.95f,
                    Elevation = 106.1f,
                    ElevationUnit = "METERS",
                    Id = "NEXRAD:KRAX",
                    Latitude = 35.66528f,
                    Longitude = -78.49f,
                    Maxdate = DateTime.Parse("7/20/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/9/1995 12:00:00 AM"),
                    Name = "RALEIGH DURHAM, NC US"
                }
            };
            var apiInstance = new StationApi();
            apiInstance.ApiClient.AddDefaultHeader("token", token);
            DateTime? startdate = DateTime.Parse("7/01/2019");
            DateTime? enddate = DateTime.Parse("7/22/2019");
            string sortfield = null;
            string sortorder = null;
            int limit = 10;
            int offset = 0;
            List<string> datasetid = new List<string>() { "NEXRAD3" };
            List<string> locationid = new List<string>() { "CITY:US370017" };
            List<string> datacategoryid = null;
            List<string> datatypeid = null;
            List<string> extent = null;
            var response = apiInstance.FindStations(datasetid, locationid, datacategoryid, datatypeid, extent, startdate, enddate, sortfield, sortorder, limit, offset);
            Assert.IsInstanceOfType(response, typeof(StationResult), "response is StationResult");
            Assert.AreEqual(expected.Count, response.Results.Count, "Stations response count match");
        }

        /// <summary>
        /// This test finds up to the third set of 10 available data types for
        /// station NEXRAD:KRAX (RALEIGH DURHAM, NC US)
        /// any time range
        /// PRCP (Precipitation) data category
        /// in either the NEXRAD3 (Weather Radar (Level III)) dataset
        /// </summary>
        [Ignore]
        [TestMethod]
        public void TestNEXRAD3KRAXFindDatatypes()
        {
            List<Datatype> expected = new List<Datatype>()
            {
                new Datatype()
                {
                    Datacoverage = 0.95f,
                    Id = "N1R",
                    Maxdate = DateTime.Parse("7/20/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/20/1994 12:00:00 AM"),
                    Name = "Base Reflectivity (approx. elev. angle: 1.5 deg)"
                },
                new Datatype()
                {
                    Datacoverage = 0.95f,
                    Id = "N1S",
                    Maxdate = DateTime.Parse("7/20/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/20/1994 12:00:00 AM"),
                    Name = "Storm Relative Velocity (approx. elev. angle: 1.5 deg)"
                },
                new Datatype()
                {
                    Datacoverage = 0.95f,
                    Id = "N1V",
                    Maxdate = DateTime.Parse("7/20/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/20/1994 12:00:00 AM"),
                    Name = "Base Velocity (approx. elev. angle: 1.5 deg)"
                },
                new Datatype()
                {
                    Datacoverage = 0.95f,
                    Id = "N1X",
                    Maxdate = DateTime.Parse("7/20/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("3/8/2011 12:00:00 AM"),
                    Name = "Differential Reflectivity (approx. elev. angle: 1.5 deg)"
                },
                new Datatype()
                {
                    Datacoverage = 0.95f,
                    Id = "N2C",
                    Maxdate = DateTime.Parse("7/20/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("3/8/2011 12:00:00 AM"),
                    Name = "Correlation Coefficient (approx. elev. angle: 2.4 deg)"
                },
                new Datatype()
                {
                    Datacoverage = 0.95f,
                    Id = "N2H",
                    Maxdate = DateTime.Parse("7/20/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("3/8/2011 12:00:00 AM"),
                    Name = "Hydrometeor Classification (approx. elev.: 2.4 deg)"
                },
                new Datatype()
                {
                    Datacoverage = 0.95f,
                    Id = "N2K",
                    Maxdate = DateTime.Parse("7/20/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("3/8/2011 12:00:00 AM"),
                    Name = "Specific Differential Phase (approx. elev.: 2.4 deg)"
                },
                new Datatype()
                {
                    Datacoverage = 0.95f,
                    Id = "N2Q",
                    Maxdate = DateTime.Parse("7/20/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/20/1994 12:00:00 AM"),
                    Name = "Digital Base Reflectivity (approx. elev. angle: 2.4 deg)"
                },
                new Datatype()
                {
                    Datacoverage = 0.95f,
                    Id = "N2R",
                    Maxdate = DateTime.Parse("7/20/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/20/1994 12:00:00 AM"),
                    Name = "Base Reflectivity (approx. elev. angle: 2.4 deg)"
                },
                new Datatype()
                {
                    Datacoverage = 0.95f,
                    Id = "N2S",
                    Maxdate = DateTime.Parse("7/20/2019 12:00:00 AM"),
                    Mindate = DateTime.Parse("5/20/1994 12:00:00 AM"),
                    Name = "Storm Relative Velocity (approx. elev. angle: 2.4 deg)"
                }
            };
            var apiInstance = new DatatypeApi();
            apiInstance.ApiClient.AddDefaultHeader("token", token);
            List<string> locationid = null;
            List<string> stationid = new List<string>() { "NEXRAD:KRAX" };
            DateTime? startdate = null;
            DateTime? enddate = null;
            string sortfield = null;
            string sortorder = null;
            long? limit = 10;
            long? offset = 30;
            List<string> datasetid = new List<string>() { "NEXRAD3" };
            List<string> datacategoryid = null;
            var response = apiInstance.FindDatatypes(datasetid, locationid, datacategoryid, stationid, startdate, enddate, sortfield, sortorder, limit, offset);
            Assert.IsInstanceOfType(response, typeof(DatatypeResult), "response is DatatypeResult");
            Assert.AreEqual(expected.Count, response.Metadata.Resultset.Count, "datatype response count match");
        }

        /// <summary>
        /// This test finds up to the first 10 data for 
        /// N1R (Base Reflectivity (approx. elev. angle: 1.5 deg))
        /// city US370017 (Raleigh, NC US)
        /// station KRAX (RALEIGH DURHAM, NC US),
        /// between July 18, 2019 and July 20, 2011,
        /// in the NEXRAD3 (Weather Radar (Level III)) dataset
        /// NOTE:  I have not been able to get data from NEXRAD3
        /// "{\"statusCode\":\"500\",\"userMessage\":\"An error occured while servicing your request.\",\"developerMessage\":\"An error occured while servicing your request.\"}"
        /// </summary>
        [Ignore]
        [TestMethod]
        public void TestFindN1RData()
        {
            List<Data> expected = new List<Data>()
            {
                new Data()
                {
                    Attributes = "",
                    Datatype= "",
                    Date = DateTime.Parse("9/1/2010 12:00:00 AM"),
                    Station = "NEXRAD:KRAX",
                    Value = "0"
                },
                new Data()
                {
                    Attributes = "",
                    Datatype= "",
                    Date = DateTime.Parse("12/1/2010 12:00:00 AM"),
                    Station = "NEXRAD:KRAX",
                    Value = "127"
                }
            };
            var apiInstance = new DataApi();
            apiInstance.ApiClient.AddDefaultHeader("token", token);
            DateTime? startdate = DateTime.Parse("7/19/2019 2:00:00 PM");
            DateTime? enddate = DateTime.Parse("7/19/2019 3:00:00 PM");
            string sortfield = null;
            string sortorder = null;
            int limit = 10;
            int offset = 0;
            string datasetid = "NEXRAD3";
            List<string> locationid = new List<string>() { "CITY:US370017" };
            List<string> stationid = new List<string>() { "NEXRAD:KRAX" };
            List<string> datatypeid = null;// new List<string>() { "N1R" };
            string units = null;
            bool? includemetadata = false;
            var response = apiInstance.FindData(datasetid, startdate, enddate, datatypeid, locationid, stationid, units, sortfield, sortorder, limit, offset, includemetadata);
            Assert.IsInstanceOfType(response, typeof(DataResult), "response is DataResult");
            Assert.AreEqual(expected.Count, response.Results.Count, "Data response count match");
        }

    }
}
