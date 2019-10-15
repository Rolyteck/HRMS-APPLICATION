<%@ Control Language="VB" AutoEventWireup="false" CodeFile="product.ascx.vb" Inherits="webroot_web_controls_products" %>
<asp:UpdatePanel ID="uPnlControl" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:TextBox ID="txtCode" runat="server" CssClass="textbox"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtCode"
            ErrorMessage="Party is required!">*</asp:RequiredFieldValidator>
        <asp:HiddenField ID="txtHiddenCode" runat="server" />
        <asp:HiddenField ID="txtHiddenName" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>
<asp:Panel ID="pnlModal" runat="server" CssClass="modalPopup" Style="display: none">
    <table width="100%" border="0">
        <thead>
            <tr>
                <td>
                    <table width="100%" border="0">
                        <tr>
                            <td width="100px" align="right">
                                Search&nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="textboxFree"></asp:TextBox>
                                <asp:Label ID="lbMsg" runat="server" Text="Find Vendor by name."></asp:Label>
                            </td>
                            <td width="100px" align="right">
                                <asp:Button ID="cmdClose" runat="server" CssClass="buttonFree" Text="Close" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    <asp:UpdatePanel ID="uPnlModal" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server" CssClass="modalGrid">
                                <asp:GridView ID="GridView1" runat="server" CssClass="GridStyle" AllowPaging="false"
                                    AllowSorting="false" ShowHeader="false" ShowFooter="false">
                                    <RowStyle CssClass="GridRowStyle" />
                                    <HeaderStyle CssClass="GridHeaderStyle" />
                                    <FooterStyle CssClass="GridFooterStyle" />
                                    <PagerStyle CssClass="GridPagerStyle" />
                                </asp:GridView>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>
<div style="display:none">
<asp:HiddenField ID="HiddenField1" runat="server" />
<ajax:ModalPopupExtender ID="mpe" runat="server" TargetControlID="HiddenField1" PopupControlID="pnlModal"
    OkControlID="cmdClose" BackgroundCssClass="modalBackground" RepositionMode="RepositionOnWindowResizeAndScroll" />
</div>
