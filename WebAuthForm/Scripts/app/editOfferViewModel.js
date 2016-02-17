EditOfferViewModel = kendo.observable({
    IdOffer: null,
    IdUser: null,
    NameOffer: null,
    Description: null,
    Date: null,
    Type: null,
    State: null,
    _validator: null,

    resetVM: function () {
        this.IdOffer = null;
        this.IdUser = null;
        this.NameOffer = null;
        this.Description = null;
        this.Date = null;
        this.Type = null;
        this.State = null;
        this._validator = null;
    },

    setOfferData: function (data, validator) {
        this.resetVM();
        this.IdOffer = data.IdOffer;
        this.IdUser = data.IdUser;
        this.NameOffer = data.NameOffer;
        this.Description = data.Description;
        this.Date = data.Date;
        this.Type = data.Type;
        this.State = data.State;
        this._validator = validator;
    },

    getOfferData: function ()
    {
        return {
            IdOffer: this.IdOffer,
            IdUser: this.IdUser,
            NameOffer: this.NameOffer,
            Description: this.Description,
            Date: this.Date.toISOString().substring(0, 10),
            Type:this.Type,
            State:this.State
        }
    },

    saveOffer: function () {
        if(this._validator.validate()) {
            $.post("/Offers/SaveOffer", this.getOfferData());
            window.location.href = "/Offers/Offers";
        }
    },

    offerTypes: [1, 2, 3, 4]
});