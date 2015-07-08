function ButtonOnClickEvent(event, args) {

    var page = window,
        browser = page.navigator.appCodeName,
        isMozilla = false;

    if (browser == 'Mozilla') {
        isMozilla = true;
    }

    if (isMozilla) {
        alert('Yes, its Mozzila');
    } else {
        alert('No, go download Firefox !');
    }
}