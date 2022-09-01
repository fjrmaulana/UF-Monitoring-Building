using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.GeneralTable
{
    public class itgr_repost_detail_chars
    {

        public string APP_REQUEST { get; set; }
        public string DOC_NUMBER_SAP { get; set; }
        public string DOC_NUMBER_ITGR { get; set; }
        public string DOC_TYPE { get; set; }
        public string DOC_DATE { get; set; }
        public string REF_DOC_NO { get; set; }
        public string ITEMNO_ACC { get; set; }
        public string FIELDNAME { get; set; }
        public string CHARACTER { get; set; }
        public string TGL_KIRIM_SAP { get; set; }
        public string TGL_KIRIM_TOS { get; set; }
        public int REC_STAT { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime LAST_UPDATED_DATE { get; set; }
        public string LAST_UPDATED_BY { get; set; }
        public string PROGRAM_NAME { get; set; }
        public itgr_repost_detail_chars(){}

        public static List<itgr_repost_detail_chars> GetForDataSources()
        {
            List<itgr_repost_detail_chars> l = new List<itgr_repost_detail_chars>();
            l.Add(new itgr_repost_detail_chars { APP_REQUEST = "IBS", CHARACTER = "47995", CREATED_BY = "IBS", CREATED_DATE = System.DateTime.Now, DOC_DATE = "20220822", DOC_NUMBER_ITGR = "I850000049/2022", DOC_NUMBER_SAP = "", DOC_TYPE = "1R", FIELDNAME = "KNDNR", ITEMNO_ACC = "0000000001", LAST_UPDATED_BY = "IBS", LAST_UPDATED_DATE = System.DateTime.Now, PROGRAM_NAME = "IBS", REC_STAT = 0, REF_DOC_NO = "RCL676700001", TGL_KIRIM_SAP = "", TGL_KIRIM_TOS = "" });
            l.Add(new itgr_repost_detail_chars { APP_REQUEST = "IBS", CHARACTER = "1000", CREATED_BY = "IBS", CREATED_DATE = System.DateTime.Now, DOC_DATE = "20220822", DOC_NUMBER_ITGR = "I850000049/2022", DOC_NUMBER_SAP = "", DOC_TYPE = "1R", FIELDNAME = "KOKRS", ITEMNO_ACC = "0000000002", LAST_UPDATED_BY = "IBS", LAST_UPDATED_DATE = System.DateTime.Now, PROGRAM_NAME = "IBS", REC_STAT = 0, REF_DOC_NO = "RCL676700001", TGL_KIRIM_SAP = "", TGL_KIRIM_TOS = "" });
            l.Add(new itgr_repost_detail_chars { APP_REQUEST = "IBS", CHARACTER = "0000099999", CREATED_BY = "IBS", CREATED_DATE = System.DateTime.Now, DOC_DATE = "20220822", DOC_NUMBER_ITGR = "I850000049/2022", DOC_NUMBER_SAP = "", DOC_TYPE = "1R", FIELDNAME = "PRCTR", ITEMNO_ACC = "0000000003", LAST_UPDATED_BY = "IBS", LAST_UPDATED_DATE = System.DateTime.Now, PROGRAM_NAME = "IBS", REC_STAT = 0, REF_DOC_NO = "RCL676700001", TGL_KIRIM_SAP = "", TGL_KIRIM_TOS = "" });
            l.Add(new itgr_repost_detail_chars { APP_REQUEST = "IBS", CHARACTER = "1000", CREATED_BY = "IBS", CREATED_DATE = System.DateTime.Now, DOC_DATE = "20220822", DOC_NUMBER_ITGR = "I850000049/2022", DOC_NUMBER_SAP = "", DOC_TYPE = "1R", FIELDNAME = "BUKRS", ITEMNO_ACC = "0000000004", LAST_UPDATED_BY = "IBS", LAST_UPDATED_DATE = System.DateTime.Now, PROGRAM_NAME = "IBS", REC_STAT = 0, REF_DOC_NO = "RCL676700001", TGL_KIRIM_SAP = "", TGL_KIRIM_TOS = "" });
            l.Add(new itgr_repost_detail_chars { APP_REQUEST = "IBS", CHARACTER = "99999", CREATED_BY = "IBS", CREATED_DATE = System.DateTime.Now, DOC_DATE = "20220822", DOC_NUMBER_ITGR = "I850000049/2022", DOC_NUMBER_SAP = "", DOC_TYPE = "1R", FIELDNAME = "WW006", ITEMNO_ACC = "0000000005", LAST_UPDATED_BY = "IBS", LAST_UPDATED_DATE = System.DateTime.Now, PROGRAM_NAME = "IBS", REC_STAT = 0, REF_DOC_NO = "RCL676700001", TGL_KIRIM_SAP = "", TGL_KIRIM_TOS = "" });
            return l;
        }

        public static List<itgr_repost_detail_chars> GetFromDocNo(string doc_no)
        {
            List<itgr_repost_detail_chars> l = itgr_repost_detail_chars.GetForDataSources();
            return l.Where(a => a.REF_DOC_NO.ToLower() == doc_no.ToLower()).ToList();
        }
    }
}
