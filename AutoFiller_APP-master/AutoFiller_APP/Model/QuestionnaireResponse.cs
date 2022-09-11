using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFiller_API.Model
{
    public class QuestionnaireResponse
    {
        public enum Marketing_Source
        {
            Google = 0,
            Facebook = 1,
            Yelp = 2,
            Lawyer = 3,
            TV = 4,
            Newspaper = 5,
            Radio = 6,
            Bing = 7,
            Other = 8,
        }

        public Marketing_Source _answer;
        public string _extraData;

        public QuestionnaireResponse(Marketing_Source answer, string extraData)
        {
            _answer = answer;
            _extraData = extraData;
        }
    }
}