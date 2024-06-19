using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Fillgrid();
            }

        }

        public void Fillgrid()
        {
            SqlConnection con = new SqlConnection("Data Source= LAPTOP-HICFVN3N\\SQLEXPRESS; Integrated Security=true;Initial Catalog=Assignment");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_GetData", con);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);


            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            if (ds.Tables[0].Rows.Count>0)
            {
                grdData.DataSource = ds.Tables[0];
                grdData.DataBind();
            }
            else
            {
                lblmsg.Text = "No Records Found";
                lblmsg.ForeColor = System.Drawing.Color.Red;

            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                int id = Convert.ToInt32(ds.Tables[1].Rows[0]["ProductID"].ToString());
                id++;
                txtProductId.Text= id.ToString();
            }
            else
            {
                txtProductId.Text = "1";

            }

        }

        public int GetProductCount()
        {

            int count = 0;  
            SqlConnection con = new SqlConnection("Data Source= LAPTOP-HICFVN3N\\SQLEXPRESS; Integrated Security=true;Initial Catalog=Assignment");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_GetProductCount", con);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                count = Convert.ToInt32(dt.Rows[0]["count"].ToString());
            }
            else
            {
                count = 0;
                //lblmsg.Text = "No Records Found";
                //lblmsg.ForeColor = System.Drawing.Color.Red;

            }
            return count;
        }

        //private DataTable GetData()
        //{
        //    DataTable dt = new DataTable();

        //    using (SqlConnection con = new SqlConnection("Data Source= LAPTOP-HICFVN3N\\SQLEXPRESS; Integrated Security=true;Initial Catalog=Assignment"))

        //    {

        //        SqlCommand cmd = new SqlCommand("sp_GetData", con);

        //        con.Open();

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);

        //        da.Fill(dt);
        //        //grdData.DataSource =dt;
        //        //grdData.DataBind();


        //    }

        //    return dt;
        //}

        //protected void btnsubmit_Click(object sender, EventArgs e)
        //{

        //    try
        //    {

        //        if(btnsubmit.Text=="Submit")
        //        {

        //            if (FileUpload1.HasFile)
        //            {
        //                // Save the uploaded file to a folder on the server
        //                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
        //                string filePath = Server.MapPath("~/SavedImages/") + fileName;
        //                FileUpload1.SaveAs(filePath);




        //                // Add the new product data, including the image path, to your data source
        //                DataTable dt = GetData(); // Assume you have a method to get your data source
        //                DataRow newRow = dt.NewRow();
        //                newRow["ProductID"] = txtProductId.Text; // Set the appropriate values
        //                newRow["ProductName"] = txtProductName.Text;
        //                newRow["Price"] = txtPrice.Text;
        //                newRow["MRP"] = txtMRP.Text;
        //                newRow["ManagerEmail"] = txtManagerEmail.Text;
        //                newRow["PhoneNumber"] = txtPhone.Text;
        //                newRow["Description"] = txtDescription.Text;
        //                newRow["Images"] = "~/SavedImages/" + fileName; // Save the image path
        //                dt.Rows.Add(newRow);



        //                // Bind the updated data source to the GridView
        //                grdData.DataSource = dt;
        //                grdData.DataBind();
        //            }
        //            else
        //            {
        //                lblmsg.Text = "Please select an image file.";
        //            }

        //            int count = GetProductCount();
        //            if (count>10)
        //            {
        //                lblmsg.Text = "You cannot add more than 10 questions";
        //                lblmsg.ForeColor = System.Drawing.Color.Red;
        //                return ;
        //            }
        //            else
        //            {
        //                SqlConnection con = new SqlConnection("Data Source= LAPTOP-HICFVN3N\\SQLEXPRESS; Integrated Security=true;Initial Catalog=Assignment");
        //                con.Open();
        //                SqlCommand cmd = new SqlCommand("sp_InsertProduct", con);
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
        //                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
        //                cmd.Parameters.AddWithValue("@MRP", txtMRP.Text);
        //                cmd.Parameters.AddWithValue("@ManagerEmail", txtManagerEmail.Text);
        //                cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
        //                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
        //                cmd.Parameters.AddWithValue("@Images", "~/SavedImages/" + fileName);

        //                int res = cmd.ExecuteNonQuery();
        //                if (res > 0)
        //                {
        //                    lblmsg.Text = "Product Added Successfully";
        //                    lblmsg.ForeColor = System.Drawing.Color.Green;

        //                    txtProductName.Text = txtPrice.Text = txtMRP.Text = txtManagerEmail.Text = txtPhone.Text = txtDescription.Text = "";

        //                    Fillgrid();
        //                }
        //                else
        //                {
        //                    lblmsg.Text = "Unable to Add Product";
        //                    lblmsg.ForeColor = System.Drawing.Color.Red;
        //                };
        //            }




        //        }
        //        else
        //        {
        //            SqlConnection con = new SqlConnection("Data Source= LAPTOP-HICFVN3N\\SQLEXPRESS; Integrated Security=true;Initial Catalog=Assignment");
        //            con.Open();
        //            SqlCommand cmd = new SqlCommand("[sp_updateProduct]", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ProductID", txtProductId.Text);

        //            cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
        //            cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
        //            cmd.Parameters.AddWithValue("@MRP", txtMRP.Text);
        //            cmd.Parameters.AddWithValue("@ManagerEmail", txtManagerEmail.Text);
        //            cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
        //            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
        //            cmd.Parameters.AddWithValue("@Images", FileUpload1.FileName);




        //            int res = cmd.ExecuteNonQuery();
        //            if (res > 0)
        //            {
        //                lblmsg.Text = "Product Updated Successfully";
        //                lblmsg.ForeColor = System.Drawing.Color.Green;

        //                txtProductName.Text = txtPrice.Text = txtMRP.Text = txtManagerEmail.Text = txtPhone.Text = txtDescription.Text = "";

        //                Fillgrid();

        //                btnsubmit.Text = "Submit";
        //            }
        //            else
        //            {
        //                lblmsg.Text = "Unable to Update Product";
        //                lblmsg.ForeColor = System.Drawing.Color.Red;
        //            };
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        lblmsg.Text = "Something Went Wrong!!" + ex;
        //    }
        //}

        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection("Data Source= LAPTOP-HICFVN3N\\SQLEXPRESS; Integrated Security=true;Initial Catalog=Assignment"))
            {
                SqlCommand cmd = new SqlCommand("sp_GetData", con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }



        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnsubmit.Text == "Submit")
                {

                    if (FileUpload1.HasFile)
                    {
                        string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        string rootPath = Server.MapPath("~/SavedImages/");
                        string filePath = Path.Combine(rootPath, fileName);

                        filePath = Server.MapPath("~/SavedImages/") + fileName;
                        FileUpload1.SaveAs(filePath);



                        DataTable dt = GetData();
                        DataRow newRow = dt.NewRow();
                        newRow["ProductID"] = txtProductId.Text;
                        newRow["ProductName"] = txtProductName.Text;
                        newRow["Price"] = txtPrice.Text;
                        newRow["MRP"] = txtMRP.Text;
                        newRow["ManagerEmail"] = txtManagerEmail.Text;
                        newRow["PhoneNumber"] = txtPhone.Text;
                        newRow["Description"] = txtDescription.Text;
                        newRow["Images"] = "~/SavedImages/" + fileName;
                        //newRow["Images"] = filePath;
                        dt.Rows.Add(newRow);



                        grdData.DataSource = dt;
                        grdData.DataBind();
                    }
                    else
                    {
                        lblmsg.Text = "Please select an image file.";
                    }



                    int count = GetProductCount();
                    if (count > 10)
                    {
                        lblmsg.Text = "You cannot add more than 10 questions";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        using (SqlConnection con = new SqlConnection("Data Source= LAPTOP-HICFVN3N\\SQLEXPRESS; Integrated Security=true;Initial Catalog=Assignment"))
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("sp_InsertProduct", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                            cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                            cmd.Parameters.AddWithValue("@MRP", txtMRP.Text);
                            cmd.Parameters.AddWithValue("@ManagerEmail", txtManagerEmail.Text);
                            cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
                            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                            cmd.Parameters.AddWithValue("@Images", "~/SavedImages/"+FileUpload1.FileName );
                            //cmd.Parameters.AddWithValue("@Images", Server.MapPath("~/SavedImages/") + FileUpload1.FileName);
                            //cmd.Parameters.AddWithValue("@Images", filePath);




                            int res = cmd.ExecuteNonQuery();
                            if (res > 0)
                            {
                                lblmsg.Text = "Product Added Successfully";
                                lblmsg.ForeColor = System.Drawing.Color.Green;



                                txtProductName.Text = txtPrice.Text = txtMRP.Text = txtManagerEmail.Text = txtPhone.Text = txtDescription.Text = "";



                                Fillgrid();
                            }
                            else
                            {
                                lblmsg.Text = "Unable to Add Product";
                                lblmsg.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                }
                else
                {
                    using (SqlConnection con = new SqlConnection("Data Source= LAPTOP-HICFVN3N\\SQLEXPRESS; Integrated Security=true;Initial Catalog=Assignment"))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("[sp_updateProduct]", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProductID", txtProductId.Text);
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                        cmd.Parameters.AddWithValue("@MRP", txtMRP.Text);
                        cmd.Parameters.AddWithValue("@ManagerEmail", txtManagerEmail.Text);
                        cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@Images", "~/SavedImages/" + FileUpload1.FileName);



                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            lblmsg.Text = "Product Updated Successfully";
                            lblmsg.ForeColor = System.Drawing.Color.Green;



                            txtProductName.Text = txtPrice.Text = txtMRP.Text = txtManagerEmail.Text = txtPhone.Text = txtDescription.Text = "";



                            Fillgrid();
                        }
                        else
                        {
                            lblmsg.Text = "Unable to Update Product";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = "An error occurred: " + ex.Message;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }



        protected void grdData_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                //lblmsg.Text = string.Empty;
                //btnUpdate.Visible = true;
                //btnSave.Visible = false;
                Label lblProductId = (Label)grdData.Rows[e.NewSelectedIndex].FindControl("lblProductId");
     
                //ViewState["ProductId"] = lblProductId.Text;

                //Label lblProductId = (Label)grdData.Rows[e.NewSelectedIndex].FindControl("lblProductId");
                Label lblProductName = (Label)grdData.Rows[e.NewSelectedIndex].FindControl("lblProductName");
                Label lblprice = (Label)grdData.Rows[e.NewSelectedIndex].FindControl("lblprice");
                Label lblMRP = (Label)grdData.Rows[e.NewSelectedIndex].FindControl("lblMRP");
                Label lblManagerEmail = (Label)grdData.Rows[e.NewSelectedIndex].FindControl("lblManagerEmail");
                Label lblPhoneNumber = (Label)grdData.Rows[e.NewSelectedIndex].FindControl("lblPhoneNumber");
                Label lblDescription = (Label)grdData.Rows[e.NewSelectedIndex].FindControl("lblDescription");
                //Label lblImages = (Label)grdData.Rows[e.NewSelectedIndex].FindControl("lblImages");


                txtProductId.Text = lblProductId.Text;
                txtProductName.Text = lblProductName.Text;
                txtPrice.Text = lblprice.Text;
                txtMRP.Text = lblMRP.Text;
                txtManagerEmail.Text = lblManagerEmail.Text;
                txtPhone.Text = lblPhoneNumber.Text;
                txtDescription.Text = lblDescription.Text;

                btnsubmit.Text = "Update";

            }
            catch (Exception ex)
            {

                lblmsg.Text = "grdData_SelectedIndexChanging click " + ex;
                lblmsg.ForeColor = Color.Red;
            }
        }

        protected void grdData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblmsg.Text = string.Empty;
            try
            {
                Label lblProductId = (Label)grdData.Rows[e.RowIndex].FindControl("lblProductId");



                int ProductId = Convert.ToInt32(lblProductId.Text);
                string query = "sp_deleteProduct";
                SqlConnection con = new SqlConnection("Data Source= LAPTOP-HICFVN3N\\SQLEXPRESS; Integrated Security=true;Initial Catalog=Assignment");
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductID", ProductId);
                cmd.CommandType = CommandType.StoredProcedure;



                int result = cmd.ExecuteNonQuery();



                if (result > 0)
                {
                    lblmsg.Text = "Record deleted successfully";
                    lblmsg.ForeColor = Color.Blue;
                    Fillgrid();



                }



                else
                {
                    lblmsg.Text = "unable to delete record";
                    lblmsg.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {



                lblmsg.Text = "grdData_RowDeleting click " + ex;
                lblmsg.ForeColor = Color.Red;
            }
        }
    }
}