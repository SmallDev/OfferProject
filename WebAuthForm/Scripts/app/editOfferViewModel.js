function EditOfferViewModel(){
    this.IdOffer = null;
    this.IdUser = null;
    this.NameOffer = null;
    this.Description = null;
    this.Date = null;
    this.Type = null;
    this.State = null;
    this._validator = null;
    this.modelIsValid = null;

    this.resetVM = function () {
        this.IdOffer = null;
        this.IdUser = null;
        this.NameOffer = null;
        this.Description = null;
        this.Date = null;
        this.Type = null;
        this.State = null;
        this._validator = null;
    };

    this._getOffer = function(offerId){
        var offer;
        jQuery.ajax({
            url: "/Offers/GetOffer",
            success: function(data) {
                offer = data;
            },
            data: { id: offerId },
            async: false,
            cache: false
        });

        return offer;
    }

    this.setOfferData = function (offerId, validator) {

        var data = this._getOffer(offerId);

        this.resetVM();
        this.IdOffer = data.IdOffer;
        this.IdUser = data.IdUser;
        this.NameOffer = data.NameOffer;
        this.Description = data.Description;
        this.Date = data.Date;
        this.Type = data.Type;
        this.State = data.State;
        this._validator = validator;
    };

    this.validate = function () {
        this.set("modelIsValid", this._validator.validate());
    };

    this.getOfferData = function () {
        return {
            IdOffer: this.IdOffer,
            IdUser: this.IdUser,
            NameOffer: this.NameOffer,
            Description: this.Description,
            Date: typeof this.Date === 'string' ? this.Date : _getDate(this.Date),
            Type: this.Type,
            State: this.State
        }
    };

    function _getDate(offerDate) {
        var tempMonth = offerDate.getMonth() + 1;
        var month = tempMonth.toString().length === 2 ? tempMonth : '0' + tempMonth;

        var tempDeys = offerDate.getDate();
        var days = tempDeys.toString().length === 2 ? tempDeys : '0' + tempDeys;

        return month + "." + days + "." + offerDate.getFullYear();
    }

    this.saveOffer = function () {
        if (this._validator.validate()) {
            jQuery.ajax({
                url: "/Offers/SaveOffer",
                type: "post",
                cache: false,
                data: this.getOfferData(),
                success: function (data) {
                    window.location = "/Offers/Offers";
                },
                async: false
            });
        }
    };

    this.cancel = function () {
        window.location = "/Offers/Offers";
    };

    this.onChangeInput = function () {
        this.set("modelIsValid", this._validator.validate());
    };

    this.offerTypes = [1, 2, 3, 4];
};