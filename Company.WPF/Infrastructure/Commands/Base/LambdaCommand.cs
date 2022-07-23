using System;

namespace Company.WPF.Infrastructure.Commands.Base
{
    public class LambdaCommand : Command
    {
        private readonly Action<object?> _Execute;
        private readonly Func<object?, bool>? _CanExecute;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public LambdaCommand(Action execute, Func<bool>? canExecute = null)
            : this(p => execute(), canExecute is null ? (Func<object?, bool>?) null : p => canExecute())
        {

        }

        public LambdaCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _CanExecute = canExecute;
        }

        protected override void Execute(object? parameter) => _Execute(parameter);

        protected override bool CanExecute(object? parameter) => _CanExecute?.Invoke(parameter) ?? true;
    }
}