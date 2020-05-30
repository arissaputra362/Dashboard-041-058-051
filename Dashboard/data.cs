using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Dashboard
{
    /* Mohammad Aris Saputra (18051204041)
       M. Hafizh Ferdiansyah (18051204058)
       Gregorius Ferdyan S.  (18051204051)
       TI2018 B*/
    public partial class data : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmdTahunan;
        private DataTable dtTahunan;
        private string sqlTahunan;
        private OleDbCommand cmdPesananTahunan;
        private DataTable dtPesananTahunan;
        private string sqlPesananTahunan;
        public data()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            akun f = new akun();
            this.Hide();
            f.Show();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void data_load(object sender, EventArgs e)
        {
            conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Data.mdb;");
            conn.ConnectionString =
                        "Provider=Microsoft.Jet.OLEDB.4.0;" +
                        "Data Source = Data.mdb;";
            dataPendapatanTahunan();
            dataPesananTahunan();
            getDiagramPendapatanTahun();
            getDiagramPesananTahun();
        }

        public void dataPendapatanTahunan()
        {
            try
            {
                conn.Open();
                sqlTahunan = "SELECT Tahun, Bulan, Pendapatan FROM laporanBulanan";
                cmdTahunan = new OleDbCommand(sqlTahunan, conn);
                dtTahunan = new DataTable();
                dtTahunan.Load(cmdTahunan.ExecuteReader());
                laporanTahunan.DataSource = null;
                laporanTahunan.DataSource = dtTahunan;
                conn.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void dataPesananTahunan()
        {
            try
            {
                conn.Open();
                sqlPesananTahunan = "SELECT Tahun, Bulan, Pesanan FROM laporanBulanan";
                cmdPesananTahunan = new OleDbCommand(sqlPesananTahunan, conn);
                dtPesananTahunan = new DataTable();
                dtPesananTahunan.Load(cmdPesananTahunan.ExecuteReader());
                laporanPesananTahunan.DataSource = null;
                laporanPesananTahunan.DataSource = dtPesananTahunan;
                conn.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getDiagramPendapatanTahun()
        {
            grafikPendapatanTahun.AxisX.Add(new Axis
            {
                Title = "Bulan",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "Mei", "Jun", "Jul", "Agu", "Sep", "Okt", "Nov", "Des" }
            });

            grafikPendapatanTahun.AxisY.Add(new Axis
            {
                Title = "Pendapatan",
                LabelFormatter = value => value.ToString("C")
            });

            grafikPendapatanTahun.LegendLocation = LegendLocation.Right;

            grafikPendapatanTahun.Series.Clear();
            SeriesCollection series = new SeriesCollection();

            try
            {
                conn.Open();
                OleDbDataReader myReader = cmdTahunan.ExecuteReader();

                List<string> yearsList = new List<string>();
                while (myReader.Read())
                {
                    yearsList.Add(myReader["Tahun"].ToString());
                }
                var years = yearsList.Distinct();

                //create dot based on monthly frequency
                foreach (var year in years)
                {
                    List<double> frekuensiList = new List<double>();
                    for (int month = 1; month <= 12; month++)
                    {
                        double frekuensi = 0;
                        DataRow[] result = dtTahunan.Select("Tahun = " + year + " AND Bulan = " + month);
                        foreach (DataRow row in result)
                        {
                            frekuensi = Double.Parse(row[2].ToString());
                        }
                        frekuensiList.Add(frekuensi);
                    }
                    series.Add(new LineSeries()
                    {
                        Title = year.ToString(),
                        Values = new ChartValues<double>(frekuensiList)
                    });
                }
                grafikPendapatanTahun.Series = series;
                conn.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }

            grafikPendapatanTahun.DataClick += CartesianChart1OnDataClick;
        }

        public void getDiagramPesananTahun()
        {
            grafikPesananTahun.AxisX.Add(new Axis
            {
                Title = "Bulan",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "Mei", "Jun", "Jul", "Agu", "Sep", "Okt", "Nov", "Des" }
            });

            grafikPesananTahun.AxisY.Add(new Axis
            {
                Title = "Pesanan",
            });

            grafikPesananTahun.LegendLocation = LegendLocation.Right;

            grafikPesananTahun.Series.Clear();
            SeriesCollection series = new SeriesCollection();

            try
            {
                conn.Open();
                OleDbDataReader myReader = cmdPesananTahunan.ExecuteReader();

                List<string> yearsList = new List<string>();
                while (myReader.Read())
                {
                    yearsList.Add(myReader["Tahun"].ToString());
                }
                var years = yearsList.Distinct();

                //create dot based on monthly frequency
                foreach (var year in years)
                {
                    List<double> frekuensiList = new List<double>();
                    for (int month = 1; month <= 12; month++)
                    {
                        double frekuensi = 0;
                        DataRow[] result = dtPesananTahunan.Select("Tahun = " + year + " AND Bulan = " + month);
                        foreach (DataRow row in result)
                        {
                            frekuensi = Double.Parse(row[2].ToString());
                        }
                        frekuensiList.Add(frekuensi);
                    }
                    series.Add(new LineSeries()
                    {
                        Title = year.ToString(),
                        Values = new ChartValues<double>(frekuensiList)
                    });
                }
                grafikPesananTahun.Series = series;
                conn.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }

            grafikPesananTahun.DataClick += CartesianChart1OnDataClick;
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            coffe_shop f = new coffe_shop();
            this.Hide();
            f.Show();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (!bunifuCards2.Visible)
            {
                bunifuTransition1.ShowSync(bunifuCards2);
                bunifuTransition1.ShowSync(bunifuCards3);
                bunifuTransition1.ShowSync(bunifuCards4);
            }
            else
            {
                bunifuTransition1.HideSync(bunifuCards2);
                bunifuTransition1.HideSync(bunifuCards3);
                bunifuTransition1.HideSync(bunifuCards4);
            }
        }
    }
}
