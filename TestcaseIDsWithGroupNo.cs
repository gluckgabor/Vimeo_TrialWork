using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium.NetCore.Test
{
    class TestcaseIDline
    {
        
        public int groupNo { get; set; }
        public int testcaseID { get; set; }
        public String testerToBeAssignedOnFE { get; set; }

        public TestcaseIDline(string testcaseIDline)
        {
            string[] testcaseIDlineSplitted = testcaseIDline.Split(";");
        
            testcaseID = Convert.ToInt32(testcaseIDlineSplitted[1]);
            groupNo = Convert.ToInt32(testcaseIDlineSplitted[5]);
        }
    }
}
