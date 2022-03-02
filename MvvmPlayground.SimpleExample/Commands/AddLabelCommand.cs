using System;
using System.Windows.Input;
using MvvmPlayground.SimpleExample.ViewModels;

namespace MvvmPlayground.SimpleExample.Commands;

public class AddLabelCommand: ICommand
{
    private readonly MainViewModel _viewModel;
    
    public event EventHandler? CanExecuteChanged;

    public AddLabelCommand(MainViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(_viewModel.BoxText))
            {
                OnCanExecuteChanged();
            }
        };
    }
    
    public bool CanExecute(object? parameter)
    {
        return !string.IsNullOrWhiteSpace(_viewModel.BoxText);
    }

    public void Execute(object? parameter)
    {
        _viewModel.Labels.Add(new LabelViewModel{Text = _viewModel.BoxText});
    }
    
    public void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}