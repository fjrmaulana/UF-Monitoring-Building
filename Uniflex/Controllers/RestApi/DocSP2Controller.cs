using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.Controllers.RestApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocSP2Controller : ControllerBase
    {

        [HttpPost, Route("SP2"),Microsoft.AspNetCore.Authorization.AllowAnonymous, Microsoft.AspNetCore.Cors.EnableCors("CorsPolicy")]
        public IActionResult SP2([FromBody] I_HUB.Model.Inbound.DocSp2 p)
        {
            object hasil = new { Status = "E", Message = "Initial" };

            string optional_id = "PLD" + "-" + p.pelabuhan + System.DateTime.Now.ToString("yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            string tglTrans = DateTime.Now.ToString("yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture) + p.pelabuhan;// + "querty";

            // Create jsonText For nle_itgr
            List<GeneralTable.Container> containr = new List<GeneralTable.Container>();
            containr.Add(new GeneralTable.Container { container_no = p.container[0].container_no, container_size = p.container[0].container_size, container_type = p.container[0].container_type, gate_pass = p.container[0].gate_pass });

            List<GeneralTable.Dokuman> document = new List<GeneralTable.Dokuman>();
            document.Add(new GeneralTable.Dokuman { document_date = p.dokumen[0].document_date, document_no = p.dokumen[0].document_no, document_status = p.dokumen[0].document_status });
            GeneralTable.ParamDocSP2Post newData = new GeneralTable.ParamDocSP2Post
            {
                request_booking_id = optional_id,// PLD-IDPSU-TGLTRX.
                bl_date = p.bl_date,
                bl_no = p.bl_no,
                container = containr,
                date_doc_release = p.date_doc_release,
                dokumen = document,
                id_platform = p.id_platform,
                is_finished =int.Parse(p.is_finished),
                jenis_channel = p.jenis_channel,
                jenis_sp2 = p.jenis_sp2,
                kd_document_type = p.kd_document_type,
                nm_cargoowner = p.nm_cargoowner,
                nm_ppjk = p.nm_ppjk,
                no_doc_release = p.no_doc_release,
                npwpCargoOwner = p.npwpCargoOwner,
                npwp_ppjk = p.npwp_ppjk,
                paid_thrud_date = p.paid_thrud_date,
                party = int.Parse(p.party),
                pelabuhan = p.pelabuhan,
                platform_booking_id = "PLD-" + DateTime.Now.ToString("yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture),// PLD-TGLTRX
                port_of_discharge = p.port_of_discharge,
                port_of_loading = p.port_of_loading,
                price = int.Parse(p.price),
                proforma = p.proforma,
                proforma_date = p.proforma_date,
                sppb_date = System.Convert.ToDateTime(p.sppb_date).ToString("yyyy-MM-dd HH:mm:ss"),
                sppb_no = p.sppb_no,
                status = p.status,
                terminal = p.terminal
            };

            GeneralTable.nle_sp2_itgr nle_Sp2_Itgr = new GeneralTable.nle_sp2_itgr()
            {
                DOCUMENT_DATE = newData.dokumen[0].document_date,
                DOCUMENT_NO = newData.dokumen[0].document_no,
                DOCUMENT_STATUS = newData.dokumen[0].document_status,
                IS_FINISHED = newData.is_finished.ToString(),
                MESSAGE_SENT = "",
                JSON_TEXT = Newtonsoft.Json.JsonConvert.SerializeObject(newData, Formatting.Indented),
                KD_DOCUMENT_TYPE = newData.kd_document_type,
                KD_TERMINAL = newData.pelabuhan,
                ID = tglTrans,
                ID_PLATFORM = newData.id_platform,
                BL_DATE = newData.bl_date,
                BL_NO = newData.bl_no,
                CREATE_DATE = System.DateTime.Now,
                DATE_DOC_RELEASE = newData.date_doc_release,
                NM_CARGOOWNER = newData.nm_cargoowner,
                NO_DOC_RELEASE = newData.no_doc_release,
                NPWPCARGOOWNER = newData.npwpCargoOwner,
                PAID_THRUD_DATE = newData.paid_thrud_date,
                PARTY = newData.party.ToString(),
                PRICE = newData.price.ToString(),
                PROFORMA = newData.proforma,
                PROFORMA_DATE = newData.proforma_date,
                STATUS = newData.status,
                STATUS_SENT = "0",
                TERMINAL = newData.terminal,
                TIPE = p.tipe
            };

            GeneralTable.nle_sp2_itgr_det itgr_det = new GeneralTable.nle_sp2_itgr_det
            {
                CONTAINER_NO = newData.container[0].container_no,
                GETPASS = newData.container[0].gate_pass,
                CONTAINER_TYPE = newData.container[0].container_type,
                ID = tglTrans,
                CONTAINER_SIZE = newData.container[0].container_size
            };
            int save_nle_sp2_itgr_success = GeneralTable.nle_sp2_itgr.SaveData(nle_Sp2_Itgr);
            int save_nle_sp2_itgr_det_success = GeneralTable.nle_sp2_itgr_det.SaveData(itgr_det);
            if ((save_nle_sp2_itgr_success > 0) && (save_nle_sp2_itgr_det_success > 0))
            {
                hasil = new { Status = "S", Message = "Berhasil Menyimpan Data" };
                return Ok(hasil);
            }
            else
            {
                hasil = new { Status = "E", Message = "Gagal Menyimpan Data!" };
                return Ok(hasil);
            }

            return Ok(hasil);
        }

      
    }
}
