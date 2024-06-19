<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Assignment.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">

    <script type="text/javascript">
        function validateMRP() {
            var price = document.getElementById('<%= txtPrice.ClientID %>').value;
            var mrp = document.getElementById('<%= txtMRP.ClientID %>').value;
            if (parseFloat(mrp) < parseFloat(price)) {
                document.getElementById('mrpValidationMsg').style.display = 'inline';
            } else {
                document.getElementById('mrpValidationMsg').style.display = 'none';
            }
        }
        function validateForm() {
            var isValid = true;
            var errorMessage = "";




            var productName = document.getElementById('<%=txtProductName.ClientID%>').value.trim();
            var price = document.getElementById('<%=txtPrice.ClientID%>').value.trim();
            var mrp = document.getElementById('<%=txtMRP.ClientID%>').value.trim();
            var managerEmail = document.getElementById('<%=txtManagerEmail.ClientID%>').value.trim();
            var phone = document.getElementById('<%=txtPhone.ClientID%>').value.trim();
            var description = document.getElementById('<%=txtDescription.ClientID%>').value.trim();
            var fileUpload = document.getElementById('<%=FileUpload1.ClientID%>');



            if (productName === "") {
                errorMessage += "Product Name is required.\n";
                isValid = false;
            }



            if (price === "" || isNaN(price)) {
                errorMessage += "Valid Price is required.\n";
                isValid = false;
            }



            if (mrp === "" || isNaN(mrp)) {
                errorMessage += "Valid MRP is required.\n";
                isValid = false;
            }



            if (managerEmail === "") {
                errorMessage += "Manager Email is required.\n";
                isValid = false;
            } else {
                var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
                if (!emailPattern.test(managerEmail)) {
                    errorMessage += "Valid Manager Email is required.\n";
                    isValid = false;
                }
            }



            if (phone === "" || isNaN(phone)) {
                errorMessage += "Valid Phone Number is required.\n";
                isValid = false;
            }



            if (description === "") {
                errorMessage += "Description is required.\n";
                isValid = false;
            }



            //if (!fileUpload.hasChildNodes()) {
            //    errorMessage += "Image is required.\n";
            //    isValid = false;
            //}



            if (!isValid) {
                alert(errorMessage);
            }



            return isValid;
        }
    </script>
</head>
<form id="form1" runat="server">
    <div>
        <h1>Product Page</h1>


        <table class="table" style="width: 100%; text-align: center">
            <tr>
                <td style="width: 50%; text-align: right">

                    <asp:Label ID="Label8" runat="server" Text="Product ID"></asp:Label>
                    <span style="color: red">*</span>
                </td>
                <td style="width: 50%; text-align: left">
                    <asp:TextBox ID="txtProductId" Enabled="false" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="width: 50%; text-align: right">

                    <asp:Label ID="Label1" runat="server" Text="Product Name"></asp:Label>
                    <span style="color: red">*</span>
                </td>
                <td style="width: 50%; text-align: left">
                    <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="width: 50%; text-align: right">
                    <asp:Label ID="Label2" runat="server" Text="Price"></asp:Label>
                    <span style="color: red">*</span>
                </td>
                <td style="width: 50%; text-align: left">
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 50%; text-align: right">
                    <asp:Label ID="Label3" runat="server" Text="MRP"></asp:Label>
                    <span style="color: red">*</span>
                </td>
                <td style="width: 50%; text-align: left">
                    <asp:TextBox ID="txtMRP" runat="server" onblur="validateMRP()"></asp:TextBox>
                    <span id="mrpValidationMsg" style="color: red; display: none;">MRP should not be less than Price</span>
                </td>
            </tr>

            <%-- <tr>
                <td style="width: 50%; text-align: right">
                    <asp:Label ID="Label2" runat="server" Text="Price"></asp:Label>
                    <span style="color: red">*</span>

                </td>
                <td style="width: 50%; text-align: left">
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="width: 50%; text-align: right">
                    <asp:Label ID="Label3" runat="server" Text="MRP"></asp:Label>
                    <span style="color: red">*</span>

                </td>
                <td style="width: 50%; text-align: left">
                    <asp:TextBox ID="txtMRP" runat="server"></asp:TextBox>
                </td>
            </tr>--%>

            <tr>
                <td style="width: 50%; text-align: right">
                    <asp:Label ID="Label4" runat="server" Text="Manager Email"></asp:Label>
                    <span style="color: red">*</span>

                </td>
                <td style="width: 50%; text-align: left">
                    <asp:TextBox ID="txtManagerEmail" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="width: 50%; text-align: right">
                    <asp:Label ID="Label5" runat="server" Text="Phone Number"></asp:Label>
                    <span style="color: red">*</span>

                </td>
                <td style="width: 50%; text-align: left">
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="width: 50%; text-align: right">
                    <asp:Label ID="Label6" runat="server" Text="Description"></asp:Label>
                    <span style="color: red">*</span>

                </td>
                <td style="width: 50%; text-align: left">
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="width: 50%; text-align: right">
                    <asp:Label ID="Label7" runat="server" Text="Image"></asp:Label>
                    <span style="color: red">*</span>

                </td>
                <td style="width: 50%; text-align: left">

                    <asp:FileUpload ID="FileUpload1" runat="server" />

                </td>
            </tr>

            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                </td>
            </tr>

            <tr>
                <td colspan="2" style="text-align: center">
                    <%--                     <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />--%>
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClientClick="return validateForm();" OnClick="btnsubmit_Click" />
                    <%--                    <asp:Button ID="btnupdate" runat="server" Text="Update" visible="false"/>--%>

                </td>
            </tr>

        </table>

        <table class="table" style="width: 100%; text-align: center">
            <tr>
                <td style="text-align: center">

                    <%--<asp:GridView ID="grdData" runat="server">
                     </asp:GridView>--%>

                    <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanging="grdData_SelectedIndexChanging" OnRowDeleting="grdData_RowDeleting">
                        <columns>
                            <asp:TemplateField HeaderText="Product Id">
                                <itemtemplate>
                                    <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Name">
                                <itemtemplate>
                                    <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Price">
                                <itemtemplate>
                                    <asp:Label ID="lblprice" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MRP">
                                <itemtemplate>
                                    <asp:Label ID="lblMRP" runat="server" Text='<%# Eval("MRP") %>'></asp:Label>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Manager Email">
                                <itemtemplate>
                                    <asp:Label ID="lblManagerEmail" runat="server" Text='<%# Eval("ManagerEmail") %>'></asp:Label>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone Number">
                                <itemtemplate>
                                    <asp:Label ID="lblPhoneNumber" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:Label>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <itemtemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Image" HeaderStyle-Width="200px">
                                <Itemtemplate>
                                    <%--<asp:Label ID="lblImages" runat="server" Text='<%# Eval("Images") %>'></asp:Label>--%>
                                       <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Images") %>' Height="80px" Width="100px" />
                                </Itemtemplate>
                            </asp:TemplateField>



                            <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                            <asp:TemplateField ShowHeader="False">
                                <itemtemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('Are you sure u want to delete ?')" Text="Delete"></asp:LinkButton>


                                </itemtemplate>
                            </asp:TemplateField>

                        </columns>
                        <footerstyle backcolor="#F7DFB5" forecolor="#8C4510" />
                        <headerstyle backcolor="#A55129" font-bold="True" forecolor="White" />
                        <pagerstyle forecolor="#8C4510" horizontalalign="Center" />
                        <rowstyle backcolor="#FFF7E7" forecolor="#8C4510" />
                        <selectedrowstyle backcolor="#738A9C" font-bold="True" forecolor="White" />
                        <sortedascendingcellstyle backcolor="#FFF1D4" />
                        <sortedascendingheaderstyle />
                        <sorteddescendingcellstyle backcolor="#F1E5CE" />
                        <sorteddescendingheaderstyle backcolor="#93451F" />
                    </asp:GridView>

                </td>
            </tr>
        </table>
    </div>
</form>
</html>
