$(document).ready(function() {
    // 页面中的Dom已经装载完成时，执行的代码
    $(".hmain> a").click(function() {
        //找到主菜单项对应的子菜单项
        var ulNode = $(this).next("ul");
        ulNode.slideToggle(400);  //区分大小写
        changeIcon($(this));
    });
});

//修改主菜单的指示图标
function changeIcon(mainNode) {
    if (mainNode) {
        if (mainNode.css("background-image").indexOf("collapsed.gif") >= 0) {
            mainNode.css("background-image", "url('images/expanded.gif'");
        }
        else {
            mainNode.css("background-image", "url('images/collapsed.gif'");
        }
    }
}