using AutoMapper;
using EXPRACU2_AGUIRRE_BASURTO.Models;
using EXPRACU2_AGUIRRE_BASURTO.ViewModels;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EXPRACU2_AGUIRRE_BASURTO.Startup))]
namespace EXPRACU2_AGUIRRE_BASURTO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            Mapper.Initialize(cfg => {
                cfg.CreateMap<AgregarPersonalViewModel,Persona>();
                cfg.CreateMap<Persona, AgregarPersonalViewModel>();
            });
        }
    }
}
