﻿function Sales() {

    var instance = this;
    instance.settings_route = "";

    instance.save_Reservation_Url = instance.settings_route + "/Sales/SaveAvailableReservation";
    instance.save_ReservedSale_Url = instance.settings_route + "/Sales/UpdateReservedSale"
    instance.save_PendingSale_Url = instance.settings_route + "/Sales/UpdatePendingSale";
    instance.save_Individual_Url = instance.settings_route + "/Sales/SaveIndividual";
    instance.save_Purchaser_Url = instance.settings_route + "/Sales/SavePurchaser";
    instance.getAgentDetails_Url = instance.settings_route + "/Sales/GetAgentSaleDetails";
    instance.get_Individual_Url = instance.settings_route + "/Sales/GetIndividual";
    instance.getSaleTypes_Url = instance.settings_route + "/Sales/GetSaleTypes";
    instance.getPreferedContactTypes_Url = instance.settings_route + "/Sales/GetPreferedContactMethods";
    instance.getDepositProofTypes_Url = instance.settings_route + "/Sales/GetSaleDepositProofs";
    instance.getCompanyOrginator_Url = instance.settings_route + "/Sales/GetCompanyOriginator";
    instance.getPurchaserEntityTypes_Url = instance.settings_route + "/Sales/GetPurchaserEntityTypes";
    instance.uploadDocuments_Url = instance.settings_route + "/Sales/UploadDocuments?id=";
    instance.IndividualAdded = false;
    instance.PurchaserFormValid = false;
    instance.ReservedFormValid = false;
    instance.PendingFormValid = false;
    instance.dublicateIndividualRecords = null;
    instance.updateIndividualRecord = false;

    instance.resources = null;

    this.load = function () {

        instance.resources = new Resources();
        instance.resources.MaskCellPhone();
        instance.resources.MaskWorkPhone();

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

        $('[data-toggle="tooltip"]').tooltip()

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

        $('#divPanelBonds').click(function () {
            $(this).find('i').toggleClass('fa-plus-circle fa-minus-circle');
        });

        var dateToday = new Date();
        var convertDateToday = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
        $("#txtReservationDate").datepicker("setValue", convertDateToday);

        $("#txtReservationDate").on('changeDate', function (ev) {
            var reservationDate = document.getElementById('txtReservationDate').value;
            var convertedReservationDate = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
            var tempDate = moment(convertedReservationDate, 'DD/MM/YYYY').add('days', 2).format('DD/MM/YYYY');
            $("#txtExpiryDate").datepicker("setValue", tempDate);
        });

        var reservationDate = document.getElementById('txtReservationDate').value;
        var convertedReservationDate = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
        var tempDate = moment(convertedReservationDate, 'DD/MM/YYYY').add('days', 2).format('DD/MM/YYYY');

        var numericInputControls = new Array("txtDepositPaid", "txtSaleBondRequiredAmount");

        instance.initializeNumericInputValues(numericInputControls)

        $("#txtExpiryDate").datepicker("setValue", tempDate);
        
        $('#checkReservationTimeExtention').change(function () {
            $("#selectTimeExtention").prop("disabled", !$(this).is(':checked'));
        });
        
        $('#checkPurchaserContractSigned').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtPurchaserContractSigned").val("");
            }
            else {
                $("#txtPurchaserContractSigned").prop("disabled", false);
                $("#txtPurchaserContractSigned").prop("readonly", false);
                var dateToday = new Date();
                var convertDateToday = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
                $("#txtPurchaserContractSigned").datepicker("setValue", convertDateToday);
            }
        });

        $('#checkDepositPaid').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtDepositPaidDate").val("");
                $("#showNonCashPaymentSection").addClass('hide');
                $(this).val(0);
            }
            else {
                $(this).val(1);
                $("#txtDepositPaidDate").prop("disabled", false);
                $("#txtDepositPaidDate").prop("readonly", false);
                var dateToday = new Date();
                var convertDateToday = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
                $("#txtDepositPaidDate").datepicker("setValue", convertDateToday);
                $("#showNonCashPaymentSection").removeClass('hide');
            }
        });

        $('#checkProofDepositPaidDate').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtDepositPaidProofDate").prop("disabled", true);
                $("#txtDepositPaidProofDate").val("");
            }
            else {
                $("#txtDepositPaidProofDate").prop("disabled", false);
                $("#txtDepositPaidProofDate").datepicker("setValue", new Date());
            }
        });

        $('#checkSalesDepositProofBt').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtSalesDepositProofDt").prop("disabled", true);
                $("#txtSalesDepositProofDt").val("");
                $(this).val(0);
            }
            else {
                $(this).val(1);
                $("#txtSalesDepositProofDt").prop("disabled", false);
                var dateToday = new Date();
                var convertDateToday = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
                $("#txtSalesDepositProofDt").datepicker("setValue", convertDateToday);
            }
        });

        $('#checkBondRequired').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtBondRequiredDate").prop("disabled", true);
                $("#txtSaleBondDueTime").prop("disabled", true);
                $("#txtSaleBondDueExpiryDt").prop("disabled", true);
                $("#txtSaleBondDueTime").val("");
                $("#txtSaleBondDueExpiryDt").val("");
                $("#txtBondRequiredDate").val("");

                $(this).val(0);
            }
            else {
                $(this).val(1);
                $("#txtBondRequiredDate").prop("disabled", false);
                $("#txtSaleBondDueTime").prop("disabled", false);
                $("#txtSaleBondDueExpiryDt").prop("disabled", false);
                var dateToday = new Date();
                var convertDateToday = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
                var _saleBondDueTimeDt = moment(convertedReservationDate, 'DD/MM/YYYY').add('days', 2).format('DD/MM/YYYY');
                var _saleBondDueExpiryDt = moment(convertedReservationDate, 'DD/MM/YYYY').add('days', 45).format('DD/MM/YYYY');
                $("#txtBondRequiredDate").datepicker("setValue", convertDateToday);
                $("#txtSaleBondDueTime").datepicker("setValue", _saleBondDueTimeDt);
                $("#txtSaleBondDueExpiryDt").datepicker("setValue", _saleBondDueExpiryDt);
            }
        });

        $("#txtBondRequiredDate").on('changeDate', function (ev) {
            var reservationDate = document.getElementById('txtBondRequiredDate').value;
            var convertedReservationDate = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
            var _saleBondDueTimeDt = moment(convertedReservationDate, 'DD/MM/YYYY').add('days', 2).format('DD/MM/YYYY');
            var _saleBondDueExpiryDt = moment(convertedReservationDate, 'DD/MM/YYYY').add('days', 45).format('DD/MM/YYYY');
            $("#txtSaleBondDueTime").datepicker("setValue", _saleBondDueTimeDt);
            $("#txtSaleBondDueExpiryDt").datepicker("setValue", _saleBondDueExpiryDt);
        });
        
        $('#checkPendingSellerContractSigned').change(function () {
            if (!$(this).is(':checked')) {
                //$("#txtSellerContractSignedDate").prop("disabled", true);
                $("#txtSellerContractSignedDate").val("");
                $(this).val(0);
            }
            else {
                $(this).val(1);
                $("#txtSellerContractSignedDate").prop("disabled", false);
                var dateToday = new Date();
                var convertDateToday = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
                $("#txtSellerContractSignedDate").datepicker("setValue", convertDateToday);
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

        $('input.money-bank').on('keydown', function (e) {
            // tab, esc, enter
            if ($.inArray(e.keyCode, [9, 27, 13]) !== -1 ||
                // Ctrl+A
                (e.keyCode == 65 && e.ctrlKey === true) ||
                // home, end, left, right, down, up
                (e.keyCode >= 35 && e.keyCode <= 40)) {
                return;
            }

            e.preventDefault();

            // backspace & del
            if ($.inArray(e.keyCode, [8, 46]) !== -1) {
                $(this).val('');
                return;
            }

            var a = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "`"];
            var n = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "0"];

            var value = $(this).val();
            var clean = value.replace(/\./g, '').replace(/,/g, '').replace(/^0+/, '');

            var charCode = String.fromCharCode(e.keyCode);
            var p = $.inArray(charCode, a);

            if (p !== -1) {
                value = clean + n[p];

                if (value.length == 2) value = '0' + value;
                if (value.length == 1) value = '00' + value;

                var formatted = '';
                for (var i = 0; i < value.length; i++) {
                    var sep = '';
                    if (i == 2) sep = ',';
                    if (i > 3 && (i + 1) % 3 == 0) sep = '.';
                    formatted = value.substring(value.length - 1 - i, value.length - i) + sep + formatted;
                }

                $(this).val(formatted);
            }

            return;

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

        $('#selectFinanceType').on('change', function () {
            $("#selectFinanceType option:first").attr('disabled', true);
            var value = $('#selectFinanceType').val();
            if (value == 1) {
                $("#divSaleBondDetails").addClass('show')
                .removeClass('hide');
            }
            else {
                $("#divSaleBondDetails").removeClass('show')
                .addClass('hide');
                $("#txtBondRequiredDate").val(null);
                $("#txtSaleBondDueTime").val(null);
                $("#txtSaleBondDueExpiryDt").val(null);
                $("#txtSaleBondRequiredAmount").val(null); 
                $("#checkBondRequired").prop("checked", false);
                $("#checkBondRequired").attr("checked", false);

            }
        });

        $('#selectPurchaserType').on('change', function () {
            var value = $('#selectPurchaserType').val();
            if (value == 2) {
                instance.LoadIndividualDetails();
            }
            else {

            }

        });

        $("#btnUpdateReservation").click(function () {

            if (instance.IndividualAdded) {
                instance.UpdateReservationDetails();
            }
            else {
                toastr.warning("Please add an individual to continue");
            }

        });

        $("#btnUpdateReservedSale").click(function () {
            if (instance.validateReservedUpdateSale()) {
                if (instance.ReservedFormValid) {
                    $("#PendingFormCompleteAndValid").attr('value', 0);
                    instance.UpdateReservedSale();
                    toastr.success("Updated Successfully");
                }
            }
        });

        $("#btnAddUpdatePurchaser").click(function () {
            if (instance.validatePurchaser()) {
                instance.UpdatePurchaserDetails();
            }

        });

        $("#btnUpdatePendingSale").click(function () {

            if (instance.PurchaserFormValid) {
                if (instance.validateReservedSale()){
                    if (instance.validatePendingSale())
                    {
                        $("#PendingFormCompleteAndValid").attr('value', 1);
                        instance.UpdatePendingSale();
                        toastr.success("Updated Successfully");
                    }
                }
                else {
                    $("#PendingFormCompleteAndValid").attr('value', 0);
                    toastr.warning("please complete Contract signed and Deposit details to continue");
                }
               
            }
            else {
                $("#PendingFormCompleteAndValid").attr('value', 0);
                toastr.warning("please add purchaser to continue");
            }

        });

        $("#btnReservedUpdatePersonDetails").click(function () {
            if (instance.validateClient("individualFormReserved")) {
                instance.UpdateIndividualDetails();
                instance.IndividualAdded = true;
            }


        });

        $("#btnPendingUpdatePersonDetails").click(function () {
            if (instance.validateClient("individualFormPending")) {
                instance.UpdatePendingPersonDetails();
            }
            
        });

        $('#btnUploadProof').on('change', function (e) {
            var files = e.target.files;
            if (files.length > 0) {
                if (window.FormData !== undefined) {
                    var data = new FormData();
                    for (var x = 0; x < files.length; x++) {
                        data.append("file" + x, files[x]);
                    }

                    $.ajax({
                        type: "POST",
                        url: instance.uploadDocuments_Url + files,
                        contentType: false,
                        processData: false,
                        data: data,
                        success: function (result) {
                            toastr.success(result);
                        },
                        error: function (xhr, status, p3, p4) {
                            var err = "Error " + " " + status + " " + p3 + " " + p4;
                            console.log(err);
                            if (xhr.responseText && xhr.responseText[0] == "{")
                                err = JSON.parse(xhr.responseText).Message;
                            toastr.error(err);
                        }
                    });
                } else {
                    alert("This browser doesn't support HTML5 file uploads!");
                }
            }
        });

        $(".clearDuplicateIndividualForm").click(function () {
            if (instance.updateIndividualRecord == true) {

                $("#txtCellNumberPending").val("");
                $("#txtWorkNumberPending").val("");
                $("#txtEmailPending").val("");

                instance.updateIndividualRecord == false;
            }
            else {
                $("#duplicateIndividuals").find("tr:gt(0)").remove();
                $('#DuplicateIndividualDetailsModal').modal('hide');
                $('#individualFormReserved').trigger("reset");
                $('#individualFormReserved')[0].reset();
            }
        });

        instance.LoadSaleTypes();
        instance.LoadContactPreferedTypes();
        instance.LoadDepositProofTypes();
        instance.LoadPurchaserEntityTypes();
        instance.LoadCompanyOrginators();
        instance.initializeSaleDetails();
    }

    this.initializeSaleDetails = function () {
        $.ajax({
            url: instance.getAgentDetails_Url,
            type: 'GET',
            datatype: 'json',
            data: {},
            async : true,
            success: function (data) {
                console.log("response...");
                console.log(data);
                if (data.IsNewSale != "NewSale") {
                    instance.MapUnitDetails(data);
                    instance.MapIndividualDetails(data);
                    instance.MapSaleDetails(data);
                    instance.MapBondsDetails(data);
                    instance.MapPurchaserlDetails(data);
                    var saleStatus = data.CurrentSalesStatusId;
                    console.log(saleStatus);
                    if (saleStatus == 1) {

                        $("#collapseOne").removeClass("collapse").addClass("in");
                        $("#collapseOne").css("height", "auto");
                        $("#showPanelReservedOpenClose").removeClass("fa-plus-circle").addClass("fa-minus-circle");

                        console.log("we are here");
                        $('#txtSaleReservedPanelStatus').val(data.CurrentSalesStatus);

                        $("#SaleReservedForm input").attr("disabled", false);
                        $("#SaleReservedForm select").prop('disabled', false);


                        $("#individualFormReserved input").attr("disabled", false);
                        $("#individualFormReserved select").attr("disabled", false);

                        $("#soldPanel").addClass("disabledbutton");
                        $("#pendingPanel").addClass("disabledbutton");
                        $("#bondsPanel").addClass("disabledbutton");
                    }
                    if (saleStatus == 2) {

                        $("#collapseOne").removeClass("collapse").addClass("in");
                        $("#collapseOne").css("height", "auto");
                        $("#showPanelReservedOpenClose").removeClass("fa-plus-circle").addClass("fa-minus-circle");

                        $('#txtSaleReservedPanelStatus').val(data.CurrentSalesStatus);
                        $('#txtSalePendingPanelStatus').val(data.CurrentSalesStatus);

                        $("#SaleReservedForm input").attr("disabled", true);
                        $("#SaleReservedForm select option").prop('disabled', 'disabled');

                        $("#individualFormReserved input").attr("disabled", true);
                        $("#individualFormReserved select").attr("disabled", 'disabled');

                        var PendingFormCompleteAndValid = data.PendingFormCompleteAndValid;

                        if (PendingFormCompleteAndValid == 0) {

                            $("#SalePendingForm input").attr("disabled", false);
                            $("#SalePendingForm select").prop("disabled", false);
                            $("#SalePendingForm select option").prop("disabled", false);
                        }
                        $("#txtFirstNamePending").addClass("disabledControls");
                        $("#txtLastNamePending").addClass("disabledControls");

                        $("#individualFormPending input").attr("disabled", false);
                        $("#individualFormPending select").prop("disabled", false);
                        $("#individualFormPending select option").prop("disabled", false);

                        $("#pendingPanel").removeClass("disabledbutton");
                        $("#soldPanel").addClass("disabledbutton");
                        $("#bondsPanel").addClass("disabledbutton");
                    }
                    if (saleStatus == 3) {

                        $("#collapseTwo").removeClass('panel-collapse collapse').addClass('panel-collapse in');
                        $("#collapseTwo").css("height", "auto");
                        $("#showPanelPendingOpenClose").removeClass("fa-plus-circle").addClass("fa-minus-circle");

                        $('#txtSaleReservedPanelStatus').val(data.CurrentSalesStatus);
                        $('#txtSalePendingPanelStatus').val(data.CurrentSalesStatus);
                        $('#txtSaleSoldPanelStatus').val(data.CurrentSalesStatus);

                        $("#SaleReservedForm input").attr("disabled", true);
                        $("#SaleReservedForm select option").prop('disabled', 'disabled');

                        $("#individualFormReserved input").attr("disabled", true);
                        $("#individualFormReserved select").attr("disabled", 'disabled');

                        var PendingFormCompleteAndValid = data.PendingFormCompleteAndValid;

                        if (PendingFormCompleteAndValid == 0) {
                            $("#SalePendingForm input").attr("disabled", false);
                            $("#SalePendingForm select").prop("disabled", false);
                        }

                        if (PendingFormCompleteAndValid == 1) {
                            $("#SalePendingForm input").attr("disabled", true);
                            $("#SalePendingForm select").prop("disabled", 'disabled');
                        }
                        
                        $("#individualFormPending input").attr("disabled", true);
                        $("#individualFormPending select").prop("disabled", true);
                        $("#individualFormPending select option").prop("disabled", true);

                        $("#SaleSoldForm input").attr("disabled", false);
                        $("#SaleSoldForm select").prop("disabled", false);
                        $("#SaleSoldForm select option").prop("disabled", false);

                        $("#purchaserFormSold input").attr("disabled", false);
                        $("#purchaserFormSold select").prop("disabled", false);
                        $("#purchaserFormSold select option").prop("disabled", false);

                        $("#pendingPanel").removeClass("disabledbutton");
                        $("#soldPanel").removeClass("disabledbutton");
                        $("#bondsPanel").addClass("disabledbutton");

                    }

                    if (saleStatus >= 4) {

                        $("#collapseThree").removeClass('panel-collapse collapse').addClass('panel-collapse in');
                        $("#collapseThree").css("height", "auto");
                        $("#showPanelSoldOpenClose").removeClass("fa-plus-circle").addClass("fa-minus-circle");

                        $('#txtSaleReservedPanelStatus').val(data.CurrentSalesStatus);
                        $('#txtSalePendingPanelStatus').val(data.CurrentSalesStatus);
                        $('#txtSaleSoldPanelStatus').val(data.CurrentSalesStatus);

                        $("#SaleReservedForm input").attr("disabled", true);
                        $("#SaleReservedForm select option").prop('disabled', 'disabled');

                        $("#individualFormReserved input").attr("disabled", true);
                        $("#individualFormReserved select").attr("disabled", 'disabled');

                        $("#SalePendingForm input").attr("disabled", true);
                        $("#SalePendingForm select").prop("disabled", 'disabled');

                        $("#individualFormPending input").attr("disabled", true);
                        $("#individualFormPending select").prop("disabled", 'disabled');
                        $("#individualFormPending select option").prop("disabled", 'disabled');

                        $("#SaleSoldForm input").attr("disabled", true);
                        $("#SaleSoldForm select").prop("disabled", 'disabled');
                        $("#SaleSoldForm select option").prop("disabled", 'disabled');

                        $("#purchaserFormSold input").attr("disabled", true);
                        $("#purchaserFormSold select").prop("disabled", 'disabled');
                        $("#purchaserFormSold select option").prop("disabled", 'disabled');

                        $("#pendingPanel").removeClass("disabledbutton");
                        $("#soldPanel").removeClass("disabledbutton");
                        $("#bondsPanel").removeClass("disabledbutton");

                    }
                }
                else {

                    console.log(data);
                    $("#lblUnitPhase").html(data.UnitPhase);
                    $("#lblUnitPrice").html("R " + data.UnitPriceIncluding);
                    $("#lblUnitNumber").html(data.UnitNumber);
                    $("#lblUnitStatus").html(data.CurrentSalesStatus)
                    $("#lblUnitSize").html(data.UnitSize);
                    $("#lblUnitFloor").html(data.UnitFloor);


                    $('#txtSaleReservedPanelStatus').val("Available");

                    $("div#divReservationExtend input").attr("disabled", false);
                    $("#divReservationExtend").addClass('disabledControls');

                    $("#SaleReservedForm input").attr("disabled", false);
                    $("#SaleReservedForm select").prop('disabled', false);
                    $("#SaleReservedForm select option").prop('disabled', false);

                    $("#individualFormReserved input").attr("disabled", false);
                    $("#individualFormReserved select").attr("disabled", false);
                    $("#individualFormReserved select option").attr("disabled", false);

                    $("#bondsPanel").addClass("disabledbutton");
                    $("#soldPanel").addClass("disabledbutton");
                    $("#pendingPanel").addClass("disabledbutton");

                }
            },
            error: function (data) {
                console.log(data);
            }
        });
    }

    this.initializeNumericInputValues = function(controls)
    {
        for (var i = 0; i < controls.length; i++) {
            $("#" + controls[i]).attr("data-a-sign", "R ");
            $("#" + controls[i]).autoNumeric('init', { vMax: '9999999999999.99', vMin: '-9999999999999.99', mDec: 2 });
        }
       
    }

    this.validatePurchaser = function () {
        var form = $("#purchaserFormSold").serializeArray();
        console.log(form);
        var validForm = true;
        instance.PurchaserFormValid = true;
        for (var i = 0; i < form.length; i++) {
            var controlName = form[i].name;

            if (controlName == "EntityTypeID") {
                if (form[i].value === "0") {
                    validForm = false;
                    instance.PurchaserFormValid = false;
                    toastr.error("Purchaser Type required");
                    $("#selectPurchaserType").addClass("required-field");
                    break;
                }
                else {
                    $("#selectPurchaserType").removeClass("required-field");
                }
            }
            if (controlName == "PurchaserDescription") {
                if (form[i].value === '') {
                    validForm = false;
                    instance.PurchaserFormValid = false;
                    toastr.error("Purchaser Description required");
                    $("#txt" + controlName).addClass("required-field");
                    break;
                }
                else {
                    $("#txt" + controlName).removeClass("required-field");
                }
            }
            if (controlName == "PurchaserContactPerson") {
                if (form[i].value === '') {
                    validForm = false;
                    instance.PurchaserFormValid = false;
                    toastr.error("Purchaser Contact Person required");
                    $("#txt" + controlName).addClass("required-field");
                    break;
                }
                else {
                    $("#txt" + controlName).removeClass("required-field");
                }
            }
            if (controlName == "PurchaserContactCell") {
                if (form[i].value === '') {
                    validForm = false;
                    instance.PurchaserFormValid = false;
                    toastr.error("Purchaser Cell Number required");
                    $("#txt" + controlName).addClass("required-field");
                    break;
                }
                else {
                    $("#txt" + controlName).removeClass("required-field");
                }
            }
            if (controlName == "PurchaserEmail") {
                if (form[i].value === '') {
                    validForm = false;
                    instance.PurchaserFormValid = false;
                    toastr.error("Purchaser Email Address required");
                    $("#txt" + controlName).addClass("required-field");
                    break;
                }
                else {
                    $("#txt" + controlName).removeClass("required-field");
                }
            }
            if (controlName == "PurchaserEmail") {
                if (form[i].value != '') {
                    var email = $("#txtPurchaserEmail").val();
                    if (!instance.resources.validateEmailAddress(email))
                    {
                        validForm = false;
                        instance.PurchaserFormValid = false;
                        toastr.error("Purchaser Email Address Invalid");
                        $("#txt" + controlName).addClass("required-field");
                        break;
                    }
                }
                else {
                    $("#txt" + controlName).removeClass("required-field");
                }
            }

        }
        return validForm;
    }

    this.validateReservedUpdateSale = function () {
        var form = $("#SalePendingForm").serializeArray();
        console.log(form);

        var validForm = true;
        instance.ReservedFormValid = false;
        for (var i = 0; i < form.length; i++) {
            var controlName = form[i].name;
            if (controlName == "SaleContractSignedPurchaserDt") {
                if (form[i].value === '' && form[2].value === '') {
                    validForm = false;
                    instance.ReservedFormValid = false;
                    $("#PendingFormCompleteAndValid").attr('value', 0);
                    toastr.error("Deposit Paid or Contract signed required");
                    break;
                }

                if (form[i].value != '' && form[1].value === '') {
                    validForm = true;
                    instance.ReservedFormValid = true;
                    $("#PendingFormCompleteAndValid").attr('value', 0);
                    break;
                }

            }

            if (controlName == "SalesDepoistPaidDt") {
                if (form[i].value === '' && form[0].value === '') {
                    validForm = false;
                    instance.ReservedFormValid = false;
                    $("#PendingFormCompleteAndValid").attr('value', 0);
                    toastr.error("Deposit Paid or Contract signed required");
                    break;
                }


                if (form[i].value != '' && form[0].value === '' || form[0].value != '') {

                    if (form[3].value === '') {
                        validForm = false;
                        instance.ReservedFormValid = false;
                        $("#PendingFormCompleteAndValid").attr('value', 0);
                        toastr.error("Deposit Type required");
                        break;
                    }

                    if(form[4].value === '')
                    {
                        validForm = false;
                        instance.ReservedFormValid = false;
                        $("#PendingFormCompleteAndValid").attr('value', 0);
                        toastr.error("Deposit Amount required");
                        break;
                    }

                    if (form[4].value === '0' || form[4].value === 0.00 || form[4].value === 'R 0.00') {
                        validForm = false;
                        instance.ReservedFormValid = false;
                        $("#PendingFormCompleteAndValid").attr('value', 0);
                        toastr.error("Deposit Amount cannot be Zero");
                        break;
                    }

                    if (form[5].value === '') {
                        validForm = false;
                        instance.ReservedFormValid = false;
                        $("#PendingFormCompleteAndValid").attr('value', 0);
                        toastr.error("Deposit Proof Date required");
                        break;
                    }
                }
            }

        }
        instance.ReservedFormValid = true
        return validForm;
    };

    this.validateReservedSale = function () {
        var form = $("#SalePendingForm").serializeArray();
        console.log(form);
        var validForm = true;
        instance.ReservedFormValid = false;

        for (var i = 0; i < form.length; i++) {
            var controlName = form[i].name;
            if (controlName == "SaleContractSignedPurchaserDt") {
                if (form[i].value === '') {
                    validForm = false;
                    instance.ReservedFormValid = false;
                    toastr.error("Contract signed required");
                    break;
                }
            }

            if (controlName == "SalesDepoistPaidDt") {
                if (form[i].value === '') {
                    validForm = false;
                    instance.ReservedFormValid = false;
                    toastr.error("Deposit Paid required");
                    break;
                }
            }

            if (controlName == "SalesTotalDepositAmount") {
                if (form[i].value === '' ) {
                    validForm = false;
                    instance.ReservedFormValid = false;
                    toastr.error("Deposit Amount  as required");
                    break;
                }

                if (form[i].value === '0' || form[i].value === 0.00 || form[i].value === 'R 0.00') {
                    validForm = false;
                    instance.ReservedFormValid = false;
                    toastr.error("Deposit amount cannot be zero");
                    break;
                }
            }

            if (controlName == "SalesDepositProofDt") {
                if (form[i].value === '') {
                    validForm = false;
                    instance.ReservedFormValid = false;
                    toastr.error("Deposit Proof Date required");
                    break;
                }
            }

     

        }
        return validForm;
    };

    this.validatePendingSale = function () {
        var form = $("#SaleSoldForm").serializeArray();
        console.log(form);

        var validForm = true;
        instance.PendingFormValid = false;

        var financeType = $("#selectFinanceType").val();
        if (financeType < 1)
        {
            validForm = false;
            instance.PendingFormValid = false;
            $("#PendingFormCompleteAndValid").attr('value', 1);
            toastr.error("Please select Finance Type");
            return false;
        }


        for (var i = 0; i < form.length; i++) {
            var controlName = form[i].name;
            if (controlName == "SaleContractSignedSellerDt") {
                if (form[i].value === '') {
                    validForm = false;
                    instance.PendingFormValid = false;
                    $("#PendingFormCompleteAndValid").attr('value', 1);
                    toastr.error("Contract signed by seller required");
                    break;
                }
            }

            if (controlName == "SaleTypeID") {

                if (form[i].value === '0') {
                    validForm = false;
                    instance.PendingFormValid = false;
                    $("#PendingFormCompleteAndValid").attr('value', 1);
                    toastr.error("Please select Finance Type");
                    break;
                }

                if (form[i].value === '2' && form[2].value === '') {
                    validForm = false;
                    instance.PendingFormValid = false;
                    $("#PendingFormCompleteAndValid").attr('value', 1);
                    toastr.error("Contract signed by seller required");
                    break;
                }
            }

            if (controlName == "SalesBondRequiredDt") {
                if (form[i].value === '' && form[3].value === '1') {
                    validForm = false;
                    instance.PendingFormValid = false;
                    $("#PendingFormCompleteAndValid").attr('value', 1);
                    toastr.error("Bond Date required");
                    break;
                }
            }

            if (controlName == "SaleBondRequiredAmount") {
                if (form[i].value === '' && form[3].value === '1') {
                    validForm = false;
                    instance.PendingFormValid = false;
                    $("#PendingFormCompleteAndValid").attr('value', 1);
                    toastr.error("Bond amount required");
                    break;
                }

                if (form[i].value === '0' || form[i].value === 0.00 || form[i].value === 'R 0.00' && form[3].value === '1') {
                    validForm = false;
                    instance.PendingFormValid = false;
                    $("#PendingFormCompleteAndValid").attr('value', 1);
                    toastr.error("Bond amount cannot be zero");
                    break;
                }
            }
        }
        instance.PendingFormValid = true
        return validForm;
    }

    this.validateIndividiual = function () {

        var form = $("#individualFormReserved").serializeArray();
        var validForm = true;
        for (var i = 0; i < form.length; i++) {
            if (form[i].value === '') {
                validForm = false;
                break;
            }
        }
    }

    this.validateClient = function (formId) {
        var form = $("#" + formId).serializeArray();
        var validForm = true;
        instance.ReservedFormValid = false;
        var pendingForm = false;
        
        if (formId == "individualFormPending"){ pendingForm = true;}
        else { pendingForm = false;}
        
        for (var i = 0; i < form.length; i++) {
            var controlName = form[i].name;
            if (controlName == "IndividualName") {
                if (form[i].value === '') {
                    validForm = false;
                    instance.IndividualAdded = false;
                    toastr.error("Individual First Name is required");
                    $("#txt" + controlName).addClass("required-field");
                    break;
                }
                else {
                    $("#txt" + controlName).removeClass("required-field");
                }

            }
            if (controlName == "IndividualSurname") {
                if (form[i].value === '') {
                    validForm = false;
                    instance.IndividualAdded = false;
                    toastr.error("Individual Last Name is required");
                    $("#txt" + controlName).addClass("required-field");
                    break;
                }
                else {
                    $("#txt" + controlName).removeClass("required-field");
                }
            }
            if (controlName == "IndividualContactCell") {
                if (form[i].value === '') {
                    validForm = false;
                    instance.IndividualAdded = false;
                    toastr.error("Individual Cell required");
                    if (!pendingForm)
                    {
                        $("#txt" + controlName).addClass("required-field");
                    }
                    else {
                        $("#txtCellNumberPending").addClass("required-field");
                    }
                   
                    break;
                }
                else {
                    if (formId != "individualFormPending") {
                        $("#txt" + controlName).removeClass("required-field");
                    }
                    else {
                        $("#txtCellNumberPending").removeClass("required-field");
                    }
                }
            }

            if (controlName == "IndividualEmail") {
                if (form[i].value === '') {
                    validForm = false;
                    instance.IndividualAdded = false;
                    toastr.error("Individual Email required");
                    if (!pendingForm) {
                        $("#txt" + controlName).addClass("required-field");
                    }
                    else {
                        $("#txtEmailPending").addClass("required-field");
                    }
                    break;
                }
                else {
                    if (formId != "individualFormPending") {
                        $("#txt" + controlName).removeClass("required-field");
                    }
                    else {
                        $("#txtEmailPending").removeClass("required-field");
                    }
                }
            }

            if (controlName == "IndividualEmail") {
                if (formId == "individualFormPending") {
                    var email = $("#txtEmailPending").val();
                } else {
                    var email = $("#txtIndividualEmail").val();
                }

                if (form[i].value != '') {
                   
                    if (!instance.resources.validateEmailAddress(email)) {
                        validForm = false;
                        instance.IndividualAdded = false;
                        toastr.error("Email Address invalid");
                        if (!pendingForm) {
                            $("#txt" + controlName).addClass("required-field");
                        }
                        else {
                            $("#txtEmailPending").addClass("required-field");
                        }
                        break;
                    }
                    else {
                        if (formId != "individualFormPending") {
                            $("#txt" + controlName).removeClass("required-field");
                        }
                        else {
                            $("#txtEmailPending").removeClass("required-field");
                        }
                    }
                }
            }

        }
        return validForm;
    }

    this.UpdateReservationDetails = function () {
        var formData = $("#SaleReservedForm").serialize();
        $.ajax({
            url: instance.save_Reservation_Url,
            type: "POST",
            data: formData,
            success: function (data) {
                    instance.RedirectToDashBoard();
                    toastr.success('Reservation has been updated');
            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }

    this.UpdateReservedSale = function () {

        $("#txtDepositPaid").val($("#txtDepositPaid").autoNumeric('get'));

        var formData = $("#SalePendingForm").serialize();
        $.ajax({
            url: instance.save_ReservedSale_Url,
            type: "POST",
            data: formData,
            success: function (data) {
                    if (data.PendingFormCompleteAndValid != 0) {
                        instance.RedirectToDashBoard();
                        toastr.success('Updated successful');
                    }
                    else {
                        window.location.reload(true);
                        toastr.success('Updated successful');
                    }
            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }

    this.UpdatePendingSale = function () {

        $("#txtSaleBondRequiredAmount").val($("#txtSaleBondRequiredAmount").autoNumeric('get'));

        var formData = $("#SaleSoldForm").serialize();
        $.ajax({
            url: instance.save_PendingSale_Url,
            type: "POST",
            data: formData,
            success: function (data) {
                    instance.RedirectToDashBoard();
                    toastr.success('Updated successful');
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
                //instance.MapIndividualDetails(data);
            },
            error: function (exception) {
                console.log(exception);
                
               
            }

        });
    }

    this.UploadDocuments = function () {

        $('#btnUploadProof').on('change', function (e) {
            var files = e.target.files;
            if (files.length > 0) {
                if (window.FormData !== undefined) {
                    var data = new FormData();
                    for (var x = 0; x < files.length; x++) {
                        data.append("file" + x, files[x]);
                    }
                    $("#progress").removeClass('hide');
                    $.ajax({
                        type: "POST",
                        url: '/Sales/UploadDocuments?id=' + myID,
                        contentType: false,
                        processData: false,
                        data: data,
                        success: function (result) {
                            console.log(result);
                        },
                        error: function (xhr, status, p3, p4) {
                            var err = "Error " + " " + status + " " + p3 + " " + p4;
                            if (xhr.responseText && xhr.responseText[0] == "{")
                                err = JSON.parse(xhr.responseText).Message;
                            console.log(err);
                        }
                    }).done(function (data) {$(".progress").addClass('hide'); });
                } else {
                    alert("This browser doesn't support HTML5 file uploads!");
                }
            }
        });
    }

    this.HandleUnauthorizedPermissions = function (data) {
        toastr.error(data.description);
    }

    this.isArray = function(ob) {
        return ob.constructor === Array;
    }

    this.LoadDuplicateIndividuals = function(data)
    {
        instance.dublicateIndividualRecords = data;

        $("#duplicateIndividuals").find("tr:gt(0)").remove();
        for (var i = 0; i < data.length; i++) {
            tr = $('<tr/>');
            tr.append("<td class='hide'>" + data[i].IndividualID + "</td>");
            tr.append("<td>" + data[i].IndividualName + "</td>");
            tr.append("<td>" + data[i].IndividualSurname + "</td>");
            tr.append("<td>" + data[i].IndividualContactCell + "</td>");
            tr.append("<td>" + data[i].IndividualEmail + "</td>");
            tr.append("<td>" + "Company XYZ" + "</td>");
            tr.append("<td>" + '<a id="selectedDuplicateIndividualRecord" individualID=' + data[i].IndividualID + ' class="btn btn-xs btn-default selectIndividual"><span class="glyphicon glyphicon-ok"></span> select</a>' + "</td>");
           
            $('#duplicateIndividuals').append(tr);

            $("#DuplicateIndividualDetailsModal").modal('show');
        }

        $(".selectIndividual").on('click', function () {
            var id = $(this).attr('individualID');
            for (var i = 0; i < instance.dublicateIndividualRecords.length; i++) {

                if(instance.dublicateIndividualRecords[i].IndividualID == id)
                {
                    if (instance.updateIndividualRecord == true) {
                        $("#txtCellNumberPending").val(instance.dublicateIndividualRecords[i].IndividualContactCell);
                        $("#txtEmailPending").val(instance.dublicateIndividualRecords[i].IndividualEmail);

                        instance.updateIndividualRecord == false;
                        $('#DuplicateIndividualDetailsModal').modal('hide');
                        break;
                    }
                    else {

                        $('#individualFormReserved').trigger("reset");
                        $('#individualFormReserved')[0].reset();
                        $("#txtIndividualName").val(instance.dublicateIndividualRecords[i].IndividualName);
                        $("#txtIndividualSurname").val(instance.dublicateIndividualRecords[i].IndividualSurname);
                        $("#txtIndividualContactCell").val(instance.dublicateIndividualRecords[i].IndividualContactCell);
                        $("#txtIndividualEmail").val(instance.dublicateIndividualRecords[i].IndividualEmail);
                        $("#DuplicateIndividualFound").val(1);
                        $('#DuplicateIndividualDetailsModal').modal('hide');
                       
                        break;
                    }
                }
            }
        });
    }
    
    this.UpdateIndividualDetails = function () {

        var formData = $("#individualFormReserved").serialize();
        $("#progress").removeClass('hide');
        $.ajax({
            url: instance.save_Individual_Url,
            type: "POST",
            data: formData,
            async: true,
            cache: false,
            success: function (data) {
                console.log(data)
                    if (instance.isArray(data)) {
                        toastr.info("Duplicate record(s) found");
                        instance.LoadDuplicateIndividuals(data);
                    }
                    else {
                        instance.MapIndividualDetails(data);
                        $("#DuplicateIndividualFound").val(0);
                        toastr.success("Individual added successfully");
                    }
            },
            error: function (exception) {
                console.log(exception);
            }
        }).done(function (data) { console.log(data); $(".progress").addClass('hide'); });
    }

    this.UpdatePurchaserDetails = function () {
        var formData = $("#purchaserFormSold").serialize();
        $.ajax({
            url: instance.save_Purchaser_Url,
            type: "POST",
            data: formData,
            async: true,
            cache: false,
            success: function (data) {
                    instance.MapPurchaserlDetails(data);
                    toastr.success("Purchaser added successfully");
            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }

    this.UpdatePendingPersonDetails = function () {
       // $("#IndividualID").attr('value', data.IndividualID);
       // $("#CurrentIndividualID").attr('value', data.IndividualID);
        $("#IndividualUpdateID").val($("#CurrentIndividualID").val());

        var person = $("#individualFormPending").serialize();
        $.ajax({
            url: instance.save_Individual_Url,
            type: "POST",
            data: person,
            async: true,
            cache: false,
            success: function (data) {
                    if (instance.isArray(data)) {
                        toastr.info("Duplicate record(s) found");
                        instance.updateIndividualRecord = true;
                        instance.LoadDuplicateIndividuals(data);
                    }
                    else {
                        instance.MapIndividualDetails(data);
                        toastr.success("Individual updated successfully");
                    }
            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }

    this.LoadIndividualDetails = function () {

        $.ajax({
            url: instance.get_Individual_Url,
            type: "GET",
            data: {},
            async: true,
            cache: false,
            success: function (data) {
                instance.MapIndividualToPurchaser(data);

            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }

    this.RedirectToDashBoard = function () {
        window.location.href = instance.settings_route + "/Development/Dashboard";
    }

    this.ConvertCurrentDate = function (currentDate, control) {
        if (currentDate == "" || currentDate == null)
        {
            $("#" + control).prop("disabled", true);
            $("#" + control).val("");
        }
        else {
            var convertedCurrentDate = moment(currentDate, 'YYYY-MM-DD').format('DD/MM/YYYY');
            $("#" + control).datepicker("setValue", convertedCurrentDate);
        }
    }

    this.MapIndividualDetails = function (data) {
        console.log(data);
        $('#individualFormReserved').trigger("reset");
        $('#individualFormReserved')[0].reset();
        $("#IndividualID").attr('value', data.IndividualID);
        $("#CurrentIndividualID").attr('value', data.IndividualID);
        $("#txtIndividualName").val(data.IndividualName);
        $("#txtIndividualSurname").val(data.IndividualSurname);
        $("#txtIndividualContactCell").val(data.IndividualContactCell);
        $("#txtIndividualContactWork").val(data.IndividualContactWork);
        $("#txtIndividualEmail").val(data.IndividualEmail);
        var contactMethod = instance.MapPreferedContactMethod(data.PreferedContactMethodID);
        $("#PreferedContactMethodID").val(contactMethod);
        $("#txtPendingPreferedContactMethod").val(contactMethod);
        $("#txtFirstNamePending").val(data.IndividualName);
        $("#txtLastNamePending").val(data.IndividualSurname);
        $("#txtCellNumberPending").val(data.IndividualContactCell);
        $("#txtWorkNumberPending").val(data.IndividualContactWork);
        $("#txtEmailPending").val(data.IndividualEmail);

    }

    this.MapPurchaserlDetails = function (data) {
        console.log(data);
        $('#purchaserFormSold').trigger("reset");
        $('#purchaserFormSold')[0].reset();
        $("#selectPurchaserType").val("" + data.EntityTypeID + "");
        $("#CurrentPurchaserID").attr('value', data.PurchaserID);
        $("#txtPurchaserDescription").val(data.PurchaserDescription);
        $("#txtPurchaserContactPerson").val(data.PurchaserContactPerson);
        $("#txtPurchaserContactCell").val(data.PurchaserContactCell);
        $("#txtPurchaserContactHome").val(data.PurchaserContactHome);
        $("#txtPurchaserContactWork").val(data.PurchaserContactWork);
        $("#txtPurchaserEmail").val(data.PurchaserEmail);
        $("#txtPurchaserAddress").val(data.PurchaserAddress);
        $("#txtPurchaserAddress1").val(data.PurchaserAddress1);
        $("#txtPurchaserAddress2").val(data.PurchaserAddress2);
        $("#txtPurchaserAddress3").val(data.PurchaserAddress3);
        $("#txtPurchaserSuburb").val(data.PurchaserSuburb);
        $("#txtPurchaserPostalCode").val(data.PurchaserPostalCode);
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

    this.MapPreferedContactMethod = function (data) {
        var method = data;
        switch (method) {
            case 1:
                {
                    return 0
                    break;
                }
            case 2:
                {
                    return 2
                    break;
                }

            case 3:
                {
                    return 3
                    break;
                }
            case 4:
                {
                    return 1
                    break;
                }

            default:
                break;

        }
    }

    this.MapUnitDetails = function (data) {
        $("#lblUnitPhase").html(data.UnitPhase);
        $("#lblUnitPrice").html("R " + data.UnitPriceIncluding);
        $("#lblUnitNumber").html(data.UnitNumber);
        $("#lblUnitSize").html(data.UnitSize);
        $("#lblUnitFloor").html(data.UnitFloor);
        $("#lblDevName").html(data.Development);
        $("#lblUnitStatus").html(data.CurrentSalesStatus);
        $("#txtReservationLapses").val(data.ReservationDate);
        $('#txtSignedDate').val(data.DateSignedBySeller);
        $('#txtSaleReservedPanelStatus').val(data.CurrentSalesStatus);
        $('#txtSalePendingPanelStatus').val(data.CurrentSalesStatus);

    }

    this.MapSaleDetails = function (data) {
        console.log(data);

        if (data.CurrentSalesStatusId >= 3) {

            var depositProofID = data.SalesDepositProofID;
            if (depositProofID > 0) {
                $("#showNonCashPaymentSection").removeClass("hide");

                instance.ConvertCurrentDate(data.SaleContractSignedPurchaserDt, "txtPurchaserContractSigned");
                instance.ConvertCurrentDate(data.SalesDepoistPaidDt, "txtDepositPaidDate");
                instance.ConvertCurrentDate(data.SalesDepositProofDt, "txtSalesDepositProofDt");
                $("#txtDepositPaid").val(data.SalesTotalDepositAmount);
                $("#selectSalesDepositProof").val(data.SalesDepositProofID);

                if (data.SaleContractSignedPurchaserDt != null)
                {
                    $("#txtPurchaserContractSigned").addClass("disabledControls");
                    $("#checkPurchaserContractSigned").addClass("disabledControls");
                }

                if (data.SalesDepoistPaidDt != "")
                {
                    $("#txtDepositPaidDate").addClass("disabledControls");
                    $("#checkDepositPaid").addClass("disabledControls");
                }
                   
                if (data.SalesDepositProofDt != "")
                {
                    $("#txtSalesDepositProofDt").addClass("disabledControls");
                    $("#checkSalesDepositProofBt").addClass("disabledControls");
                }
                  
                if (data.SalesTotalDepositAmount != 0)
                    $("#txtDepositPaid").addClass("disabledControls");
                //if (data.SalesDepositProofID != "")
                //    $("#selectSalesDepositProof").addClass("disabledbutton");
               
            }
            else {
                $("#showNonCashPaymentSection").addClass("hide");
            }
        }

        if (data.CurrentSalesStatusId >= 4) {
            instance.ConvertCurrentDate(data.SaleContractSignedSellerDt, "txtSellerContractSignedDate");
            instance.ConvertCurrentDate(data.SalesBondRequiredDt, "txtBondRequiredDate");
            instance.ConvertCurrentDate(data.SalesBondGrantedDt, "txtGranted");
            instance.ConvertCurrentDate(data.SalesBondClientAcceptDt, "txtClientAccepted");
            instance.ConvertCurrentDate(data.SaleBondDueTimeDt, "txtSaleBondDueTime");
            instance.ConvertCurrentDate(data.SaleBondDueExpiryDt, "txtSaleBondDueExpiryDt");
            $("#txtPurchaserContractSigned").removeClass("disabledControls");
            $("#txtDepositPaidDate").removeClass("disabledControls");
            $("#txtSalesDepositProofDt").removeClass("disabledControls");
            $("#txtDepositPaid").removeClass("disabledControls");
            $("#selectSalesDepositProof").removeClass("disabledControls");
            $("#txtSaleBondBank").val(data.SaleBondBank);
            $("#txtSaleBondRequiredAmount").val("R " + data.SaleBondRequiredAmount);
            $("#selectFinanceType").val(data.SaleTypeID);
            if (data.SaleTypeID == 2) {
                $("#divSaleBondDetails").removeClass('show')
                               .addClass('hide');
            }
            if (data.SaleTypeID == 1) {
                $("#divSaleBondDetails").addClass('show')
                .removeClass('hide');
            }
            $("#selectOriginator").val(data.BondOriginatorID);
            $("#txtAmountGranted").val(data.SalesBondAmount);
            $("#txtSaleSoldPanelStatus").val(data.CurrentSalesStatus);
        }
    }

    this.MapBondsDetails = function (data) {
        console.log(data);

        $("#SaleBondsForm input").attr("disabled", true);
        $("#SaleBondsForm select option").prop('disabled', 'disabled');
        $("#SaleBondsForm select").attr("disabled", 'disabled');

        $("#txtSaleBondBank").val(data.SaleBondBank);
        $("#txtSalesBondAccountNo").val(data.SalesBondAccountNo);
        $("#txtSalesBondAmount").val("R " + data.SalesBondAmount);
        $("#txtSalesBondInterestRate").val(data.SalesBondInterestRate + " %");
        var item = $("#selectOriginator").val;
        if (data.SalesBondGrantedBt == 1)
            $("#checkSalesBondGrantedBt").prop('checked', true);
        else
            $("#checkSalesBondGrantedBt").prop('checked', false);
        if (data.SalesBondClientAcceptBt == 1)
            $("#checkSalesBondClientAcceptBt").prop('checked', true);
        else
            $("#checkSalesBondClientAcceptBt").prop('checked', false);
        if (data.SalesBondClientContactedBt == 1)
            $("#checkSalesBondClientContactedBt").prop('checked', true);
        else
            $("#checkSalesBondClientContactedBt").prop('checked', false);
        if (data.SalesBondBondDocsRecBt == 1)
            $("#checkSalesBondBondDocsRecBt").prop('checked', true);
        else
            $("#checkSalesBondBondDocsRecBt").prop('checked', false);

        instance.ConvertCurrentDate(data.SalesBondClientAcceptDt, "txtClientAccepted");
        instance.ConvertCurrentDate(data.SalesBondClientContactedDt, "txtSalesBondClientContactedDt");
        instance.ConvertCurrentDate(data.SalesBondBondDocsRecDt, "txtSalesBondBondDocsRecDt");
        instance.ConvertCurrentDate(data.OriginatorTrSubmittedDt, "txtOriginatorTrSubmittedDt");
        instance.ConvertCurrentDate(data.OriginatorTrAIPDt, "txtOriginatorTrAIPDt");
        instance.ConvertCurrentDate(data.OriginatorTrGrantDt, "txtOriginatorTrGrantDt");
        instance.ConvertCurrentDate(data.OriginatorTrAcceptDt, "OriginatorTrAcceptDt");

    }

    this.GetSaleTypes = function (data) {
        $("#selectFinanceType option").remove();
        $("#selectFinanceType").append('<option value=' + 0 + '>' + "[ select finance type ]" + '</option>');
        $("#selectFinanceType option:first").attr('disabled', true);
        $.each(data, function (index, item) {
            var index = index + 1;
            $("#selectFinanceType").append('<option value=' + index + '>' + item + '</option>');
        });

    }

    this.GetDepositProofTypes = function (data) {
        $("#selectSalesDepositProof option").remove();
        //$("#selectSalesDepositProof").append('<option>' + "[ Select ]" + '</option>');
        $.each(data, function (index, item) {
            $("#selectSalesDepositProof").append('<option value=' + index + '>' + item + '</option>');
        });

        $("#selectSalesDepositProof").val(2);

    }

    this.GetPurchaserEntityTypes = function (data) {
        $("#selectPurchaserType option").remove();
        $("#selectPurchaserType").append('<option value=' + 0 + '>' + "[ select purchaser type ]" + '</option>');
        $.each(data, function (index, item) {
            var index = index + 1;
            $("#selectPurchaserType").append('<option value=' + index + '>' + item + '</option>');
        });
        $("#selectPurchaserType option:first").attr('disabled', true);
    }

    this.GetReservedPreferedContactTypes = function (data) {
        $("#PreferedContactMethodID option").remove();
        $.each(data, function (index, item) {
            $("#PreferedContactMethodID").append('<option value=' + index + '>' + item + '</option>');
        });
    }

    this.GetPendingPreferedContactTypes = function (data) {
        $("#txtPendingPreferedContactMethod option").remove();
        $.each(data, function (index, item) {
            $("#txtPendingPreferedContactMethod").append('<option value=' + index + '>' + item + '</option>');
        });
    }

    this.GetCompanyOrginators = function (data) {
        $("#selectOriginator option").remove();
        $.each(data, function (index, item) {
            $("#selectOriginator").append('<option value=' + index + '>' + item + '</option>');

        });
    }

    this.LoadSaleTypes = function () {
        $.ajax({
            url: instance.getSaleTypes_Url,
            type: "GET",
            data: {},
            async: true,
            cache: false,
            success: function (data) {
                instance.GetSaleTypes(data);
            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }

    this.LoadContactPreferedTypes = function () {
        $.ajax({
            url: instance.getPreferedContactTypes_Url,
            type: "GET",
            data: {},
            async: true,
            cache: false,
            success: function (data) {
                instance.GetReservedPreferedContactTypes(data);
                instance.GetPendingPreferedContactTypes(data);
            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }

    this.LoadDepositProofTypes = function () {
        $.ajax({
            url: instance.getDepositProofTypes_Url,
            type: "GET",
            data: {},
            async: true,
            cache: false,
            success: function (data) {
                instance.GetDepositProofTypes(data);
            },
            error: function (exception) {
                console.log(exception);
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

    this.LoadCompanyOrginators = function () {
        $.ajax({
            url: instance.getCompanyOrginator_Url,
            type: "GET",
            data: {},
            async: true,
            cache: false,
            success: function (data) {
                instance.GetCompanyOrginators(data);
            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }
}






