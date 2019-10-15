<%@ Control Language="VB" AutoEventWireup="false" CodeFile="paygridarea.ascx.vb" Inherits="webroot_web_controls_Pay_gridarea" %>
<style type="text/css">
    .style1
    {
        width: 25%;
    }
</style>
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
                                <asp:Label ID="lblwhere" runat="server" Text="Where:"></asp:Label>
                                &nbsp;</td>
                            <td runat="server" id="ddl1" width="25%">
                                <asp:DropDownList ID="cbSearchOn" runat="server" Width="120px" CssClass="dropdown">
                                </asp:DropDownList>
                            </td>
                            <td width="10px">
                                <asp:Label ID="lblContains" runat="server" Text="Contains:"></asp:Label>
                            </td>
                            <td width="25%">
                                <asp:TextBox ID="txtSearchStr" runat="server" CssClass="textboxFree" MaxLength="64"
                                    Width="120px"></asp:TextBox>
                            </td>
                            <td width="10px">
                                <asp:Label ID="lblsheet" runat="server" Text="Pay Sheet:"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:DropDownList ID="cdbPaysheet" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
                            </td>
                            <td width="10px">
                                <asp:Label ID="lblperiod" runat="server" Text="Period:"></asp:Label>
                            </td>
                            <td width="25%">
                                <asp:DropDownList ID="cdbPayPeriod" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="10px">
                                <asp:Label ID="lblPayOption" runat="server" Text="Pay Options:"></asp:Label>
                            </td>
                            <td runat="server" width="25%">
                                <asp:DropDownList ID="cdbPayoption" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
                            </td>
                            <td width="10px">
                                &nbsp;</td>
                            <td width="25%">
                                <asp:Button ID="cmdFilter" runat="server" CssClass="buttonFilter" 
                                    Text="Apply" />
                            </td>
                            <td width="10px">
                                <asp:Label ID="lblgradeLevel" runat="server" Text="Grade Level:"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:DropDownList ID="cdbGradelevel" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
                            </td>
                            <td width="10px">
                                <asp:Label ID="NextMonth" runat="server" Text="Period:" Visible="False"></asp:Label>
                            </td>
                            <td width="25%">
                                <asp:DropDownList ID="cdbPayNextmonth" runat="server" CssClass="dropdown" 
                                    Visible="False">
                                </asp:DropDownList>
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
