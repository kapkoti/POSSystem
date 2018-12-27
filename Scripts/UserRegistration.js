//Function for getting the Data Based upon Employee ID
function getbyID(id) {
    debugger;
    //$('#Name').css('border-color', 'lightgrey');
    //$('#Age').css('border-color', 'lightgrey');
    //$('#State').css('border-color', 'lightgrey');
    //$('#Country').css('border-color', 'lightgrey');
 
    $.ajax({

        url: "/UserRegistration/GetbyIDcon/" + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            //$('#id').val(result.EmployeeID);

            alert(result);
           
            $('#txt_name').val(result.Name);
            $('#txt_phone').val(result.phone);
            $('#txt_email').val(result.email);
            $('#txt_username').val(result.user_name);

          $('#modal-default').modal('show');
            //$('#btnUpdate').show();
            //$('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    debugger;
    return false;
}

//function for updating employee's record

//function Update() {
//    debugger;
//    var res = validate();
//    if (res == false) {
//        return false;
//    }
//    var empObj = {
//        EmployeeID: $('#EmployeeID').val(),
//        Name: $('#Name').val(),
//        Age: $('#Age').val(),
//        State: $('#State').val(),
//        Country: $('#Country').val(),
//    };
//    $.ajax({
//        url: "/Home/Update",
//        data: JSON.stringify(empObj),
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            loadData();
//            $('#myModal').modal('hide');
//            $('#EmployeeID').val("");
//            $('#Name').val("");
//            $('#Age').val("");
//            $('#State').val("");
//            $('#Country').val("");
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}