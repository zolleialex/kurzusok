// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const PlaceHolderElement = $('#PlaceHolderHere');//GET fĂĽggvĂ©nyek meghĂ­vĂˇsa
var SubmitValue = "asd";
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
        else if (url == "/Home/EditCourse") {
            PlaceHolderElement.find('.editcoursemodal').modal('show');
        }
        else {
            PlaceHolderElement.find('.coursemodal').modal('show');

        }
    })
})
PlaceHolderElement.on('click', '[data-dismiss="modal"]', function (event) {// Oldal ĂşjratĂ¶ltĂ©se 
    location.reload();
})

function copyDivContent() { //div mĂˇsolĂˇsa formhoz
    var $el = $('.copyThisDiv:first').clone();
    $('#toCopy').append($el);
}

function addTeacherSelect() { //div mĂˇsolĂˇsa formhoz
    var $el = $('.TeacherClass:first').clone();
    $('#moreTeacher').append($el);
}
PlaceHolderElement.on('click', "#save", function (event) {
    SubmitValue = "save";
})
PlaceHolderElement.on('click', "#saveandnext", function (event) {
    SubmitValue = "saveandnext";
})

PlaceHolderElement.on('click', 'button[id="hidedivbutton"]', function (event) {//FormbĂłl eltĂˇvolĂ­tĂˇs
    event.preventDefault();
    var copydivCount = $("div[class*='copyThisDiv']").length;
    if (copydivCount > 1) { // KivĂ©ve ha mĂˇr csak egy van, hĂĽlyebiztosĂ­tĂˇs
        var _t = $(this);
        _t.parents('.copyThisDiv').remove();
    }

})



ajaxpostBasic = form => {// Form PostolĂˇsa
    try {
        $('#errorAlert').hide();
        $('#errorLoad').hide();
        let formdata = new FormData(form);
        let sumLoads = 0;
        for (var value of formdata.entries()) {
            if (value[0] == "LoadList") {
                sumLoads = sumLoads + parseInt(value[1]);                
            }
        }
        let difference = 100 - sumLoads;
        if (difference != 0) {            
            $('#errorLoad').show();
            $('#errorLoadmessage').html("A tanárok össz terhelése nem 100%!");
        } else {

            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (response) {
                    if (response.isvalid) {// Ha a sikeresen vĂ©ghezment minden                
                        PlaceHolderElement.find('.subjectmodal').modal('hide');// Jelenlegi Modal eltĂĽntetĂ©se
                        if (response.createCourse || SubmitValue == "saveandnext") { // Ăšj kurzus felvĂ©telre irĂˇnyĂ­tĂˇs
                            $.get("/Home/CreateCourse", { id: response.subjectid }).done(function (data) {
                                PlaceHolderElement.find('.coursemodal').modal('hide');
                                PlaceHolderElement.html(data);
                                PlaceHolderElement.find('.coursemodal').modal('show');
                            })
                        } else {// Vagy az oldal frissĂ­tĂ©se
                            // location.reload();
                        }
                    } else {
                        $('#errorAlert').show();
                        $('#errormessage').html(response.responseText);
                    }
                }
            })
        }
    } catch (e) {
        $('#errorAlert').show();
        $('#errormessage').html('Valami hiba történt a kérés feldolgozása közben!');
        console.log(e);
    }
    //A default event megelĹ‘zĂ©se miatt
    return false;
}

window.addEventListener("load", function () {// TĂˇblĂˇzat nĂ©zet megtartĂˇsa Local Storage-val.
    if (screen.width > 1500 || $(window).width() > 1500) {
        let checkBox = document.getElementById("tableView");
        let chtblId = localStorage.getItem("tableViewStore");
        if (chtblId === null) {
            chtblId = "1";
            localStorage.setItem("tableViewStore", chtblId);
        }
        else {
            if (chtblId == "0") {
                checkBox.checked = true;
            }
            else {
                checkBox.checked = false;
                keepCollapse();
            }
            changeTable();
        }
    }
    else {
        keepCollapse();
    }
})

window.addEventListener("resize", function () {
    if (screen.width < 1500 || $(window).width() < 1500) {
        let checkBox = document.getElementById("tableView");
        checkBox.checked = false;
        changeTable();
    }

})

function keepCollapse() {
    let collaps = JSON.parse(localStorage.getItem("collapsedTable"));
    if (collaps != null) {
        for (let i of collaps) {
            let oneCollapse = document.getElementById(i);
            oneCollapse.classList.add("show");
            oneCollapse.previousElementSibling.firstElementChild.lastElementChild.firstElementChild.classList.remove("fa-chevron-down");
            oneCollapse.previousElementSibling.firstElementChild.lastElementChild.firstElementChild.classList.add("fa-chevron-up");
            if (collapsedTables.includes(i) == false) {
                collapsedTables.push(i);
            }
        }
    }
}

function changeTable() {
    let checkBox = document.getElementById("tableView");
    if (checkBox.checked == true) {

        localStorage.setItem("tableViewStore", "0");
        document.getElementById("excelTable").style.display = "block";
        document.getElementById("dropdownTable").style.display = "none";
        document.getElementById("opencloseButtons").style.display = "none";
    } else {
        localStorage.setItem("tableViewStore", "1");
        document.getElementById("dropdownTable").style.display = "block";
        document.getElementById("excelTable").style.display = "none";
        document.getElementById("opencloseButtons").style.display = "inline-flex";
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
$('a[data-toggle="add-comment-modal"]').click(function (event) {
    let id = $(this).data('id');
    $('#courseId').attr("value", id)
    $('#applyComment').modal('show');
})


$(".collapse").on('show.bs.collapse', function (e) {
    e.target.previousElementSibling.firstElementChild.lastElementChild.firstElementChild.classList.remove("fa-chevron-down");
    e.target.previousElementSibling.firstElementChild.lastElementChild.firstElementChild.classList.add("fa-chevron-up");
    collapsedTables.push(e.target.id);

    localStorage.setItem("collapsedTable", JSON.stringify(collapsedTables));
});

$(".collapse").on('hide.bs.collapse', function (e) {
    e.target.previousElementSibling.firstElementChild.lastElementChild.firstElementChild.classList.remove("fa-chevron-up");
    e.target.previousElementSibling.firstElementChild.lastElementChild.firstElementChild.classList.add("fa-chevron-down");
    collapsedTables.splice(collapsedTables.indexOf(e.target.id), 1);
    localStorage.setItem("collapsedTable", JSON.stringify(collapsedTables));
});

//Prevent collapse on button clicks
$('.no-collapsable').on('click', function (e) {
    e.stopPropagation();
});

//Új félév megnyitásakor a collapse localStorage törlése
function clearCollapse() {
    localStorage.removeItem("collapsedTable");
}

$('#allopen').on('click', function () {
    let tables = document.getElementsByClassName('allcollapse');
    console.log(tables.length);
    for (let i of tables) {
        console.log(i.id);
        $(i).collapse('show');
    }
});
$('#allclose').on('click', function () {
    let tables = document.getElementsByClassName('allcollapse');
    console.log(tables.length);
    for (let i of tables) {
        console.log(i.id);
        $(i).collapse('hide');
    }
});