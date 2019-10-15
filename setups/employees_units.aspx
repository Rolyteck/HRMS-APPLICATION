<%@ Page Language="VB" MasterPageFile="~/webroot/web/modules/main.master" AutoEventWireup="false" Inherits="employees_units_Index_aspx" CodeFile="employees_units.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="masterContent">
        <table id="table8" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td class="pageTitleBar">
                        <asp:Label ID="lbHeader" runat="server" Text="Label">Setup units</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc:msgbox ID="Msgbox1" runat="server"></uc:msgbox>
                    </td>
                </tr>
                  <tr>
                    <td class="sectionTabBar">
                        <uc:toptabs ID="toptabs1" runat="server" GroupName="adm_employees_1" />
                    </td>
                </tr>
                       <tr>
                    <td>
                        <uc:gridarea ID="gridarea1" runat="server" GroupName="admin_units_list" />
                    </td>
                    </tr>
                    <tr>
                    <td>
                        <asp:Panel ID="Panel1" runat="server" CssClass="FloatingFooterDiv1">
                            <asp:Button ID="cmdDelete" runat="server" CssClass="button" Text="Delete..." />
                            <asp:Button ID="cmdNew" runat="server" CssClass="button" Text="New Units" />
                        </asp:Panel>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
