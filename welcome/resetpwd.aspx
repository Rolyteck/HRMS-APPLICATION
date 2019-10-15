<%@ Page Language="VB" Inherits="welcome_resetpwd_aspx" CodeFile="resetpwd.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="masterContent">
        <table id="table8" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td class="pageTitleBar">
                        Reset Your Password
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc:Msgbox ID="Msgbox1" runat="server"></uc:Msgbox>
                    </td>
                </tr>
                <tr>
                    <td class="sectionTitleBar">
                        Send a Reset Password Request here</td>
                </tr>
                <tr>
                    <td class="pageGroupPanel">
                        <table class="pageGroupBox" cellspacing="1" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td class="editColA">
                                        <b>Username</b></td>
                                    <td class="editColB">
                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td class="editColCD" rowspan="6">
                                        <table class="quickInfoBox" id="table12" cellspacing="0" cellpadding="10" width="100%"
                                            align="center" border="0">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <span class="small"><span class="emphasis">Reset Password Proceedure<br/>
                                                        </span>
                                                            <br/>
                                                            Please enter your username here. A reset password request will be sent to 
                                                        your administrator.<br/>
                                                            <br/>
                                                            Your administrator may confirm by phone to know if you really want a reset 
                                                        and why.</span></td>
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
                                        &nbsp;</td>
                                    <td class="editColB">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="editColA">
                                    </td>
                                    <td class="editColB">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="editColA">
                                        &nbsp;</td>
                                    <td class="editColB">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="editColA">
                                    </td>
                                    <td class="editColB">
                                        &nbsp;</td>
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
                                            Text="Submit" MessageEnabled="False" />
            </div>
            <div class="FloatingFooterDiv2">
                </div>
        </div>
    </div>
</asp:Content>
