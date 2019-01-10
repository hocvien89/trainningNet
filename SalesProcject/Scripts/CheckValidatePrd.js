function checkValidate() {

    var flag = true;
    /* Check Catalog == null */
    var isNumber = /^\d+$/;
    var isSpecial = /^[a-zA-Z0-9 ]*$/;
    if ($("#drpCatalog").val() == 0) {
        $('#lblMessage').css("display", "block");
        $('#lblMessage').html("Bạn vui lòng chọn nhóm sản phẩm.");
        flag = false;
    }
    else {
        $('#lblMessage').html("");
        $('#lblMessage').css("display", "none");
        /* Check Name == null || length > 50 */
        if ($("#txtName").val().length == 0) {
            $('#lblMessage').css("display", "block");
            $('#lblMessage').html("Tên sản phẩm không được để trống.");
            flag = false;
        }
        else {
            $('#lblMessage').html("");
            $('#lblMessage').css("display", "none");
            if ($("#txtName").val().length > 50) {
                $('#lblMessage').css("display", "block");
                $('#lblMessage').html("Tên sản phẩm tối đa 50 ký tự.");
                flag = false;
            }
            else {
                $('#lblMessage').html("");
                $('#lblMessage').css("display", "none");              
                if (isSpecial.test($("#txtName").val()) == false) {
                    $('#lblMessage').css("display", "block");
                    $('#lblMessage').html("Tên sản phẩm không dấu và được chứa kí tự đặc biệt.");
                    flag = false;
                }
                else {
                    $('#lblMessage').html("");
                    $('#lblMessage').css("display", "none");
                    /* Check Amount == null || string */                 
                    if ($("#txtAmount").val().length == 0) {
                        $('#lblMessage').css("display", "block");
                        $('#lblMessage').html("Số lượng không được để trống.");
                        flag = false;
                    }
                    else {
                        $('#lblMessage').html("");
                        $('#lblMessage').css("display", "none");
                        if (isNumber.test($("#txtAmount").val()) == false) {
                            $('#lblMessage').css("display", "block");
                            $('#lblMessage').html("Số lượng chỉ được nhập số.");
                            flag = false;
                        }
                        else {
                            $('#lblMessage').html("");
                            $('#lblMessage').css("display", "none");
                            /* Check Unit == nul */
                            if ($("#txtUnit").val().length == 0) {
                                $('#lblMessage').css("display", "block");
                                $('#lblMessage').html("Đơn vị không được để trống.");
                                flag = false;
                            }
                            else {
                                $('#lblMessage').html("");
                                $('#lblMessage').css("display", "none");
                                /* Check Pricebuy == null || string */
                                if ($("#txtPricebuy").val().length == 0) {
                                    $('#lblMessage').css("display", "block");
                                    $('#lblMessage').html("Giá nhập không được để trống.");
                                    flag = false;
                                }
                                else {
                                    $('#lblMessage').html("");
                                    $('#lblMessage').css("display", "none");
                                    if (isNumber.test($("#txtPricebuy").val()) == false) {
                                        $('#lblMessage').css("display", "block");
                                        $('#lblMessage').html("Giá nhập chỉ được nhập số.");
                                        flag = false;
                                    }
                                    else {
                                        $('#lblMessage').html("");
                                        $('#lblMessage').css("display", "none");
                                        /* Check Pricebuy == null || string */
                                        if ($("#txtPrice").val().length == 0) {
                                            $('#lblMessage').css("display", "block");
                                            $('#lblMessage').html("Giá bán không được để trống.");
                                            flag = false;
                                        }
                                        else {
                                            $('#lblMessage').html("");
                                            $('#lblMessage').css("display", "none");
                                            if (isNumber.test($("#txtPrice").val()) == false) {
                                                $('#lblMessage').css("display", "block");
                                                $('#lblMessage').html("Giá bán chỉ được nhập số");
                                                flag = false;
                                            }
                                            else {
                                                $('#lblMessage').html("");
                                                $('#lblMessage').css("display", "none");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    ///*Check ID Search*/
    //if ($("#txtSearchID").val().length == 0) {
    //    $('#lblMessage').css("display", "block");
    //    $('#lblMessage').html("Bạn vui lòng nhập vào ID.");
    //    flag = false;
    //}
    //else {
    //    $('#lblMessage').html("");
    //    $('#lblMessage').css("display", "none");
    //    if (isNumber.test($("#txtName").val()) == false) {
    //        $('#lblMessage').css("display", "block");
    //        $('#lblMessage').html("ID chỉ được nhập số.");
    //        flag = false;
    //    }
    //    else {
    //        $('#lblMessage').html("");
    //        $('#lblMessage').css("display", "none");

    //    }
    //}
    return flag;
}