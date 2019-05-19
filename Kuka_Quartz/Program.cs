using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace KuKa_Quartz
{
    class Program
    {

        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<Kuka_QuartzService>(s =>
                {
                    s.ConstructUsing(name => new Kuka_QuartzService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("KuKa_QuartzService Host");
                x.SetDisplayName("KuKa_QuartzService");
                x.SetServiceName("KuKa_QuartzService");
            });
        }

    }
}
