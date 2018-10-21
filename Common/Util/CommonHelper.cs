//------------------------------------------------------------------------------
// The contents of this file are subject to the nopCommerce Public License Version 1.0 ("License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at  http://www.nopCommerce.com/License.aspx. 
// 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. 
// See the License for the specific language governing rights and limitations under the License.
// 
// The Original Code is nopCommerce.
// The Initial Developer of the Original Code is NopSolutions.
// All Rights Reserved.
// 
// Contributor(s): _______. 
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

namespace Common
{
    /// <summary>
    /// Represents a common helper
    /// </summary>
    public class CommonHelper
    {
        #region Methods
        /// <summary>
        /// Verifies that a string is in valid e-mail format
        /// </summary>
        /// <param name="Email">Email to verify</param>
        /// <returns>true if the string is a valid e-mail address and false if it's not</returns>
        public static bool IsValidEmail(string Email)
        {
            return Regex.IsMatch(Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// Gets query string value by name
        /// </summary>
        /// <param name="Name">Parameter name</param>
        /// <returns>Query string value</returns>
        public static string QueryString(string Name)
        {
            string result = string.Empty;
            if (HttpContext.Current != null && HttpContext.Current.Request.QueryString[Name] != null)
                result = HttpContext.Current.Request.QueryString[Name].ToString();
            return result;
        }

        /// <summary>
        /// Gets boolean value from query string 
        /// </summary>
        /// <param name="Name">Parameter name</param>
        /// <returns>Query string value</returns>
        public static bool QueryStringBool(string Name)
        {
            string resultStr = QueryString(Name).ToUpperInvariant();
            return (resultStr == "YES" || resultStr == "TRUE" || resultStr == "1");
        }

        /// <summary>
        /// Gets integer value from query string 
        /// </summary>
        /// <param name="Name">Parameter name</param>
        /// <returns>Query string value</returns>
        public static decimal QueryStringDecimal(string Name)
        {
            string resultStr = QueryString(Name).ToUpperInvariant();
            decimal  result;
            decimal.TryParse (resultStr, out result);
            return result;
        }

        /// <summary>
        /// Gets integer value from query string 
        /// </summary>
        /// <param name="Name">Parameter name</param>
        /// <param name="DefaultValue">Default value</param>
        /// <returns>Query string value</returns>
        public static decimal QueryStringDecimal(string Name, int DefaultValue)
        {
            string resultStr = QueryString(Name).ToUpperInvariant();
            if (resultStr.Length > 0)
            {
                return decimal.Parse(resultStr);
            }
            return DefaultValue;
        }
        /// <summary>
        /// Gets integer value from query string 
        /// </summary>
        /// <param name="Name">Parameter name</param>
        /// <returns>Query string value</returns>
        public static int QueryStringInt(string Name)
        {
            string resultStr = QueryString(Name).ToUpperInvariant();
            int result;
            Int32.TryParse(resultStr, out result);
            return result;
        }

        /// <summary>
        /// Gets integer value from query string 
        /// </summary>
        /// <param name="Name">Parameter name</param>
        /// <param name="DefaultValue">Default value</param>
        /// <returns>Query string value</returns>
        public static int QueryStringInt(string Name, int DefaultValue)
        {
            string resultStr = QueryString(Name).ToUpperInvariant();
            if (resultStr.Length > 0)
            {
                return Int32.Parse(resultStr);
            }
            return DefaultValue;
        }

        /// <summary>
        /// Gets GUID value from query string 
        /// </summary>
        /// <param name="Name">Parameter name</param>
        /// <returns>Query string value</returns>
        public static Guid? QueryStringGUID(string Name)
        {
            string resultStr = QueryString(Name).ToUpperInvariant();
            Guid? result = null;
            try
            {
                result = new Guid(resultStr);
            }
            catch
            {
            }
            return result;
        }

        /// <summary>
        /// Gets BigInt value from query string 
        /// </summary>
        /// <param name="Name">Parameter name</param>
        /// <returns>Query string value</returns>
        public static decimal QueryStringInt64(string Name)
        {
            string resultStr = QueryString(Name).ToUpperInvariant();
            Int64  result;
            Int64.TryParse(resultStr, out result);
            return result;
        }

        /// <summary>
        /// Gets integer value from query string 
        /// </summary>
        /// <param name="Name">Parameter name</param>
        /// <param name="DefaultValue">Default value</param>
        /// <returns>Query string value</returns>
        public static decimal QueryStringInt64(string Name, int DefaultValue)
        {
            string resultStr = QueryString(Name).ToUpperInvariant();
            if (resultStr.Length > 0)
            {
                return Int64.Parse(resultStr);
            }
            return DefaultValue;
        }


        /// <summary>
        /// Selects item
        /// </summary>
        /// <param name="List">List</param>
        /// <param name="Value">Value to select</param>
        public static void SelectListItem(DropDownList List, object Value)
        {
            if (List.Items.Count != 0)
            {
                ListItem selectedItem = List.SelectedItem;
                if (selectedItem != null)
                    selectedItem.Selected = false;
                if (Value != null)
                {
                    selectedItem = List.Items.FindByValue(Value.ToString());
                    if (selectedItem != null)
                        selectedItem.Selected = true;
                }
            }
        }

        /// <summary>
        /// Gets server variable by name
        /// </summary>
        /// <param name="Name">Name</param>
        /// <returns>Server variable</returns>
        public static string ServerVariables(string Name)
        {
            string tmpS = String.Empty;
            try
            {
                if (HttpContext.Current.Request.ServerVariables[Name] != null)
                {

                    tmpS = HttpContext.Current.Request.ServerVariables[Name].ToString();

                }
            }
            catch
            {
                tmpS = String.Empty;
            }
            return tmpS;
        }

        /// <summary>
        /// Gets a value indicating whether requested admin page
        /// </summary>
        public static bool IsAdmin()
        {
            string thisPageURL = GetThisPageURL(false);
            if (string.IsNullOrEmpty(thisPageURL))
                return false;

            string adminUrl1 = GetAppLocation(false) + "Admin";
            string adminUrl2 = GetAppLocation(true) + "Admin";            
            bool flag1 = thisPageURL.ToLowerInvariant().StartsWith(adminUrl1.ToLower());
            bool flag2 = thisPageURL.ToLowerInvariant().StartsWith(adminUrl2.ToLower());
            bool isAdmin = flag1 || flag2;
            return isAdmin;
        }

        /// <summary>
        /// Gets this page name
        /// </summary>
        /// <returns></returns>
        public static string GetThisPageURL(bool includeQueryString)
        {
            string URL = string.Empty;
            if (HttpContext.Current == null)
                return URL;

            if (includeQueryString)
            {
                string storeHost = GetAppHost(false);
                if (storeHost.EndsWith("/"))
                    storeHost = storeHost.Substring(0, storeHost.Length - 1);
                URL = storeHost + HttpContext.Current.Request.RawUrl;
            }
            else
            {
                URL = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path);
            }
            return URL;
        }

        /// <summary>
        /// Gets store location
        /// </summary>
        /// <param name="UseSSL">Use SSL</param>
        /// <returns>Store location</returns>
        public static string GetAppLocation(bool UseSSL)
        {
            string result = GetAppHost(UseSSL);
            if (result.EndsWith("/"))
                result = result.Substring(0, result.Length - 1);
            result = result + HttpContext.Current.Request.ApplicationPath;
            if (!result.EndsWith("/"))
                result += "/";

            return result;
        }

        /// <summary>
        /// Gets store admin location
        /// </summary>
        /// <param name="UseSSL">Use SSL</param>
        /// <returns>Store admin location</returns>
        public static string GetAppAdminLocation(bool UseSSL)
        {
            string result = GetAppLocation(UseSSL);
            result += "Admin/";

            return result;
        }

        /// <summary>
        /// Gets store host location
        /// </summary>
        /// <param name="UseSSL">Use SSL</param>
        /// <returns>Store host location</returns>
        public static string GetAppHost(bool UseSSL)
        {
            string result = "http://" + ServerVariables("HTTP_HOST");
            if (!result.EndsWith("/"))
                result += "/";

            if (UseSSL)
            {
                ////////if (!String.IsNullOrEmpty(SettingManager.GetSettingValue("Common.SharedSSL")))
                ////////{
                ////////    result = SettingManager.GetSettingValue("Common.SharedSSL");
                ////////}
                ////////else
                ////////{
                ////////    result = result.Replace("http:/", "https:/");
                ////////    result = result.Replace("www.www", "www");
                ////////}
            }

            if (!result.EndsWith("/"))
                result += "/";

            return result;
        }

        /// <summary>
        /// Reloads current page
        /// </summary>
        public static void ReloadCurrentPage()
        {
            ReloadCurrentPage(false);
        }

        /// <summary>
        /// Reloads current page
        /// </summary>
        /// <param name="UseSSL">Use SSL</param>
        public static void ReloadCurrentPage(bool UseSSL)
        {
            string storeHost = GetAppHost(UseSSL);
            if (storeHost.EndsWith("/"))
                storeHost = storeHost.Substring(0, storeHost.Length - 1);
            string URL = storeHost + HttpContext.Current.Request.RawUrl;
            HttpContext.Current.Response.Redirect(URL);
        }

        /// <summary>
        /// Modifies query string
        /// </summary>
        /// <param name="url">Url to modify</param>
        /// <param name="queryStringModification">Query string modification</param>
        /// <param name="targetLocationModification">Target location modification</param>
        /// <returns>New url</returns>
        public static string ModifyQueryString(string url, string queryStringModification, string targetLocationModification)
        {
            string str = string.Empty;
            string str2 = string.Empty;
            if (url.Contains("#"))
            {
                str2 = url.Substring(url.IndexOf("#") + 1);
                url = url.Substring(0, url.IndexOf("#"));
            }
            if (url.Contains("?"))
            {
                str = url.Substring(url.IndexOf("?") + 1);
                url = url.Substring(0, url.IndexOf("?"));
            }
            if (!string.IsNullOrEmpty(queryStringModification))
            {
                if (!string.IsNullOrEmpty(str))
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (string str3 in str.Split(new char[] { '&' }))
                    {
                        if (!string.IsNullOrEmpty(str3))
                        {
                            string[] strArray = str3.Split(new char[] { '=' });
                            if (strArray.Length == 2)
                            {
                                dictionary[strArray[0]] = strArray[1];
                            }
                            else
                            {
                                dictionary[str3] = null;
                            }
                        }
                    }
                    foreach (string str4 in queryStringModification.Split(new char[] { '&' }))
                    {
                        if (!string.IsNullOrEmpty(str4))
                        {
                            string[] strArray2 = str4.Split(new char[] { '=' });
                            if (strArray2.Length == 2)
                            {
                                dictionary[strArray2[0]] = strArray2[1];
                            }
                            else
                            {
                                dictionary[str4] = null;
                            }
                        }
                    }
                    StringBuilder builder = new StringBuilder();
                    foreach (string str5 in dictionary.Keys)
                    {
                        if (builder.Length > 0)
                        {
                            builder.Append("&");
                        }
                        builder.Append(str5);
                        if (dictionary[str5] != null)
                        {
                            builder.Append("=");
                            builder.Append(dictionary[str5]);
                        }
                    }
                    str = builder.ToString();
                }
                else
                {
                    str = queryStringModification;
                }
            }
            if (!string.IsNullOrEmpty(targetLocationModification))
            {
                str2 = targetLocationModification;
            }
            return (url + (string.IsNullOrEmpty(str) ? "" : ("?" + str)) + (string.IsNullOrEmpty(str2) ? "" : ("#" + str2)));
        }

        /// <summary>
        /// Remove query string from url
        /// </summary>
        /// <param name="url">Url to modify</param>
        /// <param name="queryString">Query string to remove</param>
        /// <returns>New url</returns>
        public static string RemoveQueryString(string url, string queryString)
        {
            string str = string.Empty;
            if (url.Contains("?"))
            {
                str = url.Substring(url.IndexOf("?") + 1);
                url = url.Substring(0, url.IndexOf("?"));
            }
            if (!string.IsNullOrEmpty(queryString))
            {
                if (!string.IsNullOrEmpty(str))
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (string str3 in str.Split(new char[] { '&' }))
                    {
                        if (!string.IsNullOrEmpty(str3))
                        {
                            string[] strArray = str3.Split(new char[] { '=' });
                            if (strArray.Length == 2)
                            {
                                dictionary[strArray[0]] = strArray[1];
                            }
                            else
                            {
                                dictionary[str3] = null;
                            }
                        }
                    }
                    dictionary.Remove(queryString);

                    StringBuilder builder = new StringBuilder();
                    foreach (string str5 in dictionary.Keys)
                    {
                        if (builder.Length > 0)
                        {
                            builder.Append("&");
                        }
                        builder.Append(str5);
                        if (dictionary[str5] != null)
                        {
                            builder.Append("=");
                            builder.Append(dictionary[str5]);
                        }
                    }
                    str = builder.ToString();
                }
            }
            return (url + (string.IsNullOrEmpty(str) ? "" : ("?" + str)));
        }

        /// <summary>
        /// Ensures that requested page is not secured (http://)
        /// </summary>
        public static void EnsureNonSSL()
        {
            if (HttpContext.Current.Request.IsSecureConnection)
            {
                ReloadCurrentPage(false);
            }
        }

        /// <summary>
        /// Sets cookie
        /// </summary>
        /// <param name="cookieName">Cookie name</param>
        /// <param name="cookieValue">Cookie value</param>
        /// <param name="ts">Timespan</param>
        public static void SetCookie(String cookieName, string cookieValue, TimeSpan ts)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(cookieName);
                cookie.Value = HttpContext.Current.Server.UrlEncode(cookieValue);
                DateTime dt = DateTime.Now;
                cookie.Expires = dt.Add(ts);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch (Exception exc)
            {
                ////////LogManager.InsertLog(LogTypeEnum.CustomerError, exc.Message, exc);
            }
        }

        /// <summary>
        /// Gets cookie string
        /// </summary>
        /// <param name="cookieName">Cookie name</param>
        /// <param name="decode">Decode cookie</param>
        /// <returns>Cookie string</returns>
        public static String GetCookieString(String cookieName, bool decode)
        {
            if (HttpContext.Current.Request.Cookies[cookieName] == null)
            {
                return String.Empty;
            }
            try
            {
                string tmp = HttpContext.Current.Request.Cookies[cookieName].Value.ToString();
                if (decode)
                    tmp = HttpContext.Current.Server.UrlDecode(tmp);
                return tmp;
            }
            catch
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Gets boolean value from cookie
        /// </summary>
        /// <param name="cookieName">Cookie name</param>
        /// <returns>Result</returns>
        public static bool GetCookieBool(String cookieName)
        {
            string str1 = GetCookieString(cookieName, true).ToUpperInvariant();
            return (str1 == "TRUE" || str1 == "YES" || str1 == "1");
        }

        /// <summary>
        /// Gets integer value from cookie
        /// </summary>
        /// <param name="cookieName">Cookie name</param>
        /// <returns>Result</returns>
        public static int GetCookieInt(String cookieName)
        {
            string str1 = GetCookieString(cookieName, true);
            if (!String.IsNullOrEmpty(str1))
                return Convert.ToInt32(str1);
            else
                return 0;
        }

        /// <summary>
        /// Gets a decimal value of an input string in US locale
        /// </summary>
        /// <param name="Str">The string</param>
        /// <returns>The value</returns>
        public static decimal ConvertToDecimalNative(string Str)
        {
            return ConvertToDecimalNative(Str, decimal.Zero);
        }

        /// <summary>
        /// Gets a decimal value of an input string in US locale
        /// </summary>
        /// <param name="Str">The string</param>
        /// <param name="DefaultValue">The default value</param>
        /// <returns>The value</returns>
        public static decimal ConvertToDecimalNative(string Str, decimal DefaultValue)
        {
            if (Str.Length > 0)
            {
                return decimal.Parse(Str, new CultureInfo("en-US"));
            }
            return DefaultValue;
        }

        /// <summary>
        /// Converts the value of the specified System.Decimal number to its equivalent System.String representation.
        /// </summary>
        /// <param name="Value">Value</param>
        /// <returns>The System.String equivalent of the value of value.</returns>
        public static string ConvertToStringFromDecimalNative(decimal Value)
        {
            return Convert.ToString(Value, new CultureInfo("en-US"));
        }

        /// <summary>
        /// IIF
        /// </summary>
        /// <param name="condition">Condition</param>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <returns>Result</returns>
        static public int IIF(bool condition, int a, int b)
        {
            int x = 0;
            if (condition)
                x = a;
            else
                x = b;
            return x;
        }

        /// <summary>
        /// IIF
        /// </summary>
        /// <param name="condition">Condition</param>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <returns>Result</returns>
        static public bool IIF(bool condition, bool a, bool b)
        {
            bool x = false;
            if (condition)
                x = a;
            else
                x = b;
            return x;
        }

        /// <summary>
        /// IIF
        /// </summary>
        /// <param name="condition">Condition</param>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <returns>Result</returns>
        static public float IIF(bool condition, Single a, Single b)
        {
            float x = 0;
            if (condition)
            {
                x = a;
            }
            else
            {
                x = b;
            }
            return x;
        }

        /// <summary>
        /// IIF
        /// </summary>
        /// <param name="condition">Condition</param>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <returns>Result</returns>
        static public double IIF(bool condition, double a, double b)
        {
            double x = 0;
            if (condition)
            {
                x = a;
            }
            else
            {
                x = b;
            }
            return x;
        }

        /// <summary>
        /// IIF
        /// </summary>
        /// <param name="condition">Condition</param>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <returns>Result</returns>
        static public decimal IIF(bool condition, decimal a, decimal b)
        {
            decimal x = 0;
            if (condition)
            {
                x = a;
            }
            else
            {
                x = b;
            }
            return x;
        }

        /// <summary>
        /// IIF
        /// </summary>
        /// <param name="condition">Condition</param>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <returns>Result</returns>
        static public string IIF(bool condition, String a, String b)
        {
            String x = String.Empty;
            if (condition)
            {
                x = a;
            }
            else
            {
                x = b;
            }
            return x;
        }

       
        /// <summary>
        /// Write XML to response
        /// </summary>
        /// <param name="xml">XML</param>
        /// <param name="Filename">Filename</param>
        public static void WriteResponseXML(string xml, string Filename)
        {
            if (!String.IsNullOrEmpty(xml))
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(xml);
                ((XmlDeclaration)document.FirstChild).Encoding = "utf-8";
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.Charset = "utf-8";
                response.ContentType = "text/xml";
                response.AddHeader("content-disposition", string.Format("attachment; filename={0}", Filename));
                response.BinaryWrite(Encoding.UTF8.GetBytes(document.InnerXml));
                response.End();
            }
        }

        /// <summary>
        /// Generate random digit code
        /// </summary>
        /// <param name="Length">Length</param>
        /// <returns>Result string</returns>
        public static string GenerateRandomDigitCode(int Length)
        {
            Random random = new Random();
            string s = "";
            for (int i = 0; i < Length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

        /// <summary>
        /// Convert enum for front-end
        /// </summary>
        /// <param name="s">Input string</param>
        /// <returns>Covnerted string</returns>
        public static string ConvertEnum(string s)
        {
            string result = string.Empty;
            char[] letters = s.ToCharArray();
            foreach (char c in letters)
                if (c.ToString() != c.ToString().ToLower())
                    result += " " + c.ToString();
                else
                    result += c.ToString();
            return result;
        }

        /// <summary>
        /// Fills drop down list with values of enumaration
        /// </summary>
        /// <param name="List">Dropdownlist</param>
        /// <param name="enumType">Enumeration</param>
        public static void FillDropDownWithEnum(DropDownList List, Type enumType)
        {
            if (List == null)
            {
                throw new ArgumentNullException("List");
            }
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("enumType must be enum type");
            }

            List.Items.Clear();
            string[] strArray = Enum.GetNames(enumType);
            foreach (string str2 in strArray)
            {
                int enumValue = (int)Enum.Parse(enumType, str2, true);
                ListItem ddlItem = new ListItem(CommonHelper.ConvertEnum(str2), enumValue.ToString());
                List.Items.Add(ddlItem);
            }
        }
        
       
        #endregion
    }
}
