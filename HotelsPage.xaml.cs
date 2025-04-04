using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {

        public HotelsPage()
        {
            InitializeComponent();
            //DGridHotels.ItemsSource = BusTicketEntities.GetContext().Hotel.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Schedules));

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            Manager.MainFrame.Navigate(new AddEditPage(null));

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

            var shelduesForRemoving = DGridSchedules.SelectedItems.Cast<Routes>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить:{shelduesForRemoving.Count}", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BusTicketEntities.GetContext().Routes.RemoveRange(shelduesForRemoving);
                    BusTicketEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridSchedules.ItemsSource = BusTicketEntities.GetContext().Routes.ToList();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }


        }



        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BusTicketEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridSchedules.ItemsSource = BusTicketEntities.GetContext().Routes.ToList();

            }
        }

















    }
}
















/*private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
{
    if (Visibility == Visibility.Visible)
    {
        // Создаем новый контекст, чтобы сбросить все изменения
        BusTicketEntities.CreateNewContext(); // Этот метод нужно реализовать в классе BusTicketEntities

        DGridHotels.ItemsSource = BusTicketEntities.GetContext().Hotel.ToList();
    }
}*/