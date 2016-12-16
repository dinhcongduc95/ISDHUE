$(document)
    .ready(function () {
        var addedProducts = new Array();
        var deleteProducts = new Array();
        var cartId = $("input:hidden[name='CartId']").attr("value");
        $(":checkbox.addProductCb").css("background", "red");

        $(":checkbox.addProductCb")
            .click(function () {
                if ($(this).is(":checked")) {
                    $(this).closest("tr").css("background", "red");

                } else {
                    $(this).closest("tr").removeProp("style");
                }
                updateAddedProductArr();
            });
        $(":checkbox.deleteProductCb")
            .click(function () {
                if ($(this).is(":checked")) {
                    $(this).closest("tr").css("background", "red");

                } else {
                    $(this).closest("tr").removeProp("style");
                }
                updateDeleteProductArr();
            });

        $("#addBtn")
            .click(function () {
                sendAddProduct();
            });

        $("#deleteBtn")
            .click(function () {
                sendDeleteProduct();
            });

        function updateAddedProductArr() {
            addedProducts = new Array();
            $("input:checked")
                .each(function () {
                    addedProducts.push($(this).attr("id"));
                });
        }

        function updateDeleteProductArr() {
            deleteProducts = new Array();
            $("input:checked")
                .each(function () {
                    deleteProducts.push($(this).attr("id"));
                });
        }

        function sendAddProduct() {
            var urlGetProduct = "http://" + location.host + "/Admin/CartProducts/AddProductAjax/";
            var request = $.ajax({
                url: urlGetProduct,
                type: "POST",
                data: { addedProducts: addedProducts, cartId: cartId },
                dataType: "json"
            });

            request.done(function (response) {
                location.reload();
            });

            request.fail(function (jqXHR, textStatus) {
                alert("Request failed: " + textStatus);
            });
        }

        function sendDeleteProduct() {
            var urlGetProduct = "http://" + location.host + "/Admin/CartProducts/DeleteProductAjax/";
            var request = $.ajax({
                url: urlGetProduct,
                type: "POST",
                data: { deleteProducts: deleteProducts, cartId: cartId },
                dataType: "json"
            });

            request.done(function (response) {
                location.reload();
            });

            request.fail(function (jqXHR, textStatus) {
                alert("Request failed: " + textStatus);
            });
        }
    });
