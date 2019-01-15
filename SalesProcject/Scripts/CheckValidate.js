
//Hàm check sự kiện thêm//
function checkValidateAdd() {
    
    var flag = true;

   
          

    var regex1 = /([^\s])/;
    if (regex1.test($("#user_cdp").val()) == false) {
        $('#user_cdperr').css("display", "block");
        flag = false;

    } else {
        $('#user_cdperr').css("display", "none");
        $('#user_cdp').css("border-color", "");


        if ($("#user_cdp").val().length != 8) {
            $('#user_cdperr1').css("display", "block");
            flag = false;

        } else {
            $('#user_cdperr1').css("display", "none");
            $('#user_cdp').css("border-color", "");

            //var regex9 = /[!@#$ %^&* (),.?":{}|<>]/;
            //if (regex9.test($("#user_cdp").val()) == false) {
            //    $('#user_cdperr2').css("display", "block");
            //    flag = false;

            //} else {
            //    $('#user_cdperr2').css("display", "none");
            //}
        
        }
    }

    var regex2 = /([^\s])/;
    if (regex2.test($("#user_namep").val()) == false) {
        $('#user_nameperr').css("display", "block");
        flag = false;

    } else {
        $('#user_nameperr').css("display", "none");
        if ($("#user_namep").val().length < 5 || $("#user_namep").val().length > 15) {
            $("#user_nameperr1").css("display", "block");
            flag = false;
        } else {
            $('#user_nameperr1').css("display", "none");
        }
    }

    var regex4 = /([^\s])/;
    if (regex4.test($("#pass_wordp").val()) == false) {
        $('#pass_wordperr').css("display", "block");
        flag = false;

    } else {
        $('#pass_wordperr').css("display", "none");
        if ($("#pass_wordp").val().length < 8 || $("#pass_wordp").val().length > 15) {
            $("#pass_wordperr1").css("display", "block");
            flag = false;
        }
        else {
            $("#pass_wordperr1").css("display", "none");
        
        }
    }
    var regex6= /([^\s])/;
    if (regex6.test($("#namep").val()) == false) {
        $('#nameperr').css("display", "block");
        flag = false;

    } else {
        $('#nameperr').css("display", "none");
        $('#namep').css("border-color", "");

    }
    var regex7 = /^\d+$/;
    if (regex7.test($("#mobilep").val()) == false) {
        $('#mobileperr').css("display", "block");
        flag = false;

    } else {
        $('#mobileperr').css("display", "none");
        if ($("#mobilep").val().length < 10 || $("#mobilep").val().length > 15) {
            $("#mobileperr1").css("display", "block");
            flag = false;
        }
        else {
            $("#mobileperr1").css("display", "none");
        }

          
    }

    
    var regex8 = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (regex8.test($("#emailp").val()) == false) {
        $('#emailperr').css("display", "block");
        flag = false;

    } else {
        $('#emailperr').css("display", "none");
        $('#emailp').css("border-color", "");
    }
    return flag;
    
}





//Hàm check sự kiện sửa//
function checkValidateUpdate() {
    var flag = true;


    //var regex5 = /([^\s])/;
    //if (regex5.test($("#pass_wordp").val()) == false) {
    //    $('#pass_wordperr').css("display", "block");
        
    //    flag = false;

    //} else {
    //    $('#pass_wordperr').css("display", "none");
    //    $('#pass_wordp').css("border-color", "");
    //}

    
    //var regex6 = /([^\s]){8,15}/;
    //if (regex6.test($("#pass_wordp").val()) == false) {
    //    $('#pass_wordperr1').css("display", "block");
        
    //    flag = false;

    //} else {
    //    $('#pass_wordperr1').css("display", "none");
    //    $('#pass_wordp').css("border-color", "");
    //}

    var regex6 = /([^\s])/;
    if (regex6.test($("#pass_wordp").val()) == false) {
        $('#pass_wordperr').css("display", "block");
        flag = false;

    } else {
        $('#pass_wordperr').css("display", "none");
        if ($("#pass_wordp").val().length < 8 || $("#pass_wordp").val().length > 15) {
            $("#pass_wordperr1").css("display", "block");
            flag = false;
        }
        else {
            $("#pass_wordperr1").css("display", "none");

        }
    }
    
    var regex7 = /([^\s])/;
    if (regex7.test($("#namep").val()) == false) {
        $('#nameperr').css("display", "block");
        
        flag = false;

    } else {
        $('#nameperr').css("display", "none");
        $('#namep').css("border-color", "");
    }

    
    var regex8 = /^\d+$/;
    if (regex8.test($("#mobilep").val()) == false) {
        $('#mobileperr').css("display", "block");
        flag = false;

    } else {
        $('#mobileperr').css("display", "none");
        if ($("#mobilep").val().length < 10 || $("#mobilep").val().length > 15) {
            $("#mobileperr1").css("display", "block");
            flag = false;
        }
        else {
            $("#mobileperr1").css("display", "none");
        }
    }

    
    var regex10 = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (regex10.test($("#emailp").val()) == false) {
        $('#emailperr').css("display", "block");
        
        flag = false;

    } else {
        $('#emailperr').css("display", "none");
        $('#emailp').css("border-color", "");
    }
    return flag;
}



//function ckeckValidate() {
//    var flag = true;
//    var regex0 = /^[a-zA-Z0-9]{1,15}$/;
//    if (regex0.test($('#vehicleNo').val()) == false) {
//        $('#errVehicleNo').css("display", "block");
//        $('#vehicleNo').css("border-color", "red");
//        flag = false;

//    } else {
//        $('#errVehicleNo').css("display", "none");
//        $('#vehicleNo').css("border-color", "");

//    }

//    var regex1 = /^[a-zA-Z0-9]{1,14}$/;
//    if (regex1.test($('#vehicleType :selected').val()) == false) {
//        $('#errVehicleType').css("display", "block");
//        $('#vehicleType').css("border-color", "red");
//        flag = false;

//    } else {
//        $('#errVehicleType').css("display", "none");
//        $('#vehicleType').css("border-color", "");
//    }

//    var regex2 = /^[a-zA-Z0-9]{1,2}$/;

//    if (regex2.test($('#territoryCd :selected').val()) == false) {
//        $('#errTerritoryCd').css("display", "block");
//        $('#territoryCd').css("border-color", "red");
//        flag = false;

//    } else {
//        $('#errTerritoryCd').css("display", "none");
//        $('#territoryCd').css("border-color", "");

//    }

//    var regex3 = /^[a-zA-Z0-9]{1,30}$/;

//    if (regex3.test($('#ownerCompanyName :selected').val()) == false) {
//        $('#errOwnerCompanyName').css("display", "block");
//        $('#ownerCompanyName').css("border-color", "red");
//        flag = false;

//    } else {
//        $('#errOwnerCompanyName').css("display", "none");
//        $('#ownerCompanyName').css("border-color", "");

//    }

//    return flag;
//}