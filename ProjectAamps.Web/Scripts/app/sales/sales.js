﻿function Sales() {

    var instance = this;
    instance.save_Reservation_Url = "/Sales/SaveAvailableReservation";
    instance.save_ReservedSale_Url = "/Sales/UpdateReservedSale"
    instance.save_PendingSale_Url = "/Sales/UpdatePendingSale";
    instance.save_Individual_Url = "/Sales/SaveIndividual";
    instance.getAgentDetails_Url = "/Sales/GetAgentSaleDetails";
    instance.getSaleTypes_Url = "/Sales/GetSaleTypes";
    instance.getPreferedContactTypes_Url = "/Sales/GetPreferedContactMethods";
    instance.getDepositProofTypes_Url = "/Sales/GetSaleDepositProofs";
    instance.getCompanyOrginator_Url = "/Sales/GetCompanyOriginator";
    

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

        $('#checkPurchaserContractSignedDatePending').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtPurchaserContractSignedDatePending").prop("disabled", true);
                $("#txtPurchaserContractSignedDatePending").val("");
            }
            else {
                $("#txtPurchaserContractSignedDatePending").prop("disabled", false);
                $("#txtPurchaserContractSignedDatePending").datepicker("setValue", new Date());
            }
        });

        $('#checkPurchaserContractSigned').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtPurchaserContractSigned").prop("disabled", true);
                $("#txtPurchaserContractSigned").val("");
            }
            else {
                $("#txtPurchaserContractSigned").prop("disabled", false);
                var dateToday = new Date();
                var convertDateToday = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
                $("#txtPurchaserContractSigned").datepicker("setValue", convertDateToday);
            }
        });

        $('#checkHasPaidDeposit').change(function(){
            if (!$(this).is(':checked')) {
                

            }
            else {
                

            }
        });

        $('#checkDepositPaid').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtDepositPaidDate").prop("disabled", true);
                $("#txtDepositPaidDate").val("");
                $("#showNonCashPaymentSection").addClass('hide');
                $(this).val(0);
            }
            else {
                $(this).val(1);
                $("#txtDepositPaidDate").prop("disabled", false);
                var dateToday = new Date();
                var convertDateToday = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
                $("#txtDepositPaidDate").datepicker("setValue", convertDateToday);
                $("#showNonCashPaymentSection").removeClass('hide');
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

        $('#checkSalesDepositProofBt').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtSalesDepositProofDt").prop("disabled", true);
                $("#txtSalesDepositProofDt").val("");
                $(this).val(0);
            }
            else{
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
                $("#txtBondRequiredDate").val("");
                $(this).val(0);
            }
            else {
                $(this).val(1);
                $("#txtBondRequiredDate").prop("disabled", false);
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
                $("#txtSellerContractSignedDate").prop("disabled", true);
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

        $('#checkGranted').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtGranted").prop("disabled", true);
                $("#txtGranted").val("");
            }
            else {
                $("#txtGranted").prop("disabled", false);
                var dateToday = new Date();
                var convertDateToday = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
                $("#txtGranted").datepicker("setValue", convertDateToday);
            }
        });

        $('#checkClientAccepted').change(function () {
            if (!$(this).is(':checked')) {
                $("#txtClientAccepted").prop("disabled", true);
                $("#txtClientAccepted").val("");
            }
            else {
                $("#txtClientAccepted").prop("disabled", false);
                var dateToday = new Date();
                var convertDateToday = moment(reservationDate, 'DD/MM/YYYY').format('DD/MM/YYYY');
                $("#txtClientAccepted").datepicker("setValue", convertDateToday);
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

        //$('#selectSalesDepositProof').on('change', function () {
        //    var selectedItem = $(this).val();
        //    if(selectedItem > 0)
        //        $("#showNonCashPaymentSection").removeClass("hide");
        //    else
        //        $("#showNonCashPaymentSection").addClass("hide");
        //});

        $("#btnUpdateReservation").click(function () {
            
            if (instance.validateClient()) {
                instance.UpdateReservationDetails();
            }
            else {
                alert("please complete required fields*");
            }
        });



        $("#btnUpdateReservedSale").click(function () {
            if (instance.validateReservedSale()) {

                instance.UpdateReservedSale();
            }
            else {
                alert("please complete required fields*");
            }
        });

        $("#btnUpdatePendingSale").click(function () {
            instance.UpdatePendingSale();
        });

        $("#btnReservedUpdatePersonDetails").click(function () {
            instance.UpdateIndividualDetails();
        });
        $("#btnPendingUpdatePersonDetails").click(function () {
            instance.UpdatePendingPersonDetails();
        });

        instance.LoadSaleTypes();
        instance.LoadContactPreferedTypes();
        instance.LoadDepositProofTypes();
        instance.LoadCompanyOrginators();
        instance.initializeSaleDetails();

    }

    this.initializeSaleDetails = function(){
        $.ajax({
            url: instance.getAgentDetails_Url,
            type: 'GET',
            datatype: 'json',
            data: {},
            success: function (data) {
                console.log("response...");
                console.log(data);
                if (data.IsNewSale != "NewSale") {
                    instance.MapUnitDetails(data);
                    instance.MapIndividualDetails(data);
                    instance.MapSaleDetails(data);
                    instance.MapPurchaserlDetails(data);
                    var saleStatus = data.CurrentSalesStatusId;
                    console.log(saleStatus);
                    if (saleStatus == 1) {

                        $('#txtSaleReservedPanelStatus').val(data.CurrentSalesStatus);

                        $("#SaleReservedForm input").attr("disabled", false);
                        $("#SaleReservedForm select").prop('disabled', false);

                        $("#individualFormReserved input").attr("disabled", false);
                        $("#individualFormReserved select").attr("disabled", false);

                        $("#soldPanel").addClass("disabledbutton");
                        $("#pendingPanel").addClass("disabledbutton");
                    }
                    if (saleStatus == 2) {

                        $('#txtSaleReservedPanelStatus').val(data.CurrentSalesStatus);
                        $('#txtSalePendingPanelStatus').val(data.CurrentSalesStatus);

                        $("#SaleReservedForm input").attr("disabled", true);
                        $("#SaleReservedForm select option").prop('disabled', 'disabled');

                        $("#individualFormReserved input").attr("disabled", true);
                        $("#individualFormReserved select").attr("disabled", 'disabled');

                        $("#SalePendingForm input").attr("disabled", false);
                        $("#SalePendingForm select").prop("disabled", false);
                        $("#SalePendingForm select option").prop("disabled", false);

                        $("#individualFormPending input").attr("disabled", true);
                        $("#individualFormPending select").prop("disabled", true);
                        $("#individualFormPending select option").prop("disabled", true);

                        $("#pendingPanel").removeClass("disabledbutton");
                        $("#soldPanel").addClass("disabledbutton");
                    }
                    if (saleStatus == 3) {

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

                        $("#SaleSoldForm input").attr("disabled", false);
                        $("#SaleSoldForm select").prop("disabled", false);
                        $("#SaleSoldForm select option").prop("disabled", false);

                        $("#purchaserFormSold input").attr("disabled", false);
                        $("#purchaserFormSold select").prop("disabled", false);
                        $("#purchaserFormSold select option").prop("disabled", false);

                        $("#pendingPanel").removeClass("disabledbutton");
                        $("#soldPanel").removeClass("disabledbutton");
                    }

                    if (saleStatus >= 4) {
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

                    }
                }
                else {

                    console.log(data);
                    $("#lblUnitPhase").html(data.UnitPhase);
                    $("#lblUnitPrice").html("R " + data.UnitPrice);
                    $("#lblUnitNumber").html(data.UnitNumber);
                    $("#lblUnitSize").html(data.UnitSize);
                    $("#lblUnitFloor").html(data.UnitFloor);

                    $('#txtSaleReservedPanelStatus').val("Available");
                    $("#SaleReservedForm input").attr("disabled", false);
                    $("#SaleReservedForm select").prop('disabled', false);
                    $("#SaleReservedForm select option").prop('disabled', false);

                    $("#individualFormReserved input").attr("disabled", false);
                    $("#individualFormReserved select").attr("disabled", false);
                    $("#individualFormReserved select option").attr("disabled", false);

                    $("#soldPanel").addClass("disabledbutton");
                    $("#pendingPanel").addClass("disabledbutton");

                }
            },
            error: function (data) {
                console.log(data);
            }
        });
    }

    this.validateReservedSale = function () {
        var form = $("#SalePendingForm").serializeArray();
        var validForm = true;
        for (var i = 0; i < form.length; i++) {
            if (form[i].value === '') {
                validForm = false;
                break;
            }
        }
        return validForm;
    };

    
    this.validateClient = function () {
        var form = $("#individualFormReserved").serializeArray();
        var validForm = true;
        for (var i = 0; i < form.length; i++) {
            if (form[i].value === '') {
                validForm = false;
                break;
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
        var formData = $("#SalePendingForm").serialize();
        $.ajax({
            url: instance.save_ReservedSale_Url,
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

    this.UpdatePendingSale = function () {
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

    this.UpdateIndividualDetails = function () {
        var formData = $("#individualFormReserved").serialize();
        $.ajax({
            url: instance.save_Individual_Url,
            type: "POST",
            data: formData,
            async: true,
            cache: false,
            success: function (data) {
                instance.MapIndividualDetails(data);
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
                instance.MapIndividualDetails(data);
                
            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }

    this.RedirectToDashBoard = function () {
        window.location.href = "/Development/Dashboard";
    }

    this.ConvertCurrentDate = function (currentDate, control) {
        var convertedCurrentDate = moment(currentDate, 'DD-MM-YYYY').format('DD/MM/YYYY');
        var convertedCurrentDate = moment(currentDate, 'YYYY-MM-DD').format('DD/MM/YYYY');
        $("#" + control).datepicker("setValue", convertedCurrentDate);
    }

    this.MapIndividualDetails = function (data) {
        console.log(data);
        $('#individualFormReserved').trigger("reset");
        $('#individualFormReserved')[0].reset();
        $("#IndividualID").attr('value',data.IndividualID);
        $("#CurrentIndividualID").attr('value', data.IndividualID);
        $("#txtFirstNameReserved").val(data.IndividualName);
        $("#txtLastNameReserved").val(data.IndividualSurname);
        $("#txtCellNumberReserved").val(data.IndividualContactCell);
        $("#txtWorkNumberReserved").val(data.IndividualContactWork);
        $("#txtEmailReserved").val(data.IndividualEmail);
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
        $("#CurrentIndividualID").attr('value', data.PurchaserDescription);
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
        $("#lblUnitPrice").html("R " + data.UnitPrice);
        $("#lblUnitNumber").html(data.UnitNumber);
        $("#lblUnitSize").html(data.UnitSize);
        $("#lblUnitFloor").html(data.UnitFloor);
        $("#lblDevName").html(data.Development);
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
                $("#txtDepositPaid").val(data.SalesBondAmount);
                $("#selectSalesDepositProof").val(data.SalesDepositProofID);
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
            $("#txtSaleBondRequiredAmount").val(data.SaleBondRequiredAmount);
            $("#selectFinanceType").val(data.SaleTypeID);
            $("#selectOriginator").val(data.BondOriginatorID);
            $("#txtAmountGranted").val(data.SalesBondAmount);
            $("#txtSaleSoldPanelStatus").val(data.CurrentSalesStatus);
        }
    }

    this.GetSaleTypes = function (data)
    {
        $("#selectFinanceType option").remove(); 
        $.each(data, function (index, item) { 
            $("#selectFinanceType").append('<option value=' + index + '>' + item + '</option>');
        });
    }

    this.GetDepositProofTypes = function (data) {
        $("#selectSalesDepositProof option").remove();
        //$("#selectSalesDepositProof").append('<option>' + "[ Select ]" + '</option>');
        $.each(data, function (index, item) {
            $("#selectSalesDepositProof").append('<option value=' + index + '>' + item + '</option>');
        });
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

    this.LoadSaleTypes = function()
    {
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
};




