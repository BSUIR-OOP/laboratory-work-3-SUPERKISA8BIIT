using lab3.Struct;
using lab3.Transports;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ListOfTransports _transports { get; set; } = new();

        private List<Transport> _availbleType = new()
        {
            new Jet(),
            new Plane(),
            new Tanker(),
            new CargoShip()
        };
        public MainWindow()
        {
            InitializeComponent();

            SelectClass.ItemsSource = _availbleType;
            listView.ItemsSource = _transports;
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Transport newTrs = (Transport)SelectClass.SelectedItem;

            newTrs = (Transport)newTrs.Clone();
            newTrs.model = modelBox.Text; 
            newTrs.power = int.Parse(powerBox.Text); 
            newTrs.capacity = int.Parse(capacBox.Text);

            if (((Button)sender).Tag.ToString() == "upd")
                _transports[listView.SelectedIndex] = newTrs;
            else
                _transports.Add(newTrs);

            listView.Items.Refresh();
        }

        private void DeserialzeAct(object sender, RoutedEventArgs e)
        {
            var text = File.ReadAllText("data.txt");
            _transports = (ListOfTransports)_transports.FromText(text);

            listView.ItemsSource = _transports;
            listView.Items.Refresh();
        }

        private void SerializeAct(object sender, RoutedEventArgs e)
        {
            var text = _transports.ToText();
            File.WriteAllText("data.txt",text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _transports.RemoveAt(listView.SelectedIndex);
            listView.Items.Refresh();
        }
    }
}
