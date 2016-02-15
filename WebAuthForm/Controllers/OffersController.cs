using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using BusinessLayerLibrary.Domain.Model;
using BusinessLayerLibrary.Facades;
using WebAuthForm.Models;

namespace WebAuthForm.Controllers
{
    public class OffersController : Controller
    {

        public OfferFacade OfferService { get; set; }

        public OffersController(OfferFacade offerFac)
        {
            this.OfferService = offerFac;
        }

        public ActionResult Offers()
        {
            return View();
        }

        public ActionResult ListOffers(int page=1, int pageSize=5)
        {
            var countOffers = OfferService.GetOffersCount();
            var totalPagesCount = (int)Math.Ceiling(1D * countOffers / pageSize);
            if (page > totalPagesCount) page = 1;
            var items = OfferService.GetOffers(page, pageSize).ToList<Offer>();

            var model = OfferListViewModel.CreateOfferListViewModel(page, pageSize,countOffers,totalPagesCount,items);
            return Json( model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id = 0)
        {
            OfferViewModel offerVM=new OfferViewModel();
            if (id > 0)
            {
                var offer = OfferService.GetOffer(id);
                offerVM = OfferViewModel.ConvertToOfferViewModel(offer);
            }
            return View("EditOffer", offerVM);
        }

        [HttpPost]
        public ActionResult Edit(OfferViewModel offerViewModel)
        {
            ModelState.Clear();
            var offer = OfferViewModel.ConvertToOffer(offerViewModel);
            if (!OfferService.Save(offer))
            {
                if ((offer.IdOffer == 0) && (OfferService.ExistOffers(offer.NameOffer)))
                {
                    ModelState.AddModelError("NameOffer", "This name is already exists!");
                }
                return new JsonErrorResult(ModelState);
            }
            return RedirectToAction("Offers");
        }
        
        /*  public JsonResult IsNameAlreadyExists(string NameOffer)
        {
            var result = OfferService.ExistOffers(NameOffer);
            return Json(!result, JsonRequestBehavior.AllowGet);
         
        }*/

    }
}