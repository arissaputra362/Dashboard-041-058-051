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
    public partial class Form1 : Form
    {
        bool grafikPendapatan = true;
        //private var con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = \\Data.mdb;");
        private OleDbConnection conn;
        private OleDbCommand cmdTahunan;
        private OleDbCommand cmdBulanan;
        private OleDbCommand cmdTotal;
        private DataTable dtTahunan;
        private DataTable dtBulanan;
        private string sqlTahunan;
        private string sqlBulanan;
        private string sqlTotal;
        public Form1()
        {
            InitializeComponent(); 
        }

        private void bunifuCards3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void bunifu_cards_mouseenter(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.animated = true;
            bunifuCircleProgressbar2.animated = true;
        }

        private void bunifu_cards_mouseleft(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.animated = false;
            bunifuCircleProgressbar2.animated = false;
        }

        private void form_load(object sender, EventArgs e)
        {
            //koneksi database
            conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Data.mdb;");
            conn.ConnectionString =
                        "Provider=Microsoft.Jet.OLEDB.4.0;" +
                        "Data Source = Data.mdb;";
            dataTotal();
            
            dataTahunan();
            getDiagramPendapatanTahun();
            getDiagramPesananTahun();

            dataBulanan();
            getDiagramPendapatanBulanan();
            getDiagramPesananBulanan();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            akun f = new akun();
            this.Hide();
            f.Show();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            data f = new data();
            this.Hide();
            f.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            coffe_shop c = new coffe_shop();
            this.Hide();
            c.Show();
        }

        private void cartesianChart1_ChildChanged_1(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            laporanBulanan.Visible = false;
            laporanTahunan.Visible = true;
            if (!grafikPendapatan)
            {
                grafikPesananBulan.Visible = false;
                grafikPesananTahun.Visible = true;
            }
            else
            {
                grafikPendapatanBulan.Visible = false;
                grafikPendapatanTahun.Visible = true;
            }
            
            buttonBulan.BackColor = Color.Transparent;
            buttonBulan.ForeColor = Color.DarkOrange;
            buttonTahun.BackColor = Color.DarkOrange;
            buttonTahun.ForeColor = Color.White;
        }

        private void buttonBulan_Click(object sender, EventArgs e)
        {
            laporanBulanan.Visible = true;
            laporanTahunan.Visible = false;
            if (!grafikPendapatan)
            {
                grafikPesananBulan.Visible = true;
                grafikPesananTahun.Visible = false;
            }
            else
            {
                grafikPendapatanBulan.Visible = true;
                grafikPendapatanTahun.Visible = false;
            }

            buttonTahun.BackColor = Color.Transparent;
            buttonTahun.ForeColor = Color.DarkOrange;
            buttonBulan.BackColor = Color.DarkOrange;
            buttonBulan.ForeColor = Color.White;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonBulan.BackColor = Color.Transparent;
            buttonBulan.ForeColor = Color.DarkOrange;
            buttonTahun.BackColor = Color.DarkOrange;
            buttonTahun.ForeColor = Color.White;

            if (comboBox1.Text == "Grafik Pendapatan")
            {
                laporanTahunan.Visible = true;
                grafikPesananBulan.Visible = false;
                grafikPesananTahun.Visible = false;
                grafikPendapatanBulan.Visible = false;
                grafikPendapatanTahun.Visible = true;
                grafikPendapatan = true;

            }
            else if(comboBox1.Text == "Grafik Pesanan")
            {
                laporanTahunan.Visible = true;
                grafikPesananBulan.Visible = false;
                grafikPendapatanBulan.Visible = false;
                grafikPendapatanTahun.Visible = false;
                grafikPesananTahun.Visible = true;
                grafikPendapatan = false;
            }
        }

        //Chart Data Tahunan
        public void dataTahunan()
        {
            try
            {
                conn.Open();
                sqlTahunan = "SELECT Tahun, Bulan, Pesanan, Pendapatan FROM laporanBulanan";
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
                foreach(var year in years)
                {
                    List<double> frekuensiList = new List<double>();
                    for (int month = 1; month <= 12; month++)
                    {
                        double frekuensi = 0;
                        DataRow[] result = dtTahunan.Select("Tahun = " + year + " AND Bulan = " + month);
                        foreach(DataRow row in result)
                        {
                            frekuensi = Double.Parse(row[3].ToString());
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
            catch(OleDbException ex)
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
                grafikPesananTahun.Series = series;
                conn.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }

            grafikPesananTahun.DataClick += CartesianChart1OnDataClick;
        }

        //Chart Data Bulanan
        public void dataBulanan()
        {
            try
            {
                conn.Open();
                sqlBulanan = "SELECT Bulan, Minggu, Pesanan, Pendapatan FROM laporanMingguan";
                cmdBulanan = new OleDbCommand(sqlBulanan, conn);
                dtBulanan = new DataTable();
                dtBulanan.Load(cmdBulanan.ExecuteReader());
                laporanBulanan.DataSource = null;
                laporanBulanan.DataSource = dtBulanan;
                conn.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getDiagramPesananBulanan()
        {
            grafikPesananBulan.AxisX.Add(new Axis
            {
                Title = "Minggu ke",
                Labels = new[] { "1", "2", "3", "4", "5" }
            });

            grafikPesananBulan.AxisY.Add(new Axis
            {
                Title = "Pesanan",
            });

            grafikPesananBulan.LegendLocation = LegendLocation.Right;

            grafikPesananBulan.Series.Clear();
            SeriesCollection series = new SeriesCollection();

            try
            {
                conn.Open();
                OleDbDataReader myReader = cmdBulanan.ExecuteReader();

                List<string> monthsList = new List<string>();
                while (myReader.Read())
                {
                    monthsList.Add(myReader["Bulan"].ToString());
                }
                var months = monthsList.Distinct();

                //create dot based on monthly frequency
                foreach (var month in months)
                {
                    List<double> frekuensiList = new List<double>();
                    for (int week = 1; week <= 5; week++)
                    {
                        double frekuensi = 0;
                        DataRow[] result = dtBulanan.Select("Bulan = " + month + " AND Minggu = " + week);
                        foreach (DataRow row in result)
                        {
                            frekuensi = Double.Parse(row[2].ToString());
                        }
                        frekuensiList.Add(frekuensi);
                    }
                    series.Add(new LineSeries()
                    {
                        Title = month.ToString(),
                        Values = new ChartValues<double>(frekuensiList)
                    });
                }
                grafikPesananBulan.Series = series;
                conn.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }

            grafikPesananBulan.DataClick += CartesianChart1OnDataClick;
        }

        public void getDiagramPendapatanBulanan()
        {
            grafikPendapatanBulan.AxisX.Add(new Axis
            {
                Title = "Minggu ke",
                Labels = new[] { "1", "2", "3", "4", "5" }
            });

            grafikPendapatanBulan.AxisY.Add(new Axis
            {
                Title = "Pendapatan",
                LabelFormatter = value => value.ToString("C")
            });

            grafikPendapatanBulan.LegendLocation = LegendLocation.Right;

            grafikPendapatanBulan.Series.Clear();
            SeriesCollection series = new SeriesCollection();

            try
            {
                conn.Open();
                OleDbDataReader myReader = cmdBulanan.ExecuteReader();

                List<string> monthsList = new List<string>();
                while (myReader.Read())
                {
                    monthsList.Add(myReader["Bulan"].ToString());
                }
                var months = monthsList.Distinct();

                //create dot based on monthly frequency
                foreach (var month in months)
                {
                    List<double> frekuensiList = new List<double>();
                    for (int week = 1; week <= 5; week++)
                    {
                        double frekuensi = 0;
                        DataRow[] result = dtBulanan.Select("Bulan = " + month + " AND Minggu = " + week);
                        foreach (DataRow row in result)
                        {
                            frekuensi = Double.Parse(row[3].ToString());
                        }
                        frekuensiList.Add(frekuensi);
                    }
                    series.Add(new LineSeries()
                    {
                        Title = month.ToString(),
                        Values = new ChartValues<double>(frekuensiList)
                    });
                }
                grafikPendapatanBulan.Series = series;
                conn.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }

            grafikPendapatanBulan.DataClick += CartesianChart1OnDataClick;
        }

        //Akses Data Total
        public void dataTotal()
        {
            try
            {
                conn.Open();
                sqlTotal = "SELECT Pesanan, Pendapatan, Pelanggan FROM Total";
                cmdTotal = new OleDbCommand(sqlTotal, conn);
                using (OleDbDataReader myReader = cmdTotal.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        totalPesanan.Text = myReader["Pesanan"].ToString();
                        totalPendapatan.Text = "Rp " + myReader["Pendapatan"].ToString();
                        totalPelanggan.Text = myReader["Pelanggan"].ToString();
                    }
                }
                conn.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}