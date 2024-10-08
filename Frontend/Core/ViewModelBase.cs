﻿using Frontend.Commands;
using Frontend.Services;

namespace Frontend.Core;

public abstract class ViewModelBase : ObservableObject
{
    protected ViewModelBase(INavigationService navigationService, IMainDataService mainDataService)
    {
        NavigationService = navigationService;
        MainDataService = mainDataService;
        _commands = new();
    }

    public INavigationService NavigationService
    {
        get { return _navigationService; }
        set { SetValue(ref _navigationService, value); }
    }

    public IMainDataService MainDataService
    {
        get { return _mainDataService; }
        set { SetValue(ref _mainDataService, value); }
    }

    protected Command GetCommand(Action action)
    {
        if (!_commands.TryGetValue(action.Method.Name, out var command))
        {
            command = _commands[action.Method.Name] = new Command(action);
        }
        return (Command)command;
    }

    protected ParameterCommand GetCommand(Action<object?> action)
    {
        if (!_commands.TryGetValue(action.Method.Name, out var command))
        {
            command = _commands[action.Method.Name] = new ParameterCommand(action);
        }
        return (ParameterCommand)command;
    }

    private readonly Dictionary<string, BaseCommand> _commands;

    private INavigationService _navigationService = null!;
    private IMainDataService _mainDataService = null!;
}
