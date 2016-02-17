using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayerLibrary.Domain.Model;

namespace WebAuthForm.Models
{
    public class OfferViewModel
    {
        public int IdOffer { get; set; }

        public int IdUser { get; set; }

        [Required]
       /* [StringLength(100)]
        [Remote("IsNameAlreadyExists", "Offers", ErrorMessage = "NameAlreadyExists!!!")]*/
        public string NameOffer { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        public string Date { get; set; }

        public short Type { get; set; }

        [StringLength(20)]
        public string State { get; set; }


        public static OfferViewModel ConvertToOfferViewModel(Offer offer)
        {
            return new OfferViewModel
            {
                IdOffer = offer.IdOffer,
                IdUser = offer.IdUser,
                Type = offer.Type,
                NameOffer = offer.NameOffer,
                Description = offer.Description,
                Date = offer.Date.ToShortDateString()
             };
        }

        public static Offer ConvertToOffer(OfferViewModel offerViewModel)
        {
            return new Offer
            {
                IdOffer = offerViewModel.IdOffer,
                IdUser= offerViewModel.IdUser,
                NameOffer = offerViewModel.NameOffer,
                Description = offerViewModel.Description,
                Date = DateTime.Parse(offerViewModel.Date, CultureInfo.CurrentCulture),
                Type = offerViewModel.Type
            };
        }
    }
}