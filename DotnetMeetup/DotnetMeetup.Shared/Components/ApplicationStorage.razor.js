export function saveToSession(key, value) {
    try {
        window.sessionStorage.setItem(key, value);
    }
    catch (err) {
        console.error(err);
    }
}

export function clearSession() {
    window.sessionStorage.clear();
}

export function getFromSession(key) {
    try {

        return window.sessionStorage.getItem(key);
    }
    catch (err) {
        console.error(err);
    }
}

export function removeFromSession(key) {
    window.sessionStorage.removeItem(key);
}


