<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Security.aspx.cs" Inherits="Facility_Reservation_Kiosk.Security" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
    }
        .auto-style2 {
            height: 180px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="nav-justified">
    <tr>
        <td class="auto-style1">Search By DeviceID:
            <asp:TextBox ID="txtSearch" runat="server" Height="22px"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server"  Text="Search" OnClick="btnSearch_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style2" colspan="2">
            <asp:GridView ID="GridViewSearch" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="99%" AutoGenerateColumns="False"  Height="105px" OnRowDataBound="GridViewSearch_RowDataBound">
                <AlternatingRowStyle BackColor="White" />
                <Columns>                   
                    <asp:BoundField DataField="DeviceID" HeaderText="Device ID" />                   
                    <asp:BoundField DataField="Status" HeaderText="Status" />                     
                    <asp:BoundField DataField="ApprovedDateTime" HeaderText="Approved DateTime" >
                    </asp:BoundField>
                    <asp:BoundField DataField="RejectedOrRevokedDateTime" HeaderText="Rejected Or Revoked DateTime" >
                    </asp:BoundField>
                    <asp:BoundField DataField="RejectedOrRevokedReason" HeaderText="Rejected Or Revoked Reason" >
                    </asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:TemplateField HeaderText="Unique ID">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DeviceGeneratedUniqueID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblUniqueID" runat="server" Text='<%# Bind("DeviceGeneratedUniqueID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actions" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbapp" runat="server" Text="Approve" Visible="false" OnClick="lbapp_Click" CommandName="Select" ></asp:LinkButton>
                                <asp:LinkButton ID="lbrej" runat="server" Text="Reject" Visible="false" OnClick="lbrej_Click"></asp:LinkButton>
                              <asp:LinkButton ID="lbedit" runat="server" Text="Edit" Visible="false" OnClick="lbedit_Click"  ></asp:LinkButton>
                               <asp:LinkButton ID="lbrevoke" runat="server" Text="Revoke" Visible="false" OnClick="lbrevoke_Click" ></asp:LinkButton>


                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:label runat="server" ID="lblTest" ></asp:label>
        </td>
    </tr>
</table>
</asp:Content>

