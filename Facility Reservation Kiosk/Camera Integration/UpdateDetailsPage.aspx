<%@ Page  EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="UpdateDetailsPage.aspx.cs" Inherits="Camera_Integration.UpdateDetailsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 213px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td class="auto-style1">CameraID:</td>
            <td>
                <asp:Label ID="lblCam" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Facility ID:</td>
            <td>
                <asp:Label ID="lblFacilityID" runat="server" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Camera&nbsp; IP Address:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtIpAddress" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">MinimumDensity:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtMinDensity" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">MaximumDensity:</td>
            <td>
                <asp:TextBox ID="txtMaxDensity" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlFacility" runat="server">
                    <asp:ListItem>-Select-</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <br />
            </td>
            <td class="auto-style5">
&nbsp;&nbsp;&nbsp;<asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click1" Text="Update Confirm" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="2">
                &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblUpdate" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
