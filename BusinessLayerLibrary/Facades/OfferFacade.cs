using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayerLibrary.DAL;
using BusinessLayerLibrary.DAL.Repositories;
using BusinessLayerLibrary.Domain.Model;
using BusinessLayerLibrary.Domain.Validators;

namespace BusinessLayerLibrary.Facades
{
    public class OfferFacade
    {
        private readonly IDataManagerFactory factory;

        public OfferFacade(IDataManagerFactory factory)
        {
            this.factory = factory;
        }
        public ICollection<Offer> GetOffers(Int32 page, Int32 size)
        {
            using (var dataManager = factory.GetDataManager())
            {
                var repository = dataManager.GetRepository<IOfferRepository>();
                return repository.GetOffers(page, size);
            }
        }
        public Offer GetOffer(Int32 id)
        {
            using (var dataManager = factory.GetDataManager())
            {
                var repository = dataManager.GetRepository<IOfferRepository>();
                return repository.GetOffer(id);
            }
        }
        public bool ExistOffers(string NameOffer)
        {
            using (var dataManager = factory.GetDataManager())
            {
                var repository = dataManager.GetRepository<IOfferRepository>();
                return repository.ExistOffers(NameOffer);
            }
        }
        /// <summary> Сохранение или обновление информации по предложению </summary>
        public Boolean Save(Offer offer)
        {
            if (offer == null)
               throw new NullReferenceException("Не указано предложение");
            
            var result = new OfferValidator(offer).Validate();

            if ((result.Any())||((offer.IdOffer == 0) && (ExistOffers(offer.NameOffer))))
                return false;

            using (var dataManager = factory.GetDataManager(ConcurrencyLock.Optimistic))
            {
                var repository = dataManager.GetRepository<IOfferRepository>();
                repository.Save(offer);
                dataManager.Commit();
            }

            return true;
        }

        public Int64 GetOffersCount()
        {
            using (var dataManager = factory.GetDataManager())
            {
                var repository = dataManager.GetRepository<IOfferRepository>();
                return repository.GetOffersCount();
            }
        }

    }
}
