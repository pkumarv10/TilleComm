function AddtoCart(productId, control) {
    $.ajax({
        type: "GET",
        url: "/Home/AddtoCart",
        data: { productId: productId },
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            $('#pMyCartItemsCount').html("My Cart Items(" + data + ")");
            $(control).attr("onclick", "RemoveFromCart(" + productId + ", this)");
            $(control).attr("value", "Remove from Cart");
            $(control).attr("class", "btn btn-danger");
        },
        error: function (data) {
            alert("Error occured!!");
        }
    });
}

function RemoveFromCart(productId, control) {
    $.ajax({
        type: "GET",
        url: "/Home/RemoveFromCart",
        data: { productId: productId },
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            $('#pMyCartItemsCount').html("My Cart Items(" + data + ")");
            $(control).attr("onclick", "AddtoCart(" + productId + ", this)");
            $(control).attr("value", "Add to Cart");
            $(control).attr("class", "btn btn-primary");
        },
        error: function (data) {
            alert("Error occured!!");
        }
    });
}
function IncrementProduct(productId, controlId) {
    var currentVal = $('#'+controlId).val() * 1;
    var nextVal = currentVal + 1;
    $('#' + controlId).val(nextVal);
    FormJson();
}

function DecrementProduct(productId, controlId) {
    var currentVal = $('#' + controlId).val();
    if (currentVal != 1) {
        var nextVal = currentVal - 1;
        $('#' + controlId).val(nextVal);
    }
    FormJson();
    
}

function FormJson() {
    var length = $('.txtFindProduct').length;
    var str = "";
    var products;
    for (var i = 0; i < length; i++) {
        str = str + ",{\"ProductId\":" + $($('.txtFindProduct')[i]).attr("data-productid") + ",\"Quantity\":" + $($('.txtFindProduct')[i]).val() + "}";
        //var product;
        //product.ProductId = $($('.txtFindProduct')[i]).attr("data-productid");
        //product.Quantity = $($('.txtFindProduct')[i]).val();
        //products.push(product);

    }
    var finalStr = "[" + str.substr(1, str.length) + "]";
    $.ajax({
        type: "POST",
        url: "/Home/GetCartDetailsView",
        data: finalStr,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            $('#divCartPage').html(data.responseText);
        },
        error: function (data) {
            $('#divCartPage').html(data.responseText);
        }
    });
}