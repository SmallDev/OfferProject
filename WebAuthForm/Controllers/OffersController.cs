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
using BusinessLayerLibrary.Common;

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

        public ActionResult GetOffersStat()
        {
            var countOffers = OfferService.GetOffersCount();
            var offers = OfferService.GetOffers(1, (int) countOffers).ToArray<Offer>();

            var model = offers.GroupBy(_ => _.Type).Select(i => new { Type = i.Key, Count = i.Count() });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetOffersTotalCount()
        {
            var countOffers = OfferService.GetOffersCount();
            return Json(countOffers, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditOffer(int? id)
        {
            
            return View(id);
        }

        [HttpGet]
        public ActionResult GetOffer(int id)
        {
            OfferViewModel offerVM = new OfferViewModel();
            if (id > 0)
            {
                var offer = OfferService.GetOffer(id);
                offerVM = OfferViewModel.ConvertToOfferViewModel(offer);
            }
            return Json( offerVM, JsonRequestBehavior.AllowGet);
        }  

        [HttpPost]
        public void SaveOffer(OfferViewModel offerViewModel)
        {
            var offer = OfferViewModel.ConvertToOffer(offerViewModel);
            if (!OfferService.Save(offer))
            {
                /*if ((offer.IdOffer == 0) && (OfferService.ExistOffers(offer.NameOffer)))
                {
                    ModelState.AddModelError("NameOffer", "This name is already exists!");
                }*/
            }
        }

        public ActionResult Report()
        {
            return View();
        }


        /*  public JsonResult IsNameAlreadyExists(string NameOffer)
        {
            var result = OfferService.ExistOffers(NameOffer);
            return Json(!result, JsonRequestBehavior.AllowGet);
         
        }*/

    }
}