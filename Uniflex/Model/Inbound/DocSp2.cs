using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.Model.Inbound
{
    public class DocSp2
    {
        public string tipe { get; set; }
        public string kd_terminal { get; set; }
        public string kd_document_type { get; set; }
        public string npwpCargoOwner { get; set; }
        public string nm_cargoowner { get; set; }
        public string no_doc_release { get; set; }
        public string date_doc_release { get; set; }
        public string bl_no { get; set; }
        public string bl_date { get; set; }
        public string id_platform { get; set; }
        public string terminal { get; set; }
        public string paid_thrud_date { get; set; }
        public string proforma { get; set; }
        public string proforma_date { get; set; }
        public string price { get; set; }
        public string status { get; set; }
        public string is_finished { get; set; }
        public string party { get; set; }
        public string npwp_ppjk { get; set; }
        public string nm_ppjk { get; set; }
        public string port_of_loading { get; set; }
        public string port_of_discharge { get; set; }
        public string pelabuhan { get; set; }
        public string jenis_sp2 { get; set; }
        public string jenis_channel { get; set; }
        public string sppb_no { get; set; }
        public System.DateTime sppb_date { get; set; }

        public List<Dokumin> dokumen { get; set; }
        public List<Containersp> container { get; set; }
       
        public DocSp2()
        {

        }
    }

    public class Containersp
    {
        public string gate_pass { get; set; }
        public string container_type { get; set; }
        public string container_size { get; set; }
        public string container_no { get; set; }
    }
    public class Dokumin
    {
        public string document_no { get; set; }
        public string document_date { get; set; }
        public string document_status { get; set; }
        public string link_document { get; set; }
    }
}
