 // Read Blog 

$('#PostListPage').live('pageshow', function (event) {
getPostList();
});

function getPostList() {
    $.getJSON('/api/posts', function (data) {
        $('#postList li').remove();
        $.each(data, function (index, post) {
            $('#postList').append("<li><a href='" + "/Home/ReadPost?id=" + post.ID + "'>" + post.PostTitle + "</a></li>");
        });
        $('#postList').listview('refresh');
    });
}


// Read Post

$('#ReadPostPage').live('pageshow', function (event) {
    var id = getUrlVars()["id"];
    getPost(id);
});

function getPost(id) {
    var url = "/api/posts?id=" + id;
    $.getJSON(url, function (data) {
        $('#postDisplay').html("<h2>" + data.PostTitle + "</h2>" +
        "<p>" + data.PostContent + '</p><p><strong>' +
        new Date(data.PublishDate).toDateString() + "</strong></p>");
    });
}

function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

// Create Post

$('#CreatePostPage').live('pageshow', function (event) {
    $("form").submit(function () {
        $.ajax({
            url: "/api/posts",
            type: "post",
            data: $(this).serialize(),
            success: onSuccess,
            error: onError
        });
        return false;
    });

    $("#cancel").click(function () {
        resetTextFields();
    });
});


function onSuccess(data, status) {
    $.mobile.changePage('/Home/Read');
}

function onError(jqXHR, exception) {
    resetValidationMessages();
    if (jqXHR.status == 400) {
        var data = JSON.parse(jqXHR.responseText);
        if (data['post.PostTitle'] != null) {
            $("#PostTitleValidationMessage").fadeIn(2000);
            $("#PostTitleValidationMessage").css("color", "#ff0000");
            $("#PostTitleValidationMessage").text(data['post.PostTitle'][0]);
        }
        if (data['post.PostContent'] != null) {
            $("#PostContentValidationMessage").fadeIn(2000);
            $("#PostContentValidationMessage").css("color", "#ff0000");
            $("#PostContentValidationMessage").text(data['post.PostContent'][0]);
        }
        // note: can't refer to data.post.PostTitle - looks for 'data.post', which doesn't exist
    }
    else {
        var message = "Unknown error";
        $("#notification").fadeIn(2000);
        $("#notification").css("background-color", "#ff0000");
        $("#notification").text(message);
        $("#notification").fadeOut(1000);
    }
}

function resetTextFields() {
    $("#Title").val("");
    $("#Content").val("");
}

function resetValidationMessages() {
    $("#PostTitleValidationMessage").text("");
    $("#PostContentValidationMessage").text("");
}

