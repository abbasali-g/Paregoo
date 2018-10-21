using System;
using System.Collections.Generic;
 
using System.Text;

namespace Lawyer.Common.CS.Update
{
   public  class UpdateStatus
    {
        public static  string  LastVersion { get; set; }
        public static  bool  IsExistNewVersion { get; set; }
        public static bool RestartApp { get; set; }
        public static string LastVersionName { get; set; }
        public static bool CanClose { get; set; }
        public static bool CloseClick { get; set; }
        public static bool InUpdating { get; set; }


    }

   public enum ResultUpdate
   {
       exit, uptodate, update, fatal
   };

   public enum UpdateType
   { d, c, s };

}
