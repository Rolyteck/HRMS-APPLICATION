<%@ Page Language="VB" MasterPageFile="~/webroot/web/modules/main.master" AutoEventWireup="false" Inherits="welcome_changepwd_aspx" CodeFile="changepwd.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="masterContent">
        <table id="table8" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td class="pageTitleBar">
                        Change Password
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc:Msgbox ID="Msgbox1" runat="server"></uc:Msgbox>
                    </td>
                </tr>
                <tr>
                    <td class="sectionTitleBar">
                        Change Your Password
                    </td>
                </tr>
                <tr>
                    <td class="pageGroupPanel">
                        <table class="pageGroupBox" cellspacing="1" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td class="editColA">
                                        Username</td>
                                    <td class="editColB">
                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td class="editColCD" rowspan="7">
                                        <table class="quickInfoBox" id="table12" cellspacing="0" cellpadding="10" width="100%"
                                            align="center" border="0">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <span class="small"><span class="emphasis">How to Change Password<br>
                                                        </span>
                                                            <br>
                                                            To change your password, first enter your old password, then enter a new password
                                                            into the boxes provided.
                                                            <br>
                                                            <br>
                                                            You need to confirm the newly selected password. Finally, click the submit button.</span>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="editColA">
                                    </td>
                                    <td class="editColB">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
                                            ErrorMessage="Enter your username." Display="Dynamic" 
                                            CssClass="smallErrorEmphasis"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="editColA">
                                        Old Password</td>
                                    <td class="editColB">
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" 
                                            TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="editColA">
                                    </td>
                                    <td class="editColB">
                                        </td>
                                </tr>
                                <tr>
                                    <td class="editColA">
                                        New Password</td>
                                    New Password</td>
                                    <td class="editColB">
                                        <asp:TextBox ID="txtNewPassword1" runat="server" CssClass="textbox" 
                                            TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="editColA">
                                    </td>
                                    <td class="editColB">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword1"
                                            ErrorMessage="Enter your new password." Display="Dynamic" 
                                            CssClass="smallErrorEmphasis"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                            ControlToCompare="txtNewPassword1" ControlToValidate="txtNewPassword2" 
                                            CssClass="smallErrorEmphasis" ErrorMessage="Password does not match!" 
                                            Display="Dynamic"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="editColA">
                                        Confirm Password</td>
                                    <td class="editColB">
                                        <asp:TextBox ID="txtNewPassword2" runat="server" CssClass="textbox" 
                                            TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="FloatingFooter">
            <div class="FloatingFooterDiv1">
                                        <mb:ConfirmedButton ID="btnLogin" runat="server" CssClass="button" 
                                            Text="Submit" Message="Are you sure you want to do th?" 
                                            MessageEnabled="False" />
            </div>
            <div class="FloatingFooterDiv2">
                <span class="emphasis">
                    <img height="16" src="/webroot/web/images/icons/padlock2_16.gif" width="16" align="middle" />Forgot 
                your password? set page here.</a></div>
        </div>
    </div>
</asp:Content>
