using System;
using System.Collections.Generic;
using System.IO;
using Dskow.Weather.Api;
using Dskow.Weather.Model;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dskow.Weather.Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly string token = "";// "fexlYyzvGTklrMMQjseldQihSSXYOFbx";

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();

        private IConfiguration Configuration;

        private readonly WeatherConfig _secrets;

        [TestInitialize]
        public void Init()
        {
            Configuration = TestHelper.GetApplicationConfiguration(TestContext.CurrentContext.TestDirectory);
        }

        public UnitTest1(IOptions<WeatherConfig> secrets)
        {
            _secrets = secrets.Value;
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets<WeatherConfig>();
            //.AddEnvironmentVariables();
            IConfigurationSection configurationSection = Configuration.GetSection(nameof(WeatherConfig));
            token = configurationSection["WeatherToken"];
            Action<WeatherConfig> configureOptions = null;
            var services = new ServiceCollection()
                .Configure<WeatherConfig>(configureOptions)
                .AddOptions()
                .BuildServiceProvider();

            services.GetService<SecretConsumer>();
        }

        [TestMethod]
        public void TestMethod1()
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
            System.Collections.Generic.List<string> datatypeid = null;
            System.Collections.Generic.List<string> locationid = null;
            System.Collections.Generic.List<string> stationid = null;
            DateTime? startdate = null;
            DateTime? enddate = null;
            string sortfield = null;
            string sortorder = null;
            long? limit = null;
            long? offset = null;
            var response = apiInstance.FindDatasets(datatypeid, locationid, stationid, startdate, enddate, sortfield, sortorder, limit, offset);
            Assert.IsInstanceOfType(response, typeof(DatasetResult), "response is DatasetResult");
            Assert.AreEqual(expected.Count, response.Metadata.Resultset.Count, "dataset response count match");
        }
    }

    internal class Startup
    {
    }
}
