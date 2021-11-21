const PlaceHolderElement = $('#PlaceHolderHere');//GET fĂĽggvĂ©nyek meghĂ­vĂˇsa
$('button[data-toggle="subject-modal"]').click(function (event) {
    var url = $(this).data('url');
    var id = $(this).data('id');
    $.get(url, { id: id }).done(function (data) {
        PlaceHolderElement.html(data);
        if (url == "/Syllabus/CreateSubjectToSyllabus") {
            PlaceHolderElement.find('.syllabussubjectmodal').modal('show');
        }
        else if (url == "/Syllabus/EditSubject") {
            PlaceHolderElement.find('.editsyllabussubjectmodal').modal('show');
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
                   // PlaceHolderElement.find('.subjectmodal').modal('hide');// Jelenlegi Modal eltĂĽntetĂ©se                    
                   // location.reload();
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
    //A default event megelĹ‘zĂ©se miatt
    return false;
}