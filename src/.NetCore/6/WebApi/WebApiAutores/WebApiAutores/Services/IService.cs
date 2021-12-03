namespace WebApiAutores.Services
{
    public interface IService
    {
        void DoTask();
        Guid ObtenerScoped();
        Guid ObtenerSingleton();
        Guid ObtenerTransiet();
    }

    public class ServiceA : IService 
    {
        private readonly ILogger<ServiceA> logger;
        private readonly ServiceTransiet serviceTransiet;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;

        public ServiceA(ILogger<ServiceA> logger, ServiceTransiet serviceTransiet, ServiceScoped serviceScoped, ServiceSingleton serviceSingleton)
        {
            this.logger = logger;
            this.serviceTransiet = serviceTransiet;
            this.serviceScoped = serviceScoped;
            this.serviceSingleton = serviceSingleton;
        }

        public Guid ObtenerTransiet() { return serviceTransiet.Guid; }
        public Guid ObtenerScoped() { return serviceScoped.Guid; }
        public Guid ObtenerSingleton() { return serviceSingleton.Guid; }

        public void DoTask() 
        {
            throw new NotImplementedException();
        }
    }

    public class ServiceB : IService
    {   
        public void DoTask()
        {
            throw new NotImplementedException();
        }

        public Guid ObtenerScoped()
        {
            throw new NotImplementedException();
        }

        public Guid ObtenerSingleton()
        {
            throw new NotImplementedException();
        }

        public Guid ObtenerTransiet()
        {
            throw new NotImplementedException();
        }
    }

    public class ServiceTransiet {
        public Guid Guid = Guid.NewGuid();
    }

    public class ServiceScoped
    {
        public Guid Guid = Guid.NewGuid();
    }

    public class ServiceSingleton
    {
        public Guid Guid = Guid.NewGuid();
    }
}