using AppXamarin.Models;
using AppXamarin.Services;
using Autofac;

namespace AppXamarin
{
	public class Setup
    {
		public IContainer CreateContainer()
		{
			ContainerBuilder containerBuilder = new ContainerBuilder();
			RegisterDependencies(containerBuilder);
			return containerBuilder.Build();
		}

		protected virtual void RegisterDependencies(ContainerBuilder builder)
		{
			builder.RegisterInstance<IDataStore<Item>>(new MockDataStore());
		}
	}
}
