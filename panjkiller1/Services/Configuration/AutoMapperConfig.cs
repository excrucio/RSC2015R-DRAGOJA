using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;

namespace Services.Configuration
{
    public static class AutoMapperConfig
    {
        private static bool _hasConfigured = false;
        private static Object _threadSafetyLock = new object();
        public static void Configure()
        {
            lock (_threadSafetyLock)
            {
                if (!_hasConfigured)
                {
                    _configure();
                    _hasConfigured = true;
                }
            }
        }

        private static void _configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new MecProfile());

            });
        }
    }
}
