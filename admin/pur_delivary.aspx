<%@ Page Language="VB" MasterPageFile="~/webroot/web/modules/main.master" AutoEventWireup="false" CodeFile="pur_delivary.aspx.vb" Inherits="webroot_web_modules_accounts_ledger_cashbooks" title="Ledger Cash books Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="masterContent">
        <table id="table8" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td class="pageTitleBar">
                        <asp:Label ID="lbHeader" runat="server" Text="Label">Purchase Requisition</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc:msgbox ID="Msgbox1" runat="server"></uc:msgbox>
                    </td>
                </tr>
                <tr>
                    <td class="sectionTabBar">
                        <uc:toptabs ID="toptabs1" runat="server" GroupName="purchases_details" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc:gridarea ID="gridarea1" runat="server" GroupName="purchase_invoices" />
                    </td>
                    </tr>
                    <tr>
                    <td>
                            <asp:Panel ID="Panel1" runat="server" CssClass="FloatingFooterDiv1">
                            <asp:Button ID="cmdBack" runat="server" CssClass="buttonBack" Text="Main Menu" />
                            <asp:Button ID="cmdNew" runat="server" CssClass="button" Text="New Requisition" />
                                <asp:Button ID="cmdApprove" runat="server" CssClass="button" 
                                    Text="Approve Requisition" />
                            <asp:Button ID="cmdPrint" runat="server" CssClass="button" Text="Print" />
                        </asp:Panel>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>

