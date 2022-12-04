﻿using System.Windows.Input;

namespace App.Examples;

public partial class Other4Switch : ContentView
{
	public Other4Switch()
	{
		InitializeComponent();
	}

	public event EventHandler<ToggledEventArgs>? Toggled = null;
	public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(Other4Switch), false, BindingMode.TwoWay);
	public bool IsToggled
	{
		get => (bool)GetValue(IsToggledProperty);
		set => SetValue(IsToggledProperty, value);
	}

	public static readonly BindableProperty ToggledCommandProperty = BindableProperty.Create(nameof(ToggledCommand), typeof(ICommand), typeof(Other4Switch));
	public ICommand ToggledCommand
	{
		get => (ICommand)GetValue(ToggledCommandProperty);
		set => SetValue(ToggledCommandProperty, value);
	}
	void CustomSwitch_SwitchPanUpdate(object sender, CustomSwitch.Events.SwitchPanUpdatedEventArgs e)
	{
		Flex.TranslationX = -(e.TranslateX + e.XRef);
	}

	void CustomSwitch_Toggled(object sender, ToggledEventArgs e)
	{
		Toggled?.Invoke(sender, e);
	}
}