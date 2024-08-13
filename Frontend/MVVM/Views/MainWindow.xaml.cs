using Frontend.MVVM.Models.SaveData;
using Frontend.MVVM.ViewModels;
using System.Windows;

namespace Frontend;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var viewModel = ((MainViewModel)DataContext);
        viewModel.SerializationService.Serialize(new MainData(new BreastFeedData(), new ToiletData(), new SleepData()));
    }
}