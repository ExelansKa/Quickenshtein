﻿using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using Quickenshtein.Benchmarks.Columns;

namespace Quickenshtein.Benchmarks.Config
{
	class BaseRuntimeConfig : ManualConfig
	{
		public BaseRuntimeConfig()
		{
			AddDiagnoser(MemoryDiagnoser.Default);
			
			AddJob(Job.Default
				.WithRuntime(ClrRuntime.Net472)
				.AsBaseline());

			AddJob(Job.Default
				.WithRuntime(CoreRuntime.Core60));

			AddColumn(StatisticColumn.OperationsPerSecond);
			AddColumn(SpeedupRatioColumn.SpeedupOfMean);
			AddDiagnoser(new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(maxDepth: 3)));
		}
	}
}
