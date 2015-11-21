using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Services.Configuration
{
    public class BaseConfiguration
    {
        public BaseConfiguration()
        {
            AutoMapperConfig.Configure();
        }
    }
}
