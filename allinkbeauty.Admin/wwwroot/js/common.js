$(function () {
    datePicker();
})


function datePicker() {

    flatpickr(".datepicker", {
        locale: "ko",
        dateFormat: "Y-m-d"
    });

    //$('.datepicker').datepicker({ //클래스로 datepicker 적용
    //    startDt: new Date('2022'),
    //    calendarWeeks: false,
    //    todayHighlight: true,
    //    autoclose: true,
    //    format: "yyyy-mm-dd",
    //    language: "ko"

    //});

}

function showLoading() { $('#loading-overlay').show(); }
function hideLoading() { $('#loading-overlay').hide(); }