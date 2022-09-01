﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.GeneralTable
{
    public class ihub_config
    {
        public int ID { get; set; }
        public string PARAMS_NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public bool ACTIVE_THIS { get; set; }
        public string USER_ENTRY { get; set; }
        public DateTime USER_CREATED { get; set; }
        public DateTime USER_UPDATE { get; set; }
        public ihub_config(){}

        public static List<ihub_config> GetForDataSource()
        {
            List<ihub_config> list = new List<ihub_config>();
            using (DataAccess.Oracle db = new DataAccess.Oracle())
            {
                db.CommandText = "SELECT ID, PARAMS_NAME, DESCRIPTION, ACTIVE_THIS, USER_ENTRY, USER_CREATED, USER_UPDATE FROM IHUB_CONFIG";
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader rdr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader) {
                    if (rdr.HasRows) {
                        while (rdr.Read()) {
                            ihub_config i = new ihub_config
                            {
                                ACTIVE_THIS =Helper.GeneralHelper.NullToBool(rdr["ACTIVE_THIS"],false),
                                DESCRIPTION = rdr["DESCRIPTION"].ToString(),
                                ID = Helper.GeneralHelper.NullToInt(rdr["ID"],0),
                                PARAMS_NAME = rdr["PARAMS_NAME"].ToString(),
                                USER_CREATED =Helper.GeneralHelper.NullToDateTime( rdr["USER_CREATED"],System.DateTime.Now),
                                USER_ENTRY = rdr["USER_ENTRY"].ToString(),
                                USER_UPDATE = Helper.GeneralHelper.NullToDateTime(rdr["USER_UPDATE"], System.DateTime.Now)
                            };
                            list.Add(i);
                        }
                    }
                    if (!rdr.IsClosed) rdr.Close();
                }
                db.Close();
            }
            return list;
        }
    }
}


/*
 CREATE TABLE IHUB_CONFIG(
         ID NUMBER GENERATED BY DEFAULT AS IDENTITY,
         PARAMS_NAME VARCHAR2(100) DEFAULT 'USER',
	     DESCRIPTION VARCHAR2(200) DEFAULT '',
         ACTIVE_THIS NUMBER(1) DEFAULT 1,
	     USER_ENTRY  VARCHAR2(200) DEFAULT 'by_system',
         USER_CREATED  TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
         USER_UPDATE  TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
		 PRIMARY KEY(ID)
) 
 */

/*
 INSERT INTO IHUB_CONFIG (params_name,DESCRIPTION,ACTIVE_THIS) values('default_role','Bila User registrasi maka otomatis masuk rolenya User',1)
 */