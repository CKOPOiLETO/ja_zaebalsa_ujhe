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

namespace day15uprspo
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Schedules _currentSchedules = new Schedules();
        private bool _editSchedules = false;
        public AddEditPage(Schedules selectedSchedules)
        {
            InitializeComponent();
            if (selectedSchedules != null) {
                _currentSchedules = selectedSchedules;
                _editSchedules = true;
            }

            DataContext = _currentSchedules;
            ComboBuses.ItemsSource = BusTicketEntities.GetContext().Buses.ToList();
                
        }




        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentSchedules.Routes == null)
            {
                _currentSchedules.Routes = new Routes();
            }

            if (string.IsNullOrWhiteSpace(_currentSchedules.Routes.DepartuePoint))
                errors.AppendLine("Укажите пункт отправки");
            if (string.IsNullOrWhiteSpace(_currentSchedules.Routes.Destination))
                errors.AppendLine("Укажите пункт прибытия");
            if (_currentSchedules.DepartureData == null)
                errors.AppendLine("Выберите дату отправления");
            if (string.IsNullOrWhiteSpace(_currentSchedules.DepartureTime.ToString()))
                errors.AppendLine("Укажите время отправления");
            if (string.IsNullOrWhiteSpace(_currentSchedules.ArrivalTime.ToString()))
                errors.AppendLine("Укажите время прибытия");
            if (_currentSchedules.BusId <= 0)
                errors.AppendLine("Укажите номер автобуса");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (!_editSchedules)
            {
                BusTicketEntities.GetContext().Schedules.Add(_currentSchedules);
            }

            try
            {
                BusTicketEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }







        /* private void BtnSave_Click(object sender, RoutedEventArgs e)
         {
             StringBuilder errors = new StringBuilder();
             if (string.IsNullOrWhiteSpace(_currentSchedules.Name))
                 errors.AppendLine("Укажите название отеля");
             if (_currentSchedules.CountOfStars < 1 || _currentSchedules.CountOfStars > 5)
                 errors.AppendLine("Неверное количество звёзд");
             if (_currentSchedules.Country == null)
                 errors.AppendLine("Выберите страну");
             if (errors.Length > 0)
             {
                 MessageBox.Show(errors.ToString());
                 return;

             }
             if (!_editSchedules)
             {
                 var hotelSpis = BusTicketEntities.GetContext().Schedules.ToList();
                 BusTicketEntities.GetContext().Schedules.Add(_currentSchedules);
                 for (int i = 0; true; i++)
                 {
                     if (hotelSpis.All(h => h.Id != i))
                     {
                         _currentSchedules.Id = i;
                         break;
                     }
                 }
                 BusTicketEntities.GetContext().Schedules.Add(_currentSchedules);

             }


             try
             {
                 BusTicketEntities.GetContext().SaveChanges();
                 MessageBox.Show("Информация сохранена!");
                 Manager.MainFrame.GoBack();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message.ToString());


             }*/
    }















        /*private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentSchedules.Name))
                errors.AppendLine("Укажите название отеля");
            if (_currentSchedules.CountOfStars < 1 || _currentSchedules.CountOfStars > 5)
                errors.AppendLine("Неверное количество звёзд");
            if (_currentSchedules.Country == null)
                errors.AppendLine("Выберите страну");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentSchedules.Id == 0)
            {
                BusTicketEntities.GetContext().Schedules.Add(_currentSchedules);
            }

            try
            {
                BusTicketEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }*/
    
} 
