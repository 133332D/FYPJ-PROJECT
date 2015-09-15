<%@ Page Title="" Language="C#" MasterPageFile="~/Camera.Master" AutoEventWireup="true" CodeBehind="CameraModuleEdit.aspx.cs" Inherits="Camera_Integration.CameraModuleEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <section class="content-header">
        <h1>Edit Camera

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
                    <div class="box-header">
                        <h4 class="modal-title">Create</h4>
                    </div>
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
                                         <asp:DropDownList ID="ddlFacilityID" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                             <asp:ListItem>-Select-</asp:ListItem>
                                         </asp:DropDownList>
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

                              </div>
                            </td>
                            </tr>
                             <tr>
                            <td>
                              <div class="form-group">

                                  <asp:Label ID="Label2" runat="server" Text="Minimum Density"></asp:Label>
                                  <br />
                                  <asp:TextBox ID="txtMinDensity" runat="server"></asp:TextBox>
                                  <br />

                              </div>
                            </td>
                            </tr>
                             <tr>
                            <td>
                              <div class="form-group">

                                  <asp:Label ID="Label3" runat="server" Text="Maximum Density"></asp:Label>
                                  <br />
                                  <asp:TextBox ID="txtMaxDensity" runat="server"></asp:TextBox>
                                  <br />

                              </div>
                            </td>
                            </tr>
                            </table>
                        </div>
                    </div>
                             <div class="box-footer">
                        <asp:LinkButton ID="LinkButton1" runat="server" ValidationGroup="SignUp" OnClick="btnRegister_Click" 
                            CssClass="btn btn-primary pull-left">
                            <span class="glyphicon glyphicon-save">&nbsp;Save</span>
                        </asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-primary pull-right" OnClick="LinkButton2_Click"><span class="glyphicon 
                            glyphicon-remove">&nbsp;Close</span>

                        </asp:LinkButton>
                        <br />

                    </div>
                                 
        </div>
   </div>

  </section> 
</asp:Content>

  

  

