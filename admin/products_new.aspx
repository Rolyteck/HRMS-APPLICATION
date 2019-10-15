<%@ Page Language="VB" MasterPageFile="~/webroot/web/modules/main.master" AutoEventWireup="false"
    CodeFile="products_new.aspx.vb" Inherits="webroot_web_modules_admin_branch_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="masterContent">
        <table id="table8" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td class="pageTitleBar">
                        New Products</td>
                </tr>
                <tr>
                    <td>
                        <uc:msgbox ID="Msgbox1" runat="server"></uc:msgbox>
                    </td>
                </tr>
                <tr>
                    <td class="sectionTabBar">
                        <uc:toptabs ID="toptabs1" runat="server" GroupName="inventory_family" />
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
                            Company Branch</asp:Label></div>
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
                                        <td class="editColA" style="height: 15px">
                                            Product Code</td>
                                        <td class="editColB" style="height: 15px">
                                            <asp:TextBox ID="txtproductCode" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="editColC" style="height: 15px">
                                            category</td>
                                        <td class="editColD" style="height: 15px">
                                            <asp:DropDownList ID="ddlcategory" runat="server" CssClass="dropdown">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                        </td>
                                        <td class="editColB">
                                            &nbsp;</td>
                                        <td class="editColC">
                                        </td>
                                        <td class="editColD">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            Product Name</td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtProductName" runat="server" CssClass="textbox" 
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td class="editColC">
                                            Remarks</td>
                                        <td class="editColD" runat="server">
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
                                            Quantity</td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtQty" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="editColC">
                                            Unit Price</td>
                                        <td class="editColD">
                                            <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="textbox"></asp:TextBox>
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
                                            Reorder Quantity</td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtReorderQty" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="editColC">
                                            Reorder Level</td>
                                        <td class="editColD">
                                            <asp:TextBox ID="txtreorderlevel" runat="server" CssClass="textbox"></asp:TextBox>
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
                <mb:ConfirmedButton ID="btnCancel" runat="server" CssClass="buttonBack" 
                    Text="Go Back" CausesValidation="False" />
                <mb:ConfirmedButton ID="btnOk" runat="server" CssClass="button" Text="Submit" />
                
            </div>
            <div class="FloatingFooterDiv2">
            </div>
        </div>
    </div>
</asp:Content>
