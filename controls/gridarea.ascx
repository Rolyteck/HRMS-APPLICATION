<%@ Control Language="VB" AutoEventWireup="false" CodeFile="gridarea.ascx.vb" Inherits="webroot_web_controls_gridarea" %>
<table id="table99" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tbody>
        <tr id="filterBoxDiv" runat="server">
            <td class="pageFilterBox">
                <div class="pageFilterBoxHeader">
                    <mb:ExpandingImageButton ID="ExpandingImageButton1" ExpandedAlternateText="Expand this node."
                        ContractedAlternateText="Close this node." CssClass="ExpandingImageButton" ControlToToggle="filterTable1"
                        ExpandedImageUrl="/webroot/web/images/icons/expanded_13.gif" ContractedImageUrl="/webroot/web/images/icons/expand_13.gif"
                        runat="server" />
                    <asp:Label ID="Label3" runat="server" AssociatedControlID="ExpandingImageButton1">Search Filter</asp:Label></div>
                <asp:Panel ID="filterTable1" runat="server" DefaultButton="cmdFilter">
                    <table border="0" cellpadding="5" cellspacing="0" width="100%">
                        <tr>
                            <td width="10px">
                                where
                            </td>
                            <td runat="server" id="ddl1" width="25%">
                                <asp:DropDownList ID="cbSearchOn" runat="server" Width="120px" CssClass="dropdown">
                                </asp:DropDownList>
                            </td>
                            <td width="10px">
                                contains
                            </td>
                            <td width="25%">
                                <asp:TextBox ID="txtSearchStr" runat="server" CssClass="textboxFree" MaxLength="64"
                                    Width="120px"></asp:TextBox>
                            </td>
                            <td width="10px">
                                <asp:Label ID="lbBetween" runat="server" Text="Label">between</asp:Label>
                            </td>
                            <td width="25%">
                                <asp:TextBox ID="txtDate1" runat="server" MaxLength="11" CssClass="textboxDateFree"
                                    Width="120px"></asp:TextBox>
                            </td>
                            <td width="10px">
                                <asp:Label ID="lbBtwAnd" runat="server" Text="Label">and</asp:Label>
                            </td>
                            <td width="25%">
                                <asp:TextBox ID="txtDate2" runat="server" MaxLength="11" CssClass="textboxDateFree"
                                    Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                                <asp:Label ID="lblsheet" runat="server" Text="Pay Sheet:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cdbPaysheet" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;
                                <asp:Button ID="cmdFilter" runat="server" CssClass="buttonFilter" 
                                    Text="Apply" />
                            </td>
                        
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" CssClass="GridStyle">
                    <RowStyle CssClass="GridRowStyle" />
                    <HeaderStyle CssClass="GridHeaderStyle" />
                    <FooterStyle CssClass="GridFooterStyle" />
                    <PagerStyle CssClass="GridPagerStyle" />
                    <PagerTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="PagerTable">
                            <tbody>
                                <tr>
                                    <td nowrap class="PagerText" align="left">
                                        <asp:Label ID="Label1" runat="server">Viewing X to Y of Z</asp:Label>
                                    </td>
                                    <td nowrap class="PagerNums" width="70%" align="center">
                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                    </td>
                                    <td class="PagerDdl" runat="server" id="td_ddl" width="10%" align="right">
                                        <asp:DropDownList CssClass="dropdownFree" ID="DropDownList1" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="pagerDdl_SelectedIndexChanged" Enabled="false">
                                            <asp:ListItem Value="25">25 items per page</asp:ListItem>
                                            <asp:ListItem Value="50">50 items per page</asp:ListItem>
                                            <asp:ListItem Value="100">100 items per page</asp:ListItem>
                                            <asp:ListItem Value="200">200 items per page</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </PagerTemplate>
                </asp:GridView>
            </td>
        </tr>
    </tbody>
</table>
