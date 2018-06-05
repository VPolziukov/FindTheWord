using FindWord.BLL;
using FindWord.DAL;
using FindWord.DAL.Repository;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace FindWord
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();            
            container.RegisterType<ISentenceManager, SentenceManager>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            RegisterTypes(container);
            return container;
        }
        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}