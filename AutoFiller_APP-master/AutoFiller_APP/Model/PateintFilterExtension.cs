using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFiller_APP.Model
{
    public static class PateintFilterExtension
    {
        public static List<PatientExportModel> PatientFilters(this IEnumerable<PatientExportModel> request, bool isAll, DateTime startDate, DateTime endDate, string gender, string address, string phoneNo, string email)
        {
            var result = request.ToList();
            if (isAll)
            {
                return result;
            }
            else
            {
                result = result.Where(d => Convert.ToDateTime(d._dateOfCreation).Date >= startDate.Date && Convert.ToDateTime(d._dateOfCreation).Date <= endDate.Date).ToList();

                if (!string.IsNullOrEmpty(gender))
                {
                    var type = gender == "Male" ? PatientExportModel.Sex.M : PatientExportModel.Sex.F;

                    result = result.Where(f => f._sex == type).ToList();
                }

                if (!string.IsNullOrEmpty(address))
                {
                    result = result.Where(f => f._addressCity.Trim().ToLower().Contains(address.Trim().ToLower()) ||
                                            f._addressStreet.Trim().ToLower().Contains(address.Trim().ToLower()) ||
                                            f._addressZip.Trim().ToLower().Contains(address.Trim().ToLower())).ToList();
                }

                if (!string.IsNullOrEmpty(phoneNo))
                {
                    result = result.Where(f => f._applicantMobileNumber.Trim().ToLower().Contains(phoneNo.Trim().ToLower()) ||
                                            f._applicantPhoneNumber.Trim().ToLower().Contains(phoneNo.Trim().ToLower())).ToList();
                }

                if (!string.IsNullOrEmpty(email))
                {
                    result = result.Where(f => f._applicantEmail.Trim().ToLower().Contains(phoneNo.Trim().ToLower())).ToList();
                }
                return result;
            }
        }

    }

    public class ItemGender
    {
        public ItemGender() { }

        public string Value { set; get; }
        public string Text { set; get; }
    }
}
