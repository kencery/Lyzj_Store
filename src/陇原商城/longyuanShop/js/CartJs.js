if (typeof (Cart8571) == "undefined") {
    Cart8571 = {};
}
Cart8571 = {
    //修改购买的数量
ChangeBuyNum: function(cartId, pId) {
        alert(pId);
        var cartBuyNumObj = $("txtBuyNum_" + pId);
        if (cartBuyNumObj) {
            cartBuyNumObj.value = FixNum(cartBuyNumObj.value);
            var buyNum = parseInt(cartBuyNumObj.value);
            if (isNaN(buyNum)) {
                cartBuyNumObj.value = 0;
                buyNum = "0";
            }
            if (creRequest()) {
                startRequest("POST", "requestext", "../ajax/AddCart.aspx", "RequestType=change&PId=" + pId + "&CardID=" + cartId + "&BuyNUm=" + buyNum, Cart8571.BindTotalPricesInfo);
            }
            else {
                alert('对不起，您的浏览器不支持Ajax技术，请安装IE6.0以上或FF浏览器.....');
                return;
            }
        }
    },
    //重新显示购买的商品
    BindTotalPricesInfo: function(str) {
        document.getElementById("CartList").innerHTML = str;
    },
    DelCartProduct: function(cartId, PId) {
        if (confirm("您确定要从购物车中删除产品吗？")) {
            if (creRequest()) {
                startRequest("POST", "requestext", "../ajax/AddCart.aspx", "RequestType=del&PId=" + PId + "&CardId=" + cartId, Cart8571.Resultvalue);
            }
            else {
                alert('对不起，您的浏览器不支持Ajax技术，请安装IE6.0以上或FF浏览器.....');
                return;
            }
        }
        return false;
    },
    Resultvalue: function(str) {
        alert(str);
        window.location.reload();
    }
}
