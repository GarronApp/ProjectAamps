function Resources()
{
    var instance;

    this.load = function()
    {
        instance = this;

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
