using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimariORM
{
    public class ORMBase<TT> : IORM<TT> where TT : class
    {
        Type TipGetir
        {
            get
            {
                return typeof(TT);
            }
        }

        public DataTable Select()
        {
            SqlDataAdapter adp = new SqlDataAdapter($"prc_{TipGetir.Name}_Select", Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public bool Insert(TT entity)
        {
            return Tools.ProcedureType<TT>("Insert", entity);
        }

        public bool Update(TT entity)
        {
            return Tools.ProcedureType<TT>("Update", entity);
        }

        public bool Delete(int id)
        {
            TT ent = Activator.CreateInstance<TT>();

            SqlCommand cmd = new SqlCommand($"prc_{TipGetir.Name}_Delete", Tools.Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;

            PropertyInfo primaryColumn = TipGetir.GetProperty("PrimaryColumn");
            cmd.Parameters.AddWithValue($"@{primaryColumn.GetValue(ent)}", id);

            return Tools.ExecuteNonQuery(cmd);
        }
    }
}
