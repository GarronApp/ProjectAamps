(function Exceptions() {
    $(document).ajaxError(function (event, jqxhr, settings, exception) {
        if (jqxhr.status == 403) {
            console.log(jqxhr);
            toastr.error("You do not have permissions to perform this action");
            $(".progress").addClass("hide");
            if (console.Forbidden) {
                window.location.href = data.newurl;
            }
        }
    });
}());