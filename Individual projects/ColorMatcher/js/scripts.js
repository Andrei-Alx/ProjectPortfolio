if ("serviceWorker" in navigator) {
    navigator.serviceWorker
        .register("service-worker.js")
        .then(function (registering) {
            console.log(
                "Browser: Service Worker registration is successful with the scope",
                registering.scope
            );
        })
        .catch(function (error) {
            console.log(
                "Browser: Service Worker registration failed with the error",
                error
            );
        });
} else {
    console.log("Browser: I don't support Service Workers :(");
}


document.getElementById('saveColor').addEventListener('click', function() {
    const colorPicker = document.getElementById('colorPicker')
    const savedColor = document.getElementById('savedColor');

    localStorage.setItem('savedColor', colorPicker.value);


    savedColor.style.backgroundColor = colorPicker.value;
});

function hexToRgb(hex) {
    var result = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(hex);
    return result ? {
        r: parseInt(result[1], 16),
        g: parseInt(result[2], 16),
        b: parseInt(result[3], 16)
    } : null;
}
