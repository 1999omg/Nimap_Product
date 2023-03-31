using Microsoft.Data.SqlClient;

namespace Nimap_Product.Models
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;


        public ProductDAL(IConfiguration configuration)
        {

            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("MyDbConnection"));



        }

        public int AddProduct(Products prod)
        {
            int result = 0;
            string qry = "insert into tblProduct values (@pId,@pName,@pPrice)";
            
            cmd = new SqlCommand(qry, con);
            con.Open();
            cmd.Parameters.AddWithValue("@pId", prod.ProductId);
            cmd.Parameters.AddWithValue("@pName", prod.ProductName);
            cmd.Parameters.AddWithValue("@pPrice", prod.ProductPrice);

            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


        public List<Products> list()
        {
            List<Products> list = new List<Products>();
            string str = "select *from tblProduct";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {


                    Products prod = new Products();
                    prod.ProductId = Convert.ToInt32(dr["pId"]);
                    prod.ProductName = dr["pName"].ToString();
                    prod.ProductPrice = Convert.ToDecimal(dr["pPrice"]);
                    list.Add(prod);

                }

                con.Close();
                return list;

            }
            con.Close();

            return list;


        }


        public Products  GetProductById (int productId)
        {
            string qry = "select * from tblProduct where pId=@ProductId";
            Products prod = new Products();
            cmd = new SqlCommand(qry, con);
            con.Open();
            cmd.Parameters.AddWithValue("@pId", productId);
            
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    prod.ProductId = Convert.ToInt32(dr["pId"]);
                    prod.ProductName = dr["pName"].ToString();
                    prod.ProductPrice = Convert.ToDecimal(dr["pPrice"]);
                }
            }
            con.Close();
            return prod;
        }

        public int DeleteProduct (int productId)
        {
            int result = 0;
            string qry = "delete from tblProduct where pId=@ProductId";
            cmd= new SqlCommand(qry, con);  
            con.Open();
            cmd.Parameters.AddWithValue("@pId", productId);
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
            

        }

        public int UpdateProduct (Products prod)
        {
            int result = 0;
            string qry = "update tblProduct where pId=@ProductId set (pName=@ProductName,pPrice=@ProductPrice)";
            cmd= new SqlCommand(qry, con);
            con.Open();
            cmd.Parameters.AddWithValue("@pId", prod.ProductId);
            cmd.Parameters.AddWithValue("@pName",prod.ProductName);
            cmd.Parameters.AddWithValue("@pPrice", prod.ProductPrice);

            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;


        }


    }
}
