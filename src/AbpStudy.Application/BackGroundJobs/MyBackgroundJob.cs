using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using static AbpStudy.BackGroundJobs.MyBackgroundJob;

namespace AbpStudy.BackGroundJobs
{
    public class MyBackgroundJob : BackgroundJob<MyJobArgs>
    {
        public  override async void Execute(MyJobArgs args)
        {
            Console.WriteLine($"Running background job with argument: {args.Argument}");
            await Task.Delay(5000); 
            Console.WriteLine("Background job completed.");
        }

       
        public class MyJobArgs
        {
            public string Argument { get; set; }
        }
    }
}
