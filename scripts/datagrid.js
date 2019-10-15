//row selector script for datagrids

function datagrid_selectRow(e) {
	if (e.type == "radio") {
		_datagrid_radioSelected(e);
	} 
	else {
		_datagrid_rowSelected(e.parentNode.parentNode, e.checked);
	}
}
function datagrid_selectAllRows(e) {
	var theTable = e.parentNode.parentNode.parentNode;
	for (i=1; i < theTable.rows.length; i++) {
		if (theTable.rows[i].cells[0].childNodes[0].type == "checkbox") {
		_datagrid_rowSelected(theTable.rows[i], e.checked);
		}
	}
}
function _datagrid_radioSelected(e) {
	var theTable = e.parentNode.parentNode.parentNode;
	for (i=1; i < theTable.rows.length; i++) {
		var theRow = theTable.rows[i];
		_datagrid_rowSelected(theRow, theRow.cells[0].childNodes[0].checked);
	}
}
function _datagrid_rowSelected(row, checked) {
	if (checked) {
		if (!row.className.match(/.*Selected/)) {
		row.className = row.className+"Selected";
		row.cells[0].childNodes[0].checked = true;
		}
	}
	else {
		if (row.className.match(/.*Selected/)) {
		row.className = row.className.replace("Selected","");
		row.cells[0].childNodes[0].checked = false;
		}
	}
}
function datagrid_rowHover(row, mouseover) {
	if (mouseover) {
		if (row.className.match(/.*Selected/)) { //don't hover a selected row
		// skip. do absolutely nothing
		} else if (!row.className.match(/.*Hover/)) {
		row.className = row.className+"Hover";
		}
	}
	else {
		if (row.className.match(/.*Hover/)) {
		row.className = row.className.replace("Hover","");
		}
	}
}
//function datagrid_rowSelected(row, checked) {
//	if (checked) {
//		if (!row.className.match(/.*Selected/)) {
//		row.className = row.className+"Selected";
//		}
//	}
//	else {
//		if (row.className.match(/.*Selected/)) {
//		row.className = row.className.replace("Selected","");
//		}
//	}
//}
function datagrid_selectOneRow(row) {
	var theTable = row.parentNode.parentNode;
	for (i=0; i < theTable.rows.length; i++) {
		var theRow = theTable.rows[i];
		if (theRow.className.match(/.*Selected/)) {
		theRow.className = theRow.className.replace("Selected","");
		}
	}
	if (!row.className.match(/.*Selected/)) {
	row.className = row.className+"Selected";
	}
}
