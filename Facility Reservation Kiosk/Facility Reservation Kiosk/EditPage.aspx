<%@ Page EnableEventValidation="False" Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="Facility_Reservation_Kiosk.EditPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td class="auto-style1">Device ID:</td>
            <td>
                <asp:Label ID="lblDeviceID" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Description:</td>
            <td>
                <asp:TextBox ID="tbDescription" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Department:</td>
            <td>
                <asp:DropDownList ID="ddlDepartment" runat="server">
                 
                    <asp:ListItem Value="NYP">Nanyang Polytechnic (NYP)</asp:ListItem>
                    <asp:ListItem Value="SBM">School Of Business Management (SBM)</asp:ListItem>
                    <asp:ListItem Value="SCL">School Of Chemical Life Science (SCL)</asp:ListItem>
                    <asp:ListItem Value="SDN">School Of Design (SDN)</asp:ListItem>
                    <asp:ListItem Value="SEG">School Of Engineering (SEG)</asp:ListItem>
                    <asp:ListItem Value="SHS">School Of Health Science (SHS)</asp:ListItem>
                    <asp:ListItem Value="SIDM">School Of Interactive Media Design (SIDM)</asp:ListItem>
                    <asp:ListItem Value="SIT">School Of Information Technology (SIT)</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Default Filter:</td>
            <td>
                <asp:TextBox ID="tbFilter" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" colspan="2">
                <asp:Label ID="lbUpdate" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
