<%@ Page Language="VB" MasterPageFile="~/webroot/web/modules/main.master" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="webroot_web_modules_inventory_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="masterContent">
        <table id="table8" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td class="pageTitleBar">
                        Admin Overview
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
                            ImageUrl="8150215c.JPG" />
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

