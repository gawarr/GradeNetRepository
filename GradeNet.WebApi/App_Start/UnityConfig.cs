using GradeNet.Infrastructure.Helpers;
using GradeNet.Infrastructure.Interfaces;
using GradeNet.Infrastructure.Managers;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace GradeNet.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IUserManager, UserManager>();
            container.RegisterType<ITeacherManager, TeacherManager>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}