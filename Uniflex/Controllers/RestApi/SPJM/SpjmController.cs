using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.Controllers.RestApi.SPJM
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpjmController : ControllerBase
    {

        [HttpGet, Route("GetPandu"), Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public IActionResult GetPandu(string periode,string kodecabang)
        {
            //HttpContext httpContext ;//new Newtonsoft.Json.JsonSerializerSettings()
            //string authHeader = this.httpContext.Request.Headers["Authorization"];
            if (!this.Request.Headers.TryGetValue("Authorization", out var token))
            {
                return Unauthorized();
            }

            string Authorization_ = Helper.GetHeader.GetReq(this.Request, "Authorization").ToString().Replace("Bearer ", "").Replace("Bearer ", "");
            if (string.IsNullOrEmpty(Authorization_))
            {
                return Ok(new { status = "error", msg = "Authorization Not Found" });
            };

            var user = I_HUB.Maintenance.Users.GetFromToken(Authorization_);
            if (user == null)
            {
                return Ok(new { status = "error", msg = Authorization_ + " Not Found" });
            }

            List<GeneralTable.sharing_revenue_pandu> p_list = GeneralTable.sharing_revenue_pandu.GetPanduFromPeriodAndCabang(kodecabang, periode);
            return Ok(new { status = "success", count = p_list.Count(), data = p_list });
        }

        [HttpGet, Route("GetTunda"), Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public IActionResult GetTunda(string periode, string kodecabang)
        {
            //HttpContext httpContext ;//new Newtonsoft.Json.JsonSerializerSettings()
            //string authHeader = this.httpContext.Request.Headers["Authorization"];
            //JsonResult jsonr = null;

            if (!this.Request.Headers.TryGetValue("Authorization", out var token))
            {
                return Unauthorized();
            }

            string Authorization_ = Helper.GetHeader.GetReq(this.Request, "Authorization").ToString().Replace("Bearer ", "").Replace("Bearer ", "");
            if (string.IsNullOrEmpty(Authorization_))
            {
                return Ok(new { status = "error", msg = "Authorization Not Found" });
            };

            var user = I_HUB.Maintenance.Users.GetFromToken(Authorization_);
            if (user == null)
            {
                return Ok(new { status = "error", msg = Authorization_ + " Not Found" });
            }

            List<GeneralTable.sharing_revenue_tunda> p_list = GeneralTable.sharing_revenue_tunda.GetTundaFromPeriodAndCabang(kodecabang, periode);
            return Ok(new { status = "success", count = p_list.Count(), data = p_list });
        }

        [HttpPost, Route("PostPandu"), Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public IActionResult PostPandu([FromBody] I_HUB.Model.SPJM.Pandu_Post_Params p)
        {
            if (!this.Request.Headers.TryGetValue("Authorization", out var token))
            {
                return Unauthorized();
            }

            string Authorization_ = Helper.GetHeader.GetReq(this.Request, "Authorization").ToString().Replace("Bearer ", "").Replace("Bearer ", "");
            if (string.IsNullOrEmpty(Authorization_))
            {
                return Ok(new { status = "error", msg = "Authorization Not Found" });
            };

            var user = I_HUB.Maintenance.Users.GetFromToken(Authorization_);
            if (user == null)
            {
                return Ok(new { status = "error", msg = Authorization_ + " Not Found" });
            }
            GeneralTable.sharing_revenue_pandu pandu_data = new GeneralTable.sharing_revenue_pandu
            {
                ID_TRX = "PLD" + "-" + System.DateTime.Now.ToString("yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture),
                BENDERA = p.bendera,
                DISCOUNT = p.diskon,
                GERAKAN = p.gerakan,
                GERAKAN_DARI = p.gerakan_dari,
                GERAKAN_KE = p.gerakan_ke,
                GRT = p.grt,
                KODE_CABANG = p.kode_cabang,
                KODE_FAKTUR =p.kode_faktur,
                KODE_LOKASI = p.kode_lokasi,
                LOA = p.loa,
                MULAI_KEGIATAN = p.mulai_kegiatan,
                NAMA_KAPAL = p.nama_kapal,
                NAMA_PELANGGAN = p.nama_pelanggan,
                NOMOR_FAKTUR = p.nomor_faktur,
                NOMOR_NOTA = p.nomor_nota,
                NOMOR_PKK = p.nomor_pkk,
                PENDAPATAN = p.pendapatan,
                PERIODE = p.periode,
                PNBP = p.pnbp,
                PNBP_MIGAS = p.pnbp_migas,
                SELESAI_KEGIATAN = p.selesai_kegiatan
            };

            int save_success = GeneralTable.sharing_revenue_pandu.SaveData(pandu_data);
            if (save_success > 0)
            {
                return Ok(new { status = "success", msg = "Data Hasbeen Saved!", data = pandu_data });
            }
            else
            {

                return Ok(new { status = "error", msg = "Cant Save Data!" });
            }

        }

        [HttpPost, Route("PostTunda"), Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public IActionResult PostTunda([FromBody] I_HUB.Model.SPJM.Tunda_Post_Params p)
        {
            if (!this.Request.Headers.TryGetValue("Authorization", out var token))
            {
                return Unauthorized();
            }

            string Authorization_ = Helper.GetHeader.GetReq(this.Request, "Authorization").ToString().Replace("Bearer ", "").Replace("Bearer ", "");
            if (string.IsNullOrEmpty(Authorization_))
            {
                return Ok(new { status = "error", msg = "Authorization Not Found" });
            };

            var user = I_HUB.Maintenance.Users.GetFromToken(Authorization_);
            if (user == null)
            {
                return Ok(new { status = "error", msg = Authorization_ + " Not Found" });
            }
            GeneralTable.sharing_revenue_tunda tunda_data = new GeneralTable.sharing_revenue_tunda
            {
                ID_TRX = "PLD" + "-" + System.DateTime.Now.ToString("yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture),
                BENDERA = p.bendera,
                DISCOUNT = p.diskon,
                GERAKAN = p.gerakan,
                GERAKAN_DARI = p.gerakan_dari,
                GERAKAN_KE = p.gerakan_ke,
                GRT = p.grt,
                KODE_CABANG = p.kode_cabang,
                KODE_FAKTUR = p.kode_faktur,
                KODE_LOKASI = p.kode_lokasi,
                LOA = p.loa,
                MULAI_KEGIATAN = p.mulai_kegiatan,
                NAMA_KAPAL = p.nama_kapal,
                NAMA_PELANGGAN = p.nama_pelanggan,
                NOMOR_FAKTUR = p.nomor_faktur,
                NOMOR_NOTA = p.nomor_nota,
                NOMOR_PKK = p.nomor_pkk,
                PENDAPATAN = p.pendapatan,
                PERIODE = p.periode,
                PNBP = p.pnbp,
                PNBP_MIGAS = p.pnbp_migas,
                SELESAI_KEGIATAN = p.selesai_kegiatan,
                KODE_KAPAL_TUNDA=p.kode_kapal_tunda,
                PRODUKSI=p.produksi
            };

            int save_success = GeneralTable.sharing_revenue_tunda.SaveData(tunda_data);
            if (save_success > 0)
            {
                return Ok(new { status = "success", msg = "Data Hasbeen Saved!", data = tunda_data });
            }
            else
            {

                return Ok(new { status = "error", msg = "Cant Save Data!" });
            }

        }
    }
}
