const PlaceHolderElement = $('#PlaceHolderHere');//GET függvények meghí­vása
$('button[data-toggle="add-teacher-modal"]').click(function (event) {
    var url = $(this).data('url');
    $.get(url).done(function (data) {
        PlaceHolderElement.html(data);
        if (url == "/Teachers/AddTeacher") {
            PlaceHolderElement.find('.addteachermodal').modal('show');
        }
    })
})
$('button[data-toggle="edit-teacher-modal"]').click(function (event) {
    var url = $(this).data('url');
    var id = $(this).data('id');
    $.get(url, { id: id }).done(function (data) {
        PlaceHolderElement.html(data);
        if (url == "/Teachers/EditTeacher") {
            PlaceHolderElement.find('.editteachermodal').modal('show');
        }
        else if (url == "/Teachers/TeacherLeft") {
            PlaceHolderElement.find('.teacherleftmodal').modal('show');
        }

    })
})


ajaxpostBasic = form => {// Form PostolĂˇsa
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.isvalid) {// Ha a sikeresen vĂ©ghezment minden  
                    PlaceHolderElement.find('.addteachermodal').modal('hide');
                    PlaceHolderElement.find('.editteachermodal').modal('hide');
                    PlaceHolderElement.find('.teacherleftmodal').modal('hide');
                    location.reload();
                } else {
                    $('#errorAlert').show();
                    $('#errormessage').html(response.responseText);
                }
            }
        })
    } catch (e) {
        $('#errorAlert').show();
        $('#errormessage').html('Valami hiba történt a kérés feldolgozása közben!');
        console.log(e);
    }
    return false;
}
