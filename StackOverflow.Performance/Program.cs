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

		readonly ICommand _action, _decorated;
		readonly string _message;

		public Program() : this(new EmitMessage()) {}

		public Program(ICommand action) : this(action, Decorate.Get(action), "Hello World!") {}

		public Program(ICommand action, ICommand decorated, string message)
		{
			_action    = action;
			_decorated = decorated;
			_message = message;
		}

		[Benchmark]
		public void Direct()
		{
			_action.Execute(_message);
		}

		[Benchmark]
		public void Decorated()
		{
			_decorated.Execute(_message);
		}
	}
}