using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;  //data set
using System.Data.SqlClient;  // sqlconnection, sqlcommandbuilder, sqldataAdapter
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_CRUD_April301224
{
    public partial class Employee_Reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["EmpDB4AprilConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlDataAdapter adp = new SqlDataAdapter("select * from tblEmployee", con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adp);
            DataSet ds = new DataSet();
            adp.Fill(ds, "tblEmployee");

            DataRow row = ds.Tables["tblEmployee"].NewRow();
            row[0] = txtEmpID.Text;
            row["name"] = txtEmpName.Text;
            row["contact"] = txtContact.Text;
            row["cityName"] = dropCity.SelectedValue;

            ds.Tables["tblEmployee"].Rows.Add(row);
           int n= adp.Update(ds, "tblEmployee");
            if (n>0)
            {
                Response.Write("<script>alert('record inserted successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('record NOT inserted!!!!!');</script>");
            }


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            /*
            string constr = ConfigurationManager.ConnectionStrings["EmpDB4AprilConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlDataAdapter adp = new SqlDataAdapter("select * from tblEmployee", con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adp);
            DataSet ds = new DataSet();
            adp.Fill(ds, "tblEmployee");
            int i = 0;
            bool flag=false;
            while(i< ds.Tables["tblEmployee"].Rows.Count)
            {
                if (string.Compare(ds.Tables["tblEmployee"].Rows[i]["empid"].ToString(),txtEmpID.Text)==0)
                {
                    flag = true;
                    break;
                }
                i++;
            }
            txtEmpName.Text = ds.Tables["tblEmployee"].Rows[i]["name"].ToString();
            txtContact.Text= ds.Tables["tblEmployee"].Rows[i]["contact"].ToString();
            dropCity.Text= ds.Tables["tblEmployee"].Rows[i]["cityName"].ToString();
            */

            string constr = ConfigurationManager.ConnectionStrings["EmpDB4AprilConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlDataAdapter adp = new SqlDataAdapter("select * from tblEmployee where empid="+txtEmpID.Text, con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adp);
            DataSet ds = new DataSet();
            adp.Fill(ds, "tblEmployee");
            if (ds.Tables[0].Rows.Count==0)
            {
                Response.Write("<script>alert('record NOT found!!!!!');</script>");
                txtEmpName.Text = "";
                txtContact.Text = "";
               // dropCity.Text = "";
                btnUpdate.Enabled = false;
            }
            else 
            {
                txtEmpName.Text = ds.Tables["tblEmployee"].Rows[0]["name"].ToString();
                txtContact.Text = ds.Tables["tblEmployee"].Rows[0]["contact"].ToString();
                dropCity.Text = ds.Tables["tblEmployee"].Rows[0]["cityName"].ToString();
                btnUpdate.Enabled = true;
            }

            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["EmpDB4AprilConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlDataAdapter adp = new SqlDataAdapter("select * from tblEmployee", con);
            
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adp);
            DataSet ds = new DataSet();
            adp.Fill(ds, "tblEmployee");
            int i = 0;
            foreach (DataRow row1 in ds.Tables["tblEmployee"].Rows)
            {
                if (row1[0].ToString() == txtEmpID.Text)
                {
                    row1[0] = txtEmpID.Text;
                    row1["name"] = txtEmpName.Text;
                    row1["contact"] = txtContact.Text;
                    row1["cityName"] = dropCity.SelectedValue;
                }
            }
           int n= adp.Update(ds, "tblEmployee");
            if (n > 0)
            {
                Response.Write("<script>alert('record updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('record NOT updated!!!!!');</script>");
            }

        }
    }
}
