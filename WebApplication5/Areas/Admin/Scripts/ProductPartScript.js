$(document)
    .ready(function() {
        var addedParts = new Array();
        var deleteParts = new Array();
        var productId = $("input:hidden[name='ProductId']").attr("value");
        $(":checkbox.addPartCb").css("background", "red");

        $(":checkbox.addPartCb")
            .click(function() {
                if ($(this).is(":checked")) {
                    $(this).closest("tr").css("background", "red");

                } else {
                    $(this).closest("tr").removeProp("style");
                }
                updateAddedPartArr();
            });
        $(":checkbox.deletePartCb")
            .click(function () {
                if ($(this).is(":checked")) {
                    $(this).closest("tr").css("background", "red");

                } else {
                    $(this).closest("tr").removeProp("style");
                }
                updateDeletePartArr();
            });

        $("#addBtn")
            .click(function() {
                sendAddPart();
            });

        $("#deleteBtn")
            .click(function () {
                sendDeletePart();
            });

        function updateAddedPartArr() {
            addedParts = new Array();
            $("input:checked")
                .each(function() {
                    addedParts.push($(this).attr("id"));
                });
        }

        function updateDeletePartArr() {
            deleteParts = new Array();
            $("input:checked")
                .each(function () {
                    deleteParts.push($(this).attr("id"));
                });
        }

        function sendAddPart() {
            var urlGetPart = "http://" + location.host + "/Admin/ProductParts/AddPartAjax/";
            var request = $.ajax({
                url: urlGetPart,
                type: "POST",
                data: { addedParts: addedParts, productId: productId },
                dataType: "json"
            });

            request.done(function(response) {
                location.reload();
            });

            request.fail(function(jqXHR, textStatus) {
                alert("Request failed: " + textStatus);
            });
        }

        function sendDeletePart() {
            var urlGetPart = "http://" + location.host + "/Admin/ProductParts/DeletePartAjax/";
            var request = $.ajax({
                url: urlGetPart,
                type: "POST",
                data: { deleteParts: deleteParts, productId: productId },
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
