using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayerLibrary.Domain.Model;

namespace WebAuthForm.Models
{
    public class OfferListViewModel
    {
        public Paging Paging { get; set; }
        public List<OfferViewModel> Offers { get; set; }

        public static OfferListViewModel CreateOfferListViewModel(int page,int pageSize,long countOffers,int totalPagesCount,List<Offer> items)
        {
            var model=new OfferListViewModel();
            
            model.Paging = Paging.CreatePaging(page, countOffers, pageSize, totalPagesCount);
            model.Offers = new List<OfferViewModel>();
            foreach (Offer DMOffer in items)
            {
                OfferViewModel tempOffer = OfferViewModel.ConvertToOfferViewModel(DMOffer);
                model.Offers.Add(tempOffer);
            }
            
            return model;
        }

    }
}