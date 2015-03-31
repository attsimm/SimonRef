//Set the main frame of the application
function GetMainFrame() {
    $.ajax({
        beforeSend: function () { StartLoadingScreen(); },
        complete: function () { EndLoadingScreen(); },
        type: "POST",
        url: "http://dev.publi-web.net/ApplicationMobile/Bergeron.asmx/Get30Deces",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var deces = response.d;
            var output = '';
            $.each(deces, function (index, data) {
                output += MainFrameSlide(data);
                var hidden = document.getElementById('idlast');
                hidden.value = data.Id;
            });
            $('#mainframe').append(output).append($('.load-more'));
        }
    });
}
function MainFrameSlide(data) {
    return '<li class=\"table-view-cell media\" onclick="ChangeIDGlobal(' + data.Id + ')"><a class="navigate-right" href="#"><img class="decesphoto media-object pull-left" src="' + CheckImage(data.Photo) + '" alt="' + data.LastName + '"><div class="media-body media-body-deces">' + data.FirstName + ' ' + data.LastName + '<p>' + data.Date + '</p></div></a></li>';
}
function GetMoreOnTheMainFrame() {
    $.ajax({
        beforeSend: function () { StartLoadingScreen(); },
        complete: function () { EndLoadingScreen(); },
        type: "POST",
        url: "http://dev.publi-web.net/ApplicationMobile/Bergeron.asmx/Get30MoreDeces",
        data: "{id:" + document.getElementById('idlast').value + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var deces = response.d;
            var output = '';
            $.each(deces, function (index, data) {
                output += MainFrameSlide(data);
                document.getElementById('idlast').value = data.Id;
            });
            $loadMore = $('.load-more');
            $('#mainframe').append(output);
            $('#mainframe').append($loadMore);
        }
    });
}
function SearchOnTheMainFrame(search) {
    $.ajax({
        beforeSend: function () { StartLoadingScreen(); },
        complete: function () { EndLoadingScreen(); },
        type: "POST",
        url: "http://dev.publi-web.net/ApplicationMobile/Bergeron.asmx/GetSpecificDeces",
        data: "{search:'" + search + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var deces = response.d;
            var output = '';
            $('#mainframe').empty();
            $.each(deces, function (index, data) {
                output += MainFrameSlide(data);
                document.getElementById('idchosen').value = data.Id;
            });
            $loadMore = $('.load-more');
            $('#mainframe').append(output);
            $('#mainframe').append($loadMore);
        }
    });
}
function CInfo(id) {
    $.ajax({
        beforeSend: function () { StartLoadingScreen(); },
        complete: function () { EndLoadingScreen(); },
        type: "POST",
        url: "http://dev.publi-web.net/ApplicationMobile/Bergeron.asmx/Get1Deces",
        data: "{id:" + id + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var deces = response.d;
            var output = '';
            $.each(deces, function (index, data) {
                console.log(data);
                document.getElementById("dead_name").innerHTML = data.FirstName + " " + data.LastName;
                document.getElementById("dead_name_current").value = data.FirstName + " " + data.LastName;
                document.getElementById("dead_name2").innerHTML = data.FirstName + " " + data.LastName;
                document.getElementById("dead_date").innerHTML = data.Date;
                document.getElementById("dead_desc").innerHTML = data.Detail.replace(/\n/g, "<br />");
                document.getElementById("dead_img").src = data.Photo;
            });
        }
    });
}
function ExpoInfo(id) {
    $.ajax({
        type: "POST",
        url: "http://dev.publi-web.net/ApplicationMobile/Bergeron.asmx/GetExpo",
        data: "{id:" + id + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var deces = response.d;
            var output = '';
            $.each(deces, function (index, expo) {
                var n = expo.Date_Exposition.split("/", 3);
                var n2 = n[2].split(" ", 1);
                output += '<li class="table-view-cell media"><a class="navigate-right" onclick="GoToExpo(' + expo.Id + ')"><span class="media-object pull-left icon fa fa-calendar"></span><div class="media-body"><strong>' + n[1] + ' ' + GetMonth(n[0]) + ' ' + n2[0] + '</strong><br /><strong>' + expo.Location + '</strong><br /><b>' + expo.Type + '</b></div></a></li>';
            });
            if (output === '') {
                $('#expoframe').append("<li class=\"table-view-cell media\">Aucune exposition n'est prévue.</li>");
            }
            else {
                $('#expoframe').append(output);
            }
        }
    });
}
function GoToExpo(id) {
    var hiddenLocation = document.getElementById('hiddenLocation');
    var hiddenType = document.getElementById('hiddenType');
    var hiddenDate = document.getElementById('hiddenDate');
    var hiddenBegin = document.getElementById('hiddenBegin');
    var hiddenEnd = document.getElementById('hiddenEnd');
    var hiddenAddress = document.getElementById('hiddenAddress');
    $.ajax({
        type: "POST",
        url: "http://dev.publi-web.net/ApplicationMobile/Bergeron.asmx/GetExpo",
        data: "{id:" + id + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.each(response.d, function (index, expo) {
                if (expo.Id == id) {
                    hiddenLocation.value = expo.Location;
                    hiddenType.value = expo.Type;
                    hiddenDate.value = expo.Date_Exposition;
                    hiddenBegin.value = expo.Begin;
                    hiddenEnd.value = expo.End;
                    hiddenAddress.value = expo.Address.split(' ').join('+');
                }
            });
        }
    });
    ChangePageQuickIn("expomenu.html");
}

function RInfo(id) {
    $.ajax({
        type: "POST",
        url: "http://dev.publi-web.net/ApplicationMobile/Bergeron.asmx/GetRegistry",
        data: "{id:" + id + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var output = '';
            $.each(response.d, function (index, data) {
                output += '<div class=\"registry\"><b>' + data.Name + '</b><p>' + data.Message + '</p><hr /></div>';
            });
            if (output === '') {
                $('#registry_frame').append("Aucun message pour le moment.");
            }
            else {
                $('#registry_frame').append(output);
            }
        }
    });
}