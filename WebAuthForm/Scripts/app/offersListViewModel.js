function OffersListViewModel() {

    this.editOffer = function (eventArgs) {
        offerToEdit = eventArgs.sender.dataItem(eventArgs.sender.select());
        this.set("needToBeUpdated", true);
        window.location = "/Offers/EditOffer?id=" + offerToEdit.IdOffer;
    };
    this.isVisible = function () {
        var totalCount = 0;
        jQuery.ajax({
            url: "/Offers/GetOffersTotalCount",
            success: function (data) {
                totalCount = data;
            },
            cache: false,
            async: false
        });

        return totalCount > 0;
    };
    this.offersListData = new kendo.data.DataSource({
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
                    async: false,
                    cache: false
                });

                return totalCount;
            },
            data: "Offers"
        },
        transport: {
            read: function (options) {
                var pageSize = options.data.pageSize;
                var currentPage = options.data.page;

                jQuery.ajax({
                    url: "/Offers/ListOffers",
                    type: "GET",
                    data: { page: currentPage, pageSize: pageSize },
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
