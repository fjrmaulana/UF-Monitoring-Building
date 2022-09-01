using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.GeneralTable
{
    public class sharing_revenue_tunda
    {
        public sharing_revenue_tunda(){}

        public string ID_TRX { get; set; }
        public string PERIODE { get; set; }
        public string KODE_CABANG { get; set; }
        public string NOMOR_PKK { get; set; }
        public string NOMOR_NOTA { get; set; }
        public string NOMOR_FAKTUR { get; set; }
        public string NAMA_PELANGGAN { get; set; }
        public string NAMA_KAPAL { get; set; }
        public string BENDERA { get; set; }
        public decimal GRT { get; set; }
        public decimal LOA { get; set; }
        public string KODE_FAKTUR { get; set; }
        public string MULAI_KEGIATAN { get; set; }
        public string SELESAI_KEGIATAN { get; set; }
        public string GERAKAN_DARI { get; set; }
        public string GERAKAN_KE { get; set; }
        public string GERAKAN { get; set; }
        public string KODE_LOKASI { get; set; }
        public decimal PENDAPATAN { get; set; }
        public decimal PNBP { get; set; }
        public decimal PNBP_MIGAS { get; set; }
        public decimal DISCOUNT { get; set; }
        public string KODE_KAPAL_TUNDA { get; set; }
        public decimal PRODUKSI { get; set; }

        public static int SaveData(sharing_revenue_tunda s)
        {
            int return_ = 0;
            using (DataAccess.Oracle db = new DataAccess.Oracle())
            {
                try
                {
                    db.Open();
                    db.CommandText = "INSERT INTO SHARING_REVENUE_TUNDA (ID_TRX, PERIODE, KODE_CABANG, NOMOR_PKK, NOMOR_NOTA, NOMOR_FAKTUR, NAMA_PELANGGAN, NAMA_KAPAL, BENDERA, GRT, LOA, KODE_FAKTUR, MULAI_KEGIATAN, SELESAI_KEGIATAN, GERAKAN_DARI, GERAKAN_KE, GERAKAN, KODE_LOKASI, PENDAPATAN, PNBP, PNBP_MIGAS, DISCOUNT, KODE_KAPAL_TUNDA, PRODUKSI) VALUES (:ID_TRX, :PERIODE, :KODE_CABANG, :NOMOR_PKK, :NOMOR_NOTA, :NOMOR_FAKTUR, :NAMA_PELANGGAN, :NAMA_KAPAL, :BENDERA, :GRT, :LOA, :KODE_FAKTUR, :MULAI_KEGIATAN, :SELESAI_KEGIATAN, :GERAKAN_DARI, :GERAKAN_KE, :GERAKAN, :KODE_LOKASI, :PENDAPATAN, :PNBP, :PNBP_MIGAS, :DISCOUNT, :KODE_KAPAL_TUNDA, :PRODUKSI)";
                    db.AddParameter(":ID_TRX", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.ID_TRX);
                    db.AddParameter(":PERIODE", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.PERIODE);
                    db.AddParameter(":KODE_CABANG", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.KODE_CABANG);
                    db.AddParameter(":NOMOR_PKK", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.NOMOR_PKK);
                    db.AddParameter(":NOMOR_NOTA", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.NOMOR_NOTA);
                    db.AddParameter(":NOMOR_FAKTUR", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.NOMOR_FAKTUR);
                    db.AddParameter(":NAMA_PELANGGAN", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.NAMA_PELANGGAN);
                    db.AddParameter(":NAMA_KAPAL", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.NAMA_KAPAL);
                    db.AddParameter(":BENDERA", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.BENDERA);
                    db.AddParameter(":GRT", Oracle.ManagedDataAccess.Client.OracleDbType.Decimal, s.GRT);// number
                    db.AddParameter(":LOA", Oracle.ManagedDataAccess.Client.OracleDbType.Decimal, s.LOA);// number
                    db.AddParameter(":KODE_FAKTUR", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.KODE_FAKTUR);
                    db.AddParameter(":MULAI_KEGIATAN", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.MULAI_KEGIATAN);
                    db.AddParameter(":SELESAI_KEGIATAN", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.SELESAI_KEGIATAN);
                    db.AddParameter(":GERAKAN_DARI", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.GERAKAN_DARI);
                    db.AddParameter(":GERAKAN_KE", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.GERAKAN_KE);
                    db.AddParameter(":GERAKAN", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.GERAKAN);
                    db.AddParameter(":KODE_LOKASI", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.KODE_LOKASI);
                    db.AddParameter(":PENDAPATAN", Oracle.ManagedDataAccess.Client.OracleDbType.Decimal, s.PENDAPATAN);// Number
                    db.AddParameter(":PNBP", Oracle.ManagedDataAccess.Client.OracleDbType.Decimal, s.PNBP);// number
                    db.AddParameter(":PNBP_MIGAS", Oracle.ManagedDataAccess.Client.OracleDbType.Decimal, s.PNBP_MIGAS);//Number
                    db.AddParameter(":DISCOUNT,", Oracle.ManagedDataAccess.Client.OracleDbType.Decimal, s.DISCOUNT);// Number
                    db.AddParameter(":KODE_KAPAL_TUNDA", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.KODE_KAPAL_TUNDA);// number
                    db.AddParameter(":PRODUKSI", Oracle.ManagedDataAccess.Client.OracleDbType.Decimal, s.PRODUKSI);
                    db.CommandType = System.Data.CommandType.Text;
                    db.BeginTransaction();
                    return_= db.ExecuteNonQuery();
                    db.CommitTransaction();
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException e)
                {
                    if (db.Transaction != null)
                        db.RollbackTransaction();
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
                catch
                {
                    if (db.Transaction != null)
                        db.RollbackTransaction();

                    throw;
                }
                finally
                {
                    db.Close();
                }
            }
            return return_;
        }

        public static List<sharing_revenue_tunda> GetTundaFromPeriodAndCabang(string periode, string kodecabang)
        {
            List<sharing_revenue_tunda> tunda_list = new List<sharing_revenue_tunda>();

            using (DataAccess.Oracle db = new DataAccess.Oracle())
            {
                db.CommandText = "SELECT ID_TRX, PERIODE, KODE_CABANG, NOMOR_PKK, NOMOR_NOTA, NOMOR_FAKTUR, NAMA_PELANGGAN, NAMA_KAPAL, BENDERA, GRT, LOA, KODE_FAKTUR, MULAI_KEGIATAN, SELESAI_KEGIATAN, GERAKAN_DARI, GERAKAN_KE, GERAKAN, KODE_LOKASI, PENDAPATAN, PNBP, PNBP_MIGAS, DISCOUNT,KODE_KAPAL_TUNDA,PRODUKSI FROM SHARING_REVENUE_TUNDA WHERE PERIODE=:period AND KODE_CABANG=:ko ORDER BY ID_TRX asc";
                db.AddParameter(":ko", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, kodecabang);
                db.AddParameter(":period", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, periode);
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader rdr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            sharing_revenue_tunda p = new sharing_revenue_tunda()
                            {
                                BENDERA = rdr["BENDERA"].ToString(),
                                DISCOUNT = Helper.GeneralHelper.NullToDecimal(rdr["DISCOUNT"].ToString(), 0),
                                GERAKAN = rdr["GERAKAN"].ToString(),
                                GERAKAN_DARI = rdr["GERAKAN_DARI"].ToString(),
                                GERAKAN_KE = rdr["GERAKAN_KE"].ToString(),
                                GRT = Helper.GeneralHelper.NullToDecimal(rdr["GRT"].ToString(), 0),
                                ID_TRX = rdr["ID_TRX"].ToString(),
                                KODE_CABANG = rdr["KODE_CABANG"].ToString(),
                                KODE_FAKTUR = rdr["KODE_FAKTUR"].ToString(),
                                KODE_LOKASI = rdr["KODE_LOKASI"].ToString(),
                                LOA = Helper.GeneralHelper.NullToDecimal(rdr["LOA"].ToString(), 0),
                                MULAI_KEGIATAN = rdr["MULAI_KEGIATAN"].ToString(),
                                NAMA_KAPAL = rdr["NAMA_KAPAL"].ToString(),
                                NAMA_PELANGGAN = rdr["NAMA_PELANGGAN"].ToString(),
                                NOMOR_FAKTUR = rdr["NOMOR_FAKTUR"].ToString(),
                                NOMOR_NOTA = rdr["NOMOR_NOTA"].ToString(),
                                NOMOR_PKK = rdr["NOMOR_PKK"].ToString(),
                                PENDAPATAN = Helper.GeneralHelper.NullToDecimal(rdr["PENDAPATAN"].ToString(), 0),
                                PERIODE = rdr["PERIODE"].ToString(),
                                PNBP = Helper.GeneralHelper.NullToDecimal(rdr["PNBP"].ToString(), 0),
                                PNBP_MIGAS = Helper.GeneralHelper.NullToDecimal(rdr["PNBP_MIGAS"].ToString(), 0),
                                SELESAI_KEGIATAN = rdr["SELESAI_KEGIATAN"].ToString(),
                                KODE_KAPAL_TUNDA= rdr["KODE_KAPAL_TUNDA"].ToString(),
                                PRODUKSI = Helper.GeneralHelper.NullToDecimal(rdr["PRODUKSI"].ToString(), 0)
                            };
                            tunda_list.Add(p);
                        }
                    }
                    if (!rdr.IsClosed) rdr.Close();
                }
                db.Close();
            }
            return tunda_list;
        }
    }
}
