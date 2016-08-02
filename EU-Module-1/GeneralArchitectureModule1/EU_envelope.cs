using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eCTD_indexer.GeneralArchitectureModule1
{
    public class EU_envelope
    {
        public EU_envelope()
        {
            this.envelopeCountry = new List<String>();
        }

        // String variables for EU envelope
        public String UUID { get; set; }
        public String trackingNumber { get; set; }
        public String INN { get; set; }
        public String submDescr { get; set; }
        public String relSeq { get; set; }
        public String procType { get; set; }
        public String submType { get; set; }
        public String country { get; set; }
        public String language { get; set; }
        public String m131identifier { get; set; }
        public String m1euPath { get; set; }
        public int m1euPathIndex { get; set; }
        public String sequence { get; set; }
        public String appCountry { get; set; } //used to determine country in 12-form
        public String sequencePath { get; set; }
        public String applicationMode { get; set; }
        public String appHighLevelNo { get; set; }
        public String MD5Hash { get; set; }

        public List<String> agency { get; set; }
        public List<String> envelopeCountry { get; set; }

        public List<String> applicant { get; set; }
        public List<String> inventedName { get; set; }

        public bool comboBoxMode { get; set; }
        public String comboBoxSubmUnit { get; set; }
        public bool NumberEnabled { get; set; }
        }
}
