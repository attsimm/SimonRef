function StartLoadingScreen() {
    $("#wrapper-loader").fadeIn();
}
function EndLoadingScreen() {
    $("#wrapper-loader").fadeOut();
}
function ChangeIDGlobal(id) {
    var hidden = document.getElementById('idchosen');
    hidden.value = id;
    ChangePage({ url: 'defunt.html', transition: 'slide-in' });
}
function ChangePage(options) {
    if (options.url == "index.html") {
        $("#navbar").css("display", "none");
    }
    else {
        $("#navbar").css("display", "block");
    }
    PUSH(options);
}
function ChangePageQuickIn(url) {
    ChangePage({ url: url, transition: 'slide-in' });
}
function ChangePageQuickOut(url) {
    ChangePage({ url: url, transition: 'slide-out' });
}
function CheckImage(image) {
    if (image == "http://salonbergeron.com/images/dyn-fiches/.jpg") {
        return "http://placehold.it/200x200/FF4136/333/&text=Oups";
    }
    else {
        return image;
    }
}
function QueryString(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}
//Return the month in letter in French
function GetMonth(month) {
    console.log(month)
    var monthString = '';
    switch (month) {
        case '1':
            monthString = 'janvier';
            break;
        case '2':
            monthString = 'f&eacute;vrier';
            break;
        case '3':
            monthString = 'mars';
            break;
        case '4':
            monthString = 'avril';
            break;
        case '5':
            monthString = 'mai';
            break;
        case '6':
            monthString = 'juin';
            break;
        case '7':
            monthString = 'juillet';
            break;
        case '8':
            monthString = 'ao&ucirc;t';
            break;
        case '9':
            monthString = 'septembre';
            break;
        case '10':
            monthString = 'octobre';
            break;
        case '11':
            monthString = 'novembre';
            break;
        case '12':
            monthString = 'd&eacute;cembre';
            break;
        default:
            monthString = 'Non d&eacute;fini';
            break;
    }
    console.log(monthString);
    return monthString;
}
function GetMonthEN(month) {
    var monthString = '';
    switch (month) {
        case '1':
            monthString = 'January';
            break;
        case '2':
            monthString = 'February';
            break;
        case '3':
            monthString = 'March';
            break;
        case '4':
            monthString = 'April';
            break;
        case '5':
            monthstring = 'May';
            break;
        case '6':
            monthString = 'June';
            break;
        case '7':
            monthString = 'July';
            break;
        case '8':
            monthString = 'August';
            break;
        case '9':
            monthString = 'September';
            break;
        case '10':
            monthString = 'October';
            break;
        case '11':
            monthString = 'November';
            break;
        case '12':
            monthString = 'December';
            break;
        default:
            monthString = 'not define';
            break;
    }
    return monthString;
}
