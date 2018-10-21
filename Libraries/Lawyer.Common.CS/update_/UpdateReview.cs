using System;
using System.Collections.Generic;
 
using System.Text;

namespace Lawyer.Common.CS.Update
{
    public class UpdateReview
    {
        public String updVersionName { get; set; }
        public String updFileName { get; set; }
        public Byte[] updContent { get; set; }
        public Int32 updVersion { get; set; }

    }
}
