// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const PlaceHolderElement = $('#PlaceHolderHere');//GET függvények meghívása
$('button[data-toggle="subject-modal"]').click(function (event) {
    var url = $(this).data('url');
    var id = $(this).data('id');
    $.get(url, { id: id }).done(function (data) {
        PlaceHolderElement.html(data);
        if (url == "/Home/CreateSubject") {
            PlaceHolderElement.find('.subjectmodal').modal('show');
        }
        else if (url == "/Home/EditSubject") {
            PlaceHolderElement.find('.editsubjectmodal').modal('show');

        }
        else {
            PlaceHolderElement.find('.coursemodal').modal('show');

        }
    })
})

PlaceHolderElement.on('click', '[data-dismiss="modal"]', function (event) {// Oldal újratöltése 
    location.reload();
})

function copyDivContent() { //div másolása formhoz
    var $el = $('.copyThisDiv:first').clone();
    $('#toCopy').append($el);
}

function addTeacherSelect() { //div másolása formhoz
    var $el = $('.TeacherClass:first').clone();
    $('#moreTeacher').append($el);
}


PlaceHolderElement.on('click', 'button[id="hidedivbutton"]', function (event) {//Formból eltávolítás
    event.preventDefault();
    console.log("Történik valami");
    var copydivCount = $("div[class*='copyThisDiv']").length;
    if (copydivCount > 1) { // Kivéve ha már csak egy van, hülyebiztosítás
        var _t = $(this);
        _t.parents('.copyThisDiv').remove();
    }

})



ajaxpostBasic = form => {// Form Postolása
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.isvalid) {// Ha a sikeresen véghezment minden
                    PlaceHolderElement.find('.subjectmodal').modal('hide');// Jelenlegi Modal eltüntetése
                    if (response.createCourse) { // Új kurzus felvételre irányítás
                        $.get("Home/CreateCourse", { id: response.subjectid }).done(function (data) {
                            PlaceHolderElement.html(data);
                            PlaceHolderElement.find('.coursemodal').modal('show');
                        })
                    } else {// Vagy az oldal frissítése
                        location.reload();
                    }
                } else {
                    $('#errorAlert').show();
                    alert("Rossz adatok");
                }
            },
            error: function (err) {
                $('#errorAlert').show();
                consol.log(err);
            }
        })
    } catch (e) {
        $('#errorAlert').show();
        console.log(e);
    }
    //A default event megelőzése miatt
    return false;
}
var timeout = null;
function delay() {
    timeout = setTimeout(closeBar, 1000);
}
function openBar() {
    clearTimeout(timeout);
    document.getElementById("SideBar").style.width = "200px";
    document.getElementById("SideBar").style.padding = "20px";
    document.getElementById("main").style.paddingLeft = "230px";
    document.getElementById("opened").style.display = "inline";
    document.getElementById("closed").style.display = "none";
}
function closeBar() {
    $('.dropdown-toggle').dropdown('hide');
    document.getElementById("SideBar").style.width = "60px";
    document.getElementById("SideBar").style.padding = "20px 0 0 0";
    document.getElementById("main").style.paddingLeft = "90px";
    document.getElementById("opened").style.display = "none";
    document.getElementById("closed").style.display = "inline";
}


window.addEventListener("load", function () {// Táblázat nézet megtartása Local Storage-val.
    let checkBox = document.getElementById("tableView");
    let chtblId = localStorage.getItem("tableViewStore");
    console.log(checkBox.id);
    if (chtblId === null) {
        chtblId = "1";
        localStorage.setItem("tableViewStore", chtblId);
    }
    if (chtblId == "0") {
        checkBox.checked = true;
    }
    else {
        checkBox.checked = false;
    }
    changeTable();
})


function changeTable() {
    let checkBox = document.getElementById("tableView");
    if (checkBox.checked == true) {

        localStorage.setItem("tableViewStore", "0");
        document.getElementById("excelTable").style.display = "block";
        document.getElementById("dropdownTable").style.display = "none";
    } else {
        localStorage.setItem("tableViewStore", "1");
        document.getElementById("dropdownTable").style.display = "block";
        document.getElementById("excelTable").style.display = "none";
    }
}

$('a[data-toggle="subject-delete-modal"]').click(function (event) {
    let id = $(this).data('id');
    let route = "/Home/SubjectDelete/" + id;
    $('#sdel').attr("href", route)
    $('#applySubjectDelete').modal('show');
})

$('a[data-toggle="course-delete-modal"]').click(function (event) {
    let id = $(this).data('id');
    let route = "/Home/CourseDelete/" + id;
    $('#cdel').attr("href", route)
    $('#applyCourseDelete').modal('show');
})

$(".collapse").on('show.bs.collapse', function (e) {
    e.target.previousElementSibling.firstElementChild.lastElementChild.firstElementChild.classList.remove("fa-chevron-down");
    e.target.previousElementSibling.firstElementChild.lastElementChild.firstElementChild.classList.add("fa-chevron-up");
});
$(".collapse").on('hide.bs.collapse', function (e) {
    e.target.previousElementSibling.firstElementChild.lastElementChild.firstElementChild.classList.remove("fa-chevron-up");
    e.target.previousElementSibling.firstElementChild.lastElementChild.firstElementChild.classList.add("fa-chevron-down");
});