<%@ Control Language="VB" AutoEventWireup="false" CodeFile="navlogin.ascx.vb" Inherits="webroot_web_controls_navlogin" %>
<table class="quickLoginBox" cellpadding="0" cellspacing="8" border="0">
    <tr>
        <td class="sectionTitleBar">
            Quick Login Here</td>
    </tr>
    <tr>
        <td>
            Username<br />
            <asp:TextBox ID="txtUsername" runat="server" CssClass="textboxFree"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Password<br />
            <asp:TextBox ID="txtPassword" runat="server" CssClass="textboxFree" 
                TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Button ID="cmdLogin" runat="server" CssClass="button" Text="Login" />
        </td>
    </tr>
    </table>
