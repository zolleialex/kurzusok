// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const PlaceHolderElement = $('#PlaceHolderHere');
$('button[data-toggle="subject-modal"]').click(function (event) {
    var url = $(this).data('url');
    var id = $(this).data('id');
    console.log(url);
    $.get(url, { id: id }).done(function (data) {
        PlaceHolderElement.html(data);
        console.log(url);
        if (url=="/Home/CreateSubject") {
            PlaceHolderElement.find('.subjectmodal').modal('show');
        }
        else {
            PlaceHolderElement.find('.coursemodal').modal('show');

        }
    })
})
PlaceHolderElement.on('click', '[data-dismiss="modal"]', function (event) {
    location.reload();
})

function addTeacherSelect() {
    console.log("ELJUTOTTUNK A TANÁR HOZZÁADÁSÁIG");
    var $el = $('.TeacherClass:first').clone();
    $('#moreTeacher').append($el);
    
}
ajaxpostBasic = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (response) {
                console.log(response.isvalid)
                if (response.isvalid) {// Ha a válasz visszajött helyesen meghívjuk a kurzus getet
                    
                    PlaceHolderElement.find('.subjectmodal').modal('hide');
                    $.get("Home/CreateCourse", { id: response.subjectid }).done(function (data) {
                        PlaceHolderElement.html(data);
                        console.log("Eljutott 2");
                        PlaceHolderElement.find('.coursemodal').modal('show');
                    })
                } else {
                    alert("rosszak");
                }                
            },
            error: function (err) {
                consol.log(err);
            }
        })
    } catch (e) {
        console.log(e);
    }
    //A default event megelőzése miatt
    return false;
}
