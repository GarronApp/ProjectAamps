function Sales() {

    var instance = this;
    instance.save_Reservation_Url = "/Sales/SaveReservedReservation";
    instance.save_Individual_Url = "/Sales/SaveIndividual";
    instance.getAgentDetails_Url = "/Sales/GetAgentSaleDetails";

    this.load = function()
    {
        var nowTemp = new Date();
        var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate(), 0, 0, 0, 0);

        $('.datepicker').datepicker({
            format: 'dd/mm/yyyy',
            endDate: '+0d',
            autoclose: true,
            onRender: function (date) {
                return date.valueOf() > now.valueOf() ? 'disabled' : '';
            }
        }).on('changeDate', function (e) {
            $(this).datepicker('hide');
        });

        $('#accordion .panel-collapse').on('shown', function () {
            $(this).prev().find(".glyphicon").removeClass("glyphicon-chevron-right").addClass("glyphicon-chevron-down");
        });

        $('#divPanelReserved').click(function () {
            $(this).find('i').toggleClass('fa-plus-circle fa-minus-circle').animate()
        });

        $('#divPanelPending').click(function () {
            $(this).find('i').toggleClass('fa-plus-circle fa-minus-circle');
        });

        $('#divPanelSold').click(function () {
            $(this).find('i').toggleClass('fa-plus-circle fa-minus-circle');
        });


        $("#txtReservationDate").datepicker("setValue", new Date());

        $("#txtReservationDate").on('changeDate', function (ev) {
            var reservationDate = document.getElementById('txtReservationDate').value;
            var convertedReservationDate = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
            var tempDate = moment(convertedReservationDate, 'DD/MM/YYYY').add('days', 2).format('DD/MM/YYYY');
            $("#txtExpiryDate").datepicker("setValue", tempDate);
        });

        var reservationDate = document.getElementById('txtReservationDate').value;
        var convertedReservationDate = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
        var tempDate = moment(convertedReservationDate, 'DD/MM/YYYY').add('days', 2).format('DD/MM/YYYY');
        $("#txtExpiryDate").datepicker("setValue", tempDate);


        $('#checkReservationTimeExtention').change(function () {
            $("#selectTimeExtention").prop("disabled", !$(this).is(':checked'));
        });

        $('#checkPurchaserContractSigned').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtPurchaserContractSignedDate").prop("disabled",true);
                $("#txtPurchaserContractSignedDate").val("");
            }
            else {
                $("#txtPurchaserContractSignedDate").prop("disabled",false);
                $("#txtPurchaserContractSignedDate").datepicker("setValue", new Date());
            }
            //$("#txtPurchaserContractSignedDate").prop("disabled", !$(this).is(':checked'));
            //$("#txtPurchaserContractSignedDate").val("", !$(this).is(':checked'));
        });

        $('#checkSellerContractSigned ').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtSellerContractSignedDate").prop("disabled", true);
                $("#txtSellerContractSignedDate").val("");
            }
            else {
                $("#txtSellerContractSignedDate").prop("disabled", false);
                $("#txtSellerContractSignedDate").datepicker("setValue", new Date());
            }
        });

        $('#checkDepositPaid').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtDepositPaidDate").prop("disabled", true);
                $("#txtDepositPaidDate").val("");
            }
            else {
                $("#txtDepositPaidDate").prop("disabled", false);
                $("#txtDepositPaidDate").datepicker("setValue", new Date());
            }
        });

        $('#checkProofDepositPaidDate').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtDepositPaidProofDate").prop("disabled",true);
                $("#txtDepositPaidProofDate").val("");
            }
            else {
                $("#txtDepositPaidProofDate").prop("disabled", false);
                $("#txtDepositPaidProofDate").datepicker("setValue", new Date());
            }
        });

        $('#checkBondRequired').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtBondRequiredDate").prop("disabled", true);
                $("#txtBondRequiredDate").val("");
            }
            else {
                $("#txtBondRequiredDate").prop("disabled", false);
                $("#txtBondRequiredDate").datepicker("setValue", new Date());
            }
        });

        $('#checkGranted').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtGranted").prop("disabled", true);
                $("#txtGranted").val("");
            }
            else {
                $("#txtGranted").prop("disabled", false);
                $("#txtGranted").datepicker("setValue", new Date());
            }
        });

        $('#checkClientAccepted').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtClientAccepted").prop("disabled", true);
                $("#txtClientAccepted").val("");
            }
            else {
                $("#txtClientAccepted").prop("disabled", false);
                $("#txtClientAccepted").datepicker("setValue", new Date());
            }
        });

        $(document).on('change', '.btn-file :file', function () {
            var input = $(this),
                numFiles = input.get(0).files ? input.get(0).files.length : 1,
                label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
            input.trigger('fileselect', [numFiles, label]);
        });


        $('#selectTimeExtention').on('change', function () {

            var selectedReservationTimeExtention = this.value;

            var reservationDate = document.getElementById('txtExpiryDate').value;
            var convertedReservationDate = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
            var tempDate = moment(convertedReservationDate, 'DD/MM/YYYY').add('days', selectedReservationTimeExtention).format('DD/MM/YYYY');
            var reservationExpiryDate = tempDate;
            $("#txtExtentionDate").datepicker("setValue", reservationExpiryDate);

        });


        $('.btn-file :file').on('fileselect', function (event, numFiles, label) {
            console.log(numFiles);
            console.log(label);
        });

        $('#txtReservationDate').on('change', function () {
            var reservationDate = document.getElementById('txtReservationDate').value;
            var convertedReservationDate = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
            var tempDate = moment(convertedReservationDate, 'DD/MM/YYYY').add('days', 2).format('DD/MM/YYYY');
            $("#txtExpiryDate").datepicker("setValue", tempDate);
        });


        $('#selectDayExtention').on('change', function () {

            var tempSelectedDayExtention = null;
            var selectedDayExtention = this.value;

            var currentExtentionDate = document.getElementById('txtExpiryDate').value;
            var convertedReservationDate = moment(currentExtentionDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
            var tempDate = moment(convertedReservationDate, 'DD/MM/YYYY').add('days', selectedDayExtention).format('DD/MM/YYYY');
            var extentedExpiryDate = tempDate;
            $("#txtExtentionDate").datepicker("setValue", extentedExpiryDate);

        });

        $("#btnUpdateReservation").click(function () {

            instance.UpdateReservationDetails();
        });

        $("#btnReservedUpdatePersonDetails").click(function () {

            instance.UpdateReservedPersonDetails();
        });



        $("#btnPendingUpdatePersonDetails").click(function () {

            instance.UpdatePendingPersonDetails();
        });


        $.ajax({
            url: instance.getAgentDetails_Url,
            type: 'GET',
            datatype: 'json',
            data: {},
            success: function (data) {
                console.log(data);
                $("#lblUnitPhase").html(data.UnitPhase);
                $("#lblUnitPrice").html("R " + data.UnitPrice);
                $("#lblUnitNumber").html(data.UnitNumber);
                $("#lblUnitSize").html(data.UnitSize);
                $("#lblUnitFloor").html(data.UnitFloor);
                $("#lblDevName").html(data.Development);
                $("#txtReservationLapses").val(data.ReservationDate);
                $('#txtSignedDate').val(data.DateSignedBySeller);

                $('#txtFirstNameReserved').val(data.IndividualFirstName);
                $('#txtLastNameReserved').val(data.IndividualLastName);
                $('#txtCellNumberReserved').val(data.IndividualCellNo);
                $('#txtWorkNumberReserved').val(data.IndividualWorkNo);
                $('#txtEmailReserved').val(data.IndividualEmailAddress);
                $('#txtFirstNamePending').val(data.IndividualFirstName);
                $('#txtLastNamePending').val(data.IndividualLastName);
                $('#txtCellNumberPending').val(data.IndividualCellNo);
                $('#txtWorkNumberPending').val(data.IndividualWorkNo);
                $('#txtEmailPending').val(data.IndividualEmailAddress);


                


            },
            error: function (data) {
                console.log(data);
            }
        });
    }


    //this.getURLParameter(name) = function () {
    //    return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search) || [, ""])[1].replace(/\+/g, '%20')) || null
    //}
    this.UpdateReservationDetails = function () {

        var formData = $("#SaleReservedForm").serialize();

        $.ajax({
            url: instance.save_Reservation_Url,
            type: "POST",
            data: formData,
            success: function (data) {

                toastr.success('Reservation has been updated');

                $("#txtReservationDate").val(data.SaleReservationDt);
                $("#txtExpiryDate").val(data.SaleReservationExpiryDt);
                $("#txtExtentionDate").val(data.SaleReservationExtentionDt);
            },
            error: function (exception) {
                console.log(exception);
            }

        });
    }

    this.UpdateReservation = function () {

        var formData = $("#").serialize();

        $.ajax({
            url: instance.save_Individual_Url,
            type: "POST",
            data: formData,
            success: function (data) {

                toastr.success('Individual has been saved');

                $('#individualFormReserved').trigger("reset");
                $('#individualFormReserved')[0].reset();

                $("#txtFirstNameReserved").val(data.IndividualName);
                $("#txtLastNameReserved").val(data.IndividualSurname);
                $("#txtCellNumberReserved").val(data.IndividualContactCell);
                $("#txtWorkNumberReserved").val(data.IndividualContactWork);
                $("#txtEmailReserved").val(data.IndividualEmail);

                $("#txtFirstNamePending").val(data.IndividualName);
                $("#txtLastNamePending").val(data.IndividualSurname);
                $("#txtCellNumberPending").val(data.IndividualContactCell);
                $("#txtWorkNumberPending").val(data.IndividualContactWork);
                $("#txtEmailPending").val(data.IndividualEmail);

            },
            error: function (exception) {
                console.log(exception);
            }

        });
    }

    this.UpdateReservedPersonDetails = function () {
        
        var formData = $("#individualFormReserved").serialize();

        $.ajax({
            url: instance.save_Individual_Url,
            type: "POST",
            data: formData,
            success: function (data) {

                toastr.success('Individual has been saved');

                $('#individualFormReserved').trigger("reset");
                $('#individualFormReserved')[0].reset();

                $("#txtFirstNameReserved").val(data.IndividualName);
                $("#txtLastNameReserved").val(data.IndividualSurname);
                $("#txtCellNumberReserved").val(data.IndividualContactCell);
                $("#txtWorkNumberReserved").val(data.IndividualContactWork);
                $("#txtEmailReserved").val(data.IndividualEmail);

                $("#txtFirstNamePending").val(data.IndividualName);
                $("#txtLastNamePending").val(data.IndividualSurname);
                $("#txtCellNumberPending").val(data.IndividualContactCell);
                $("#txtWorkNumberPending").val(data.IndividualContactWork);
                $("#txtEmailPending").val(data.IndividualEmail);

            },
            error: function (exception) {
                console.log(exception);
            }

        });
    }

    this.UpdatePendingPersonDetails = function () {

        var person = $("#individualFormPending").serialize();
        $.ajax({
            url: instance.save_Individual_Url,
            type: "POST",
            data: person,
            async: true,
            cache: false,
            success: function (data) {

                toastr.success('Individual has been saved');

                $('#individualFormPending').trigger("reset");
                $('#individualFormPending')[0].reset();

                $("#txtFirstNamePending").val(data.IndividualName);
                $("#txtLastNamePending").val(data.IndividualSurname);
                $("#txtCellNumberPending").val(data.IndividualContactCell);
                $("#txtWorkNumberPending").val(data.IndividualContactWork);
                $("#txtEmailPending").val(data.IndividualEmail);

                $("#txtFirstNameReserved").val(data.IndividualName);
                $("#txtLastNameReserved").val(data.IndividualSurname);
                $("#txtCellNumberReserved").val(data.IndividualContactCell);
                $("#txtWorkNumberReserved").val(data.IndividualContactWork);
                $("#txtEmailReserved").val(data.IndividualEmail);

            },
            error: function (exception) {
                console.log(exception);
            }

        });
    }

};




