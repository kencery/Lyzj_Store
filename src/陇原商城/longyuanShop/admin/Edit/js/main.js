/*
*######################################
* eWebEditor v4.00 - Advanced online web based WYSIWYG HTML editor.
* Copyright (c) 2003-2007 eWebSoft.com
*
* For further information go to http://www.ewebsoft.com/
* This copyright notice MUST stay intact for use.
*######################################
*/


var sEditorRootPath = document.location.pathname;
sEditorRootPath = sEditorRootPath.substr(0, sEditorRootPath.length-15);

config.StyleMenuHeader = "<head>"
	+"<link href='" + sEditorRootPath + "/css/" + config.CssDir + "/menuarea.css' type='text/css' rel='stylesheet'>"
	+"</head>"
	+"<body scroll='no' onConTextMenu='event.returnValue=false;'>";

config.StyleEditorHeader1 = "<head>"
	+"<link href='" + sEditorRootPath + "/css/" + config.CssDir + "/editorarea.css' type='text/css' rel='stylesheet'>";
config.StyleEditorHeader2 = "</head><body MONOSPACE>" ;

if (sExtCSS){
	sExtCSS = "<link href='" + relative2fullpath(sExtCSS) + "' type='text/css' rel='stylesheet'>";
}else{
	sExtCSS = "";
}


document.write ("<title>eWebEditor</title>");
document.write ("<link href='css/" + config.CssDir + "/editor.css' type='text/css' rel='stylesheet'>");

document.write ("<script type='text/javascript' src='js/editor.js'><\/script>");
document.write ("<script type='text/javascript' src='js/table.js'><\/script>");
document.write ("<script type='text/javascript' src='js/menu.js'><\/script>");

document.write ("</head>");
document.write ("<body SCROLLING=no onConTextMenu='event.returnValue=false;'>");

document.write ("<table id=eWebEditor_Layout border=0 cellpadding=0 cellspacing=0 width='100%' height='100%'>");
document.write ("<tr><td>");

showToolbar();

document.write ("</td></tr>");
document.write ("<tr><td height='100%'>");

document.write ("	<table border=0 cellpadding=0 cellspacing=0 width='100%' height='100%'>");
document.write ("	<tr><td height='100%'>");
document.write ("	<input type='hidden' ID='ContentEdit' value=''>");
document.write ("	<input type='hidden' ID='ModeEdit' value=''>");
document.write ("	<input type='hidden' ID='ContentLoad' value=''>");
document.write ("	<input type='hidden' ID='ContentFlag' value='0'>");
document.write ("	<iframe class='Composition' ID='eWebEditor' MARGINHEIGHT='1' MARGINWIDTH='1' width='100%' height='100%' scrolling='yes'> ");
document.write ("	</iframe>");
document.write ("	</td></tr>");
document.write ("	</table>");

document.write ("</td></tr>");

if (config.StateFlag=="1"){
	document.write ("<tr><td height=25>");
	document.write ("	<TABLE border='0' cellPadding='0' cellSpacing='0' width='100%' class=StatusBar height=25>");
	document.write ("	<TR valign=middle>");
	document.write ("	<td>");
	document.write ("		<table border=0 cellpadding=0 cellspacing=0 height=20>");
	document.write ("		<tr>");
	document.write ("		<td width=10></td>");
	document.write ("		<td class=StatusBarBtnOff id=eWebEditor_CODE onclick=\"setMode('CODE')\" unselectable=on><img border=0 src='buttonimage/" + config.ButtonDir + "/modecode.gif' width=20 height=15 align=absmiddle>" + lang["StatusModeCode"] + "</td>");
	document.write ("		<td width=5></td>");
	document.write ("		<td class=StatusBarBtnOff id=eWebEditor_EDIT onclick=\"setMode('EDIT')\" unselectable=on><img border=0 src='buttonimage/" + config.ButtonDir + "/modeedit.gif' width=20 height=15 align=absmiddle>" + lang["StatusModeEdit"] + "</td>");
	document.write ("		<td width=5></td>");
	document.write ("		<td class=StatusBarBtnOff id=eWebEditor_TEXT onclick=\"setMode('TEXT')\" unselectable=on><img border=0 src='buttonimage/" + config.ButtonDir + "/modetext.gif' width=20 height=15 align=absmiddle>" + lang["StatusModeText"] + "</td>");
	document.write ("		<td width=5></td>");
	document.write ("		<td class=StatusBarBtnOff id=eWebEditor_VIEW onclick=\"setMode('VIEW')\" unselectable=on><img border=0 src='buttonimage/" + config.ButtonDir + "/modeview.gif' width=20 height=15 align=absmiddle>" + lang["StatusModeView"] + "</td>");
	document.write ("		</tr>");
	document.write ("		</table>");
	document.write ("	</td>");
	if (sFullScreen!="1"){
		document.write ("	<td align=right>");
		document.write ("		<table border=0 cellpadding=0 cellspacing=0 height=20>");
		document.write ("		<tr>");
		document.write ("		<td style='cursor:pointer;' onclick='sizeChange(300)'><img border=0 SRC='buttonimage/" + config.ButtonDir + "/sizeplus.gif' width=20 height=20 alt='" + lang["SizePlus"] + "'></td>");
		document.write ("		<td width=5></td>");
		document.write ("		<td style='cursor:pointer;' onclick='sizeChange(-300)'><img border=0 SRC='buttonimage/" + config.ButtonDir + "/sizeminus.gif' width=20 height=20 alt='" + lang["SizeMinus"] + "'></td>");
		document.write ("		<td width=40></td>");
		document.write ("		</tr>");
		document.write ("		</table>");
		document.write ("	</td>");
	}
	document.write ("	</TR>");
	document.write ("	</Table>");
	document.write ("</td></tr>");
}
document.write ("</table>");

document.write ("<div id='eWebEditor_Temp_HTML' style='VISIBILITY: hidden; OVERFLOW: hidden; POSITION: absolute; WIDTH: 1px; HEIGHT: 1px'></div>");

document.write ("</body></html>");


function relative2fullpath(url){
	if(url.indexOf("://")>=0) {return url;}
	if(url.substr(0,1)=="/") {return url;}

	var sPath = sEditorRootPath;
	while(url.substr(0,3)=="../"){
		url = url.substr(3);
		sPath = sPath.substring(0, sPath.lastIndexOf("/"));
	}
	return sPath + "/" + url;
}
