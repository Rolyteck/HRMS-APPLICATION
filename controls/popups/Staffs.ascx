<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Staffs.ascx.vb" Inherits="webroot_web_controls_StaffDetails" %>
<div class="pageFilterBoxHeader">
    <mb:ExpandingImageButton ID="ExpandingImageButton1" ExpandedAlternateText="Expand this node."
        ContractedAlternateText="Close this node." CssClass="ExpandingImageButton" ControlToToggle="pnlControl"
        ExpandedImageUrl="/webroot/web/images/icons/expanded_13.gif" ContractedImageUrl="/webroot/web/images/icons/expand_13.gif"
        runat="server" EnableClientScript="true" />
    <asp:Label ID="Label2" runat="server" AssociatedControlID="ExpandingImageButton1">Staff 
    Employee Details</asp:Label>
</div>
<asp:Panel ID="pnlControl" runat="server">
    <asp:UpdatePanel ID="uPnlControl" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tbody>
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
                            <asp:Label ID="lbNoteNo" runat="server" Text="Employee No"></asp:Label>
                            :</td>
                        <td class="editColB">
                            <asp:TextBox ID="txtCode" runat="server" CssClass="textbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtCode"
                                ErrorMessage="Debit/Credit Note No is required!">*</asp:RequiredFieldValidator>
                        </td>
                        <td class="editColC">
                            Surname:</td>
                        <td class="editColD">
                            <asp:TextBox ID="txtSurname" runat="server" CssClass="textbox"></asp:TextBox>
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
                            Other Names</td>
                        <td class="editColB">
                            <asp:TextBox ID="txtOtherNames" runat="server" CssClass="textbox"></asp:TextBox>
                        </td>
                        <td class="editColC">
                            <asp:Label ID="lblReceiptNo18" runat="server" Text="Grade Level:"></asp:Label>
                        </td>
                        <td class="editColD">
                            <asp:TextBox ID="txtGradelevel" runat="server" CssClass="textbox"></asp:TextBox>
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
                            Branch</td>
                        <td class="editColB">
                            <asp:TextBox ID="txtBranch" runat="server" CssClass="textbox"></asp:TextBox>
                        </td>
                        <td class="editColC">
                            <asp:Label ID="Label9" runat="server" Text="Confirmation Status:"></asp:Label>
                        </td>
                        <td class="editColD">
                            <asp:TextBox ID="txtconfirmstatus" runat="server" CssClass="textbox"></asp:TextBox>
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
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
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
                                <asp:Label ID="lbMsg" runat="server" Text="Find Staff by name."></asp:Label>
                            </td>
                            <td width="100px" align="right" nowrap>
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
                                <asp:Label ID="premcalc1" runat="server" Visible="false" Text="placeholder ddedeji" />
                                <asp:GridView ID="GridView1" runat="server" CssClass="GridStyle" AllowPaging="false"
                                    AllowSorting="false" ShowHeader="false" ShowFooter="false" Visible="false">
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
<ajax:ModalPopupExtender ID="mpe" runat="server" TargetControlID="HiddenField1" PopupControlID="pnlModal"
    OkControlID="cmdClose" DropShadow="true" BackgroundCssClass="modalBackground"
    RepositionMode="RepositionOnWindowResizeAndScroll" />
<asp:HiddenField ID="HiddenField1" runat="server" />
