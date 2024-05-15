// ==UserScript==
// @name         Measure Zoom Updated
// @namespace    http://tampermonkey.net/
// @version      2024-04-18
// @description  try to take over the world!
// @author       You
// @match        https://localhost:7125/home
// @icon         https://www.google.com/s2/favicons?sz=64&domain=stackoverflow.com
// @grant        none
// @require      https://raw.githubusercontent.com/eligrey/FileSaver.js/master/dist/FileSaver.js
// ==/UserScript==

var zoomBtn;
var resetBtn;

window.onload = (event) => {
    saveDataToTxt();
    return;

    if(localStorage.getItem("dataArray")) {
        localStorage.removeItem("dataArray");
    }

    setTimeout(() => { // Make sure all elements have loaded before starting
        zoomBtn = document.getElementById("zoom-upd-button");
        resetBtn = document.getElementById("reset-upd-button");

        var counter = 0;
        var i = setInterval(function(){ // Run the measurement X times, for one layout
            measureZoom();

            counter++;
            if(counter === 1000) { // Set run-times
                clearInterval(i);
                setTimeout(() => {
                    saveDataToTxt();
                }, 200)
            }
        }, 1000); //Give each process 1sec to finish before starting the next one (this MUST be longer than execution time!)
    }, 2000);
};

function measureZoom() {
    zoomBtn.click();
    setTimeout(() => {
        resetBtn.click();
    }, 500);
}

function saveDataToTxt() {
    // Write data to local textfile
    var array = JSON.parse(localStorage.getItem('dataArray'));

    var data = JSON.stringify(array, null, "\t");
    var blob = new Blob([data], {type: "text/plain;charset=utf-8"});
    saveAs(blob, "zoom-upd-data.txt");
}
