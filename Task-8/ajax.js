function sendAjaxRequest(data) {
    const xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            const resultContainer = document.getElementById('result');
            resultContainer.innerHTML = xhr.responseText;
        }
    };
}