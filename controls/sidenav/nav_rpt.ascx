<%@ Control Language="vb" AutoEventWireup="false" Inherits="nav_und" CodeFile="nav_rpt.ascx.vb" %>
<div id="SideNavBar">
    <ul>
        <li class="Header">
            <mb:ExpandingImageButton ID="ExpandingImageButton1" ExpandedAlternateText="Expand this node."
                ContractedAlternateText="Close this node." CssClass="ExpandingImageButton" ControlToToggle="Panel1"
                ExpandedImageUrl="/webroot/web/images/icons/expanded_13.gif" ContractedImageUrl="/webroot/web/images/icons/expand_13.gif"
                runat="server" EnableClientScript="true"></mb:ExpandingImageButton>
            <asp:Label ID="Label2" runat="server" AssociatedControlID="ExpandingImageButton1">Employees Menu</asp:Label></li></ul>
    <asp:Panel ID="Panel1" runat="server">
        <ul>
            <li><a href="/?cmd=acct-home">
                <img src="/webroot/web/images/icons/Report_16.gif" align="middle" border="0"/>Account
                Overview</a>
            <li><a href="/?cmd=acct-order">
                <img src="/webroot/web/images/icons/cart2_16.gif" align="middle" border="0"/>Buy
                SMS Credits!</a>
            <li><a href="/?cmd=acct-recharge">
                <img src="/webroot/web/images/icons/Move_16.gif" align="middle" border="0"/>Voucher
                Recharge</a>
            <li><a href="/?cmd=acct-flash">
                <img src="/webroot/web/images/icons/user_16.gif" align="middle" border="0"/>Transfer
                SMS Credits</a>
            <li><a href="/?cmd=acct-change-pwd">
                <img src="/webroot/web/images/icons/padlock2_16.gif" align="middle" border="0"/>Change&nbsp;Password</a>
            <li><a href="/?cmd=acct-detail">
                <img src="/webroot/web/images/icons/pencil_16.gif" align="middle" border="0"/>Registration&nbsp;Details</a>
            </li>
        </ul>
    </asp:Panel>
    <ul>
        <li class="Header">
            <mb:ExpandingImageButton ID="Expandingimagebutton2" ExpandedAlternateText="Expand this node."
                ContractedAlternateText="Close this node." CssClass="ExpandingImageButton" ControlToToggle="Panel2"
                ExpandedImageUrl="/webroot/web/images/icons/expanded_13.gif" ContractedImageUrl="/webroot/web/images/icons/expand_13.gif"
                runat="server" EnableClientScript="true"></mb:ExpandingImageButton>
            <asp:Label ID="Label1" runat="server" AssociatedControlID="ExpandingImageButton2">Marketing Menu</asp:Label></li></ul>
    <asp:Panel ID="Panel2" runat="server">
        <ul>
            <li><a href="/?cmd=sms-compose">
                <img src="/webroot/web/images/icons/write2_16.gif" align="middle" border="0"/>Send
                SMS here</a>
            <li><a href="/?cmd=sms-compose-bulk">
                <img src="/webroot/web/images/icons/write2_16.gif" align="middle" border="0"/>Send
                Bulk SMS</a>
            <li><a href="/?cmd=sms-compose-bulk">
                <img src="/webroot/web/images/icons/write2_16.gif" align="middle" border="0"/>Send
                Custom SMS</a>
            <li><a href="/?cmd=sms-sent">
                <img src="/webroot/web/images/icons/sendmail_16.gif" align="middle" border="0"/>Sent&nbsp;Messages</a>
            <li><a href="/?cmd=sms-saved">
                <img src="/webroot/web/images/icons/mail2_16.gif" align="middle" border="0"/>Saved
                Messages</a>
            <li><a href="/?cmd=sms-contacts">
                <img src="/webroot/web/images/icons/Users2_16.gif" align="middle" border="0"/>Contacts/Numbers</a>
            <li><a href="/?cmd=sms-current">
                <img src="/webroot/web/images/icons/go_16.gif" align="middle" border="0"/>Current
                Activity...</a>
            <li><a href="/?cmd=sms-settings">
                <img src="/webroot/web/images/icons/sendmail4_16.gif" align="middle" border="0">Message&nbsp;Settings</a>
            </li>
        </ul>
    </asp:Panel>
    <ul>
        <li class="Header">
            <mb:ExpandingImageButton ID="Expandingimagebutton3" ExpandedAlternateText="Expand this node."
                ContractedAlternateText="Close this node." CssClass="ExpandingImageButton" ControlToToggle="Panel4"
                ExpandedImageUrl="/webroot/web/images/icons/expanded_13.gif" ContractedImageUrl="/webroot/web/images/icons/expand_13.gif"
                runat="server" EnableClientScript="true"></mb:ExpandingImageButton>
            <asp:Label ID="Label3" runat="server" AssociatedControlID="ExpandingImageButton3">Other Links</asp:Label></li></ul>
    <asp:Panel ID="Panel4" runat="server">
        <ul>
            <li><a href="/?cmd=_prices">
                <img src="/webroot/web/images/icons/heart_16.gif" align="middle" border="0">Our
                Price List</a>
            <li><a href="/?cmd=_support">
                <img src="/webroot/web/images/icons/heart_16.gif" align="middle" border="0">Contact
                Support</a>
            <li><a href="/?cmd=api">
                <img src="/webroot/web/images/icons/heart_16.gif" align="middle" border="0">Developer
                APIs</a> </li>
        </ul>
    </asp:Panel>
</div>