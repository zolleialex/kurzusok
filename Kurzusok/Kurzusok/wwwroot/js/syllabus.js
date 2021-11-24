const PlaceHolderElement = $('#PlaceHolderHere');//GET fĂĽggvĂ©nyek meghĂ­vĂˇsa
$('button[data-toggle="subject-modal"]').click(function (event) {
    var url = $(this).data('url');
    var id = $(this).data('id');
    $.get(url, { id: id }).done(function (data) {
        PlaceHolderElement.html(data);
        if (url == "/Syllabus/CreateSubjectToSyllabus") {
            PlaceHolderElement.find('.syllabussubjectmodal').modal('show');
        }
        else if (url == "/Syllabus/EditSubjectSyllabus") {
            PlaceHolderElement.find('.editsubjectsyllabusmodal').modal('show');
        } else if (url == "/Syllabus/CreateSyllabus") {
            PlaceHolderElement.find('.createsyllabusmodal').modal('show');
        }

    })
})

$('button[data-toggle="delete-syllabus"]').click(function (event) {
    var url = $(this).data('url');
    var id = $(this).data('id');
    $.get(url, { id: id }).done(function (response) {
        if (response.isvalid) { 
            
                window.location.href = "/Syllabus/" + response.programmeid;
            

        } else {
            $('#errorAlert').show();
            $('#errormessage').html(response.responseText);
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
                    if (response.createdsyllabus) {
                        window.location.href = "/Syllabus/" + response.programmeid;
                    } else {
                        PlaceHolderElement.find('.subjectmodal').modal('hide');// Jelenlegi Modal eltĂĽntetĂ©se                    
                        location.reload();
                    }
                   
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


$('a[data-toggle="subject-delete-modal"]').click(function (event) {
    let id = $(this).data('id');
    let route = "/Syllabus/SubjectDeleteSyllabus/" + id;
    $('#sdel').attr("href", route)
    $('#applySubjectDelete').modal('show');
})