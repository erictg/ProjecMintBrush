using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ProjectMintBrushBackend
{
    public class SQLCommand
    {
        public static List<String>  ExecuteQueryWithResult(String query)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Gretchen\Documents\GitHub\ProjecMintBrush\ProjectMintBrush\ProjectMintBrushBackend\App_Data\db.mdf;Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
            
            }
            return null;
        }

        public static void ExecuteQuery(string query)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Gretchen\Documents\GitHub\ProjecMintBrush\ProjectMintBrush\ProjectMintBrushBackend\App_Data\db.mdf;Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
