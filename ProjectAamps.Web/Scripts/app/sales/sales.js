function Sales() {

    var instance = this;
    instance.save_Reservation_Url = "/Sales/SaveAvailableReservation";
    instance.save_ReservedSale_Url = "/Sales/UpdateReservedSale"
    instance.save_PendingSale_Url = "/Sales/UpdatePendingSale";
    instance.save_Individual_Url = "/Sales/SaveIndividual";
    instance.getAgentDetails_Url = "/Sales/GetAgentSaleDetails";
    instance.getSaleTypes_Url = "/Sales/GetSaleTypes";
    instance.getPreferedContactTypes_Url = "/Sales/GetPreferedContactMethods";
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

        $("#btnUpdateReservedSale").click(function () {
            instance.UpdateReservedSale();
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
                if (data != "NewSale") {
                    instance.MapUnitDetails(data);
                    instance.MapIndividualDetails(data);
                    instance.MapSaleDetails(data);
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

                        $("#individualFormPending input").attr("disabled", false);
                        $("#individualFormPending select").prop("disabled", false);
                        $("#individualFormPending select option").prop("disabled", false);

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
                        $("#SalePendingForm select option").prop("disabled", 'disabled');

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
                        $("#SalePendingForm select option").prop("disabled", 'disabled');

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
            instance.MapIndividualDetails(data);
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

    this.MapIndividualDetails = function (data) {
        $('#individualFormReserved').trigger("reset");
        $('#individualFormReserved')[0].reset();
        $("#txtFirstNamePending").val(data.IndividualFirstName);
        $("#txtLastNamePending").val(data.IndividualLastName);
        $("#txtCellNumberPending").val(data.IndividualCellNo);
        $("#txtWorkNumberPending").val(data.IndividualWorkNo);
        $("#txtEmailPending").val(data.IndividualEmailAddress);
        $("#txtFirstNameReserved").val(data.IndividualFirstName);
        $("#txtLastNameReserved").val(data.IndividualLastName);
        $("#txtCellNumberReserved").val(data.IndividualCellNo);
        $("#txtWorkNumberReserved").val(data.IndividualWorkNo);
        $("#txtEmailReserved").val(data.IndividualEmailAddress);
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
        $("#txtSaleSoldPanelStatus").val(data.CurrentSalesStatus);
        $("#txtSellerContractSignedDate").val(data.SaleContractSignedSellerDt);
        $("#txtPurchaserContractSignedDate").val(data.SaleContractSignedPurchaserDt);
        $("#SalesBondClientAcceptDt").val(data.SalesBondClientContactedDt);
        $("#txtSellerContractSignedDate").val(data.SalesBondBondDocsRecDt);
        $("#txtGranted").val(data.SalesBondGrantedDt);
        $("#txtSellerContractSignedDate").val(data.SalesBondClientAcceptDt);
        $("#SalesBondRequiredDt").val(data.SalesBondRequiredDt);
        $("#txtAmountGranted").val(data.SalesBondAmount);

    }

    this.GetSaleTypes = function (data)
    {
        $("#selectFinanceType option").remove(); 
        $.each(data, function (index, item) { 
            $("#selectFinanceType").append('<option value=' + index + '>' + item + '</option>');
        });
    }

    this.GetPreferedContactTypes = function (data) {
        $("#PreferedContactMethodID option").remove();
        $.each(data, function (index, item) {
            $("#PreferedContactMethodID").append('<option value=' + index + '>' + item + '</option>');
            $("#PreferedContactMethod").append('<option value=' + index + '>' + item + '</option>');
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
                instance.GetPreferedContactTypes(data);
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




