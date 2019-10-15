<%@ Page Language="VB" MasterPageFile="~/webroot/web/modules/main.master" AutoEventWireup="false" CodeFile="company_numbers_edit.aspx.vb" Inherits="webroot_web_modules_marketing_smsemail_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="masterContent">
        <table id="table8" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td class="pageTitleBar">
                        <asp:Label ID="lbHeader" runat="server" Text="Auto Numbers"></asp:Label>
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
                    <td class="pageFilterBox">
                        <div class="pageFilterBoxHeader">
                            <mb:ExpandingImageButton ID="ExpandingImageButton1" ExpandedAlternateText="Expand this node."
                                ContractedAlternateText="Close this node." CssClass="ExpandingImageButton" ControlToToggle="filterTable1"
                                ExpandedImageUrl="/webroot/web/images/icons/expanded_13.gif" ContractedImageUrl="/webroot/web/images/icons/expand_13.gif"
                                runat="server" EnableClientScript="true" />
                            <label for="_ctl0_ContentPlaceHolder1_ExpandingImageButton1_clicker" style="width: 96%;
                                cursor: hand">
                                <asp:Label ID="lbHeader2" runat="server" Text="Edit Auto Number"></asp:Label>
                                </label></div>
                        <asp:Panel ID="filterTable1" runat="server">
                            <table id="section1" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td class="editColA">
                                            &nbsp;</td>
                                        <td class="editColB">
                                            &nbsp;</td>
                                        <td class="editColCD">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            Auto Number</td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtAutoNum" runat="server" CssClass="textbox" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td class="editColCD" rowspan="8">
                                            <table ID="table12" align="center" border="0" cellpadding="10" cellspacing="0" 
                                                class="quickInfoBox" width="100%">
                                                <tr>    <td>
                                                        <span class="small"><span class="emphasis">Edit Auto Number<br />
                                                        </span>'$SR$ - Sub Risk Code '$RC$ - Risk Code '$YR$ - Current Year (2 digits) '$MO$
                                                            - Current Month (2 Digits) '$00000$ - Serial Number '$BR$ - Branch Code '$BR2$ -
                                                            Branch Code 2
                                                            <br />
                                                            You need to confirm the newly selected password. Finally, click the submit button.</span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                        </td>
                                        <td class="editColB">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            Branches?</td>
                                        <td class="editColB">
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                                RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True">
                                                <asp:ListItem>ALL</asp:ListItem>
                                                <asp:ListItem>SEPARATE</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            &nbsp;
                                        </td>
                                        <td class="editColB">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            Next Value</td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtNextValue" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            &nbsp;
                                        </td>
                                        <td class="editColB">
                                            <mb:ConfirmedLinkButton ID="lnkNextVal" runat="server" Message="This action will OVERWRITE all previously saved NEXT VALUE items! Continue at your own risk?">[Apply Next Value to All 
                                            Branches]</mb:ConfirmedLinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            Format</td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtFormat" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            &nbsp;</td>
                                        <td class="editColB">
                                            <mb:ConfirmedLinkButton ID="lnkFormat" runat="server" Message="This action will OVERWRITE all previously saved FORMAT values! Continue at your own risk?">[Apply Format to ALL Branches]</mb:ConfirmedLinkButton>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
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
                                <asp:CommandField ShowEditButton="True" ItemStyle-Width="50px">
                                    <ItemStyle Width="50px"></ItemStyle>
                                </asp:CommandField>
                                <asp:BoundField DataField="BranchID" HeaderText="BranchID" HeaderStyle-HorizontalAlign="Left"
                                    ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Branch" HeaderText="Branch" HeaderStyle-HorizontalAlign="Left"
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
            </tbody>
        </table>
        <div class="FloatingFooter">
            <div class="FloatingFooterDiv1">
                <mb:ConfirmedButton ID="btnOk" runat="server" CssClass="button" Text="Submit" />
            </div>
            <div class="FloatingFooterDiv2">
            </div>
        </div>
    </div>
</asp:Content>

