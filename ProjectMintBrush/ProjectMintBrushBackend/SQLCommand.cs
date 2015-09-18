using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Xml;
using System.IO;
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
        /// <summary>
        /// pass for type -- a = account c = commentEntry en = entry ev = event
        /// </summary>
        /// <typeparam name="T">Generic type of class being passed in, has to extend IModel</typeparam>
        /// <param name="type">the type of class that it is</param>
        /// <param name="obj">T object</param>
        public static void ExecuteQuerySaveObject<T>(string type, T obj) where T : ProjectMintBrushBackend.Models.IModel
        {
            string db = String.Empty;
            if(type == "a"){
                db = "Account";
            }else if(type == "c"){
                db = "CommentEntry";
            }else if(type == "en"){
                db = "Entry";
            }else if(type == "ev"){
                db = "Event";
            }

            string xml = CreateXML(obj);
            string query = "INSERT INTO " + db + " VALUES('" + obj.GetID().ID + "','" + xml + "')";

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Gretchen\Documents\GitHub\ProjecMintBrush\ProjectMintBrush\ProjectMintBrushBackend\App_Data\XMLStorage.mdf;Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static T ExecuteQueryLoadObject<T>(string hexcode, string database, string column) where T : ProjectMintBrushBackend.Models.IModel
        {
            string query = "SELECT " + column + " FROM " + database + " WHERE(ID = '" + hexcode + "')";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Gretchen\Documents\GitHub\ProjecMintBrush\ProjectMintBrush\ProjectMintBrushBackend\App_Data\XMLStorage.mdf;Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            var reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    var xml = reader.GetSqlXml(0);
                    con.Close();
                    return LoadFromXMLString<T>(xml.Value);
                }
                else
                {
                    con.Close();
                    return default(T);
                }
                
            }
            else
            {
                con.Close();
                return default(T);
            }
        }

        public static void ExecuteQueryAddEntryToList(string hexcode, string table, string idToAdd, string listToAdd)
        {
            string query = "declare @doc xml  select @doc = Object from " + table + " where ID = '" + hexcode + "'  set @doc.modify('insert <IdentificationNumber><ID>" + idToAdd + "</ID></IdentificationNumber> after (/" + table + "/" + listToAdd + "/IdentificationNumber)[1]')  update " + table + " set Object = @doc where ID = '" + hexcode + "'";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Gretchen\Documents\GitHub\ProjecMintBrush\ProjectMintBrush\ProjectMintBrushBackend\App_Data\XMLStorage.mdf;Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static void ExecuteQueryRemoveEntryFromList(string hexcode, string table, string idToDelete, string listToDeleteFrom)
        {
            string query = "declare @doc xml select @doc = Object from " + table + " where ID = '" + hexcode + "' if @doc IS NOT NULL BEGIN set @doc.modify('delete " + table+ "Model/" + listToDeleteFrom + "/IdentificationNumber/ID[text()][contains(.," + '"' + idToDelete + '"' + ")]')  set @doc.modify('delete AccountModel/EntriesOwned/IdentificationNumber[empty(./*)]') update " + table +" set Object = @doc where ID = '" + hexcode +"' END";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Gretchen\Documents\GitHub\ProjecMintBrush\ProjectMintBrush\ProjectMintBrushBackend\App_Data\XMLStorage.mdf;Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static void ExecuteQueryAddIDToIDList(string id)
        {
            ExecuteQuery("INSERT INTO dbo.IdentificationNumbers VALUES('" + id + "')");
        }

        public static void ExecuteQueryRemoveAccount(string hexcode, string username, string password, string email)
        {
            string query = "delete * from Users where ID = " + hexcode + " and USER_NAME = " + username + " and password = " + password + " and email = " + email;
            string query2 = "delete * from Account where ID = " + hexcode;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Gretchen\Documents\GitHub\ProjecMintBrush\ProjectMintBrush\ProjectMintBrushBackend\App_Data\XMLStorage.mdf;Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand(query2, con);
            com.ExecuteNonQuery();
            con.Close();
            ExecuteQuery(query);
        }

        private static string CreateXML(Object YourClassObject)
        {
            XmlDocument xmlDoc = new XmlDocument();   //Represents an XML document, 
            // Initializes a new instance of the XmlDocument class.          
            XmlSerializer xmlSerializer = new XmlSerializer(YourClassObject.GetType());
            // Creates a stream whose backing store is memory. 
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, YourClassObject);
                xmlStream.Position = 0;
                //Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }
        }

        private static T LoadFromXMLString<T>(string xmlText) where T : ProjectMintBrushBackend.Models.IModel
        {
            var stringReader = new System.IO.StringReader(xmlText);
            var serializer = new XmlSerializer(typeof(T));
            object x = serializer.Deserialize(stringReader);
            if (x != null)
            {
                return (T)x;
            }
            else
            {
                return default(T);
            }
            
        }
    }


}
