using System;
using System.Diagnostics;

namespace StackOverflow.Performance {
	sealed class EmitMessage : ICommand
	{
		readonly Action<string> _emit;

		public EmitMessage() : this(_ => {}) {}

		public EmitMessage(Action<string> emit) => _emit = emit;

		public void Execute(string message)
		{
			MethodA(message);
		}

		void MethodA(string message)
		{
			MethodB(message);
		}

		void MethodB(string message)
		{
			MethodC(message);
		}

		void MethodC(string message)
		{
			Emit(message);
		}

		void Emit(string message)
		{
			_emit(message ?? new StackTrace().ToString());
		}
	}
}