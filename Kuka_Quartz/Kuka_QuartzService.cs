using KuKa_Quartz.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuKa_Quartz
{
   public class Kuka_QuartzService
    {
        public void Start()
        {
            QuartzManage.Init();
        }

        public void Stop()
        {
            QuartzManage.StopSchedule();

            System.Environment.Exit(0);
        }
    }
}
