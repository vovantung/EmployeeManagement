var user = {
    init: function () {
        user.registerEvent();
    },
    registerEvent: function () {
        $(".employee-delete").off("click").on("click", function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data("id");
            $.ajax({
                url: "/Employee/Delete",
                data: { employeeId: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response)
                    if (response.result == true) {
                        btn.closest(".row-delete").remove();
                        alert("Delete successful!");
                    } else {
                        alert("Delete failed!");
                    }
                }
            });
        });
    }
}
user.init();