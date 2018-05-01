using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace StackOverflow.Performance
{
	public class Program
	{
		static void Main()
		{
			// Writes out the stack trace from a decorated command:
			Decorate.Get(new EmitMessage(Console.WriteLine))
			        .Execute(null);

			BenchmarkRunner.Run<Program>();
			Console.ReadKey();
		}

		readonly ICommand _direct, _decorated;
		readonly string _message;

		public Program() : this(new EmitMessage()) {}

		public Program(ICommand direct) : this(direct, Decorate.Get(direct), "Hello World!") {}

		public Program(ICommand direct, ICommand decorated, string message)
		{
			_direct    = direct;
			_decorated = decorated;
			_message = message;
		}

		[Benchmark]
		public void Direct()
		{
			_direct.Execute(_message);
		}

		[Benchmark]
		public void Decorated()
		{
			_decorated.Execute(_message);
		}
	}
}