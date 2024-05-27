using System.Data.SqlClient;
using NuGet.Protocol.Plugins;


namespace OnlineStore.Models
{
    public class productTable
    {
        public static string con_string = "Server=tcp:cloud-server.database.windows.net,1433;Initial Catalog = Cldv-DB1; Persist Security Info=False;User ID = JaydenServerAdminLogin; Password=JayMeeko01; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;\r\n";
        //public static string con_string = "Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=test;Data Source=labVMH8OX\\SQLEXPRESS";
        public static SqlConnection con = new SqlConnection(con_string);

        public int ProductID { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string Category { get; set; }

        public string Availability { get; set; }



        public int Insert_product(productTable p)
        {
            try
            {
                string sql = "INSERT INTO ProductTable (ProductName, ProductPrice, ProductCategory, ProductAvailability) VALUES (@Name, @Price, @Category, @Availability)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Availability", p.Availability);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }   
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw ex;
            }


        }

        // Method to retrieve all products from the database
        public static List<productTable> GetAllProducts()
        {
            List<productTable> products = new List<productTable>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM ProductTable";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    productTable product = new productTable();
                    product.ProductID = Convert.ToInt32(rdr["productID"]);
                    product.Name = rdr["ProductName"].ToString();
                    product.Price = rdr["ProductPrice"].ToString();
                    product.Category = rdr["ProductCategory"].ToString();
                    product.Availability = rdr["ProductAvailability"].ToString();

                    products.Add(product);
                }
            }

            return products;
        }
    }
}