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

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            decimal myTotalDeliveryPayment;
            decimal MyTotalWrapPayment;
            decimal MyTotalGSTPayment;

            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();
                totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);
                myTotalDeliveryPayment = (cProduct.TotalPayment) + 25.00m;
                totalPaymentTextBlock1.Text = myTotalDeliveryPayment.ToString();
                MyTotalWrapPayment = myTotalDeliveryPayment + 5.00m;
                totalWrapChargeTextBlock.Text = MyTotalWrapPayment.ToString();
                MyTotalGSTPayment = MyTotalWrapPayment * 1.1m;
                totalGSTChargeTextBlock.Text = MyTotalGSTPayment.ToString();

            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
