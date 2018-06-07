using MusicBox.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace MusicBox.Data.Base
{
    public class DBClass : IDisposable
    {
        private SQLiteConnection conn;
        private SQLiteTransaction trans;
        private SQLiteCommand comm;
        private bool useTransaction;

        public bool UseTransaction
        {
            get
            {
                return useTransaction;
            }
            set
            {
                useTransaction = value;
                if (useTransaction)
                {
                    trans = conn.BeginTransaction();
                    comm.Transaction = trans;
                }
                else
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                    }
                    comm.Transaction = null;
                }
            }
        }

        private DBClass()
        {
            var connStr = AppConfigurations.Configuration.DBPath;
            conn = new SQLiteConnection(string.Format(connStr, PathHelper.MapPath("/db")));
            comm = conn.CreateCommand();
            conn.Open();
        }

        public static DBClass CreateDBClass()
        {
            return new DBClass();
        }

        public void Dispose()
        {
            if (trans != null)
            {
                trans.Commit();
            }
            conn.Close();
        }

        public DataTable QueryData(string sql)
        {
            return QueryData(sql, null);
        }

        public DataTable QueryData(string sql, IEnumerable<KeyValuePair<string, object>> parms)
        {
            if (parms != null)
            {
                foreach (var parm in parms)
                {
                    comm.Parameters.AddWithValue(parm.Key, parm.Value);
                }
            }
            { }
            comm.CommandText = sql;
            var adapter = new SQLiteDataAdapter(comm);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public int ExecuteNonQuery(string sql, IEnumerable<KeyValuePair<string, object>> parms)
        {
            foreach (var parm in parms)
            {
                comm.Parameters.AddWithValue(parm.Key, parm.Value);
            }
            comm.CommandText = sql;
            try
            {
                return comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw e;
            }
        }
    }
}
