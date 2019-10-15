<%@ Page Language="VB" Inherits="welcome_login_aspx" CodeFile="login.aspx.vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="masterContent">
        <table id="table8" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td class="pageTitleBar">
                        Member Log-In
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <uc:Msgbox ID="Msgbox1" runat="server"></uc:Msgbox>
                    </td>
                </tr>
                <tr>
                    <td class="sectionTitleBar">
                        Please Login Here
                    </td>
                </tr>
                <tr>
                    <td class="pageGroupPanel">
                        <table class="pageGroupBox" cellspacing="1" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td class="editColA">
                                        Username
                                    </td>
                                    <td class="editColB">
                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="textbox">wasiu</asp:TextBox>
                                    </td>
                                    <td class="editColCD" rowspan="6">
                                        <table class="quickInfoBox" id="table12" cellspacing="0" cellpadding="10" width="100%"
                                            align="center" border="0">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <span class="small"><span class="emphasis">Login Information<br/>
                                                        </span>
                                                            <br/>
                                                            Please enter your username and password here.
                                                            <br/>
                                                            <br/>
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
                                 Password
                                    </td>
                                    <td class="editColB">
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" 
                                            TextMode="Password"></asp:TextBox>
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
                                    </td>
                                    <td class="editColB">
                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember my  username"></asp:CheckBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="editColA">
                                    </td>
                                    <td class="editColB">
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
                                            Text="Log In" MessageEnabled="False" />
            </div>
            <div class="FloatingFooterDiv2">
                <span class="emphasis">
                    <img height="16" src="/webroot/web/images/icons/padlock2_16.gif" width="16" align="middle" />Forgot 
                your password? </span></div>
        </div>
    </div>
</asp:Content>
