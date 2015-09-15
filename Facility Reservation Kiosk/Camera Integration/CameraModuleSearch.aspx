﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Camera.Master" AutoEventWireup="true" CodeBehind="CameraModuleSearch.aspx.cs" Inherits="Camera_Integration.CameraModuleSearch" %>
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

                </section>
                <!-- /.sidebar -->
            </aside>
     <section class="content-header">
        <h1>Camera
            &nbsp;
          &nbsp;
          &nbsp;
              <asp:Button ID="Button1" OnClick="Button1_Click" CssClass="btn btn-info" runat="server" Text="Create" />
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

                                <div class="form-group">
                                    Search by Faciltiy / Camera IP Address:  
                                    <br />
                                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                    <br />

                                </div>
                                <div class="form-group">
                                    <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-info" OnClick="LinkButton1_Click">
                            <span class="glyphicon glyphicon-search">Search</span>

                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div id="setDisplayNone" runat="server" style='padding: 8px; display: none;'>
                            <div class="callout callout-danger">
                                <asp:Label ID="lblResult" runat="server"></asp:Label>
                            </div>
                        </div>
                        <asp:GridView ID="GrdCamera" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="262px" Width="649px" OnPageIndexChanging="GrdCamera_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Facility Name" HeaderText=" Facility Name" />
                                <asp:BoundField DataField="IPAddress" HeaderText="Camera IP Address" />
                                <asp:BoundField DataField="MinimumDensity" HeaderText="Minimum Density" />
                                <asp:BoundField DataField="MaximumDensity" HeaderText="Maximum Density" />
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <br />

                    </div>
                </div>
                <br />
                <asp:Label ID="lblPages" runat="server" CssClass="pull-left" Text=""></asp:Label>
            </div>
        </div>
    </section> 
</asp:Content>
