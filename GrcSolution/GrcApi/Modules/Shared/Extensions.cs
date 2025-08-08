using Newtonsoft.Json;
using System.Globalization;
using System.Threading.Channels;
using System.Xml.Linq;

namespace Arm.GrcApi.Modules.Shared
{
    public static class Extensions
    {
        public static string FormatExpiryDate(this DateTime dateTime)
        {
            string yearPart = dateTime.Year.ToString();
            return $"{Monthformate(dateTime.Month)}/{yearPart[2].ToString()}{yearPart[3].ToString()}";
        }

        private static string Monthformate(int month)
        {
            if (month <= 9)
            {
                return $"0{month}";
            }
            return month.ToString();
        }
        public static string[] GetPhoneNumberCode(this string data)
        {

            string[] phoneNumber = null;
            if (data.StartsWith("+234"))
            {
                phoneNumber = new string[4];

                phoneNumber[0] = data.Substring(0, 4);
                data = data.Remove(0, 4);
                phoneNumber[1] = data.Substring(0, 3);
                data = data.Remove(0, 3);
                phoneNumber[2] = data.Substring(0, 3);
                data = data.Remove(0, 3);
                phoneNumber[3] = data;
            }
            else
            {
                data = "+234" + data.Substring(1);
                phoneNumber = new string[4];

                phoneNumber[0] = data.Substring(0, 4);
                data = data.Remove(0, 4);
                phoneNumber[1] = data.Substring(0, 3);
                data = data.Remove(0, 3);
                phoneNumber[2] = data.Substring(0, 3);
                data = data.Remove(0, 3);
                phoneNumber[3] = data;
            }

            return phoneNumber;
        }

        public static string ConvertToString(this DateTime date)
        {
            string dateString = date.ToString("yymm");
            return dateString;
        }

        public static int GetCurrentAge(this DateTime dateTime)
        {
            var currentDate = DateTime.Now;
            int age = currentDate.Year - dateTime.Year;

            if (currentDate < dateTime.AddYears(age))
            {
                age--;
            }

            return age;
        }
               
        public static string ToJson(this object value)
        {
            if (value == null) return "{ }";
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.SerializeObject(value, Formatting.Indented, settings);
        }


        public static string RemoveMiddlename(this string inputString)
        {
            if (inputString.Length > 34)
            {
                inputString = Truncate(inputString);
            }

            return inputString;
        }


        private static string Truncate(this string input)
        {
            var middleword = "";

            if (!String.IsNullOrEmpty(input))
            {
                middleword = input.Split(' ')[1];

                input = input.Replace($" {middleword}", "");


            }
            return input;
        }

        public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(
                  this IEnumerable<TSource> source, int size)
        {
            TSource[] bucket = null;
            var count = 0;

            foreach (var item in source)
            {
                if (bucket == null)
                    bucket = new TSource[size];

                bucket[count++] = item;
                if (count != size)
                    continue;

                yield return bucket;

                bucket = null;
                count = 0;
            }

            if (bucket != null && count > 0)
                yield return bucket.Take(count).ToArray();
        }

        public static string ToSentenceCase(this string phrase)
        {
            if (!string.IsNullOrEmpty(phrase))
            {
                var convertedString = phrase.Split(new char[0]).ToList().Select(e => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(e.ToLower()) + " ");
                return string.Concat(convertedString).TrimEnd();
            }
            return String.Empty;
        }

        public static string GetNonFormattedPhoneNumberTrimPlusSign(this string FormattedPhoneNumber)
        {
            String MobilePhone = FormattedPhoneNumber + "";

            if (MobilePhone.StartsWith("+"))
            {
                MobilePhone = MobilePhone.Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "").Trim();
            }
            else
            {
                MobilePhone = MobilePhone.Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "").Trim();
                if (MobilePhone.Trim().Length == 11)
                {
                    MobilePhone = MobilePhone.StartsWith("0") ? "234" + MobilePhone.Remove(0, 1) : MobilePhone;
                }
                if (MobilePhone.Trim().Length == 10)
                {
                    MobilePhone = "234" + MobilePhone;
                }

            }
            return MobilePhone;
        }


    }
}
