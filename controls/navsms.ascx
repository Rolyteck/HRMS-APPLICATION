<%@ Control Language="VB" AutoEventWireup="false" CodeFile="navsms.ascx.vb" Inherits="webroot_web_controls_navsms" %>
<table class="quickLoginBox" cellpadding="0" cellspacing="8" border="0">
    <tr>
        <td class="sectionTitleBar">
            Quick SMS</td>
    </tr>
    <tr>
        <td>
            Sender<br />
            <asp:TextBox ID="txtFrom" runat="server" CssClass="textboxFree"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Send To<br />
            <asp:TextBox ID="txtSendTo" runat="server" CssClass="textboxFree" 
                TextMode="MultiLine" Rows="4"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Message<br />
            <asp:TextBox ID="txtMessage" runat="server" CssClass="textboxFree" 
                TextMode="MultiLine" Rows="5"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Button ID="cmdLogin" runat="server" CssClass="button" Text="Send SMS!" />
        </td>
    </tr>
    </table>
