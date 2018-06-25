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
        private ObservableCollection<int> sheetWidth;
        private ObservableCollection<int> sheetLenght;
        private ObservableCollection<int> sheetThikness;
        private int res;

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
            BigSheetWidth.ItemsSource = sheetWidth;
            sheetLenght = new ObservableCollection<int> {3000, 6000};
            BigSheetLenght.ItemsSource = sheetLenght;
            sheetThikness = new ObservableCollection<int> {3, 4, 5, 6, 7, 8, 9, 10};
            BigSheetThikness.ItemsSource = sheetThikness;
            Cleaning();
        }

        //
        // Очистка полей
        //
        private void Cleaning()
        {
            BigSheetWidth.SelectedIndex = 0;
            BigSheetLenght.SelectedIndex = 0;
            BigSheetThikness.SelectedIndex = 0;
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

        private void TextInputPreview_Digitals(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckForData(textBoxLenght) & CheckForData(textBoxWidth) & CheckForData(textBoxThikness) & CheckForData(textBoxOver))
            {
                try
                {
                    Sheet bigSheet = new Sheet(int.Parse(BigSheetWidth.SelectionBoxItem.ToString()),
                        int.Parse(BigSheetLenght.SelectionBoxItem.ToString()),
                        int.Parse(BigSheetThikness.SelectionBoxItem.ToString()));

                    Sheet smallSheet = new Sheet(int.Parse(textBoxWidth.Text) + int.Parse(textBoxOver.Text),
                        int.Parse(textBoxLenght.Text) + int.Parse(textBoxOver.Text),
                        int.Parse(textBoxThikness.Text));
                    res = Calculation.Calc(bigSheet, smallSheet);
                    ProductWeight.Content = smallSheet.Weight.ToString();
                    AmountOfPieces.Content = res.ToString();
                    double totalCutoff = bigSheet.Weight - smallSheet.Weight * res;
                    TotalCutoff.Content = totalCutoff.ToString();
                    double cuttoffPercent = (totalCutoff / bigSheet.Weight) * 100;
                    CutoffPercent.Content = (cuttoffPercent.ToString());
                    string toPrint = "Результат: " + res.ToString() + " листов";
                    MessageBox.Show(toPrint);
                }
                catch (Exception ex)
                {
                    String str = "Ошибка: " + ex.Message;
                    String name = "Ошибка вычислений";
                    MessageBox.Show(str, name);
                }
            }
            else
            {
                String str = "Ошибка: внесите данные во все поля";
                String name = "Ошибка заполнения данных";
                MessageBox.Show(str, name);
            }
        }

        private bool CheckForData(TextBox textBox)
        {
            if (textBox.Text == "")
               return false;
            return true;
        }
    }
}
