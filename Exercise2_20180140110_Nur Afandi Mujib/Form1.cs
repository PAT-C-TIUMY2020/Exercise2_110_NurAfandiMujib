using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise2_20180140110_Nur_Afandi_Mujib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        string baseUrl = "http://localhost:1907/";
        private void btInsert_Click(object sender, EventArgs e)
        {
            Mahasiswa mhs = new Mahasiswa();
            mhs.nama = textBoxNama.Text;
            mhs.nim = textBoxNIM.Text;
            mhs.prodi = textBoxProdi.Text;
            mhs.angkatan = textBoxAngkatan.Text;

            var data = JsonConvert.SerializeObject(mhs);
            var postdata = new WebClient();
            postdata.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string response = postdata.UploadString(baseUrl + "Mahasiswa", data);
            Console.WriteLine(response);
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = getAllData();
        }
        public void SearchData()
        {
            var json = new WebClient().DownloadString("http://localhost:1907/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
            string nim = textBoxSearchNIM.Text;
            if (nim == null || nim == "")
            {
                dataGridView1.DataSource = data;
            }
            else
            {
                var item = data.Where(x => x.nim == textBoxSearchNIM.Text).ToList();

                dataGridView1.DataSource = item;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxNama.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            textBoxNIM.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            textBoxProdi.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            textBoxAngkatan.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
        }
        public List<Mahasiswa> getAllData()
        {
            var json = new WebClient().DownloadString("http://localhost:1907/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
            return data;
        }
        [DataContract]
        public class Mahasiswa
        {
            private string _nama, _nim, _prodi, _angkatan;
            [DataMember]
            public string nama
            {
                get { return _nama; }
                set { _nama = value; }
            }
            [DataMember]
            public string nim
            {
                get { return _nim; }
                set { _nim = value; }
            }
            [DataMember]
            public string prodi
            {
                get { return _prodi; }
                set { _prodi = value; }
            }
            [DataMember]
            public string angkatan
            {
                get { return _angkatan; }
                set { _angkatan = value; }
            }
        }

        private void btSearchNIM_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            textBoxNama.Clear();
            textBoxNIM.Clear();
            textBoxProdi.Clear();
            textBoxAngkatan.Clear();
        }
    }
}
