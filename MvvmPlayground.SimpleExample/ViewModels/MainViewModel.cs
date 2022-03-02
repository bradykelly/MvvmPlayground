﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MvvmPlayground.SimpleExample.Commands;

namespace MvvmPlayground.SimpleExample.ViewModels;

public class MainViewModel: INotifyPropertyChanged
{
    private string _boxText = "";
    
    public event PropertyChangedEventHandler? PropertyChanged;

    public string BoxText
    {
        get => _boxText;
        set
        {
            if (!string.Equals(_boxText, value))
            {
                _boxText = value;
                OnPropertyChanged();
            }
            _boxText = value;
        }
    }
    
    public ObservableCollection<LabelViewModel> Labels { get; } = new ObservableCollection<LabelViewModel>();

    public ICommand AddCommand { get; }

    public MainViewModel()
    {
        Labels.Add(new LabelViewModel{Text = "Label 1"});
        Labels.Add(new LabelViewModel{Text = "Label 2"});
        Labels.Add(new LabelViewModel{Text = "Label 3"});
        Labels.Add(new LabelViewModel{Text = "Label 4"});
        Labels.Add(new LabelViewModel{Text = "Label 5"});

        AddCommand = new AddLabelCommand(this);
    }
    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}