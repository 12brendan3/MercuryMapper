using System;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Threading;
using MercuryMapper.Config;

namespace MercuryMapper;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        AddHandler(DragDrop.DropEvent, Window_Drop);
    }
    
    private void Window_Drop(object? sender, DragEventArgs e)
    {
        Uri? path = e.Data.GetFiles()?.First().Path;
        if (path == null || !File.Exists(path.LocalPath) || Path.GetExtension(path.LocalPath) != ".mer") return;
        
        MainView.DragDrop(path.LocalPath);
        e.Handled = true;
    }

    private void Window_OnClosing(object? sender, WindowClosingEventArgs e)
    {
        if (MainView.CanShutdown) return;
        e.Cancel = true;
        Dispatcher.UIThread.Post(async () => MainView.MenuItemExit_OnClick(null, new()));
    }
}