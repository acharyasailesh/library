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
    public partial class AddBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { 

        }

        protected void submit_Click(object sender, EventArgs e)
        {

            ExecuteInsert(bookName.Text, bookAuthor.Text, Calendar1.SelectedDate.ToShortDateString(), int.Parse(ISBN.Text), int.Parse(quantity.Text)
                                          );
            Response.Write("Record was successfully added!");

            ClearControls(Page);

        }
        

        

        public string GetConnectionString()
        {
            //sets the connection string from your web config file "ConnString" is the name of your Connection String
            return System.Configuration.ConfigurationManager.ConnectionStrings["MyConsString"].ConnectionString;
        }

        private void ExecuteInsert(string name, string author, string
             publication,int ISBN, int quantity)
        {

            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql = "INSERT INTO Book ( Name,Author,PublicationDate,ISBN,Quantity) VALUES "
                        + " (@Name,@Author,@PublicationDate,@ISBN,@Quantity)";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter[] param = new SqlParameter[6];
                
                // param[0] = new SqlParameter("@Id", SqlDbType.Int, 50);
                param[1] = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                param[2] = new SqlParameter("@Author", SqlDbType.VarChar, 50);
                param[3] = new SqlParameter("@PublicationDate", SqlDbType.VarChar, 50);
                param[4] = new SqlParameter("@ISBN", SqlDbType.Int, 50);
                param[5] = new SqlParameter("@Quantity", SqlDbType.Int, 50);
                

                 // param[0].Value =id;
                param[1].Value = name;
                param[2].Value = author;
                param[3].Value = publication;
                param[4].Value = ISBN;
                param[5].Value = quantity;
                

                for (int i = 1; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            
            TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        public static void ClearControls(Control Parent)
        {

            if (Parent is TextBox)
            { (Parent as TextBox).Text = string.Empty; }
            else
            {
                foreach (Control c in Parent.Controls)
                    ClearControls(c);
            }
        }
    }
}