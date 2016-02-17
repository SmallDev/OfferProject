OffersListviewModel = kendo.observable({
    isVisible: function () {
        var totalCount = 0;
        jQuery.ajax({
            url: "/Offers/GetOffersTotalCount",
            success: function (data) {
                totalCount = data;
            },
            async: false
        });

        return totalCount > 0;
    },
    offersListData: new kendo.data.DataSource({
        serverPaging: true,
        pageSize: 15,
        schema: {
            total: function () {
                var totalCount = 0;
                jQuery.ajax({
                    url: "/Offers/GetOffersTotalCount",
                    success: function (data) {
                        totalCount = data;
                    },
                    async: false
                });

                return totalCount;
            },
            data: "Offers"
        },
        transport: {
            read: function (options) {
                var pageSize = options.data.pageSize;
                var currentPage = options.data.page;

                $.get( "/Offers/ListOffers", { page: currentPage, pageSize: pageSize} )
                 .done(function( data ) {
                     options.success(data);
                 });
            }
        }
    
    })
});
