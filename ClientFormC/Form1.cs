using ServiceRest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientFormC
{
    public partial class Form1 : Form
    {
        ServiceHost hostObjek = null;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "SERVER OFF";
            label2.Text = "Klik ON untuk Menghidupkan Server";
            btOFF.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btON_Click(object sender, EventArgs e)
        {
            try
            {
                hostObjek = new ServiceHost(typeof(TI_UMY));
                hostObjek.Open();
                label1.Text = "SERVER ON";
                label2.Text = "Klik OFF untuk mematikan Server";
                btOFF.Enabled = true;
                btON.Enabled = false;

            }
            catch (Exception ex)
            {
            }
        }

        private void btOFF_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "SERVER OFF";
                btON.Enabled = false;
                label3.Text = "Server hanya bisa dinyalakan sekali";
                label4.Text = "Silahkan Close Server dan Run lagi";

            }
            catch (Exception ex)
            {
            }

        }
    }
}
