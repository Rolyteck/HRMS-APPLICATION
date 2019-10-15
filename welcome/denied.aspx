<%@ Page Language="VB" MasterPageFile="~/webroot/web/modules/main.master" AutoEventWireup="false" CodeFile="denied.aspx.vb" Inherits="webroot_web_modules_welcome_access_denied" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="masterContent">
        <table id="table8" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td class="pageTitleBar">
                        Accesss Denied Page
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <uc:Msgbox ID="Msgbox1" runat="server"></uc:Msgbox>
                    </td>
                </tr>
                <tr>
                    <td class="sectionTitleBar">
                        Welcome 
                    </td>
                </tr>
               <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" 
                            ImageUrl="815021b.JPG" />
                        </td>
                </tr>
            </tbody>
        </table>
        <div class="FloatingFooter">
            <div class="FloatingFooterDiv1">
            </div>
            <div class="FloatingFooterDiv2">
                </div>
        </div>
    </div>
</asp:Content>


