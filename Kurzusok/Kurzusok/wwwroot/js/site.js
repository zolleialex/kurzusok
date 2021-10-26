// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


    var PlaceHolderElement = $('#PlaceHolderHere');
    $('button[data-toggle="subject-modal"]').click(function (event) {
        var url = $(this).data('url');
        var id = $(this).data('id');
        $.get(url, {id: id}).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.subjectmodal').modal('show');
        })
    })
    PlaceHolderElement.on('click', '[data-toggle="course-modal"]', function (event) {        
        console.log(url);
        var url = $(this).data('url');
        var id = 11;
        PlaceHolderElement.find('.subjectmodal').modal('hide');
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.coursemodal').modal('show');
        })
    })
    

ajaxpost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function () {
                PlaceHolderElement.find('.subjectmodal').modal('hide');               
                $.get("Home/CreateCourse").done(function (data) {
                    PlaceHolderElement.html(data);
                    console.log("Eljutott 2");
                    PlaceHolderElement.find('.coursemodal').modal('show');
                })                
            },
            error: function (err) {
                consol.log(err);
            }
        })
    } catch (e) {
        console.log(e);
    }



    //to prevent def sub event

    return false;
}