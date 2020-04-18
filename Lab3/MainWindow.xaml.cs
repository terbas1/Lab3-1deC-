using System;
using System.Collections.Generic;
using System.Data;
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

namespace Lab3
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClsDatos obj = new ClsDatos();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            dgvPedido.ItemsSource = obj.ListaPedidoFechas(Convert.ToDateTime(txtFechaInicio.Text),
                Convert.ToDateTime(txtFechaFin.Text)).DefaultView;
        }

        private void DgvDetallePedido_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int idPedido;
            var item = dgvPedido.SelectedItem as DataRowView;
            if (null == item) return;
            idPedido = Convert.ToInt32(item.Row["IdPedido"]);
            dgvDetallePedido.ItemsSource = obj.ListarDetalle(idPedido).DefaultView;
            txtTotal.Text = Convert.ToString(obj.PedidoTotal(idPedido));

        }

       
    }
}
