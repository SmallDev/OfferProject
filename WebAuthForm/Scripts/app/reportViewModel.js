function ReportViewModel() {
    this.barChartIsVisible = true;
    this.pieChartIsVisible = false;

    this.showBarChart = function () {
        this.set("barChartIsVisible", true);
        this.set("pieChartIsVisible", false);
    };

    this.showPieChart = function () {
        this.set("barChartIsVisible", false);
        this.set("pieChartIsVisible", true);
    };

    this.offers = new kendo.data.DataSource({
        transport: {
            read: function (options) {
                jQuery.ajax({
                    url: "/Offers/GetOffersStat",
                    type: "GET",
                    success: function (data) {
                        options.success(data);
                    },
                    async: false,
                    cache: false
                });
            }
        }
    })
}
