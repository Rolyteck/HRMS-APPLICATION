<%@ Page Language="VB" MasterPageFile="~/webroot/web/modules/main.master" AutoEventWireup="false" CodeFile="company_settings.aspx.vb" Inherits="webroot_web_modules_admin_admin_settings" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="masterContent">
        <table id="table8" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td class="pageTitleBar">
                        Admin Settings</td>
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
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="ExpandingImageButton1">Settings</asp:Label></div>
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
                                            Company Name:</td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtName" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="editColC">
                                            Initial Pwd&nbsp; Days:</td>
                                        <td class="editColD">
                                            <asp:TextBox ID="txtInitialPwdDays" runat="server" CssClass="textbox"></asp:TextBox>
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
                                        <td class="editColA" style="height: 15px">
                                            Compny Address:</td>
                                        <td class="editColB" style="height: 15px">
                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="editColC" style="height: 15px">
                                            Change PWD Days:</td>
                                        <td class="editColD" style="height: 15px">
                                            <asp:TextBox ID="txtchangePwdDays" runat="server" CssClass="textbox"></asp:TextBox>
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
                                        <td class="editColA" style="height: 15px">
                                            website:</td>
                                        <td class="editColB" style="height: 15px">
                                            <asp:TextBox ID="txtWebSite" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="editColC" style="height: 15px">
                                            Lock User (Disable Days): </td>
                                        <td class="editColD" style="height: 15px">
                                            <asp:TextBox ID="txtLockDays" runat="server" CssClass="textbox"></asp:TextBox>
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
                                            company Abbrevation:</td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtAbbr" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="editColC">
                                            Close Acct Period Permanently: </td>
                                        <td class="editColD">
                                            <asp:TextBox ID="txtLockAcctPeriod" runat="server" CssClass="textbox"></asp:TextBox>
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
                                            Password Length:</td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtpwdLen" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="editColC">
                                            &nbsp;</td>
                                        <td class="editColD">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            &nbsp;
                                        </td>
                                        <td class="editColB">
                                            &nbsp;
                                        </td>
                                        <td class="editColC">
                                            &nbsp;</td>
                                        <td class="editColD">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            Reset Default Pwd:</td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtResetPwd" runat="server" CssClass="textbox"></asp:TextBox>
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
                                  
                                    <tr>
                                        <td class="editColA">
                                            Lock Ledger transaction Suppress:</td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtLockLedgerSuppress" runat="server" CssClass="textbox"></asp:TextBox>
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
                
                   <tr>
                    <td class="pageFilterBox">
                        <div class="pageFilterBoxHeader">
                            <mb:ExpandingImageButton ID="ExpandingImageButton2" ExpandedAlternateText="Expand this node."
                                ContractedAlternateText="Close this node." CssClass="ExpandingImageButton" ControlToToggle="filterTable1"
                                ExpandedImageUrl="/webroot/web/images/icons/expanded_13.gif" ContractedImageUrl="/webroot/web/images/icons/expand_13.gif"
                                runat="server" EnableClientScript="true" />
                            <asp:Label ID="Label2" runat="server" AssociatedControlID="ExpandingImageButton1">Email 
                            &amp; SMS Settings</asp:Label></div>
                        <asp:Panel ID="Panel1" runat="server">
                            <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
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
                                                                     Mail box Type:</td>
                                                                 <td class="editColB">
                                                                     <asp:RadioButtonList ID="rblMailType" runat="server" AutoPostBack="True" 
                                                                         CssClass="button" Font-Bold="False" RepeatDirection="Horizontal" 
                                                                         RepeatLayout="Flow">
                                                                         <asp:ListItem Selected="True">SMTP
                                                                         </asp:ListItem>
                                                                         <asp:ListItem Value="Exchange ">Exchange Server</asp:ListItem>
                                                                     </asp:RadioButtonList>
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
                                                             <tr>
                                        <td class="editColA" style="height: 15px">
                                            <asp:Label ID="lbEmailUsername" runat="server" Text="Email Address/Username:"></asp:Label>
                                                                 </td>
                                        <td class="editColB" style="height: 15px">
                                            <asp:TextBox ID="txtEmailUsername" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="editColC" style="height: 15px">
                                            SMS Account:</td>
                                        <td class="editColD" style="height: 15px">
                                            <asp:TextBox ID="txtsmsAcct" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA" style="height: 15px">
                                            &nbsp;</td>
                                        <td class="editColB" style="height: 15px">
                                            &nbsp;</td>
                                        <td class="editColC" style="height: 15px">
                                            &nbsp;</td>
                                        <td class="editColD" style="height: 15px">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="editColA" style="height: 15px">
                                            <asp:Label ID="lbPassword" runat="server" Text="Email Password:"></asp:Label>
                                        </td>
                                        <td class="editColB" style="height: 15px">
                                            <asp:TextBox ID="txtEmailPassword" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="editColC" style="height: 15px">
                                            SMS Password:</td>
                                        <td class="editColD" style="height: 15px">
                                            <asp:TextBox ID="txtSMSPassword" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA" style="height: 15px">
                                            </td>
                                        <td class="editColB" style="height: 15px">
                                            </td>
                                        <td class="editColC" style="height: 15px">
                                            </td>
                                        <td class="editColD" style="height: 15px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            <asp:Label ID="lbServer" runat="server" Text="Email Server:"></asp:Label>
                                        </td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtEmailServerOrDoamin" runat="server" CssClass="textbox"></asp:TextBox>
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
                                    <tr>
                                        <td class="editColA">
                                            <asp:Label ID="lbSender" runat="server" Text="Email Sender:"></asp:Label>
                                        </td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtEmailSenderOrExgBox" runat="server" CssClass="textbox"></asp:TextBox>
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
                <tr>
                    <td class="pageFilterBox">
                        &nbsp;</td>
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

