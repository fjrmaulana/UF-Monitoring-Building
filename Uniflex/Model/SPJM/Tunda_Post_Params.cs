using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.Model.SPJM
{
    public class Tunda_Post_Params
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "periode code is required format yyyyMM")]
        [MaxLength(6, ErrorMessage = "Max.leng 6 format yyyyMM"), StringLength(6, ErrorMessage = "Max.leng 6 format yyyyMM")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "", DataFormatString = "yyyyMM")]
        public string periode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "kode_cabang is required")]
        [MaxLength(2, ErrorMessage = "Max.leng 2"), StringLength(2, ErrorMessage = "Max.leng 2")]
        public string kode_cabang { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "nomor_pkk is required")]
        [MaxLength(24, ErrorMessage = "Max.leng 24"), StringLength(24, ErrorMessage = "String.leng 24")]
        public string nomor_pkk { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "nomor_nota is required")]
        [MaxLength(50, ErrorMessage = "Max.leng 50"), StringLength(50, ErrorMessage = "String.leng 50")]
        public string nomor_nota { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "nomor_faktur is required")]
        [MaxLength(50, ErrorMessage = "Max.leng 50"), StringLength(50, ErrorMessage = "String.leng 50")]
        public string nomor_faktur { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "nama_pelanggan is required")]
        [MaxLength(100, ErrorMessage = "Max.leng 100"), StringLength(100, ErrorMessage = "String.leng 100")]
        public string nama_pelanggan { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "nama_kapal is required")]
        [MaxLength(100, ErrorMessage = "Max.leng 100"), StringLength(100, ErrorMessage = "String.leng 100")]
        public string nama_kapal { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "bendera is required")]
        [MaxLength(2, ErrorMessage = "Max.leng 2"), StringLength(2, ErrorMessage = "String.leng 2")]
        public string bendera { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "grt is required")]
        public decimal grt { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "loa is required")]
        public decimal loa { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "kode_faktur is required")]
        [MaxLength(3, ErrorMessage = "Max.leng 3"), StringLength(2, ErrorMessage = "String.leng 3")]
        public string kode_faktur { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "mulai_kegiatan is required")]
        [MaxLength(16, ErrorMessage = "Max.leng 16"), StringLength(16, ErrorMessage = "String.leng 16")]
        public string mulai_kegiatan { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "selesai_kegiatan is required")]
        [MaxLength(16, ErrorMessage = "Max.leng 16"), StringLength(16, ErrorMessage = "String.leng 16")]
        public string selesai_kegiatan { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "gerakan_dari is required")]
        [MaxLength(100, ErrorMessage = "Max.leng 100"), StringLength(100, ErrorMessage = "String.leng 100")]
        public string gerakan_dari { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "gerakan_ke is required")]
        [MaxLength(100, ErrorMessage = "Max.leng 100"), StringLength(100, ErrorMessage = "String.leng 100")]
        public string gerakan_ke { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "gerakan is required")]
        [MaxLength(10, ErrorMessage = "Max.leng 10"), StringLength(10, ErrorMessage = "String.leng 10")]
        public string gerakan { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "kode_lokasi is required")]
        [MaxLength(4, ErrorMessage = "Max.leng 4"), StringLength(4, ErrorMessage = "String.leng 4")]
        public string kode_lokasi { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "pendapatan is required")]
        public decimal pendapatan { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "pnbp is required")]
        public decimal pnbp { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "pnbp_migas is required")]
        public decimal pnbp_migas { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "diskon is required")]
        public decimal diskon { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "kode_kapal_tunda is required")]
        [MaxLength(4, ErrorMessage = "Max.leng 4"), StringLength(4, ErrorMessage = "String.leng 4")]
        public string kode_kapal_tunda { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "produksi is required")]
        public decimal produksi { get; set; }
        public Tunda_Post_Params(){}
    }
}
