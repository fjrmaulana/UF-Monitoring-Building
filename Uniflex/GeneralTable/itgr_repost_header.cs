using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.GeneralTable
{
    public class itgr_repost_header
    {
        public string APP_REQUEST { get; set; }

        public string DOC_NUMBER_SAP { get; set; }

        public string DOC_NUMBER_ITGR { get; set; }

        public string DOC_TYPE { get; set; }

        public string DOC_DATE { get; set; }

        public string REF_DOC_NO { get; set; }

        public string COMP_CODE { get; set; }

        public string FISC_YEAR { get; set; }

        public string PSTNG_DATE { get; set; }

        public string CUSTOMER { get; set; }

        public string BKTXT { get; set; }

        public string JASA_TEXT { get; set; }

        public string SKTD { get; set; }

        public string MATERAI { get; set; }

        public string KAPAL { get; set; }

        public string GT_KAPAL { get; set; }

        public string BENDERA_KAPAL { get; set; }

        public string KUNNR { get; set; }

        public string PARAMETER1 { get; set; }

        public string PARAMETER2 { get; set; }

        public string PARAMETER3 { get; set; }

        public string PARAMETER4 { get; set; }

        public string PARAMETER5 { get; set; }

        public string PARAMETER6 { get; set; }

        public string PARAMETER7 { get; set; }

        public string PARAMETER8 { get; set; }
        public string PARAMETER9 { get; set; }
        public string PARAMETER10 { get; set; }
        public string TGL_KIRIM_SAP { get; set; }
        public string TGL_KIRIM_TOS { get; set; }
        public int REC_STAT { get; set; }
        public string CREATED_BY { get; set; }
        public string LAST_UPDATED_BY { get; set; }
        public string PROGRAM_NAME { get; set; }
        public string REQ_HEADER { get; set; }
        public string REQ_ITGR_DETAIL_ITEMS { get; set; }
        public string REQ_ITGR_DETAIL_CHARS { get; set; }
        public int ERR_SEND { get; set; }
        public decimal TOTAL_TAGIHAN { get; set; }
        public string PROFIT_CENTER { get; set; }
        public int KD_CABANG { get; set; }
        public int KD_TERMINAL { get; set; }

        public System.DateTime START_DATE { get; set; }
        public System.DateTime END_DATE { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public System.DateTime LAST_UPDATED_DATE { get; set; }

        public itgr_repost_header()
        {

        }

        public static List<itgr_repost_header> GetForDataSources()
        {
            List<itgr_repost_header> x = new List<itgr_repost_header>();
            itgr_repost_header n = new itgr_repost_header
            {
                APP_REQUEST = "IBS",
                BENDERA_KAPAL = "INA",
                BKTXT = "RCL676700001",
                COMP_CODE = "1000",
                CREATED_BY = "IBS",
                CUSTOMER = "47995",
                DOC_DATE = "",
                DOC_NUMBER_ITGR = "I850000049/2022",
                DOC_NUMBER_SAP = "",
                DOC_TYPE = "1R",
                ERR_SEND = 0,
                FISC_YEAR = "2022",
                GT_KAPAL = "10",
                JASA_TEXT = "NOTA UJI COBA",
                KAPAL = "KM. MADAGASKAR",
                KD_CABANG = 67,
                KD_TERMINAL = 0,
                KUNNR = "47995",
                LAST_UPDATED_BY = "IBS",
                MATERAI = "",
                PARAMETER1 = "",
                PARAMETER2 = "",
                PARAMETER3 = "",
                PARAMETER4 = "",
                PARAMETER5 = "",
                PARAMETER6 = "",
                PARAMETER7 = "",
                PARAMETER8 = "",
                PARAMETER9 = "",
                PARAMETER10 = "",
                PROFIT_CENTER = "0000099999",
                PROGRAM_NAME = "IBS",
                PSTNG_DATE = "20220822",
                REC_STAT = 0,
                REF_DOC_NO = "RCL676700001",
                REQ_HEADER = "1000;2022;1R;20220823;20220823",
                REQ_ITGR_DETAIL_CHARS = "",
                REQ_ITGR_DETAIL_ITEMS = "",
                SKTD = "",
                TGL_KIRIM_SAP = "",
                TGL_KIRIM_TOS = "",
                TOTAL_TAGIHAN = 1000000,
                START_DATE = System.DateTime.Now,
                LAST_UPDATED_DATE = System.DateTime.Now,
                END_DATE = System.DateTime.Now,
                CREATED_DATE = System.DateTime.Now

                //START_DATE = System.Convert.ToDateTime("22/08/2022 09:00:00"),
                //LAST_UPDATED_DATE = System.Convert.ToDateTime("08/22/2022 23:34:38"),
                //END_DATE = System.Convert.ToDateTime("23/08/2022 19:00:00"),
                //CREATED_DATE = System.Convert.ToDateTime("08/22/2022 23:34:38")
            };
            x.Add(n);
            return x;
        }
    }
}
