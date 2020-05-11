using ConsensusScheduler.BizLogic.Abstractions.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsensusScheduler.BizLogic.Aggregates
{
    public static class BizLogicDIHelper
    {
        public static IServiceCollection UseBizLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.TryAddTransient<IPollCRUDAggregate, PollAggregate>();
            services.TryAddTransient<ISchedUserCRUDAggregate, SchedUserAggregate>();

            return services;
        }
    }
}
