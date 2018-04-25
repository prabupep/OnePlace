ngApp.controller('releasecalendarCTRL', function ($scope, $http) {

    var promise = $http.get(apiUrls.Releases.ReleaseCalendar)
    promise.then(function (data) {
        var value = data.data;
        $('#calendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay,listWeek'
            },
            //defaultDate: '2018-04-25',
            navLinks: true, // can click day/week names to navigate views
            editable: true,
            eventLimit: true, // allow "more" link when too many events
            events: value
        });
    });


});

$(document).ready(function () {
   

})

