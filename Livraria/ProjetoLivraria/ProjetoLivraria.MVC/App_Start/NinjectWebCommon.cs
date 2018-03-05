using ProjetoLivraria.Aplicacao.Interfaces;
using ProjetoLivraria.Dominio.Interfaces.Repositorios;
using ProjetoLivraria.Dominio.Interfaces.Servicos;
using ProjetoLivraria.Dominio.Servicos;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProjetoLivraria.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ProjetoLivraria.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace ProjetoLivraria.MVC.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using ProjetoLivraria.Aplicacao.Classes;
    using ProjetoLivraria.Dados.Repositorios;
    using System;
    using System.Web;

    public class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServicoBase<>)).To(typeof(AppServicoBase<>));
            kernel.Bind<ILivroAppServico>().To<LivroAppServico>();
            kernel.Bind<IEditoraAppServico>().To<EditoraAppServico>();
            kernel.Bind<ICategoriaAppServico>().To<CategoriaAppServico>();

            kernel.Bind(typeof(IServicoBase<>)).To(typeof(ServicoBase<>));
            kernel.Bind<ILivroServico>().To<LivroServico>();
            kernel.Bind<IEditoraServico>().To<EditoraServico>();
            kernel.Bind<ICategoriaServico>().To<CategoriaServico>();

            kernel.Bind(typeof(IRepositorioBase<>)).To(typeof(RepositorioBase<>));
            kernel.Bind<ILivroRepositorio>().To<LivroRepositorio>();
            kernel.Bind<IEditoraRepositorio>().To<EditoraRepositorio>();
            kernel.Bind<ICategoriaRepositorio>().To<CategoriaRepositorio>();
        }
    }
}