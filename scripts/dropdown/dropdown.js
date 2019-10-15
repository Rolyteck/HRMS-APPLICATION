function findPos(obj) { 
    var pos = {x:0, y:0};
    if (obj.offsetParent){
        while(obj) {
        pos.x += obj.offsetLeft;
        pos.y += obj.offsetTop;
        obj = obj.offsetParent;
        }
    } else if (obj.x && obj.y) {
        pos.x += obj.x;
        pos.y += obj.y;
    }
    return pos;
}
function getPosition(obj) {
	var left = 0;
	var top  = 0;
	while (obj.offsetParent){
		left+= obj.offsetLeft;
		top += obj.offsetTop;
		obj =  obj.offsetParent;
	}
	left+= obj.offsetLeft;
	top += obj.offsetTop;
	return {x:left, y:top};
}

function dropdown_showPopup(cmbid) {
    var txt = $get(cmbid+"Textbox");
    var tbl = $get(cmbid+"Table");
    //var cmb = $get(cmbid);

    if (tbl.style.display != "block") {
	    tbl.style.display = "block";
	    
	    var intPos = findPos(txt);
	    tbl.style.top = intPos.y + txt.offsetHeight;
	    tbl.style.left = intPos.x;
	    
//    	var intPos = getPosition(txt);
//	    tbl.style.top = intPos.y + txt.offsetHeight - 1;
//	    tbl.style.left = intPos.x + 1;//+txt.offsetWidth;
	    tbl.style.width = txt.offsetWidth;
	} else {
	    tbl.style.display = "none";
	}
	txt.select();
}

function dropdown_hidePopup(cmbid) { //hide after 0.2 secs 
	var t = setTimeout("$get('"+cmbid+"Table').style.display='none';", 200);
}

function dropdown_setDropValue(cmbid, newText, newValue) {
    //alert(newValue);
    var txt = $get(cmbid+"Textbox");
    var tbl = $get(cmbid+"Table");
    var cmb = $get(cmbid);
    
    cmb.value = newValue;
    txt.innerText = newText;
	tbl.style.display = "none";
    cmb.fireEvent("onchange");
	txt.select();
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function dropdown_showPopupClasses(sender, ulid) {
    var tbl = $get("classesTable");
    var tab = $get("classesTableTab");
 
	for (i = 1; i < tbl.childNodes.length; i++) {
	    if (tbl.childNodes[i].style != null) {
	        tbl.childNodes[i].style.display = "none";
	    }
    }
    $get(ulid).style.display = "block";
    
    tbl.style.display = "block";
    tab.style.display = "block";

   	var intPos = findPos(sender);
   	//tbl.style.right = 2000;

    if (/MSIE (\d+\.\d+);/.test(navigator.userAgent)){ //test for MSIE x.x;
        var ieversion = new Number(RegExp.$1) // capture x.x portion and store as a number
        if (ieversion >= 8) {
            tbl.style.top = (intPos.y-2)+"px"; 
            tbl.style.left = (intPos.x)+"px";
        } else if (ieversion >= 7) {
            tbl.style.top = (intPos.y+1)+"px"; 
            tbl.style.left = (intPos.x-1)+"px";
        } else {
            //alert(navigator.userAgent);
            tbl.style.top = (intPos.y)+"px"; 
            tbl.style.left = (intPos.x)+"px";
        }
    } else {
        tbl.style.top = (intPos.y-2)+"px"; 
        tbl.style.left = (intPos.x)+"px";
    }

    tab.innerHTML = sender.innerHTML;
    tab.style.width = (sender.offsetWidth-18)+"px";
    tab.style.height = sender.offsetHeight+"px";
}
var t1235;
function dropdown_hidePopupClasses() { //hide after 0.2 secs 
	t1235 = setTimeout("$get('classesTable').style.display='none';", 100);
}
function dropdown_cancelHidePopupClasses() {
    clearTimeout(t1235);
}
