function Bonds() {

    var instance = this;
    instance.save_Reservation_Url = "/Sales/SaveAvailableReservation";
    instance.save_BondsOrginator_Url = "/Bonds/SaveUpdateOrginator";
    instance.save_SaleBondsDetails_Url = "/Bonds/SaveSalesBondDetails";
    instance.save_ReservedSale_Url = "/Sales/UpdateReservedSale"
    instance.save_Individual_Url = "/Sales/SaveIndividual";
    instance.getBondDetails_Url = "/Bonds/GetDetails";
    instance.getOrginatorDetails_Url = "/Bonds/LoadData/";
    instance.getBanks_Url = "/Bonds/GetBanks";
    instance.getMOStatus_Url = "/Bonds/GetMOStatus";


    this.load = function () {

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


        $('#checkClientContacted').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtSalesBondClientContactedDt").prop("disabled", true);
                $("#txtSalesBondClientContactedDt").val("");
            }
            else {
                $("#txtSalesBondClientContactedDt").prop("disabled", false);
                var dateToday = new Date();
                var convertDateToday = moment(dateToday, 'DD/MM/YYYY').format('DD/MM/YYYY');
                $("#txtSalesBondClientContactedDt").datepicker("setValue", convertDateToday);
            }
        });

        $('#checkDocumentsRec').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtSalesBondBondDocsRecDt").prop("disabled", true);
                $("#txtSalesBondBondDocsRecDt").val("");
            }
            else {
                $("#txtSalesBondBondDocsRecDt").prop("disabled", false);
                var dateToday = new Date();
                var convertDateToday = moment(dateToday, 'DD/MM/YYYY').format('DD/MM/YYYY');
                $("#txtSalesBondBondDocsRecDt").datepicker("setValue", convertDateToday);
            }
        });

        $("#btnUpdateSalesBondDetails").click(function () {
            instance.UpdateSalesBondDetails();
        });

        var numericInputControls = new Array("txtOriginatorTrBondAmount");

        instance.initializeNumericInputValues(numericInputControls)

        instance.LoadBanks();
        instance.LoadMOStatus();

        $.ajax({
            url: instance.getBondDetails_Url,
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
                $('#txtSaleReservedPanelStatus').val(data.CurrentSalesStatus);

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

    this.showModalUpdateOriginator = function (id) {
        console.log(id);
        instance.loadOrginator(id);
        $('#showModalUpdateOriginator').modal('show');
    };

    this.GetBanks = function (data) {
        $("#selectBankName option").remove();
        $.each(data, function (index, item) {
            $("#selectBankName").append('<option value=' + index + '>' + item + '</option>');

        });
    }

    this.GetMOStatus = function (data) {
        $("#selectMOStatus option").remove();
        $.each(data, function (index, item) {
            $("#selectMOStatus").append('<option value=' + index + '>' + item + '</option>');
        });
    }

    this.setSelectControlValue = function (controlId, data) {
        var select = document.getElementById(controlId);
        for (var i = 0; i < select.options.length; i++) {
            if (select.options[i].text === data) {
                select.selectedIndex = i;
                break;
            }
        }
    }

    this.setDatePickerDefaultDate = function(controlId)
    {
        var dateToday = new Date();
        var convertDateToday = moment(dateToday, 'DD/MM/YYYY').format('DD/MM/YYYY');
        $("#" + controlId).datepicker("setValue", convertDateToday);
    }

    this.MapBondDefaults = function(data)
    {
        instance.setSelectControlValue("selectBankName", data.BankName);
        instance.setSelectControlValue("selectMOStatus", data.MOStatus);
        $('#OriginatorTrID').val(data.OriginatorTrID);
        $('#txtOriginatorTrBondAmount').val(data.OriginatorTrBondAmount);
        $('#txtOriginatorTrIntRate').val(data.OriginatorTrIntRate);
       

    }

    this.MapOrginatorDetails = function(data)
    {
        console.log(data);
        if (data.MOStatus == "Submitted")
        {
            instance.MapBondDefaults(data);
            instance.ConvertCurrentDate(data.OriginatorTrSubmittedDt, "OriginatorTrSubmittedDt");
            instance.setDatePickerDefaultDate("OriginatorTrAIPDt");
            $("#selectBankName").prop('disabled', true);
            $("#OriginatorTrSubmittedDt").prop('disabled', true);
            $("#OriginatorTrGrantDt").prop('disabled', true);
            $("#OriginatorTrAcceptDt").prop('disabled', true);
        }

        if (data.MOStatus == "Approve In Principal") {
            instance.MapBondDefaults(data);
            instance.ConvertCurrentDate(data.OriginatorTrSubmittedDt, "OriginatorTrSubmittedDt");
            instance.ConvertCurrentDate(data.OriginatorTrAIPDt, "OriginatorTrAIPDt");
            instance.setDatePickerDefaultDate("OriginatorTrGrantDt");
            $("#selectBankName").prop('disabled', true);
            $("#OriginatorTrSubmittedDt").prop('disabled', true);
            $("#OriginatorTrAIPDt").prop('disabled', true);
            $("#OriginatorTrAcceptDt").prop('disabled', true);
        }

        if (data.MOStatus == "Granted") {
            instance.MapBondDefaults(data);
            instance.ConvertCurrentDate(data.OriginatorTrSubmittedDt, "OriginatorTrSubmittedDt");
            instance.ConvertCurrentDate(data.OriginatorTrAIPDt, "OriginatorTrAIPDt");
            instance.ConvertCurrentDate(data.OriginatorTrGrantDt, "OriginatorTrGrantDt");
            instance.setDatePickerDefaultDate("OriginatorTrAcceptDt");
            $("#selectBankName").prop('disabled', true);
            $("#OriginatorTrSubmittedDt").prop('disabled', true);
            $("#OriginatorTrAIPDt").prop('disabled', true);
            $("#OriginatorTrGrantDt").prop('disabled', true);
        }

        if (data.MOStatus == "Client Accepted") {
            instance.MapBondDefaults(data);
            instance.ConvertCurrentDate(data.OriginatorTrSubmittedDt, "OriginatorTrSubmittedDt");
            instance.ConvertCurrentDate(data.OriginatorTrAIPDt, "OriginatorTrAIPDt");
            instance.ConvertCurrentDate(data.OriginatorTrGrantDt, "OriginatorTrGrantDt");
            instance.ConvertCurrentDate(data.OriginatorTrAcceptDt, "OriginatorTrAcceptDt");
            $("#selectBankName").prop('disabled', true);
            $("#OriginatorTrSubmittedDt").prop('disabled', true);
            $("#OriginatorTrAIPDt").prop('disabled', true);
            $("#OriginatorTrGrantDt").prop('disabled', true);
            $("#OriginatorTrAcceptDt").prop('disabled', true);
        }

    }

    this.LoadCurrentDates = function ()
    {
        $("#OriginatorTrSubmittedDt").datepicker("setValue", new Date());
        $("#OriginatorTrAIPDt").datepicker("setValue", new Date());
        $("#OriginatorTrGrantDt").datepicker("setValue", new Date());
        $("#OriginatorTrAcceptDt").datepicker("setValue", new Date());
    }

    this.UpdateSalesBondDetails = function () {

        var formData = $("#UpdateSalesBondDetailsFrom").serialize();
        $.ajax({
            url: instance.save_SaleBondsDetails_Url,
            type: "POST",
            data: formData,
            success: function (data) {
                toastr.success('Sales details updated successfully');
            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }

    this.SaveUpdateOrginator = function () {

        $("#selectBankName").prop('disabled', false);
        $("#OriginatorTrSubmittedDt").prop('disabled', false);
        $("#OriginatorTrAIPDt").prop('disabled', false);
        $("#OriginatorTrGrantDt").prop('disabled', false);
        $("#OriginatorTrAcceptDt").prop('disabled', false);

        var formData = $("#OriginatorDetailsForm").serialize();
        $.ajax({
            url: instance.save_BondsOrginator_Url,
            type: "POST",
            data: formData,
            success: function (data) {
                toastr.success('Orginator has been updated');
                window.location.reload(true);
            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }

    this.ConvertCurrentDate = function (currentDate, control) {
        var convertedCurrentDate = moment(currentDate, 'DD-MM-YYYY').format('DD/MM/YYYY');
        $("#" + control).datepicker("setValue", convertedCurrentDate);
    }

    this.initializeNumericInputValues = function (controls) {
        for (var i = 0; i < controls.length; i++) {
            $("#" + controls[i]).attr("data-a-sign", "R ");
            $("#" + controls[i]).autoNumeric('init', { vMax: '9999999999999.99', vMin: '-9999999999999.99', mDec: 2 });
        }

    }


    this.loadOrginator = function(id)
    {
        $.ajax({
            url: instance.getOrginatorDetails_Url + id,
            type: 'POST',
            success: function (data) {
                console.log(data);

                instance.MapOrginatorDetails(data);
                
            },
            error: function (data) {
                console.log(data);
            }
        });
    }

    this.LoadBanks = function () {
        $.ajax({
            url: instance.getBanks_Url,
            type: "GET",
            data: {},
            async: true,
            cache: false,
            success: function (data) {
                instance.GetBanks(data);
            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }

    this.LoadMOStatus = function () {
        $.ajax({
            url: instance.getMOStatus_Url,
            type: "GET",
            data: {},
            async: true,
            cache: false,
            success: function (data) {
                instance.GetMOStatus(data);
            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }
};




