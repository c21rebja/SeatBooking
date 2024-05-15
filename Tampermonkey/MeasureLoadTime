// ==UserScript==
// @name         Measure Load Time
// @namespace    http://tampermonkey.net/
// @version      2024-04-18
// @description  try to take over the world!
// @author       You
// @match        https://localhost:7125/home
// @icon         https://www.google.com/s2/favicons?sz=64&domain=stackoverflow.com
// @grant        none
// @require      https://raw.githubusercontent.com/eligrey/FileSaver.js/master/dist/FileSaver.js
// ==/UserScript==

var counter = 0;
var runTimes = 1000;

window.onload = (event) => {
    console.log("load");

    if(localStorage.getItem("counter")) {
        counter = localStorage.getItem("counter");
    }
    counter++;
    localStorage.setItem("counter", counter);
    console.log("counter: " + counter);

    if(counter >= runTimes) {
        setTimeout(() => {
            saveDataToTxt();
            console.log("saving");
        }, 2000)
    } else {
        setTimeout(() => {
            location.reload(true); // Needed to have "true" to overwrite cache
        }, 1500);
    }
}

function saveDataToTxt() {
    // Write data to local textfile
    var array = JSON.parse(localStorage.getItem('dataArray'));

    var data = JSON.stringify(array, null, "\t");
    var blob = new Blob([data], {type: "text/plain;charset=utf-8"});
    saveAs(blob, "load-data.txt");

    // Reset for next run
    localStorage.removeItem('dataArray');
    localStorage.setItem("counter", 0);
}
