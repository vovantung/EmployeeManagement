var user = {
    init: function () {
        user.registerEvent();
    },
    registerEvent: function () {
       
        $(".email-address").on("change", function (e) {
            e.preventDefault();
            var mail = $(this)
            var mailVal = mail.val();
            var atpos = mailVal.indexOf('@');
            var dotpos = mailVal.lastIndexOf('.');
   
            if (mailVal == "") {
                /*alert("Please provide your email!");*/
                mail.closest(".form-control-static").addClass("show");
                mail.focus();
                return;
            } else {

                if (atpos < 1 || (dotpos - atpos < 2)) {
                    /*alert("Please enter correct email");*/
                    mail.closest(".form-control-static").addClass("show");
                    mail.focus();
                    return;
                }
                else {
                    mail.closest(".form-control-static").removeClass("show");
                }
                return;
            }
        });
    }
}
user.init();