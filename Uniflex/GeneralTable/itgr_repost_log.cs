using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.GeneralTable
{
    public class itgr_repost_log
    {
        public string APP_REQUEST { get; set; }
        public string DOC_NUMBER_ITGR { get; set; }
        public string FISC_YEAR { get; set; }
        public string XML_DATA { get; set; }
        public string XML_SEND { get; set; }
        public string REF_DOC_NO { get; set; }
        public int REC_STAT { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime LAST_UPDATED_DATE { get; set; }
        public string LAST_UPDATED_BY { get; set; }
        public string PROGRAM_NAME { get; set; }
        public itgr_repost_log()
        {

        }

        public static List<itgr_repost_log> GetForDataSource()
        {
            List<itgr_repost_log> l = new List<itgr_repost_log>();
            l.Add(new itgr_repost_log
            {
                APP_REQUEST = "TOSGC",
                CREATED_BY = "jobPostingSAP",
                CREATED_DATE = System.DateTime.Now,
                DOC_NUMBER_ITGR = "I730000002/2019",
                FISC_YEAR = "2019",
                LAST_UPDATED_BY = "jobPostingSAP",
                LAST_UPDATED_DATE = System.DateTime.Now,
                PROGRAM_NAME = "jobPostingSAP",
                REC_STAT = 0,
                REF_DOC_NO = "RJ/2002186/0519",
                XML_DATA = "Error in document: BKPFF $ QERCLNT210, Value '2000002482' is not allowed for characteristic 'Customer', Value '2000002482' is not allowed for characteristic 'Customer', Account 4030205011 requires an assignment to a CO object, Customer 2000002482 is not defined in company code 1000",
                XML_SEND = "<Envelope xmlns=http://schemas.xmlsoap.org/soap/envelope/> <Body> <inboundTosPost xmlns=http://integrator.pelindo.co.id/> <ITGR_HEADER>1000;2019;1E;20190531;20190531;RJ/2002186/0519;2000002482;GENERAL CARGO : MARTHA GOLDEN;;SI-00068/SK/WPJ.19/KP.0403/2019;I000006539;5471 / 117.31;INA;20190528;20190529;07410;X;X;X;X;X;X;X;X;X;X;EPB/2001744/0519</ITGR_HEADER> <ITGR_DETAIL_ITEMS>0000000001;;29077650;0;IDR;;4030201020000000000;0000012204;0000000002;;188757660;0;IDR;;4030205010101000000;0000012204</ITGR_DETAIL_ITEMS> <ITGR_DETAIL_CHARS>0000000001;BUKRS;1000;0000000001;KOKRS;1000;0000000001;KNDNR;2000002482;0000000001;PRCTR;0000012204;0000000001;WW003;I000006539;0000000001;WW005;021FPDMG06DMG;0000000001;WW006;12204;0000000002;BUKRS;1000;0000000002;KOKRS;1000;0000000002;KNDNR;2000002482;0000000002;PRCTR;0000012204;0000000002;WW003;I000006539;0000000002;WW005;021FPDMG06DMG;0000000002;WW006;12204</ITGR_DETAIL_CHARS> </inboundTosPost> </Body> </Envelope>"
            });
            return l;
        }
    }
}
