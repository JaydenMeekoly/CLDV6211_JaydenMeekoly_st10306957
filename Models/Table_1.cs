using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Xml.Linq;


namespace OnlineStore.Models
{
    public class Table_1 
    {
        public static string con_string = "Server=tcp:cloud-server.database.windows.net,1433;Initial Catalog=Cldv-DB1;Persist Security Info=False;User ID=JaydenServerAdminLogin;Password=JayMeeko01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        //public static string con_string = "Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=test;Data Source=labVMH8OX\\SQLEXPRESS";
        public static SqlConnection con = new SqlConnection(con_string);

        public String Name { get; set; }

        public String Surname { get; set; }

        public String Email { get; set; }

        public int InsertUser(Table_1 n)
        {


                string sql = "insert into Table_1 (userName , userSurname, userEmail) VALUES (@Name, @Surname, @Email)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", n.Name);
                cmd.Parameters.AddWithValue("@Surname", n.Surname);
                cmd.Parameters.AddWithValue("@Email", n.Email);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
        }
            

        
    }

    }
