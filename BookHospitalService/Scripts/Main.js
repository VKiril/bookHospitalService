$(function () {
    function init() {
        $("select#select-patient-interval").prop('disabled', 'disabled');
    }

    init();

    $("form#doctor-create-form").on("submit", function(e) {
        //e.preventDefault();
        var form = $(this).serialize();
    });

    $("#select-patient-procedure").on("change",
        function(e) {
            $("#select-patient-interval").get(0).selectedIndex = 0;
            $("#select-patient-doctor").get(0).selectedIndex = 0;
            $("#Date").val("");
            $("select#select-patient-interval").prop('disabled', 'disabled');

            let id = $(this).val();
            $("#Procedure").val(id);

            $.ajax({
                type: "GET",
                url: GET_DOCTORS_BY_PROCEDURE + "?procedure=" + id,
                success: function (data) {
                    if (data.length !== 0) {
                        let content = '<option value="0" class="form-control">Select Doctor</option>';
                        for (i = 0; i < data.length; i++) {
                            content = content +
                                '<option value="' +
                                data[i].Id +
                                '">' +
                                data[i].Category +
                                '</option>';
                        }
                        $("#select-patient-doctor").html(content);
                    }
                }
            });
        });

    $("#select-patient-doctor").on("change",
        function () {
            $("#select-patient-interval").get(0).selectedIndex = 0;
            $("#Date").val("");
            $("select#select-patient-interval").prop('disabled', 'disabled');

            let val = $(this).val();
            $("#Doctor").val(val);
        });

    $(".create-patient #Date").on("change", function(e) {
        $("select#select-patient-interval").prop('disabled', false);

        let createdAt = $(this).val();
        $("#patient-create-date").val(createdAt);

        let procedure = $("#select-patient-procedure").val();
        let doctor = $("#select-patient-doctor").val();
        let URL = GET_AVAILABILITY_INTERVAL +
            "?procedure=" +
            procedure +
            "&doctor=" +
            doctor +
            "&createdAt=" +
            createdAt;

        $.ajax({
            type: "GET",
            url: URL,
            success: function (data) {
                if (data.length !== 0) {
                    let content = '<option value="0">Select Interval</option>';
                    for (i = 0; i < data.length; i++) {

                        if (data[i].IsAvailable) {
                            content = content +
                                '<option value="' +
                                data[i].Id +
                                '">' +
                                data[i].Interval +
                                '</option>';
                        } else {
                            content = content +
                                '<option class="bg-warning" value="' +
                                data[i].Id +
                                '" disabled="disabled">' +
                                data[i].Interval +
                                ' (reserved)</option>';
                        }
                    }
                    $("#select-patient-interval").html(content);
                }
            }
        });
    });

    $("#select-patient-interval").on("change",
        function (e) {
            let val = $(this).val();
            $("#Interval").val(val);
        });
});