using System.Linq;

namespace StackOverflow.Performance {
	static class Decorate
	{
		public static ICommand Get(ICommand parameter)
			=> Enumerable.Range(0, 10)
			             .Aggregate(parameter, (command, _) => new DecoratedCommand(command));
	}
}