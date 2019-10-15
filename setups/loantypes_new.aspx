<%@ Page Language="VB" MasterPageFile="~/webroot/web/modules/main.master" AutoEventWireup="false"
    CodeFile="loantypes_new.aspx.vb" Inherits="webroot_web_modules_admin_employees_allowances_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="masterContent">
        <table id="table8" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td class="pageTitleBar">
                        New Loan Types </td>
                </tr>
                <tr>
                    <td>
                        <uc:msgbox ID="Msgbox1" runat="server"></uc:msgbox>
                    </td>
                </tr>
                <tr>
                    <td class="sectionTabBar">
                        <uc:toptabs ID="toptabs1" runat="server" GroupName="adm_Loantypes" />
                    </td>
                </tr>
                <tr>
                    <td class="pageFilterBox">
                        <div class="pageFilterBoxHeader">
                            <mb:ExpandingImageButton ID="ExpandingImageButton1" ExpandedAlternateText="Expand this node."
                                ContractedAlternateText="Close this node." CssClass="ExpandingImageButton" ControlToToggle="filterTable1"
                                ExpandedImageUrl="/webroot/web/images/icons/expanded_13.gif" ContractedImageUrl="/webroot/web/images/icons/expand_13.gif"
                                runat="server" EnableClientScript="true" />
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="ExpandingImageButton1">New 
                            Loan types </asp:Label></div>
                        <asp:Panel ID="filterTable1" runat="server">
                            <table id="section1" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td class="editColA">
                                        </td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtcode" runat="server" CssClass="textbox" Height="16px"></asp:TextBox>
                                        </td>
                                        <td class="editColC">
                                        </td>
                                        <td class="editColD">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA" style="height: 28px">
                                            Loan Description:</td>
                                        <td class="editColB" style="height: 28px">
                                            <asp:TextBox ID="txtName" runat="server" CssClass="textbox" 
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td class="editColC" style="height: 28px">
                                            Remarks</td>
                                        <td class="editColD" runat="server" style="height: 28px">
                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" 
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            &nbsp;</td>
                                        <td class="editColB">
                                            &nbsp;</td>
                                        <td class="editColC">
                                            &nbsp;</td>
                                        <td class="editColD">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            Loan Rate:</td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtLoanRate" runat="server" CssClass="textbox">0.0</asp:TextBox>
                                        </td>
                                        <td class="editColC">
                                            &nbsp;</td>
                                        <td class="editColD">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            &nbsp;</td>
                                        <td class="editColB">
                                            &nbsp;</td>
                                        <td class="editColC">
                                            &nbsp;</td>
                                        <td class="editColD">
                                            &nbsp;</td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="FloatingFooter">
            <div class="FloatingFooterDiv1">
                <mb:ConfirmedButton ID="btnCancel" runat="server" CssClass="buttonBack" 
                    Text="Go Back" CausesValidation="False" MessageEnabled="False" />
                <mb:ConfirmedButton ID="btnOk" runat="server" CssClass="button" Text="Submit" />
                
            &nbsp;<mb:ConfirmedButton ID="cmdSaveAdd" runat="server" CssClass="button" 
                    Text="Save And Add New" />
                
            </div>
            <div class="FloatingFooterDiv2">
            </div>
        </div>
    </div>
</asp:Content>
