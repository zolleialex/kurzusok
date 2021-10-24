// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        var id = $(this).data('id');
        $.get(url, {id: id}).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })
    //PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
    //    var form = $(this).parents('.modal').find('form');
    //    var actionUrl = form.attr('action');
    //    var sendData = form.serialize();
    //    console.log(actionUrl);
    //    console.log(sendData);
    //    $.post(actionUrl, sendData).done(function (data) {
    //        PlaceHolderElement.find('.modal').modal('hide');
    //    })
    //})
})