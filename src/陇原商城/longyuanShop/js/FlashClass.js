function insertFlash(elm, url,Id, w, h,wmodeValue,fVars)
{
    if (!document.getElementById(elm)) return;
    var str = '';
    str += '<object id="'+Id+'" width="'+ w +'" height="'+ h +'" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0">';
    str += '<param name="movie" value="'+ url +'" />';
    str += '<param name="wmode" value="'+wmodeValue+'" />';//transparent|Opaque
    str += '<param name="quality" value="High" />';
    str += '<param name="FlashVars" value="'+fVars+'" />';
    str += '<embed name="'+Id+'" swliveconnect="true" width="'+ w +'" height="'+ h +'" src="'+ url +'" quality="High" wmode="'+wmodeValue+'" FlashVars="'+fVars+'" type="application/x-shockwave-flash" plugspace="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash"></embed>';
    str += '</object>';
    document.getElementById(elm).innerHTML = str;
}