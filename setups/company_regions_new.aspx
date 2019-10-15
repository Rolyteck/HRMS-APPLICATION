<%@ Page Language="VB" MasterPageFile="~/webroot/web/modules/main.master" AutoEventWireup="false"
    CodeFile="company_regions_new.aspx.vb" Inherits="webroot_web_modules_admin_Region_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="masterContent">
        <table id="table8" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td class="pageTitleBar">
                        New Company Region</td>
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
                    <td class="pageFilterBox">
                        <div class="pageFilterBoxHeader">
                            <mb:ExpandingImageButton ID="ExpandingImageButton1" ExpandedAlternateText="Expand this node."
                                ContractedAlternateText="Close this node." CssClass="ExpandingImageButton" ControlToToggle="filterTable1"
                                ExpandedImageUrl="/webroot/web/images/icons/expanded_13.gif" ContractedImageUrl="/webroot/web/images/icons/expand_13.gif"
                                runat="server" EnableClientScript="true" />
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="ExpandingImageButton1">New 
                            Region</asp:Label></div>
                        <asp:Panel ID="filterTable1" runat="server">
                            <table id="section1" cellspacing="0" cellpadding="0" width="100%" border="0">
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
                                            Region Code</td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtRegionID" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="editColC">
                                            &nbsp;</td>
                                        <td class="editColD">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                        </td>
                                        <td class="editColB">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ControlToValidate="txtRegname" CssClass="smallErrorEmphasis" Display="Dynamic" 
                                                ErrorMessage="Enter your Regional Office Name." SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="editColC">
                                        </td>
                                        <td class="editColD">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            Region Name</td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtRegName" runat="server" CssClass="textbox" 
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td class="editColC">
                                            Address</td>
                                        <td class="editColD">
                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="textbox" 
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            &nbsp;
                                        </td>
                                        <td class="editColB">
                                            &nbsp;</td>
                                        <td class="editColC">
                                            &nbsp;</td>
                                        <td class="editColD">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            Land Phone</td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtPhone2" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="editColC">
                                            Mobile Phone</td>
                                        <td class="editColD">
                                            <asp:TextBox ID="txtPhone1" runat="server" CssClass="textbox"></asp:TextBox>
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
                                            Email
                                        </td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="editColC">
                                            Fax No</td>
                                        <td class="editColD">
                                            <asp:TextBox ID="txtFaxNo" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                        </td>
                                        <td class="editColB">
                                        </td>
                                        <td class="editColC">
                                        </td>
                                        <td class="editColD">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            Manager</td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtManager" runat="server" CssClass="textbox" 
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td class="editColC">
                                            Remarks</td>
                                        <td class="editColD">
                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" 
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            &nbsp;
                                        </td>
                                        <td class="editColB">
                                            &nbsp;
                                        </td>
                                        <td class="editColC">
                                            &nbsp;
                                        </td>
                                        <td class="editColD">
                                            &nbsp;
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
                        </asp:Panel>
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="FloatingFooter">
            <div class="FloatingFooterDiv1">
                <mb:ConfirmedButton ID="btnCancel" runat="server" CssClass="button" 
                    Text="Cancel" CausesValidation="False" MessageEnabled="False" />
                <mb:ConfirmedButton ID="btnOk" runat="server" CssClass="button" Text="Submit" />
                
            </div>
            <div class="FloatingFooterDiv2">
            </div>
        </div>
    </div>
</asp:Content>
