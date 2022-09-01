namespace MyLearn.Mvc.Jobs
{
    public class JobSchedule
    {
        public Type JobType { get; set; }

        public string CronExpression { get; set; }
        public JobSchedule(Type jobtype, string cronexpression)
        {
            JobType = jobtype;
            CronExpression = cronexpression;
        }


    }
}
