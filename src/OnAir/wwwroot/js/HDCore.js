function TimcodeToMiliseconds(Timecode) {
    var timeArray = Timecode.split(":");
    if (timeArray.length < 3) return 0;
    var hours = parseInt(timeArray[0]);
    var minutes = parseInt(timeArray[1]) * 60;
    var seconds = parseInt(timeArray[2]);
    var totalTime = hours + minutes + seconds;
    return 1000 * totalTime;
}
function MilisecondsToTimeCode(milisecs) {
    var totalSec = milisecs / 1000;
    var hours = Math.floor(totalSec / 3600);
    var minutes = Math.floor((totalSec - (hours * 3600)) / 60);
    var seconds = totalSec - (hours * 3600) - (minutes * 60);
    var strHours = "" + hours;
    var strMinutes = "" + minutes;
    var strSeconds = "" + seconds;
    if (hours < 10)
        strHours = "0" + strHours;

    if (minutes < 10)
        strMinutes = "0" + strMinutes;

    if (seconds < 10)
        strSeconds = "0" + strSeconds;


    return strHours + ":" + strMinutes + ":" + strSeconds;
}