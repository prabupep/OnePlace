
var ngApp = angular.module('oneplace', []);

$(document).ready(function () {

    $(function () {
        $('a').each(function () {
            if ($(this).prop('href') == window.location.href) {
                $(this).addClass('active'); $(this).parents('li').addClass('active');
            }
        });
    });


    $(function () {
        $('#datetimepicker1').datetimepicker();
        $('#datetimepicker2').datetimepicker();
        $('#datetimepicker3').datetimepicker();
        $('#datetimepicker4').datetimepicker();
        $('#datetimepicker5').datetimepicker();
        
    });
});