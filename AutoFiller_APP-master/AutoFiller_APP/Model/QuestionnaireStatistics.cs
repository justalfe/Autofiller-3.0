using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AutoFiller_API.Model
{
    public class QuestionnaireStatistics
    {
        public const string STATISTICS_DIRECTORY = "./statistics/";

        public int _googleCount=0;
        public int _facebookCount=0;
        public int _yelpCount=0;
        public int _lawyerCount=0;
        public int _tvCount=0;
        public int _newspaperCount=0;
        public int _radioCount=0;
        public int _bingCount=0;
        public List<string> _other = new List<string>();
        public DateTime _dateTime = DateTime.Now;

        public class Storage
        {
            public static QuestionnaireStatistics Get(DateTime date)
            {
                var path = STATISTICS_DIRECTORY + date.Year + "_" + date.Month + ".json";
                if (!File.Exists(path))
                    return new QuestionnaireStatistics();
                var json = File.ReadAllText(path);
                var qs = JsonConvert.DeserializeObject<QuestionnaireStatistics>(json);
                return qs;
            }
            public static List<DateTime> ListOfStatistics()
            {
                List<DateTime> foundDates = new List<DateTime>();
                var files = Directory.GetFiles(STATISTICS_DIRECTORY);
                foreach (var file in files)
                {
                    var split = file.Split('.')[0].Split('_');
                    var date = new DateTime(int.Parse(split[0]), int.Parse(split[1]), 1);
                }
                return foundDates;
            }
            public static void Save(QuestionnaireStatistics qs)
            {
                var file = File.CreateText(STATISTICS_DIRECTORY + qs._dateTime.Year + "_" + qs._dateTime.Month + ".json");
                file.WriteLine(JsonConvert.SerializeObject(qs));
                file.Close();
            }
            public static void AddStatistic(QuestionnaireResponse qr)
            {
                var qs = Get(DateTime.UtcNow);
                switch (qr._answer)
                {
                    case QuestionnaireResponse.Marketing_Source.Bing:
                        qs._bingCount++;
                        break;
                    case QuestionnaireResponse.Marketing_Source.Facebook:
                        qs._facebookCount++;
                        break;
                    case QuestionnaireResponse.Marketing_Source.Google:
                        qs._googleCount++;
                        break;
                    case QuestionnaireResponse.Marketing_Source.Lawyer:
                        qs._lawyerCount++;
                        break;
                    case QuestionnaireResponse.Marketing_Source.Newspaper:
                        qs._newspaperCount++;
                        break;
                    case QuestionnaireResponse.Marketing_Source.Radio:
                        qs._radioCount++;
                        break;
                    case QuestionnaireResponse.Marketing_Source.TV:
                        qs._tvCount++;
                        break;
                    case QuestionnaireResponse.Marketing_Source.Yelp:
                        qs._yelpCount++;
                        break;
                    case QuestionnaireResponse.Marketing_Source.Other:
                        qs._other.Add(qr._extraData);
                        break;
                }
                Save(qs);
            }
        }
    }
}