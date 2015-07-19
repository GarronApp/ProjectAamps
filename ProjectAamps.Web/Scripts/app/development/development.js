function Development()
{
    var instance = this;
    instance.settings_route = "";

    instance.get_Agents_Url = instance.settings_route + "/Development/GetDevelopmentAgents";
    instance.get_AgentsUnits_Url = instance.settings_route + "/Development/GetAgentUnits?agent=";
    instance.get_AvailableUnits_Url = instance.settings_route + "/Development/GetAvailableUnits";

    this.load = function () {

        instance.registerEvents();
        instance.LoadAgents();
    }

    this.registerEvents = function()
    {
        $('.thumbnail').hover(
        function () {

            $(this).find('.caption').fadeIn(150); //.fadeIn(250)
        },
        function () {
            $(this).find('.caption').fadeOut(150); //.fadeOut(205)
        }
        )

        $('#selectfilteragentunits').on('change', function () {

            var selectedValue = this.value;
            if (selectedValue == 0) {
                instance.LoadAgentUnits(null);
            }
            else {
                var option = $('option:selected', this).attr('agentId');
                instance.LoadAgentUnits(option);
            }
        });

        $("#btnAvailableUnits").click(function () {
            instance.LoadAvailableUnits();
            $('#ReservationDetailsModal').modal('show');
        });

        instance.LoadDevelopmentSummary();

    }

    this.LoadDevelopmentSummary = function()
    {
        var items = [];
        $.getJSON("GetTotals", function (data) {

            items.push(data);
            console.log(data)
            var chart = c3.generate({
                size: {
                    height: 180,
                    width: 360
                },
                data: {
                    columns: [
                          [data[0].series, data[0].data],
                          [data[2].series, data[2].data],
                          [data[1].series, data[1].data],
                          [data[3].series, data[3].data],
                    ],
                    type: 'bar',
                },

            });
        });
        $.ajax({
            url: '@Url.Action("GetDevelopmentSummary", "Development")',
            type: 'GET',
            datatype: 'json',
            data: {},
            success: function (data) {

                $("#lblDevName").html(data.DevelopmentDescription);
                $("#lblEstateName").html(data.EstateName);
                $("#lblTotalUnits").html(data.TotalUnits);
                $("#lblTotalPending").html(data.PendingStatusCount);
                $("#lblTotalReserved").html(data.ReservedStatusCount);
                $("#lblTotalSold").html(data.SoldStatusCount);

            }
        });
    }

    this.MapAgents = function (data) {
        console.log(data);
        $("#selectfilteragentunits option").remove();
        $("#selectfilteragentunits").append('<option value=' + 0 + '>' + "-- All Agents --" + '</option>');
        $.each(data, function (index, item) {
            console.log(item);
            var index = index + 1;
            $("#selectfilteragentunits").append('<option agentId=' + item.UserListID + ' value=' + index + '>' + item.UserListName + ' ' + item.UserListSurname + '</option>');
        });
        $('.selectpicker').selectpicker('refresh');
    }

    this.LoadAgentUnits = function (option) {
        var agent = option;
        $(".progress").removeClass('hide');
        $("#divAgentUnitsResults").html("");
        $.ajax({
            url: instance.get_AgentsUnits_Url + agent,
            type: "POST",
            data: {},
            async: true,
            cache: false,
            success: function (data) {
                console.log(data);
                //setTimeout(function () { $(".progress").removeClass('hide'); $("#divAgentUnitsResults").html(data); }, 5000);
                $("#divAgentUnitsResults").html(data);
                
            },
            error: function (exception) {
                console.log(exception);
            }
        }).done(function (data) {
            $(".progress").addClass('hide');
        });
           
    };

    this.LoadAgents = function () {
        $.ajax({
            url: instance.get_Agents_Url,
            type: "GET",
            data: {},
            async: true,
            cache: false,
            success: function (data) {
                console.log(data);
                instance.MapAgents(data);
            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }

    this.LoadAvailableUnits = function () {
        $.ajax({
            url: instance.get_AvailableUnits_Url,
            type: "GET",
            data: {},
            async: true,
            cache: false,
            success: function (data) {
                console.log(data);
                $("#divAvailableUnits").html(data);
                $('#ReservationDetailsModal').modal('show');
            },
            error: function (exception) {
                console.log(exception);
            }
        });
    }
}