$(document).ready(function () {
    $("#productGroupList").change(function () {
        var pgID = $(this).val();
        $.post("/Home/GetProductsByGroupId", { productGroupId: pgID },
            function (data) {
                var select = $("#productList");

                select.empty();
                $.each(data, function (index, itemData) {
                   // console.log(itemData);
                    select.append($('<option/>', {
                        value: itemData.value,
                        text: itemData.text
                    }));
                });
            });
    });
    $("#productList").change(function () {
        var pID = $(this).val();
        $.post("/Home/GetProductPriceById", { productId: pID },
            function (data) {
               // console.log(data);
                $('#txtProductPrice').val(data.price);
            });
    });
});