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
    public partial class Employee : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayRecord();
            }
        }
        private string name="sailesh";
        private string address;
        private int phoneNo;
        private string sex;
        private int bookId;

        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public int BookId { get; set; }

        private SqlConnection conn;

        public Employee()
        {
             conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConsString"].ConnectionString);
        }
        
        public DataTable DisplayRecord()
        {
            conn.Open();
            // SqlDataAdapter Adp = new SqlDataAdapter("select Employee.Id,Employee.Name,Address,PhoneNo,Sex,Book.Name as Names from Employee,Book where (Employee.Id in (Select EmployeeId from Borrow) AND Book.Id in(Select BookId from Borrow)) ", conn);
            SqlDataAdapter Adp = new SqlDataAdapter("select Employee.Id,Employee.Name,Address,PhoneNo,Sex,Book.Name as Names from Borrow Inner Join Employee on Employee.id=Borrow.EmployeeId Inner Join Book on Book.Id=Borrow.BookId ", conn);

            DataTable Dt = new DataTable();
                 
            Adp.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                grid1.DataSource = Dt;

                grid1.DataBind();

            }



            return Dt;
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConsString"].ConnectionString);
            conn.Open();
            string sql = "INSERT INTO Employee( Name,Address,PhoneNo,Sex) VALUES "
                    + " (@name,@address,@phoneNo,@sex)";

            SqlCommand insert = new SqlCommand(sql, conn);
            insert.Parameters.AddWithValue("@name", employeeName.Text);

            insert.Parameters.AddWithValue("@address", employeeAddress.Text);
            insert.Parameters.AddWithValue("@phoneNo",employeePhoneNo.Text);

            insert.Parameters.AddWithValue("@sex", employeeSex.Text);


            insert.CommandType = CommandType.Text;
            insert.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("Employee.aspx");
        }

        protected void grid1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)

        {
            grid1.EditIndex = e.NewEditIndex;
            DisplayRecord();
        }

        protected void grid1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            grid1.EditIndex = -1;
            DisplayRecord();
        }

        protected void grid1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConsString"].ConnectionString);
            conn.Open();
            //Finding the controls from Gridview for the row which is going to update  
            Label id = grid1.Rows[e.RowIndex].FindControl("EmployeeId") as Label;
            TextBox employeeName = grid1.Rows[e.RowIndex].FindControl("txt_EmployeeName") as TextBox;
            TextBox employeeAddress= grid1.Rows[e.RowIndex].FindControl("txt_EmployeeAddress") as TextBox;
            TextBox employeePhone = grid1.Rows[e.RowIndex].FindControl("txt_EmployeePhone") as TextBox;
            TextBox employeeSex = grid1.Rows[e.RowIndex].FindControl("txt_EmployeeSex") as TextBox;
            // TextBox employeeBook = grid1.Rows[e.RowIndex].FindControl("txt_EmployeeBook") as TextBox;

            //updating the record
            SqlCommand cmd = new SqlCommand("Update Employee set Name='" + employeeName.Text + "',Address='" + employeeAddress.Text + "' where Id=" + Convert.ToInt32(id.Text), conn);
            
            cmd.ExecuteNonQuery();
            conn.Close();
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            grid1.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            DisplayRecord();
            
        }

        protected void grid1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConsString"].ConnectionString);
            conn.Open();
            //Finding the controls from Gridview for the row which is going to update  
            Label id = grid1.Rows[e.RowIndex].FindControl("EmployeeId") as Label;
            TextBox employeeName = grid1.Rows[e.RowIndex].FindControl("txt_EmployeeName") as TextBox;
            TextBox employeeAddress = grid1.Rows[e.RowIndex].FindControl("txt_EmployeeAddress") as TextBox;
            TextBox employeePhone = grid1.Rows[e.RowIndex].FindControl("txt_EmployeePhone") as TextBox;
            TextBox employeeSex = grid1.Rows[e.RowIndex].FindControl("txt_EmployeeSex") as TextBox;
            Label employeeBook = grid1.Rows[e.RowIndex].FindControl("txt_EmployeeBook") as Label;

            //updating the record
            // SqlCommand cmd = new SqlCommand("Update Employee set Name='" + employeeName.Text + "',Address='" + employeeAddress.Text + "' where Id=" + Convert.ToInt32(id.Text), conn);

           string NoofBook;
            SqlCommand cmd = new SqlCommand("Select NoofBookIssued from Borrow where EmployeeId=@id", conn);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id.Text));
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                if (reader.Read())
                {
                 
                    NoofBook = reader["NoofBookIssued"].ToString();
                    conn.Close();
                    conn.Open();
                    SqlCommand update = new SqlCommand("Update Borrow set NoofBookIssued -=1 where EmployeeId=@id", conn);
                    SqlCommand update1 = new SqlCommand("Update Book set Quantity +=1 where Name=@employeeBook", conn);
                    SqlCommand delete=new SqlCommand("Delete from Borrow where BookId in (Select Id from Book where Name=@employeeBook)", conn);

                    update.Parameters.AddWithValue("@id", Convert.ToInt32(id.Text));
                    update1.Parameters.AddWithValue("@employeeBook", employeeBook.Text);
                    delete.Parameters.AddWithValue("@employeeBook", employeeBook.Text);


                    update.CommandType = CommandType.Text;
                    update.ExecuteNonQuery();
                    update1.CommandType = CommandType.Text;
                    update1.ExecuteNonQuery();
                    

                    delete.CommandType = CommandType.Text;
                    delete.ExecuteNonQuery();






                }
            }

            


             
            
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            grid1.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            DisplayRecord();
            Response.Redirect("Employee.aspx");
            
        }
    }  // end of employee class
}