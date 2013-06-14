$(document).ready( function() {
    
    $("#show-details-link").click(function () {
        $(".details-link").toggle();
        $("#intro-text").animate({ marginTop: "50px" }, {
            duration: 400, complete: function () {
                $("#more-details").slideDown();
            }
        }); 
    });
    $("#hide-details-link").click(function () {
        $(".details-link").toggle();
        $("#more-details").slideUp(400, function () {
            $("#intro-text").animate({ marginTop: "200px" });
        });
    });
});