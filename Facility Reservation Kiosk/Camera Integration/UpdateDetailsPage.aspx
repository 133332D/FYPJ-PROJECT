﻿<%@ Page  EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="UpdateDetailsPage.aspx.cs" Inherits="Camera_Integration.UpdateDetailsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <aside class="main-sidebar">
                <!-- sidebar: style can be found in sidebar.less -->
                <section class="sidebar">
                    <!-- Sidebar user panel -->
                    
                    <!-- sidebar menu: : style can be found in sidebar.less -->
                    <ul class="sidebar-menu">

                        <li class="header">MAIN NAVIGATION</li>
                        <li class="treeview">
                            <a href="Home.aspx">
                                <i class="fa fa-dashboard"></i><span>Home</span>
                            </a>
                         
                        </li>

                        <li class="treeview">
                            <a href="CalendarSearch.aspx">
                                <i class="fa fa-calendar"></i><span>Calendar</span> <%--<i class="fa fa-angle-left pull-right"></i>--%>
                            </a>
                           <%-- <ul class="treeview-menu">
                                <li><a href="CalendarCreation.aspx"><i class="fa fa-circle-o"></i>Insert/Update</a></li>
                                <li><a href="CalendarSearch.aspx"><i class="fa fa-circle-o"></i>Search/Delete</a></li>
                            </ul>--%>
                        </li>

                        <li class="active treeview">
                            <a href="CameraModuleView.aspx">
                                <i class="fa fa-camera"></i><span>Camera</span> <%--<i class="fa fa-angle-left pull-right"></i>--%>
                            </a>
                          <%--  <ul class="treeview-menu">
                                <li class="active"><a href="CameraModuleAdd.aspx"><i class="fa fa-circle-o"></i>Insert</a></li>
                                
                                <li><a href="CameraModuleView.aspx"><i class="fa fa-circle-o"></i>Search/Update/Delete</a></li>
                          
                            </ul>--%>
                        </li>

                         <li class="treeview">
                            <a href="CanteenModuleView.aspx">
                                <i class="fa fa-glass"></i><span>Canteen</span> <%--<i class="fa fa-angle-left pull-right"></i>--%>
                            </a>
                           <%-- <ul class="treeview-menu">
                                <li><a href="CanteenModuleAdd.aspx"><i class="fa fa-circle-o"></i>Insert</a></li>
                               
                                <li><a href="CanteenModuleView.aspx"><i class="fa fa-circle-o"></i>Search/Update/Delete</a></li>
                               
                               
                            </ul>--%>
                        </li>

                          <li class="treeview">
                            <a href="UserSearch.aspx">
                                <i class="fa fa-user"></i><span>Users</span> <%--<i class="fa fa-angle-left pull-right"></i>--%>
                            </a>
                           <%-- <ul class="treeview-menu">
                                <li><a href="UserCreation.aspx"><i class="fa fa-circle-o"></i>Insert/Update</a></li>
                                <li><a href="UserSearch.aspx"><i class="fa fa-circle-o"></i>Search/Delete</a></li>            
                            </ul>--%>
                        </li>
                        </ul>
                </section>
                <!-- /.sidebar -->
            </aside>
     <section class="content-header">
        <h1>Update&nbsp; Camera
            &nbsp;
          &nbsp;
          &nbsp;
              </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Camera</li>
        </ol>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-xs-12">

                <div class="box box-info">

                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:Label ID="Label1" runat="server" Text="Camera ID :"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblCam" runat="server" ForeColor="#0033CC" Font-Bold="True"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="Label2" runat="server" Text="Facility ID : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlFacility" runat="server">
                                    <asp:ListItem>-Select-</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <br />
                                <asp:Label ID="Label3" runat="server" Text="Camera IP Address :"></asp:Label>
&nbsp;
                                <asp:TextBox ID="txtIpAddress" runat="server"></asp:TextBox>
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
                                <br />
                                <asp:Label ID="Label4" runat="server" Text="Minimum Density :"></asp:Label>
&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txtMinDensity" runat="server"></asp:TextBox>
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
                                <asp:Label ID="Label5" runat="server" Text="Maximum Density :"></asp:Label>
&nbsp;&nbsp;
                                <asp:TextBox ID="txtMaxDensity" runat="server"></asp:TextBox>
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Update Confirm" Width="159px" />
                                <br />
                                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblUpdate" runat="server" ForeColor="#0033CC" Font-Bold="True"></asp:Label>
     </div>
      </div>
      </div>
      </div>
     </div>
 </div>
</section>
</asp:Content>
