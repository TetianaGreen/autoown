
    function GetModelList() {
        debugger;
        var BrandId = $("#brandDropDown").val();
        $.ajax
        ({
            url: '/Cars/GetModelList',
            type: 'POST',
            datatype: 'application/json',
            contentType: 'application/json',
            data: JSON.stringify({ BrandId: +BrandId }),
            success: function (result) {
                $("#modelDropDown").html("");
                $.each($.parseJSON(result), function (i, model) {
                    $("#modelDropDown").append
                    ($('<option></option>').val(model.ModelId).html(model.Name))
                })
            },
            error: function () {
                alert("Something went wrong..")
            },
        });
    }

