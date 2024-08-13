using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Frontend.MVVM.Views;
/// <summary>
/// Interaction logic for SleepView.xaml
/// </summary>
public partial class SleepView : UserControl
{
    public SleepView()
    {
        InitializeComponent();

        GenerateIntervalColumns();
    }

    private void GenerateIntervalColumns()
    {
        // Assuming your DataGrid's name in XAML is "dataGrid"
        for (int i = 0; i < 48; i++)
        {
            var column = new DataGridTemplateColumn
            {
                Header = $"Interval {i + 1}",
                Width = new DataGridLength(1, DataGridLengthUnitType.Star)
            };

            // DataTemplate for Cell
            var template = new DataTemplate();
            var buttonFactory = new FrameworkElementFactory(typeof(Button));

            // Binding to the specific Interval based on index
            buttonFactory.SetBinding(Button.CommandProperty, new Binding($"DataContext.ToggleFlagCommand")
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGrid), 1),
            });
            buttonFactory.SetBinding(Button.CommandParameterProperty, new Binding($"Intervals[{i}]")
            {
                Mode = BindingMode.OneWay
            });
            buttonFactory.SetBinding(Button.BackgroundProperty, new Binding($"Intervals[{i}].HasSlept")
            {
                Converter = (IValueConverter)Resources["BoolToBrushConverter"],
                Mode = BindingMode.OneWay
            });
            var borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetBinding(Border.BackgroundProperty, new Binding($"Intervals[{i}].HasSlept")
            {
                Converter = (IValueConverter)Resources["BoolToBrushConverter"],
                Mode = BindingMode.OneWay
            });

            borderFactory.AppendChild(buttonFactory);
            template.VisualTree = borderFactory;

            column.CellTemplate = template;

            // Add the column to the DataGrid
            dataGrid.Columns.Add(column);
        }
    }
}
