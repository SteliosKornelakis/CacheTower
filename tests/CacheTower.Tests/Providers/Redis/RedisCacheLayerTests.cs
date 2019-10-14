﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheTower.Providers.Redis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackExchange.Redis;

namespace CacheTower.Tests.Providers.Redis
{
	[TestClass, Ignore]
	public class RedisCacheLayerTests : BaseCacheLayerTests
	{
		private static ConnectionMultiplexer Connection { get; set; }

		[AssemblyInitialize]
		public static void AssemblyInitialise(TestContext testContext)
		{
			Connection = ConnectionMultiplexer.Connect("localhost:6379");
		}

		[TestInitialize]
		public void Setup()
		{
		}

		[TestMethod]
		public async Task GetSetCache()
		{
			await AssertGetSetCache(new RedisCacheLayer(Connection));
		}

		[TestMethod]
		public async Task IsCacheAvailable()
		{
			await AssertCacheAvailability(new RedisCacheLayer(Connection), true);
		}

		[TestMethod]
		public async Task EvictFromCache()
		{
			await AssertCacheEviction(new RedisCacheLayer(Connection));
		}

		[TestMethod]
		public async Task CacheCleanup()
		{
			await AssertCacheCleanup(new RedisCacheLayer(Connection));
		}

		[TestMethod]
		public async Task CachingComplexTypes()
		{
			await AssertComplexTypeCaching(new RedisCacheLayer(Connection));
		}
	}
}