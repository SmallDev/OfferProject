using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using Autofac;
using BusinessLayerLibrary.DAL;
using BusinessLayerLibrary.DAL.Repositories;
using BusinessLayerLibrary.Domain.Model;
using BusinessLayerLibrary.Facades;
using BusinessLayerLibrary.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace BLLTests
{
    [TestClass]
    public class Test
    {
        private readonly IContainer ioc;

        public Test()
        {
            this.ioc = CreateContainer();
        }

        private IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Config>().As<IDbConfig>().InstancePerDependency();
            builder.RegisterType<UserFacade>().InstancePerDependency();
            builder.RegisterType<OfferFacade>().InstancePerDependency();
            builder.RegisterType<DataManagerFactory>().As<IDataManagerFactory>().InstancePerDependency();
            builder.RegisterType<SHA1CryptoServiceProvider>().As<HashAlgorithm>().InstancePerDependency();

            IContainer ioC = builder.Build();
           // var res = new Autofac.Integration.Mvc.AutofacDependencyResolver(ioC);
            //DependencyResolver.SetResolver(res);
            return ioC;
        }


        [TestMethod]
        public void TestAddUser()
        {
            using (var dataManager=ioc.Resolve<IDataManagerFactory>().GetDataManager(ConcurrencyLock.Optimistic))
            {
                var UserRepository = dataManager.GetRepository<IUserRepository>();
                var newUser = GetNewUser();
                UserRepository.Save(newUser);
                dataManager.Commit();
            }

        }



        [TestMethod]
        public void TestAddOffer()
        {
            using (var dataManager = ioc.Resolve<IDataManagerFactory>().GetDataManager(ConcurrencyLock.Optimistic))
            {
                var OfferRepository = dataManager.GetRepository<IOfferRepository>();
                var newOffers = GetNewOffers();
                foreach (var offer in newOffers)
                {
                    OfferRepository.Save(offer);
                
                }
                dataManager.Commit();
            }

        }

        private User GetNewUser()
        {
            var algorithm = ioc.Resolve<HashAlgorithm>();
            return new User
            {
                Login="admin",
                Name="Admin",
                PasswordHash = algorithm.ComputeHash(new MemoryStream(Encoding.UTF8.GetBytes("123")))
            };
             
        }
        private List<Offer> GetNewOffers()
        {
            var ListOffers = new List<Offer>();

            for(int i=0;i<10;i++)
            {
                var tempOffer = new Offer()
                {
                    IdUser = 4,
                    NameOffer = "HolidaysOffer #"+i.ToString(),
                    Description ="Hey! New Year!!!",
                    Date=DateTime.Now+new TimeSpan(1,0,0,0),
                    Type=1,
                    State="Valid"
                };

                ListOffers.Add(tempOffer);

                tempOffer = new Offer()
                {
                    IdUser = 4,
                    NameOffer = "HolidaysOffer #" + i.ToString(),
                    Description = "Hey! New Year!!!",
                    Date = DateTime.Now + new TimeSpan(1, 0, 0, 0),
                    Type = 2,
                    State = "NoValid"
                };
                ListOffers.Add(tempOffer);
            }
            return ListOffers;

        }
    }
}
