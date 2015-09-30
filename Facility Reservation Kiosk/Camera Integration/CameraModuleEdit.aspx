<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Camera.Master" AutoEventWireup="true" CodeBehind="CameraModuleEdit.aspx.cs" Inherits="Camera_Integration.CameraModuleEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<asp:ScriptManager runat="server">
     
    </asp:ScriptManager>
    <section class="content-header">
        <h1>Edit&nbsp; Camera

        </h1>
         <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Camera</li>
        </ol>
     </section>
    <section class="content">
        <div class="row">
            <!-- left column -->
            <div class="col-md-12">
                <div class="box box-primary">
                    
                    <div id="setDisplayNone" runat="server" style='padding: 8px; display: none'>
                        <div class="callout callout-danger">
                            <asp:Label ID="lblResult" runat="server"></asp:Label>
                        </div>
                    </div>
                    <!-- /.content -->

                    <div class="box-body">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <div class="form-group">
                                         <label style="color: #000000"><span class="glyphicon glyphicon-cutlery">&nbsp;Facility:</span></label>
                                         <br />
                                         <asp:DropDownList ID="ddlFacilityID" runat="server" AppendDataBoundItems="True" CssClass="form-control" OnSelectedIndexChanged="ddlFacilityID_SelectedIndexChanged" Width="667px" AutoPostBack="True">
                                             <asp:ListItem>~SELECT~</asp:ListItem>
                                         </asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="RequireddlFacility" runat="server" ControlToValidate="ddlFacilityID" ErrorMessage="This field is required" ></asp:RequiredFieldValidator>
                                         <br />
                                        </div>
                                    </td>
                                </tr>
                            <tr>
                            <td>
                              <div class="form-group">

                                  <asp:Label ID="Label1" runat="server" Text="Camera IP Address:"></asp:Label>
                                  <br />
                                  <asp:TextBox ID="txtIPAddress" runat="server"></asp:TextBox>
                                  <br />

                                  <asp:RequiredFieldValidator ID="RequiredtxtIPAddress" runat="server" ControlToValidate="txtIPAddress" Display="None" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                                  <br />

                              </div>
                            </td>
                            </tr>
                             <tr>
                            <td>
                              <div class="form-group">

                                  <asp:Label ID="Label2" runat="server" Text="Minimum Density"></asp:Label>
                                  <br />
                                  <asp:TextBox ID="txtMinDensity" runat="server" CssClass="form-control" Width="641px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredtxtMinDensity" runat="server" ControlToValidate="txtMinDensity" Display="None" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                                  <br />

                              </div>
                            </td>
                            </tr>
                             <tr>
                            <td>
                              <div class="form-group">

                                  <asp:Label ID="Label3" runat="server" Text="Maximum Density"></asp:Label>
                                  <br />
                                  <asp:TextBox ID="txtMaxDensity" runat="server" Width="666px"></asp:TextBox>
                                  <br />
                                  <asp:RequiredFieldValidator ID="RequiredtxtMaxDensity" runat="server" ControlToValidate="txtMaxDensity" Display="None" ErrorMessage="This field is required"></asp:RequiredFieldValidator>
                                  <br />
                                  <br />
                                  <asp:Button ID="btnEdit" runat="server" Height="35px" Text="Edit" Width="95px" OnClick="btnEdit_Click" />
                                  <br />
                                  <br />
                                  <asp:Label ID="lblDisplay" runat="server"></asp:Label>
                                  <br />

                              </div>
                            </td>
                            </tr>
                            </table>
                        </div>
                    </div>
                                   
        </div>
   </div>
  </section> 
</asp:Content>

  

  

