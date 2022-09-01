using Quartz;
using Quartz.Spi;

namespace MyLearn.Mvc.Jobs
{
    
    public class JobFactory : IJobFactory
    {
        readonly IServiceProvider _serviceprovider;
        public JobFactory(IServiceProvider serviceprovider)
        {
            _serviceprovider = serviceprovider;
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return _serviceprovider.GetRequiredService(bundle.JobDetail.JobType) as IJob;
        }

        public void ReturnJob(IJob job)
        {

        }
    }
}
