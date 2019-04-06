$.extend({
    toast: function (obj) {
        if ($("#toast-div").length) return;
        $("body").append('<div id="toast-div" class="bottomright"><div id="toast-content" class="innerToast">' + obj.title + '</div></div>');
        $("#toast-div").fadeIn(1000);
        setTimeout(function () {
            $("#toast-div").fadeOut(1000);
        }, 2000);
        setTimeout(function () {
            $("#toast-div").remove();
        }, 2000 + 1000);
    }
});