EditOfferViewModel = kendo.observable({
    IdOffer: null,
    IdUser: null,
    NameOffer: null,
    Description: null,
    Date: null,
    Type: null,
    State: null,
    _validator: null,
    modelIsValid: null,

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
        this.set("IdOffer", data.IdOffer);
        this.set("IdUser", data.IdUser);
        this.set("NameOffer", data.NameOffer);
        this.set("Description", data.Description);
        this.set("Date", data.Date);
        this.set("Type", data.Type);
        this.set("State", data.State);
        this._validator = validator;
    },

    validate: function (){
        this.set("modelIsValid", this._validator.validate());
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
        if (this._validator.validate()) {
            $.post("/Offers/SaveOffer", this.getOfferData());
            window.location.href = "/Offers/Offers";
        }
    },

    cancel: function () {
        window.location.href = "/Offers/Offers";
    },

    onChangeInput: function(){
        this.set("modelIsValid", this._validator.validate());
    },

    offerTypes: [1, 2, 3, 4]
});