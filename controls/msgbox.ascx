<%@ Control Language="vb" AutoEventWireup="false" Inherits="msgbox" CodeFile="msgbox.ascx.vb" %>
<asp:Panel ID="PanelError" CssClass="msgboxInfo" runat="server" Visible="False">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td width="10%">
            </td>
            <td valign="middle" align="center">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </td>
            <td width="10px" valign="top" visible="false">
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="close" ImageUrl="~/webroot/web/images/icons/expanded_16.gif">
                    close
                </asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="PanelHelp" CssClass="msgboxHelp" runat="server" Visible="false">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td valign="middle" align="center">
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Panel>
<%--<ajax:AnimationExtender ID="ae" runat="server" TargetControlID="HyperLink1">
    <Animations>
        <OnLoad>
            <FadeIn Duration="1.0" Fps="18" AnimationTarget="PanelError" />
        </OnLoad>
        <OnClick>                
            <Parallel>                  
                <FadeOut Duration="0.2" Fps="12" AnimationTarget="PanelError" />
                <Resize Height="0" Unit="px" AnimationTarget="PanelError" />             
            </Parallel>        
        </OnClick> 
    </Animations>
</ajax:AnimationExtender>
--%>