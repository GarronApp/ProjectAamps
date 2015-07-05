function Resources()
{
    var instance = this;

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

    this.loadSelectControl = function (control,data) {
        $("#" + control +  "option").remove();
        $.each(data, function (index, item) {
            $("#" + control).append('<option value=' + index + '>' + item + '</option>');
        });
    }
    
    this.convertCurrentDate = function (currentDate, control) {
        if (currentDate == "" || currentDate == null || currentDate == 'undefined') {
            $("#" + control).prop("disabled", true);
            $("#" + control).val("");
        }
        else {
            var convertedCurrentDate = moment(currentDate, 'YYYY-MM-DD').format('DD/MM/YYYY');
            $("#" + control).datepicker("setValue", convertedCurrentDate);
        }
    }

    this.formatNumber = function(num) {
        return "R " + num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,")
    }

    this.formatTableColumnRandValue = function(tableID, columnIndex, element)
    {
        $("table#" + tableID + "> tbody > tr").each(function () {
            $(this).find('td:eq(' + columnIndex + ')').html(instance.formatNumber($("#" + element).html()));
        });
    }

    this.formatTableColumnDateValue = function (tableID, columnIndex, element) {
        $("table#" + tableID + "> tbody > tr").each(function () {
            var currentDate = $(this).find('td:eq(' + columnIndex + ')').html();
            var convertedCurrentDate = moment(currentDate, 'YYYY-MM-DD hh:mm A').format('DD/MM/YYYY');
            if (convertedCurrentDate == "01/01/0000")
            {
                $(this).find('td:eq(' + columnIndex + ')').html("");
            }
            else {
                $(this).find('td:eq(' + columnIndex + ')').html(convertedCurrentDate);
            }
               
        });
    };
    
    this.MaskCellPhone = function () {
        $(".cellphone").mask('000 000 0000');
    }

    this.MaskWorkPhone = function () {
        $(".workphone").mask('(000) 000 0000');
    }

    this.validateEmailAddress = function (email) {
        var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        return filter.test(email);
     }

    this.redirectToDashBoard = function (url) {
        window.location.href = url;
        return true;
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

    this.getSelectTypesData = function (control,url) {
        $.ajax({
            url: url,
            type: "GET",
            data: {},
            async: true,
            cache: false,
            success: function (data) {
                instance.loadSelectControl(control,data);
            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }

}
