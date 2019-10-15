<%@ Page Language="VB" MasterPageFile="~/webroot/web/modules/main.master" AutoEventWireup="false" Inherits="sytem_numbers_aspx" CodeFile="company_numbers.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="masterContent">
        <table id="table8" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td class="pageTitleBar">
                        <asp:Label ID="lbHeader" runat="server" Text="Label">Auto Numbers</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc:msgbox ID="Msgbox1" runat="server"></uc:msgbox>
                    </td>
                </tr>
                <tr>
                    <td class="sectionTabBar">
                        <uc:toptabs ID="toptabs1" runat="server" GroupName="adm_company" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" CssClass="GridStyle" AutoGenerateColumns="False">
                            <RowStyle CssClass="GridRowStyle" />
                            <HeaderStyle CssClass="GridHeaderStyle" />
                            <FooterStyle CssClass="GridFooterStyle" />
                            <PagerStyle CssClass="GridPagerStyle" />
                            <Columns>
                                <asp:HyperLinkField DataTextField="AutoNum" HeaderText="Auto Number" 
                                    DataNavigateUrlFields="AutoNum" 
                                    DataNavigateUrlFormatString="/webroot/web/modules/setups/company_numbers_edit.aspx?edit-id={0}">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:HyperLinkField>
                                <asp:BoundField DataField="BranchID" HeaderText="Branch" HeaderStyle-HorizontalAlign="Left"
                                    ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="NextVal" HeaderText="Next Value" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Format" HeaderText="Format" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="Panel1" runat="server" CssClass="FloatingFooterDiv1">
                        </asp:Panel>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
