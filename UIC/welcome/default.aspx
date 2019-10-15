<%@ Page Language="VB" MasterPageFile="~/webroot/web/modules/main.master" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="datafiles_welcome_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="masterContent">
        <table id="table8" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td align="center">
                        <uc:Msgbox ID="Msgbox1" runat="server"></uc:Msgbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" 
                            ImageUrl="/datafiles/staco/welcome/815021b.JPG" />
                        
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>

