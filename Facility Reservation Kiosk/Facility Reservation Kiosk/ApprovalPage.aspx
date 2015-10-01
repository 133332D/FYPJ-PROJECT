<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ApprovalPage.aspx.cs" Inherits="Facility_Reservation_Kiosk.ApprovalPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 181px;
        }
        .auto-style2 {
            width: 181px;
            height: 20px;
        }
        .auto-style3 {
            height: 20px;
        }
        .auto-style4 {
            width: 181px;
            height: 29px;
        }
        .auto-style5 {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td class="auto-style1">Device ID:</td>
            <td>
                <asp:Label ID="lblDeviceID" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Description<asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                :</td>
            <td class="auto-style3">
                <asp:TextBox ID="tbDescription" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Department<asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                :</td>
            <td class="auto-style3">
                <asp:TextBox ID="tbDepartment" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Default Filter<asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
                :</td>
            <td>
                <asp:TextBox ID="tbDefaultFilter" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm" />
            </td>
            <td class="auto-style5">
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblDateTime" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="2">
                <asp:Label ID="lblUpdate" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

