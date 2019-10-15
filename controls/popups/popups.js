var pop_timeoutObj;

function pop_showModalPopup(txtSearchID, mpeID)
{
	var txtSearch = $get(txtSearchID);
    var popModal = $find(mpeID);
    popModal.show();
    txtSearch.focus();
    txtSearch.select();
}
function pop_onNewClick(uPnlModalID)
{
    __doPostBack(uPnlModalID, 'newitem');
    //pol_showModalPopup();
}
function pop_onSearchKeyPress(lbMsgID, txtCodeID, txtSearchID, uPnlModalID)
{
	clearTimeout(pop_timeoutObj);
	pop_timeoutObj = setTimeout("pop_populateGrid('"+lbMsgID+"','"+txtCodeID+"','"+txtSearchID+"','"+uPnlModalID+"');", 500);
}
function pop_populateGrid(lbMsgID, txtCodeID, txtSearchID, uPnlModalID)
{
	var lbMsg = $get(lbMsgID);
	var txtCode = $get(txtCodeID);
	var txtSearch = $get(txtSearchID);
    if (txtSearch.value.length > 2) {
        __doPostBack(uPnlModalID,'gridview');
	    lbMsg.innerHTML = '';
    } else {
	    lbMsg.innerHTML = 'Type 3 characters or more.';
    }
}
function pop_itemSelected(txtCodeID, mpeID, uPnlControlID, value) {
	var txtCode = $get(txtCodeID);
    var popModal = $find(mpeID);
    txtCode.value = value;
    popModal.hide();
    __doPostBack(uPnlControlID, 'update');
}