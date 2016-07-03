using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Shop.Data;
using Shop.Entities;
using Repository.Pattern.Repositories;
using Shop.Services;
using Repository.Pattern.UnitOfWork;
 

namespace Shop.Api.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            container
    .RegisterType<IDataContextAsync, ShopDBContext>(new PerRequestLifetimeManager())
    .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager())
    .RegisterType<IRepositoryAsync<Customer>, Repository<Customer>>()
    .RegisterType<IRepositoryAsync<Product>, Repository<Product>>()
     .RegisterType<IRepositoryAsync<Menu>, Repository<Menu>>()
    .RegisterType<IRepositoryAsync<Error>, Repository<Error>>()
     .RegisterType<IRepositoryAsync<Category>, Repository<Category>>()
    .RegisterType<IMembershipService, MembershipService>()
     .RegisterType<IMenuService, MenuService>()
    .RegisterType<IErrorService, ErrorService>()
    .RegisterType<IProductService, ProductService>()
    .RegisterType<IRepositoryAsync<User>, Repository<User>>()
    .RegisterType<IRepositoryAsync<UserRole>, Repository<UserRole>>()
    .RegisterType<IRepositoryAsync<Role>, Repository<Role>>()
   // .RegisterType<IRepository<Role>, Repository<Role>>()
    .RegisterType<IEncryptionService, EncryptionService>()
    .RegisterType<ICategoryService, CategoryService>()
    .RegisterType<ICustomerService, CustomerService>()
    .RegisterType<IStoredProcedureService, StoredProcedureService>()    
    .RegisterType<IShopStoredProcedures, ShopDBContext>(new PerRequestLifetimeManager());
        }
    }
}
