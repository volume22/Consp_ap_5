using Repository;
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

namespace WpfApp1
{
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
            DateTime from = DateTime.MinValue;
            DateTime to = DateTime.MinValue;
            if (DateFrom.SelectedDate != null)
            {
                from = (DateTime)DateFrom.SelectedDate;
            }
            else
            {
                MessageBox.Show("Выберите дату c");
            }
            if (DateTo.SelectedDate != null)
            {
                to = (DateTime)DateTo.SelectedDate;
            }
            else
            {
                MessageBox.Show("Выберите дату по");
            }

            DataSetings setings = new DataSetings(@"C:\Users\ГерценЕ\Downloads\OverallRepairList.xlsx");

            List<newEquipment> newEquipments = setings.getListOfCar(from,to);
            if (!newEquipments.Any())
            {
                MessageBox.Show("Даных по выбраным пораметрам не найдено");
            }
            else
            {

                if (setings.creatExel(newEquipments))
                {
                    MessageBox.Show("Файл успешно создан");
                }
                else
                {
                    MessageBox.Show("Файл не создан");
                }

            }
        }
    }
}
