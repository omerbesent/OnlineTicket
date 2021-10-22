using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // bu bir method gerekli configurasyonlara göre Production veya Test gibi neyi nerden ne kulanacağını belirtebiliriz.
            builder.RegisterType<CountyManager>().As<ICountyService>().SingleInstance();
            builder.RegisterType<EfCountyDal>().As<ICountyDal>().SingleInstance();

            builder.RegisterType<EventManager>().As<IEventService>();
            builder.RegisterType<EfEventDal>().As<IEventDal>();

            builder.RegisterType<PlaceManager>().As<IPlaceService>().SingleInstance();
            builder.RegisterType<EfPlaceDal>().As<IPlaceDal>().SingleInstance();

            builder.RegisterType<PlaceSeatingPlanManager>().As<IPlaceSeatingPlanService>().SingleInstance();
            builder.RegisterType<EfPlaceSeatingPlanDal>().As<IPlaceSeatingPlanDal>().SingleInstance();

            builder.RegisterType<PosterManager>().As<IPosterService>().SingleInstance();
            builder.RegisterType<EfPosterDal>().As<IPosterDal>().SingleInstance();

            builder.RegisterType<SessionManager>().As<ISessionService>().SingleInstance();
            builder.RegisterType<EfSessionDal>().As<ISessionDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<MailManager>().As<IMailService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
