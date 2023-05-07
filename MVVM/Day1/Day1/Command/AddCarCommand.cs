using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Day1.Command
{
	public class AddCarCommand : ICommand
	{
		public event EventHandler? CanExecuteChanged;

		private readonly Action<object?> _Execute;
		private readonly Predicate<object?> _CanExecute;

		public AddCarCommand(Action<object?> execute, Predicate<object?> canExecute)
		{
			_Execute = execute;
			_CanExecute = canExecute;
		}

		public bool CanExecute(object? parameter)
		{
			return _CanExecute is null ? false : _CanExecute.Invoke(parameter);
		}

		public void Execute(object? parameter)
		{
			_Execute.Invoke(parameter);
		}
	}
}
