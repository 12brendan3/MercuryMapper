using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace MercuryMapper.Views.Settings;

public partial class SettingsView_Rendering : UserControl
{
    public SettingsView_Rendering(MainView mainView)
    {
        InitializeComponent();
        this.mainView = mainView;
        SetValuesFromConfig();
    }

    private readonly MainView mainView;

    private void SetValuesFromConfig()
    {
        NumericRefreshRate.Value = mainView.UserConfig.RenderConfig.RefreshRate;
        NumericNoteSize.Value = mainView.UserConfig.RenderConfig.NoteSize;
        NumericNoteSpeed.Value = mainView.UserConfig.RenderConfig.NoteSpeed;
        CheckBoxShowHiSpeed.IsChecked = mainView.UserConfig.RenderConfig.ShowHiSpeed;
    }
    
    private void RefreshRate_OnValueChanged(object? sender, NumericUpDownValueChangedEventArgs e)
    {
        mainView.UserConfig.RenderConfig.RefreshRate = (int)(NumericRefreshRate.Value ?? 60);
    }
    
    private void NoteSize_OnValueChanged(object? sender, NumericUpDownValueChangedEventArgs e)
    {
        mainView.UserConfig.RenderConfig.NoteSize = (int)(NumericNoteSize.Value ?? 3);
    }
    
    private void NoteSpeed_OnValueChanged(object? sender, NumericUpDownValueChangedEventArgs e)
    {
        mainView.UserConfig.RenderConfig.NoteSpeed = NumericNoteSpeed.Value ?? 4.5m;
    }

    private void ShowHiSpeed_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        mainView.UserConfig.RenderConfig.ShowHiSpeed = CheckBoxShowHiSpeed.IsChecked ?? true;
    }
}