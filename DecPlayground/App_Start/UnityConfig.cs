using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using DecPlayground.Services.Interface;
using DecPlayground.Services;

namespace DecPlayground
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            

            container.RegisterType<IVote, VoteService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
           
        }
    }
}