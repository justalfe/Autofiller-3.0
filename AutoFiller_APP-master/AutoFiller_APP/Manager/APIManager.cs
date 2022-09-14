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

        public static bool SaveCivilSurgeonPreparer(CivilSurgeon_Preparer surgeon, bool preparer)
        {
            try
            {
                var url = "/cs/add";
                if (preparer)
                    url = "/p/add";
                var rc = new RestClient(Utility.GetServerString() + url);
                var rr = new RestRequest(Method.POST);
                rr.AddJsonBody(JsonConvert.SerializeObject(surgeon));

                var result = rc.Execute(rr);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var fileData = APIManager.GetCivilSurgeonPreparer();

                    var collectionList = new List<CivilSurgeon_Preparer>();
                    //if preparer bit is false then adding surgeon else adding preparere
                    if (!preparer)
                    {
                        if (fileData != null)
                        {
                            collectionList = JsonConvert.DeserializeObject<List<CivilSurgeon_Preparer>>(fileData.surgeon.ToString());
                        }

                        var latestObj = collectionList.LastOrDefault();
                        if (latestObj != null)
                        {
                            //SAVE IN DATABASE
                            using (var context = new AutoDBContext())
                            {
                                if (!context.CivilSurgeons.Any(cs => cs.FormId.Equals(latestObj._id)))
                                {
                                    var sergeon = new CivilSurgeon();
                                    sergeon.FormId = latestObj._id;
                                    sergeon.FormData = JsonConvert.SerializeObject(latestObj);
                                    sergeon.CreatedDate = DateTime.Now;
                                    context.CivilSurgeons.Add(sergeon);
                                    context.SaveChanges();
                                }
                                else
                                {

                                    var sergeon = context.CivilSurgeons.Single(cs => cs.FormId.Equals(latestObj._id));
                                    sergeon.FormData = JsonConvert.SerializeObject(latestObj);
                                    sergeon.LastUpdated = DateTime.Now;
                                    context.SaveChanges();
                                }
                            }
                            //END
                        }
                    }
                    else
                    {

                        if (fileData != null)
                        {
                            collectionList = JsonConvert.DeserializeObject<List<CivilSurgeon_Preparer>>(fileData.preparer.ToString());
                        }

                        var latestObj = collectionList.LastOrDefault();
                        if (latestObj != null)
                        {
                            //SAVE IN DATABASE
                            using (var context = new AutoDBContext())
                            {
                                if (!context.Preparers.Any(cs => cs.FormId.Equals(latestObj._id)))
                                {
                                    var preparerObj = new Preparer();
                                    preparerObj.FormId = latestObj._id;
                                    preparerObj.FormData = JsonConvert.SerializeObject(latestObj);
                                    preparerObj.CreatedDate = DateTime.Now;
                                    context.Preparers.Add(preparerObj);
                                    context.SaveChanges();
                                }
                                else
                                {
                                    var preparerObj = context.Preparers.Single(pr => pr.FormId.Equals(latestObj._id));
                                    preparerObj.FormData = JsonConvert.SerializeObject(latestObj);
                                    preparerObj.LastUpdated = DateTime.Now;
                                    context.SaveChanges();

                                }
                            }
                            //END
                        }
                    }



                    return true;
                }

            }
            catch
            {
            }
            MessageBox.Show(Utility.Constants.UNABLE_TO_RETRIEVE_DATA);
            return false;
        }


        public static bool SaveCivilSurgeonFromFile(string uniqId, bool isPreparer)
        {
            try
            {
                var fileData = APIManager.GetCivilSurgeonPreparer();

                var collectionList = new List<CivilSurgeon_Preparer>();
                //if preparer bit is false then adding surgeon else adding preparere
                if (!isPreparer)
                {
                    if (fileData != null)
                    {
                        collectionList = JsonConvert.DeserializeObject<List<CivilSurgeon_Preparer>>(fileData.surgeon.ToString());
                    }

                    var latestObj = collectionList.Where(d => d._id == uniqId).FirstOrDefault();
                    if (latestObj != null)
                    {
                        //SAVE IN DATABASE
                        using (var context = new AutoDBContext())
                        {
                            if (!context.CivilSurgeons.Any(cs => cs.FormId.Equals(latestObj._id)))
                            {
                                var sergeon = new CivilSurgeon();
                                sergeon.FormId = latestObj._id;
                                sergeon.FormData = JsonConvert.SerializeObject(latestObj);
                                sergeon.CreatedDate = DateTime.Now;
                                context.CivilSurgeons.Add(sergeon);
                                context.SaveChanges();
                            }
                            else
                            {

                                var sergeon = context.CivilSurgeons.Single(cs => cs.FormId.Equals(latestObj._id));
                                sergeon.FormData = JsonConvert.SerializeObject(latestObj);
                                sergeon.LastUpdated = DateTime.Now;
                                context.SaveChanges();
                            }
                        }
                        //END
                    }
                }
                else
                {

                    if (fileData != null)
                    {
                        collectionList = JsonConvert.DeserializeObject<List<CivilSurgeon_Preparer>>(fileData.preparer.ToString());
                    }

                    var latestObj = collectionList.Where(d => d._id == uniqId).FirstOrDefault();
                    if (latestObj != null)
                    {
                        //SAVE IN DATABASE
                        using (var context = new AutoDBContext())
                        {
                            if (!context.Preparers.Any(cs => cs.FormId.Equals(latestObj._id)))
                            {
                                var preparerObj = new Preparer();
                                preparerObj.FormId = latestObj._id;
                                preparerObj.FormData = JsonConvert.SerializeObject(latestObj);
                                preparerObj.CreatedDate = DateTime.Now;
                                context.Preparers.Add(preparerObj);
                                context.SaveChanges();
                            }
                            else
                            {
                                var preparerObj = context.Preparers.Single(pr => pr.FormId.Equals(latestObj._id));
                                preparerObj.FormData = JsonConvert.SerializeObject(latestObj);
                                preparerObj.LastUpdated = DateTime.Now;
                                context.SaveChanges();

                            }
                        }
                        //END
                    }
                }



                return true;


            }
            catch
            {
            }
            MessageBox.Show(Utility.Constants.UNABLE_TO_RETRIEVE_DATA);
            return false;
        }

        public static bool DeleteCivilSurgeonPreparer(string id, bool preparer)
        {
            try
            {
                var url = "/cs/delete";
                if (preparer)
                    url = "/p/delete";
                var rc = new RestClient(Utility.GetServerString() + url);
                var rr = new RestRequest(Method.POST);
                rr.AddJsonBody(id);
                var result = rc.Execute(rr);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    return true;
            }
            catch
            {
            }
            MessageBox.Show(Utility.Constants.UNABLE_TO_RETRIEVE_DATA);
            return false;
        }

        public static dynamic GetCivilSurgeonPreparer()
        {
            try
            {
                var rc = new RestClient(Utility.GetServerString() + "/csp/get");
                var rr = new RestRequest(Method.POST);
                var result = rc.Execute(rr);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject(result.Content);
            }
            catch
            {
            }
            MessageBox.Show(Utility.Constants.UNABLE_TO_RETRIEVE_DATA);
            return null;
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
