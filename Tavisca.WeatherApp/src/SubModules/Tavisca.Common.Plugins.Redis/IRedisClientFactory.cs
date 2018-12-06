﻿using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.Common.Plugins.Redis
{
    public interface IRedisClientFactory
    {
        IRedisClient Create(RedisSettings settings);

    }
}
