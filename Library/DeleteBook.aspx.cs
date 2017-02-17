using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class DeleteBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConsString"].ConnectionString);
            string com = "Select Name, Author,PublicationDate,Quantity from Book";

            SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
            DataSet myDataSet = new DataSet();
            adpt.Fill(myDataSet, "UserDetail");
            DataTable myDataTable = myDataSet.Tables[0];
            DataRow tempRow = null;

            foreach (DataRow tempRow_Variable in myDataTable.Rows)
            {
                tempRow = tempRow_Variable;
                // BookList.Items.Add((tempRow["Name"] + " (" + tempRow["Author"] + ")" + " (" + tempRow["PublicationDate"] + ")" + " (" + tempRow["Quantity"] + ")"));
                 BookList.Items.Add(tempRow["Name"]+"" );

                
            }
            conn.Close();
        }
    
       



        protected void submit_Click(object sender, EventArgs e)
        {
            int totalBook, remaining;
            int bookDeletedByUser = int.Parse(deletedBookNo.Text);

            string curItem = BookList.SelectedItem.ToString();

            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConsString"].ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select Quantity from Book where name=@quantity", conn);
            cmd.Parameters.AddWithValue("@quantity", curItem);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                
                if (reader.Read())
                {
                    
                    totalBook = (int)reader["Quantity"];
                    remaining = totalBook - bookDeletedByUser;
                    conn.Close();
                    conn.Open();

                    SqlCommand cmd1 = new SqlCommand("Update Book SET Quantity=@quantity where name=@bookName", conn);

                    cmd1.Parameters.AddWithValue("@quantity", remaining);
                    cmd1.Parameters.AddWithValue("@bookName", curItem);
                    cmd1.CommandType = CommandType.Text;
                    cmd1.ExecuteNonQuery();
                    conn.Close();

                    if (remaining < 0)
                    {
                        conn.Open();

                        SqlCommand delete = new SqlCommand("Delete from Book where  name=@bookName", conn);
                        
                        delete.Parameters.AddWithValue("@bookName", curItem);
                        delete.CommandType = CommandType.Text;
                        delete.ExecuteNonQuery();
                        conn.Close();
                        Response.Redirect("DeleteBook.aspx");

                    }


                    else
                   Response.Write("Successfully deleted Books. Now total Books is" +remaining);


                }
            }








            

        }

        
    } //end of class
} //end of namespace