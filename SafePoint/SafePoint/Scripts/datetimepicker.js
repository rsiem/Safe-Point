var today = new Date();
var date = today.getDate() + 1;
var month = today.getMonth();
var year = today.getFullYear();

var dayNames = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
    if (dayNames[today.getDay()] == 'Saturday') {
        date += 1;
    }
var startDate = new Date(year, month, date, 9, 0);

$(".date").datetimepicker({
    format: "dd-mm-yyyy hh:ii",
    autoclose: true,
    //todayBtn: true,
    daysOfWeekDisabled: '0',
    todayHighlight: true,
    startDate: startDate,
    minView: 1,
    minuteStep: 30,
    pickerPosition: "bottom-left"
});

var monthNames = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']
$("#datetime").on("change paste keyup", function () {

    var datetime = $("#datetime").val();
    if (datetime != null) {
        var datePicked = datetime.split(' ')[0];
        var timePicked = datetime.split(' ')[1];
        var date = datePicked.split('-')[0];
        var month = datePicked.split('-')[1];
        var year = datePicked.split('-')[2];
        var hour = timePicked.split(':')[0];
        var mins = timePicked.split(':')[1];
        var datetimePicked = new Date(year, month - 1, date, hour, mins);
        var day = datetimePicked.getDay();
        var txt = "<p>Selected appointment time :</p><p>";
        var button = "</p><p><button id=\"continue\" class=\"btn btn-default\">Continue</button></p>";
        $("#afterpick").html(txt + dayNames[day] + ", " + date + " " + monthNames[datetimePicked.getMonth()] + " " + year + " @ " + timePicked + button);

        var id = '@ViewBag.userid';
        var userid = $("#uid").val();
        var hospid;
        var hospname;
        $("#hospitals").each(function () {
            hospid = $(".hospid", this).text().trim();
            hospname = $(".hospname", this).text().trim();
        });

        var url = "/Reservations/Create?date=" + datePicked + "T" + timePicked + "?hospid=" + hospid + "?hospname=" + hospname;
        $("#continue").click(function () {
            $(location).attr('href', url);
        });
    }
});
