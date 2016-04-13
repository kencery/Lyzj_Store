
(function($){
	$.fn.jqueryzoom = function(options){
	var settings = {
		xzoom: 200,		//zoomed width default width
		yzoom: 200,		//zoomed div default width
		offset: 10,		//zoomed div default offset
		position: "right"  //zoomed div default position,offset position is to the right of the image
	};
	if(options) {
		$.extend(settings, options);
	}
	$(this).hover(function(){
		var imageLeft = $(this).get(0).offsetLeft;
		var imageRight = $(this).get(0).offsetRight;
		var imageTop =  $(this).get(0).offsetTop;
		var imageWidth = $(this).get(0).offsetWidth;
		var imageHeight = $(this).get(0).offsetHeight;
		var bigimage = $(this).parent().attr("href");
		if($("zxx_image_zoom").get().length == 0){
			$(this).after("<span class='zxx_image_zoom'><img class='bigimg' src='"+bigimage+"'/></span>");
		}
		if(settings.position == "right"){
			leftpos = imageLeft + imageWidth + settings.offset;
		}else{
			leftpos = imageLeft - settings.xzoom - settings.offset;
		}
		$("zxx_image_zoom").css({ top: imageTop,left: leftpos });
		$("zxx_image_zoom").width(settings.xzoom);
		$("zxx_image_zoom").height(settings.yzoom);
		$("zxx_image_zoom").show();
			$(document.body).mousemove(function(e){
			var bigwidth = $(".bigimg").get(0).offsetWidth;
			var bigheight = $(".bigimg").get(0).offsetHeight;
			var scaley ='x';
			var scalex= 'y';
			if(isNaN(scalex)|isNaN(scaley)){
			var scalex = Math.round(bigwidth/imageWidth) ;
			var scaley = Math.round(bigheight/imageHeight);
			}
			mouse = new MouseEvent(e);
			scrolly = mouse.y - imageTop - ($("zxx_image_zoom").height()*1/scaley)/2 ;
			$("zxx_image_zoom").get(0).scrollTop = scrolly * scaley  ;
			scrollx = mouse.x - imageLeft - ($("zxx_image_zoom").width()*1/scalex)/2 ;
			$("zxx_image_zoom").get(0).scrollLeft = (scrollx) * scalex ;
			});
		},function(){
		   $("zxx_image_zoom").hide();
		   $(document.body).unbind("mousemove");
		   $(".lenszoom").remove();
		   $("zxx_image_zoom").remove();
		});
	}
})(jQuery);

function MouseEvent(e) {
this.x = e.pageX
this.y = e.pageY
}


