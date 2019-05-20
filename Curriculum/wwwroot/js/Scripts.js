$(function () {
    $(".editObj").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("/Objectives/Edit?Id=" + id, function () {
            $("#modal").modal();
        })
    })
});
$(function () {
    $(".deleteObj").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("/Objectives/Delete?Id=" + id, function () {
            $("#modal").modal();
        })
    })
});

$(function () {
    $(".editAcad").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("/Academics/Edit?Id=" + id, function () {
            $("#modal").modal();
        })
    })
});
$(function () {
    $(".deleteAcad").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("/Academics/Delete?Id=" + id, function () {
            $("#modal").modal();
        })
    })
});

$(function () {
    $(".editExp").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("/ProfessionalExps/Edit?Id=" + id, function () {
            $("#modal").modal();
        })
    })
});
$(function () {
    $(".deleteExp").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("/ProfessionalExps/Delete?Id=" + id, function () {
            $("#modal").modal();
        })
    })
});

$(function () {
    $(".editLang").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("/Languages/Edit?Id=" + id, function () {
            $("#modal").modal();
        })
    })
});
$(function () {
    $(".deleteLang").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("/Languages/Delete?Id=" + id, function () {
            $("#modal").modal();
        })
    })
});

$(function () {
    $(".editPers").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("/PersonalData/Edit?Id=" + id, function () {
            $("#modal").modal();
        })
    })
});
$(function () {
    $(".deletePers").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("/PersonalData/Delete?Id=" + id, function () {
            $("#modal").modal();
        })
    })
});

$(function () {
    $(".editResu").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("/Resumes/Edit?Id=" + id, function () {
            $("#modal").modal();
        })
    })
});
$(function () {
    $(".deleteResu").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("/Resumes/Delete?Id=" + id, function () {
            $("#modal").modal();
        })
    })
});

$(function () {
    $(".editExtra").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("/ExtraActivities/Edit?Id=" + id, function () {
            $("#modal").modal();
        })
    })
});
$(function () {
    $(".deleteExtra").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("/ExtraActivities/Delete?Id=" + id, function () {
            $("#modal").modal();
        })
    })
});