/*$(function () {
    $('[data-toggle="tooltip"]').tooltip();
    $('[data-toggle="popover"]').popover({
        placement: 'bottom',
        content: function () {
            return $("#notification-content").html();
        },
        html: true
    });

    $('body').append(`<div id="notification-content" class="hide"></div>`)

    function getNotification() {
        $.ajax({
            url: "https://localhost:7036/Notification/GetUserNotifications",
            method: "GET",
            success: function (result) {
                $("#notificationCount").html(result);
                console.log(result);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
    getNotification();
});
*/
