using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace OffCut
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //
        //переменные ObservableCollection для заполнения ComboBoxes
        //
        public ObservableCollection<int> sheetWidth;
        public ObservableCollection<int> sheetLenght;
        public ObservableCollection<int> sheetThikness;

        public MainWindow()
        {
           InitializeComponent();
           InitialiseComboBoxes();
        }

        //
        // Выход из приложения
        //
        private void ExitBtn_Click(object sender, RoutedEventArgs e) => this.Close();

        //
        // Очистка содержимого полей формы по нажатию кнопки Очистить
        //
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Cleaning();
        }
        //
        // Заполнение ComboBoxes
        //
        private void InitialiseComboBoxes()
        {
            sheetWidth = new ObservableCollection<int> {500, 1000, 1500, 2000};
            ComboBox1.ItemsSource = sheetWidth;
            sheetLenght = new ObservableCollection<int> {3000, 6000};
            ComboBox2.ItemsSource = sheetLenght;
            sheetThikness = new ObservableCollection<int> {3, 4, 5, 6, 7, 8, 9, 10};
            ComboBox3.ItemsSource = sheetThikness;
            Cleaning();
        }

        //
        // Очистка полей
        //
        private void Cleaning()
        {
            ComboBox1.SelectedIndex = 0;
            ComboBox2.SelectedIndex = 0;
            ComboBox3.SelectedIndex = 0;
            textBoxWidth.Text = "";
            textBoxLenght.Text = "";
            textBoxThikness.Text = "";
            textBoxOver.Text = "";
            ResultSheet.Content = "";
            AmountOfSheets.Content = "";
            ProductWeight.Content = "";
            AmountOfPieces.Content = "";
            TotalCutoff.Content = "";
            CutoffPercent.Content = "";
        }
    }
}
