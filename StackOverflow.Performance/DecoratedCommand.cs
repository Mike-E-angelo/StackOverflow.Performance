namespace StackOverflow.Performance
{
	sealed class DecoratedCommand : ICommand
	{
		readonly ICommand _command;

		public DecoratedCommand(ICommand command) => _command = command;

		public void Execute(string message)
		{
			_command.Execute(message);
		}
	}
}