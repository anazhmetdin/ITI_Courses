function getCookies(cookieName) {
    var cookies = document.cookie.split(';');

    for (var cookie of cookies) {
        cookie = cookie.split('=');
        if (cookie[0].trim() === cookieName) {
            return cookie[1];
        }
    }

    return undefined;
}

function setCookie(cookieName, cookieValue, expiryDate) {
    if (!!expiryDate) {
        document.cookie = `${cookieName}=${cookieValue};expires=${expiryDate};SameSite=Lax`;
    } else {
        document.cookie = `${cookieName}=${cookieValue};SameSite=Lax`;
    }
}

function allCookieList() {
    var cookies = document.cookie.split(';');
    var result = [];

    for (var cookie of cookies) {
        cookie = cookie.split('=');
        result[cookie[0].trim() ] = cookie[1];
    }

    return result;
}

function hasCookie(cookieName) {
    var cookies = document.cookie.split(';');

    for (var cookie of cookies) {
        cookie = cookie.split('=');
        if (cookie[0].trim() === cookieName) {
            return true;
        }
    }

    return false;
}