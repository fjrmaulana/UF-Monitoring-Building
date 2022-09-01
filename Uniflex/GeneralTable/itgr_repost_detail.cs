using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.GeneralTable
{
    public class itgr_repost_detail
    {
        public string APP_REQUEST { get; set; }
        public string DOC_NUMBER_SAP { get; set; }
        public string DOC_NUMBER_ITGR { get; set; }
        public string DOC_TYPE { get; set; }
        public string DOC_DATE { get; set; }
        public string REF_DOC_NO { get; set; }
        public string ITEMNO_ACC { get; set; }
        public string ALLOC_NMBR { get; set; }
        public string AMOUNT { get; set; }
        public decimal AMOUNT_REDUKSI { get; set; }
        public string CURRENCY { get; set; }
        public string ITEM_TEXT { get; set; }
        public string KODE_JASA { get; set; }
        public string PROFIT_CTR { get; set; }
        public string TGL_KIRIM_SAP { get; set; }
        public string TGL_KIRIM_TOS { get; set; }
        public int REC_STAT { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime LAST_UPDATED_DATE { get; set; }
        public string LAST_UPDATED_BY { get; set; }
        public string PROGRAM_NAME { get; set; }
        public itgr_repost_detail() { }

        public static List<itgr_repost_detail> GetForDataSource() {
            List<itgr_repost_detail> l = new List<itgr_repost_detail>();
            l.Add(new itgr_repost_detail
            {
                ALLOC_NMBR = "",
                AMOUNT = "1000000",
                AMOUNT_REDUKSI = 0,
                APP_REQUEST = "IBS",
                CREATED_BY = "IBS",
                CREATED_DATE = System.DateTime.Now,
                CURRENCY = "IDR",
                DOC_DATE = "20220822",
                DOC_NUMBER_ITGR = "I850000049/2022",
                DOC_NUMBER_SAP = "",
                DOC_TYPE = "1R",
                ITEMNO_ACC = "0000000001",
                ITEM_TEXT = "JASA UJI COBA",
                KODE_JASA = "4020202030101010100",
                LAST_UPDATED_BY = "IBS",
                LAST_UPDATED_DATE = System.DateTime.Now,
                PROFIT_CTR = "0000099999",
                PROGRAM_NAME = "IBS",
                REC_STAT = 0,
                REF_DOC_NO = "RCL676700001",
                TGL_KIRIM_SAP = "",
                TGL_KIRIM_TOS = ""
            });
            return l;
        }

        public static List<itgr_repost_detail> GetDatailFromDocNo(string doc_no){
            List<itgr_repost_detail> d = GeneralTable.itgr_repost_detail.GetForDataSource();
            return d.Where(a => a.REF_DOC_NO.ToLower() == doc_no.ToLower()).ToList();
        }

        }
}
