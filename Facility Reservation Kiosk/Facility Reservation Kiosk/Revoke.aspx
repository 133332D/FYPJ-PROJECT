<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Revoke.aspx.cs" Inherits="Facility_Reservation_Kiosk.Revoke" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 146px
        }
        .auto-style2 {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td colspan="2"><strong>Please enter revoke reason</strong></td>
        </tr>
        <tr>
            <td class="auto-style1">Device ID:</td>
            <td>
                <asp:Label ID="lblDeviceID" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Description:</td>
            <td>
                <asp:Label ID="lblDescription" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Revoke Reason<span class="auto-style2">*</span>:</td>
            <td>
                <asp:TextBox ID="tbReason" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
            </td>
        </tr>
    </table>
</asp:Content>
