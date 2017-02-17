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
    public partial class AssignBook : System.Web.UI.Page
    {
        private SqlConnection conn;
        public AssignBook()
        {
            conn= new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConsString"].ConnectionString);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            bookIssuedDate.Text = DateTime.Now.Date.ToShortDateString();

            string com = "Select Name from Employee";
            string book = "Select Name from Book";


            SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
            SqlDataAdapter bookAdapter = new SqlDataAdapter(book, conn);

            DataSet myDataSet = new DataSet();
            DataSet bookDataset = new DataSet();
          
            adpt.Fill(myDataSet, "UserDetail");
            bookAdapter.Fill(bookDataset, "BookDetails");

            DataTable myDataTable = myDataSet.Tables[0];
            DataTable bookTable = bookDataset.Tables[0];

            DataRow tempRow = null;
            DataRow bookRow = null;


            foreach (DataRow tempRow_Variable in myDataTable.Rows)
            {
                tempRow = tempRow_Variable;
                // BookList.Items.Add((tempRow["Name"] + " (" + tempRow["Author"] + ")" + " (" + tempRow["PublicationDate"] + ")" + " (" + tempRow["Quantity"] + ")"));
                AssignEmployeeList.Items.Add(tempRow["Name"] + "");
                
            }
            
            foreach (DataRow tempBook_Variable in bookTable.Rows)
            {
                bookRow = tempBook_Variable;
                // BookList.Items.Add((tempRow["Name"] + " (" + tempRow["Author"] + ")" + " (" + tempRow["PublicationDate"] + ")" + " (" + tempRow["Quantity"] + ")"));
                AssignBookList.Items.Add(bookRow["Name"] + "");
                
            }
            conn.Close();

        }

        protected void AssignBookList_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        /*
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();
        }
        */
        protected void submit_Click(object sender, EventArgs e)
        {
            string curItem = AssignBookList.SelectedItem.ToString();
            string employee = AssignEmployeeList.SelectedItem.ToString();

            int bookId;
            int employeeId;
                 
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConsString"].ConnectionString);
                
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select Id,Name,Quantity from Book where Name=@name", conn);
            cmd.Parameters.AddWithValue("@name", curItem);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                
                if (reader.Read())
                {
                    bookId = (int)reader["Id"];
                    int quantity = (int)reader["Quantity"];
                    string book = (string)reader["Name"];

                    if (AssignBookList.SelectedItem.ToString() != " " && AssignBookList.SelectedItem.ToString() != " ")
                    {
                        quantity--;
                        conn.Close();
                        conn.Open();
                        SqlCommand insert1 = new SqlCommand("Update Book SET Quantity = @quantity where Name=@name", conn);
                        insert1.Parameters.AddWithValue("@quantity", quantity);
                        insert1.Parameters.AddWithValue("@name", book);
                        insert1.CommandType = CommandType.Text;
                        insert1.ExecuteNonQuery();


                        conn.Close();
                        conn.Open();
                        //SqlCommand update = new SqlCommand("Update Borrow SET NoofBookIssued += 1 where BookId=@bookId", conn);
                        
                        //insert1.Parameters.AddWithValue("@bookId", bookId);
                        //insert1.CommandType = CommandType.Text;
                        //insert1.ExecuteNonQuery();




                    }

                    conn.Close();
                    conn.Open();

                    string sql = "INSERT INTO Borrow( IssueDate,BookId) VALUES "
                     + " (@IssueDate,@BookId)";

                    SqlCommand insert = new SqlCommand(sql, conn);
                    insert.Parameters.AddWithValue("@IssueDate", bookIssuedDate.Text);

                    insert.Parameters.AddWithValue("@BookId", bookId);
                    insert.CommandType = CommandType.Text;
                    insert.ExecuteNonQuery();
                    conn.Close();





                }
            }

            
            /* this is done because MUltiple sql command is not possible 
            The connection has to be closed and open again
            
            */
            conn.Open();
             //Done to get Employee Id
            SqlCommand cmd1 = new SqlCommand("Select Id,Name from Employee where Name=@name", conn);
            cmd1.Parameters.AddWithValue("@name", employee);
            cmd1.CommandType = CommandType.Text;
            cmd1.ExecuteNonQuery();
            using (SqlDataReader reader = cmd1.ExecuteReader())
            {
                if (reader.Read())
                {

                    employeeId = (int)reader["Id"];
                    string employeeName = (string)reader["Name"];


                    conn.Close();
                    conn.Open();
                    
                     SqlCommand insert = new SqlCommand("Update Borrow SET EmployeeId = @employeeId where EmployeeId is null", conn);
                    SqlCommand update = new SqlCommand("Update Borrow SET NoofBookIssued +=1 where EmployeeId=@employeeId", conn);
                    
                   insert.Parameters.AddWithValue("@employeeId", employeeId);
                    update.Parameters.AddWithValue("@employeeId", employeeId);



                    update.CommandType = CommandType.Text;
                    update.ExecuteNonQuery();

                   insert.CommandType = CommandType.Text;
                    insert.ExecuteNonQuery();
                    conn.Close();

                }

            }  //end of using


            







            //FOr inserting into Borrow Table
            //conn.Open();
            //Done to get Employee Id



            Response.Redirect("Employee.aspx");
    } //end of onclick function














        } //end of class
}