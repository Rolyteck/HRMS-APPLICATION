<%@ Page Language="VB" MasterPageFile="~/webroot/web/modules/main.master" AutoEventWireup="false" CodeFile="purchases_edit.aspx.vb" Inherits="webroot_web_modules_accounts_asset_purchases_edit" title="Purchase Requisition Page" %>

<%@ Register src="../../controls/popups/product.ascx" tagname="product" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="masterContent">
        <table id="table8" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td class="pageTitleBar">
                        <asp:Label ID="lbHeader" runat="server" Text="Purchase Requisition"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc:msgbox ID="Msgbox1" runat="server"></uc:msgbox>
                    </td>
                </tr>
                   <tr>
                    <td class="sectionTabBar">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                                ShowMessageBox="True" ShowSummary="False" />
                        <uc:toptabs ID="toptabs1" runat="server" GroupName="ledger_cashbooks" />
                    </td>
                </tr>
                   
                     <tr>
               <td class="pageFilterBox">
                        <div class="pageFilterBoxHeader">
                            <mb:ExpandingImageButton ID="ExpandingImageButton5" ExpandedAlternateText="Expand this node."
                                ContractedAlternateText="Close this node." CssClass="ExpandingImageButton" ControlToToggle="filterTable1"
                                ExpandedImageUrl="/webroot/web/images/icons/expanded_13.gif" ContractedImageUrl="/webroot/web/images/icons/expand_13.gif"
                                runat="server" EnableClientScript="true" />
                            <label for="_ctl0_ContentPlaceHolder1_ExpandingImageButton1_clicker" style="width: 96%;
                                cursor: hand">
                                <asp:Label ID="Label4" runat="server" Text="Transaction Details"></asp:Label></label></div>
                        <asp:Panel ID="filterTable1" runat="server" >
                            <table id="section1" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td class="editColA" style="height: 18px">
                                            </td>
                                        <td class="editColB" style="height: 18px">
                                        </td>
                                        <td class="editColC" style="height: 18px">
                                            </td>
                                        <td class="editColD" style="height: 18px">
                                            </td>
                                    </tr>

                                    <tr>
                                        <td class="editColA">
                                            Transaction Date:
                                        </td>
                                        <td class="editColB">
                                            <asp:TextBox ID="txtBillingDate" runat="server" CssClass="textboxDate"></asp:TextBox>
                                        </td>
                                        <td class="editColC">
                                            <asp:Label ID="lblNumber" runat="server" Text="Requisition No:"></asp:Label>
                                        </td>
                                        <td class="editColD">
                                            <asp:TextBox ID="txtReceiptNo" runat="server" CssClass="textbox">Auto</asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv1" runat="server" 
                                                ControlToValidate="txtReceiptNo" ErrorMessage="receipt  Number is required!">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            &nbsp;</td>
                                        <td class="editColB">
                                            &nbsp;</td>
                                        <td class="editColC">
                                            &nbsp;</td>
                                        <td class="editColD">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            <asp:Label ID="lblAcctCode" runat="server" Text="Vendor Details:"></asp:Label>
                                        </td>
                                        <td class="editColB">
                                            <uc:party ID="party1" runat="server" />
                                        </td>
                                        <td class="editColC">
                                            Narration:</td>
                                        <td class="editColD">
                                            <asp:TextBox ID="txtNarration" runat="server" CssClass="textbox" 
                                                TextMode="MultiLine"></asp:TextBox>
                                              </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            &nbsp;</td>
                                        <td class="editColB">
                                            &nbsp;</td>
                                        <td class="editColC">
                                            &nbsp;</td>
                                        <td class="editColD">
                                            &nbsp;</td>
                                    </tr>
                                 
                                                                  
                                                     <tr>
                                        <td class="editColA">
                                            Branch/Location:</td>
                                        <td class="editColB">
                                            <asp:DropDownList ID="cdbBranch" runat="server" CssClass="dropdown">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv15" runat="server" 
                                                ControlToValidate="cdbBranch" ErrorMessage="Branch  is required!">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td class="editColC">
                                            Total Amount:</td>
                                        <td class="editColD">
                                            <asp:TextBox ID="txttotalAmount" runat="server" CssClass="textbox">0.00</asp:TextBox>
                                            
                                                         </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA">
                                            &nbsp;
                                        </td>
                                        <td class="editColB">
                                            &nbsp;
                                            <asp:TextBox ID="txtTransGUID" runat="server" CssClass="textbox" 
                                                Visible="False"></asp:TextBox>
                                        </td>
                                        <td class="editColC">
                                            &nbsp;
                                        </td>
                                        <td class="editColD">
                                            &nbsp;
                                        </td>
                                    </tr>
                   
                                </tbody>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                
               
                <tr>
                    <td class="pageFilterBox">
                        <div class="pageFilterBoxHeader">
                            <mb:ExpandingImageButton ID="ExpandingImageButton3" ExpandedAlternateText="Expand this node."
                                ContractedAlternateText="Close this node." CssClass="ExpandingImageButton" ControlToToggle="Panel2"
                                ExpandedImageUrl="/webroot/web/images/icons/expanded_13.gif" ContractedImageUrl="/webroot/web/images/icons/expand_13.gif"
                                runat="server" EnableClientScript="true" />
                        <label for="_ctl0_ContentPlaceHolder1_ExpandingImageButton1_clicker" style="width: 96%;
                                cursor: hand">
                                <asp:Label ID="Label1" runat="server" Text="Purchase Details"></asp:Label></label>        
                        </div>
                        <asp:Panel ID="Panel2" runat="server">
                            <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td class="editColA" style="height: 18px;">
                                            <br />
                                            Products:</td>
                                        <td class="editColB" style="height: 18px">
                                            <uc1:product ID="product1" runat="server" />
                                        </td>
                                        <td class="editColC" style="height: 18px;">
                                            <br />
                                            &nbsp;Unit Price:</td>
                                        <td class="editColD" style="height: 18px">
                                            <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="textbox"></asp:TextBox>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA" style="height: 8px;">
                                            Quantity:</td>
                                        <td class="editColB" style="height: 8px">
                                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                        <td class="editColC" style="width: 393px; height: 8px;">
                                            &nbsp;Amount:&nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfv11" runat="server" 
                                                ControlToValidate="txtPaidAmount" ErrorMessage="paid amount required!">*</asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                        <td class="editColD" style="height: 8px">
                                            <asp:TextBox ID="txtPaidAmount" runat="server" CssClass="textbox">0.00</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="editColA" style="width: 256px; height: 6px;">
                                            </td>
                                        <td style="height: 6px">
                                            </td>
                                        <td class="editColC" style="width: 393px; height: 6px;">
                                            </td>
                                        <td style="height: 6px">
                                            <mb:ConfirmedButton ID="cmdAdd" runat="server" CssClass="button" 
                                                MessageEnabled="False" Text="Add" />
                                        </td>
                                    </tr>
                                 
                                </tbody>
                            </table>
                        </asp:Panel>
                                      
                        
                    </td>
                </tr>
                               
               
               <tr>
                    <td class="pageFilterBox">
                        <div class="pageFilterBoxHeader">
                            <mb:ExpandingImageButton ID="ExpandingImageButton4" ExpandedAlternateText="Expand this node."
                                ContractedAlternateText="Close this node." CssClass="ExpandingImageButton" ControlToToggle="Panel4"
                                ExpandedImageUrl="/webroot/web/images/icons/expanded_13.gif" ContractedImageUrl="/webroot/web/images/icons/expand_13.gif"
                                runat="server" EnableClientScript="true" />
                        <label for="_ctl0_ContentPlaceHolder1_ExpandingImageButton1_clicker" style="width: 96%;
                                cursor: hand">
                            <asp:Label ID="Label5" runat="server" Text="Purchases Posting Details"></asp:Label></label>
                        </div>
                        <asp:Panel ID="Panel4" runat="server">
                            <asp:DataGrid ID="Datagrid1" runat="server" CellPadding="3" Width="100%">
                                <ItemStyle CssClass="GridRowStyle" />
                                <AlternatingItemStyle CssClass="GridAltRowStyle" />
                                <HeaderStyle CssClass="GridHeaderStyle" />
                                <FooterStyle CssClass="GridFooterStyle" />
                                <PagerStyle CssClass="GridPagerStyle" />
                                <Columns>
                                    <asp:ButtonColumn CommandName="Delete" Text="Delete"></asp:ButtonColumn>
                                </Columns>
                            </asp:DataGrid>
                        </asp:Panel>
                    </td>
                </tr>
                
                </tbody>
        </table>
             <div class="FloatingFooter">
            <div class="FloatingFooterDiv1">
            <mb:ConfirmedButton ID="btnCancel" runat="server" CssClass="button" 
                    Text="Go Back" MessageEnabled="False" CausesValidation="False" />
                                    <mb:ConfirmedButton ID="btnOk" runat="server" 
                    CssClass="button" Text="Save" />
            </div>
            <div class="FloatingFooterDiv2">
            </div>
        </div>
    </div>
  
  
<script type="text/javascript" src="/webroot/web/scripts/date.js"></script>
<script type="text/javascript">

    function calcPremium() {
        var unitPrice = document.getElementById('<%=txtunitprice.ClientID %>');
        var Qty = document.getElementById('<%=txtquantity.ClientID %>');
        var Paidmount = document.getElementById('<%=txtPaidAmount.ClientID %>');


        //remove formatting 
        Paidmount.value = digit_ungrouping(Paidmount.value);
        unitPrice.value = digit_ungrouping(unitPrice.value);

        Paidmount.value = unitPrice.value * Qty.value;

        //formating

        Paidmount.value = digit_grouping(Paidmount.value);
        unitPrice.value = digit_grouping(unitPrice.value);
    }

    function digit_grouping(nStr) {
        nStr = Math.round(nStr * 100) / 100
        nStr += '';
        x = nStr.split('.');
        x1 = x[0];
        x2 = x.length > 1 ? '.' + x[1] : '';
        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
        return x1 + x2;
    }

    function digit_ungrouping(nStr) {
        return nStr.replace(',', '').replace(',', '').replace(',', '');
    }  
</script>

</asp:Content>


