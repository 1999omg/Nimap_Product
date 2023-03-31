using Microsoft.Data.SqlClient;

namespace Nimap_Product.Models
{
    public class CategoryDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;


        public  CategoryDAL (IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("MyDbConnection"));
        }

        public List<Category> List()
        {

            string qry = "select * from tblCategory ";
            List <Category> list = new List<Category>();
            cmd=new SqlCommand(qry,con);
            con.Open();
            dr = cmd.ExecuteReader();

            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    Category cad = new Category();
                    cad.CategoryId = Convert.ToInt32(dr["cId"]);
                    cad.CategoryName = dr["cName"].ToString();
                    list.Add(cad);

                }
            }
            con.Close();
            return list;

        }

        public Category GetCategoryById (int CategoryId)
        {
            Category cad = new Category();

            string qry = "Select * from tblCategory where cId=@CategoryId";
            cmd= new SqlCommand(qry,con);   
            con.Open();

            cmd.Parameters.AddWithValue("@cId", CategoryId);
        

            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cad.CategoryId = Convert.ToInt32(dr["cId"]);
                    cad.CategoryName = dr["cName"].ToString() ;
                }

       
                con.Close();
            }

            return cad;

        }

        public int AddCategory (Category cad) {

            int result= 0;
            string qry = "insert into tblCategory values (@cId,@cName)";
            cmd= new SqlCommand(qry,con);
            con.Open();
           // Category cad = new Category();
            cmd.Parameters.AddWithValue("@cId", cad.CategoryId);
            cmd.Parameters.AddWithValue("@cName", cad.CategoryName);

            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int DeleteCategory (int CategoryId)
        {
            int result= 0;
            string qry = "delete tblCategory where cId=@CategoryId";
            cmd= new SqlCommand(qry,con);
            con.Open();
            result= cmd.ExecuteNonQuery();
            return result;
            con.Close();
        }
    }
}
