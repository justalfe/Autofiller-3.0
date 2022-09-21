using AutoFiller_API;
using AutoFiller_API.Model;
using AutoFiller_APP.Entites;
using AutoFiller_APP.Model;
using DocumentFormat.OpenXml.Bibliography;
using Newtonsoft.Json;
using Org.BouncyCastle.Ocsp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFiller_APP.Manager
{
    class APIManager
    {
        public static bool CheckServer()
        {
            try
            {
                var rc = new RestClient(Utility.GetServerString() + "/get");
                var rr = new RestRequest(Method.GET);
                rr.Timeout = 10000;
                var result = rc.Execute(rr);
                return result.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch
            {
            }
            return false;
        }
        public static bool DeleteForm(string id)
        {
            try
            {
                var rc = new RestClient(Utility.GetServerString() + "/delete?id=" + (string)id);
                var rr = new RestRequest(Method.GET);
                var result = rc.Execute(rr);
                return result.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch
            {
                MessageBox.Show(Utility.Constants.UNABLE_TO_DELETE);
            }
            return false;
        }

        public static List<I693> GetForm()
        {
            try
            {
                var rc = new RestClient(Utility.GetServerString() + "/get");
                var rr = new RestRequest(Method.GET);
                var result = rc.Execute(rr);
                var decryptedString = AES.Decrypt(result.Content.Replace("\"", ""));
                var forms = JsonConvert.DeserializeObject<List<I693>>(decryptedString);
                if (forms == null)
                    return new List<I693>();
                return forms;
            }
            catch
            {
            }
            MessageBox.Show(Utility.Constants.UNABLE_TO_RETRIEVE_DATA);
            return new List<I693>();
        }

        public static bool SavePatients(List<I693> items)
        {
            int resultCount = 0;
            foreach (var item in items)
            {
                var patient = new Patient();
                patient.UniqueId = item._uniqueId;
                patient.I693Data = JsonConvert.SerializeObject(item);
                patient.CreatedDate = DateTime.Now;
                resultCount += SavePatientData(patient, item._uniqueId);
            }

            if (resultCount > 0)
                return true;

            return false;
        }

        private static int SavePatientData(Patient model, string uniqueId)
        {
            int resultCount = 0;
            try
            {
                using (var db = new AutoDBContext())
                {
                    if (!db.Patients.Any(p => p.UniqueId.Equals(uniqueId)))
                    {
                        db.Patients.Add(model);
                        resultCount = db.SaveChanges();
                    }
                }
            }
            catch (Exception ex) { }
            return resultCount;
        }     

        public static QuestionnaireStatistics GetStatistics(DateTime dt)
        {
            try
            {
                var rc = new RestClient(Utility.GetServerString() + "/s/get");
                var rr = new RestRequest(Method.POST);
                rr.AddJsonBody(new
                {
                    period = dt,
                });
                var result = rc.Execute(rr);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<QuestionnaireStatistics>(result.Content);
            }
            catch
            {
            }
            MessageBox.Show(Utility.Constants.UNABLE_TO_RETRIEVE_DATA);
            return null;
        }

        public static List<DateTime> GetExistingStatistics()
        {
            try
            {
                var rc = new RestClient(Utility.GetServerString() + "/s/all");
                var rr = new RestRequest(Method.POST);
                var result = rc.Execute(rr);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<List<DateTime>>(result.Content);
            }
            catch (Exception e)
            {
            }
            MessageBox.Show(Utility.Constants.UNABLE_TO_RETRIEVE_DATA);
            return new List<DateTime>();
        }
    }
}
