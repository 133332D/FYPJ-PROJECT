<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RevokePage.aspx.cs" Inherits="Facility_Reservation_Kiosk.RevokePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
