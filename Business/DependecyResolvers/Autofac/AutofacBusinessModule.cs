using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete;


namespace Business.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<AppointmentService>().As<IAppointmentService>();
            builder.RegisterType<AppointmentRepository>().As<IAppointmentRepository>();

            builder.RegisterType<DoctorService>().As<IDoctorService>();
            builder.RegisterType<DoctorRepository>().As<IDoctorRepository>();

            builder.RegisterType<ContactUsService>().As<IContactUsService>();
            builder.RegisterType<ContactUsRepository>().As<IContactUsRepository>();

            builder.RegisterType<AppointmentChangeTokenRepository>().As<IAppointmentChangeTokenRepository>();
        

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
