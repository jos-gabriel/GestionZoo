using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace GestionZoo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection SqlConnection;
        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["GestionZoo.Properties.Settings.bd1ConnectionString"].ConnectionString;
            SqlConnection = new SqlConnection(connectionString);
            MuestraZoos();
        }

        private void MuestraZoos()
        {
            try
            {
                string consulta = "select*from Zoo";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, SqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable zooTable = new DataTable();
                    sqlDataAdapter.Fill(zooTable);

                    ListaZoos.DisplayMemberPath = "Ubicación";
                    ListaZoos.SelectedValuePath = "Id";
                    ListaZoos.ItemsSource = zooTable.DefaultView;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString ());
            }

        }
    }
}
