function Bonds() {

    var instance = this;
    instance.save_Reservation_Url = "/Sales/SaveAvailableReservation";
    instance.save_BondsOrginator_Url = "/Bonds/SaveUpdateOrginator";
    instance.save_SaleBondsDetails_Url = "/Bonds/SaveSalesBondDetails";
    instance.save_ReservedSale_Url = "/Sales/UpdateReservedSale"
    instance.save_Individual_Url = "/Sales/SaveIndividual";
    instance.getPurchaserEntityTypes_Url = "/Sales/GetPurchaserEntityTypes";
    instance.getBondDetails_Url = "/Bonds/GetDetails";
    instance.getOrginatorDetails_Url = "/Bonds/LoadData/";
    instance.getPurchaserDetails_Url = "/Bonds/LoadPurchaser/";
    instance.getIndividualDetails_Url = "/Bonds/LoadIndividual/";
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

        $("#btnAddBankApplication").prop("disabled", true);

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

        if ($('#checkDocumentsRec').is(":checked") && $('#checkDocumentsRec').is(":checked"))
        {
            $("#btnAddBankApplication").prop("disabled", true);
        }

        $("#btnUpdateSalesBondDetails").click(function () {
            instance.UpdateSalesBondDetails();
        });

        var numericInputControls = new Array("txtOriginatorTrBondAmount");
        var percentageInputControls = new Array("txtOriginatorTrIntRate")

        instance.initializeNumericPercentageInputValues(percentageInputControls);

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
                $("#lblUnitPrice").html(data.UnitPrice);
                //$("#lblUnitPrice").html(formatNumber($("#lblUnitPrice").html()));
                $("#lblUnitNumber").html(data.UnitNumber);
                $("#lblUnitSize").html(data.UnitSize);
                $("#lblUnitFloor").html(data.UnitFloor);
                $("#lblDevName").html(data.Development);
                $("#txtReservationLapses").val(data.ReservationDate);
                $('#txtSignedDate').val(data.DateSignedBySeller);
                $('#txtSaleReservedPanelStatus').val(data.CurrentSalesStatus);
                $('#txtOriginatorTrBondAmount').val(data.OriginatorTrBondAmount);
                $('#txtHiddenInitialBondAmount').attr('value',data.InitialBondAmount);
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
                $("#txtPurchaserID").val(data.PurchaserID);
                $("#txtIndividualID").val(data.IndividualID);
                $("#txtSalesBondAccountNo").val(data.SalesBondAccountNo);
                if (data.ClientAccepted == true)
                {
                    $("#hasClientAccepted").attr('value', 1);
                }
                if (data.ClientAccepted == false)
                {
                    $("#hasClientAccepted").attr('value', 0);
                }

                if (data.SalesBondClientContactedDt == "" && data.SalesBondBondDocsRecDt == "") {

                    $("#checkClientContacted").val(0);
                    $("#checkClientContacted").prop('checked', false);
                    $("#checkClientContacted").prop("disabled", false);
                    $("#txtSalesBondClientContactedDt").val("");
                    $("#txtSalesBondClientContactedDt").prop("disabled", true);
                    $("#checkDocumentsRec").val(0);
                    $("#checkDocumentsRec").prop('checked', false);
                    $("#checkDocumentsRec").prop("disabled", true);
                    $("#txtSalesBondBondDocsRecDt").val("");
                    $("#txtSalesBondBondDocsRecDt").prop("disabled", true);
                }

                if (data.SalesBondClientContactedDt != "" && data.SalesBondBondDocsRecDt == "") {
                    instance.ConvertCurrentDate(data.SalesBondClientContactedDt, "txtSalesBondClientContactedDt");
                    $("#checkClientContacted").val(1);
                    $("#checkClientContacted").prop('checked', true);
                    $("#txtSalesBondClientContactedDt").prop("disabled", true);
                    $("#checkClientContacted").prop("disabled", true);
                    $("#checkDocumentsRec").val(0);
                    $("#checkDocumentsRec").prop('checked', false);
                    $("#checkDocumentsRec").prop('disabled', false);
                    $("#txtSalesBondBondDocsRecDt").val("");
                    $("#txtSalesBondBondDocsRecDt").prop("disabled", true);

                }

                if (data.SalesBondClientContactedDt != "" && data.SalesBondBondDocsRecDt != "") {
                    instance.ConvertCurrentDate(data.SalesBondClientContactedDt, "txtSalesBondClientContactedDt");
                    instance.ConvertCurrentDate(data.SalesBondBondDocsRecDt, "txtSalesBondBondDocsRecDt");
                    $("#txtSalesBondClientContactedDt").prop("disabled", true);
                    $("#txtSalesBondBondDocsRecDt").prop("disabled", true);
                    $("#checkClientContacted").val(1);
                    $("#checkClientContacted").prop('checked', true);
                    $("#checkClientContacted").prop("disabled", true);
                    $("#checkDocumentsRec").val(1);
                    $("#checkDocumentsRec").prop('checked', true);
                    $("#checkDocumentsRec").prop("disabled", true);

                    $("#btnAddBankApplication").prop("disabled", false);
                }


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

    this.showModalPurchaserDetails = function (id) {
        console.log(id);
        instance.loadPurchaser(id);
        $("#showModalPurchaserDetails").modal('show');
    };

    this.showModalIndividualDetails = function (id) {
        console.log(id);
        instance.loadIndividual(id);
        $("#showModalIndividualDetails").modal('show');
    };

    this.convertCurrentDate = function (currentDate, control) {
        if (currentDate == "" || currentDate == null) {
            $("#" + control).prop("disabled", true);
            $("#" + control).val("");
        }
        else {
            var convertedCurrentDate = moment(currentDate, 'YYYY-MM-DD').format('DD/MM/YYYY');
            $("#" + control).datepicker("setValue", convertedCurrentDate);
        }
    }

    this.setCurrentDate = function (currentDate, control) {
        if (currentDate == "" || currentDate == null) {
            $("#" + control).prop("disabled", true);
            $("#" + control).val("");
        }
        else {
            var convertedCurrentDate = moment(currentDate, 'DD-MM-YYYY').format('DD/MM/YYYY');
            $("#" + control).datepicker("setValue", convertedCurrentDate);
        }
    }

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

    this.validateOrginatorInterestRate = function () {
        var form = $("#OriginatorDetailsForm").serializeArray();
        var validForm = true;
        for (var i = 0; i < form.length; i++) {
            var controlName = form[i].name;
            if (controlName == "OriginatorTrGrantDt") {
                if (form[i].value != '' && form[6].value === '' || form[6].value === '0' || form[6].value === '0.0') {
                    validForm = false;
                    $("#txt" + controlName).addClass("required-field");
                    break;
                }
            }
        }
        return validForm
    }

    this.MapBondPurchaserDetails = function (data) {
        $("#selectPurchaserType").val("" +data.EntityTypeID + "");
        $('#txtPurchaserType').val(data.EntityTypeID);
        $('#txtPurchaserDescription').val(data.PurchaserDescription);
        $('#txtPurchaserContactPerson').val(data.PurchaserContactPerson);
        $('#txtPurchaserContactCell').val(data.PurchaserContactCell);
        $('#txtPurchaserContactHome').val(data.PurchaserContactHome);
        $('#txtPurchaserContactWork').val(data.PurchaserContactWork);
        $('#txtPurchaserEmail').val(data.PurchaserEmail);
        $("#txtPurchaserAddress").val(data.PurchaserAddress);
        $("#txtPurchaserAddress1").val(data.PurchaserAddress1);
        $("#txtPurchaserAddress2").val(data.PurchaserAddress2);
        $("#txtPurchaserAddress3").val(data.PurchaserAddress3);
        $("#txtPurchaserSuburb").val(data.PurchaserSuburb);
        $("#txtPurchaserPostalCode").val(data.PurchaserPostalCode);
    }

    this.MapIndividualDetails = function (data) {
        $("#txtFirstName").val(data.IndividualName);
        $("#txtLastName").val(data.IndividualSurname);
        $("#txtCellNumber").val(data.IndividualContactCell);
        $("#txtWorkNumber").val(data.IndividualContactWork);
        $("#txtEmail").val(data.IndividualEmail);
    }

    this.MapIndividualToPurchaser = function (data) {
        console.log(data.EntityTypeID);
        $("#selectPurchaserType").val()
        $("#txtPurchaserDescription").val(data.IndividualName + " " + data.IndividualSurname);
        $("#txtPurchaserContactPerson").val(data.IndividualName + " " + data.IndividualSurname);
        $("#txtPurchaserContactCell").val(data.IndividualContactCell);
        $("#txtPurchaserContactHome").val(data.IndividualContactHome);
        $("#txtPurchaserContactWork").val(data.IndividualContactWork);
        $("#txtPurchaserEmail").val(data.IndividualEmail);
    }


    this.MapBondDefaults = function(data)
    {
        instance.setSelectControlValue("selectBankName", data.BankName);
        instance.setSelectControlValue("selectMOStatus", data.MOStatus);
        $('#OriginatorTrID').val(data.OriginatorTrID);
        $('#txtOriginatorTrBondAmount').val(data.OriginatorTrBondAmount);
        $('#txtOriginatorTrIntRate').val(data.OriginatorTrIntRate);

    }

    this.MapBondTransactions = function(data)
    {
        if (data.hiddenSalesBondClientContactedDt == null && data.hiddenSalesBondBondDocsRecDt == null) {

            $("#checkClientContacted").val(0);
            $("#checkClientContacted").prop('checked', false);
            $("#checkClientContacted").prop("disabled", false);
            $("#txtSalesBondClientContactedDt").val("");
            $("#txtSalesBondClientContactedDt").prop("disabled", true);
            $("#checkDocumentsRec").val(0);
            $("#checkDocumentsRec").prop('checked', false);
            $("#checkDocumentsRec").prop("disabled", true);
            $("#txtSalesBondBondDocsRecDt").val("");
            $("#txtSalesBondBondDocsRecDt").prop("disabled", true);
        }

        if (data.hiddenSalesBondClientContactedDt != null && data.hiddenSalesBondBondDocsRecDt == null) {
            instance.setCurrentDate(data.hiddenSalesBondClientContactedDt, "txtSalesBondClientContactedDt");
            $("#checkClientContacted").val(1);
            $("#checkClientContacted").prop('checked', true);
            $("#txtSalesBondClientContactedDt").prop("disabled", true);
            $("#checkClientContacted").prop("disabled", true);
            $("#checkDocumentsRec").val(0);
            $("#checkDocumentsRec").prop('checked', false);
            $("#checkDocumentsRec").prop('disabled', false);
            $("#txtSalesBondBondDocsRecDt").val("");
            $("#txtSalesBondBondDocsRecDt").prop("disabled", true);

        }

        if (data.hiddenSalesBondClientContactedDt != null && data.hiddenSalesBondBondDocsRecDt != null) {
            instance.setCurrentDate(data.hiddenSalesBondClientContactedDt, "txtSalesBondClientContactedDt");
            instance.setCurrentDate(data.hiddenSalesBondBondDocsRecDt, "txtSalesBondBondDocsRecDt");
            $("#txtSalesBondClientContactedDt").prop("disabled", true);
            $("#txtSalesBondBondDocsRecDt").prop("disabled", true);
            $("#checkClientContacted").val(1);
            $("#checkClientContacted").prop('checked', true);
            $("#checkClientContacted").prop("disabled", true);
            $("#checkDocumentsRec").val(1);
            $("#checkDocumentsRec").prop('checked', true);
            $("#checkDocumentsRec").prop("disabled", true);
        }

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

    this.GetPurchaserEntityTypes = function (data) {
        $("#selectPurchaserType option").remove();
        $.each(data, function (index, item) {
            var index = index + 1;
            $("#selectPurchaserType").append('<option value=' + index + '>' + item + '</option>');
        });
    }



    this.UpdateSalesBondDetails = function () {

        $("#hiddenSalesBondClientContactedDt").val($("#txtSalesBondClientContactedDt").val());
        $("#hiddenSalesBondBondDocsRecDt").val($("#txtSalesBondBondDocsRecDt").val());

        var formData = $("#UpdateSalesBondDetailsFrom").serialize();
        $.ajax({
            url: instance.save_SaleBondsDetails_Url,
            type: "POST",
            data: formData,
            success: function (data) {
                toastr.success('Sales details updated successfully');
                instance.MapBondTransactions(data);
                window.location.reload(true);
            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }

    this.SaveUpdateOrginator = function () {
        if (instance.validateOrginatorInterestRate()) {
            $("#selectBankName").prop('disabled', false);
            $("#OriginatorTrSubmittedDt").prop('disabled', false);
            $("#OriginatorTrAIPDt").prop('disabled', false);
            $("#OriginatorTrGrantDt").prop('disabled', false);
            $("#OriginatorTrAcceptDt").prop('disabled', false);

            $("#txtOriginatorTrBondAmount").val($("#txtOriginatorTrBondAmount").autoNumeric('get'));
            $("#txtOriginatorTrIntRate").val($("#txtOriginatorTrIntRate").autoNumeric('get'));

            var formData = $("#OriginatorDetailsForm").serialize();
            $.ajax({
                url: instance.save_BondsOrginator_Url,
                type: "POST",
                data: formData,
                success: function (data) {
                    if (data.ClientAccepted == 1) {
                        $("table#tableBondApplications tr").removeAttr("onclick");
                        $("#txtSalesBondAccountNo").val(data.SalesBondAccountNo);
                        window.location.reload(true);
                        toastr.success('Orginator has been updated');

                    }
                    else {
                        window.location.reload(true);
                        toastr.success('Orginator has been updated');
                    }
                },
                error: function (exception) {
                    console.log(exception);
                }
            });
        }
        else { toastr.error("Interest Rate required"); }
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

    this.initializeNumericPercentageInputValues = function (controls) {
        for (var i = 0; i < controls.length; i++) {
            $("#" + controls[i]).attr("data-a-sign", " % ");
            $("#" + controls[i]).autoNumeric('init', { vMax: '100.0', vMin: '-00.0', mDec: 1, pSign: 's' });
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

    this.loadPurchaser = function (id) {
        $.ajax({
            url: instance.getPurchaserDetails_Url + id,
            type: 'POST',
            success: function (data) {
                console.log(data);
                instance.LoadPurchaserEntityTypes();
                instance.MapBondPurchaserDetails(data);
            },
            error: function (data) {
                console.log(data);
            }
        });
    }

    this.loadIndividual = function (id) {
        $.ajax({
            url: instance.getIndividualDetails_Url + id,
            type: 'POST',
            success: function (data) {
                console.log(data);
                instance.MapIndividualDetails(data);
            },
            error: function (data) {
                console.log(data);
            }
        });
    }

    this.LoadPurchaserEntityTypes = function () {
        $.ajax({
            url: instance.getPurchaserEntityTypes_Url,
            type: "GET",
            data: {},
            async: true,
            cache: false,
            success: function (data) {
                instance.GetPurchaserEntityTypes(data);
            },
            error: function (exception) {
                console.log(exception);
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




