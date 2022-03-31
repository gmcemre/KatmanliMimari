using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimariORM
{
    public class Tools
    {
        //Singleton Pattern
        private static SqlConnection _Baglanti;

        public static SqlConnection Baglanti
        {
            get
            {
                //1.Gösterim
                //if (_Baglanti == null)
                //    _Baglanti = new SqlConnection();

                //2.Gösterim
                //_Baglanti'ya atama yap , _Baglanti null ise new'le
                _Baglanti = _Baglanti ?? new SqlConnection(ConfigurationManager.ConnectionStrings["LocalBaglanti"].ConnectionString);

                return _Baglanti;
            }
        }

        public static bool ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                int rowAffected = cmd.ExecuteNonQuery();

                return rowAffected > 0 ? true : false;

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }

        public static bool ProcedureType<T>(string procType, T entity)
        {
            Type TipGetir = typeof(T);
            SqlCommand cmd = new SqlCommand($"prc_{TipGetir.Name}_{procType}", Tools.Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;

            PropertyInfo[] properties = TipGetir.GetProperties();

            foreach (PropertyInfo item in properties)
            {
                cmd.Parameters.AddWithValue($"@{item.Name}", item.GetValue(entity));
            }
            return Tools.ExecuteNonQuery(cmd);
        }
    }
}
