using LibrarySystem324.Model;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Tls;
using System;
using System.Data;
using System.Windows.Forms;

namespace LibrarySystem324 {
    public partial class FrmSpecimen : Form {
        private Specimen selectedSpecimen;
        public FrmSpecimen() {
            InitializeComponent();
        }



        private void BtnAddSpecimen_Click(object sender, EventArgs e) {
            Specimen.CreateNew();
            ShowSpecimen();
        }



        private void DataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e) {
            try {
                DataGridView Grd = dataGridView1;
                DataTable Tbl = (DataTable)Grd.DataSource;
                DataRow SelRow = Tbl.Rows[e.RowIndex];
                Specimen specimen = new Specimen(SelRow);

                txtID.Text = specimen.ID.ToString();
                txtCommonName.Text = specimen.CommonName.ToString();
                txtColor.Text = specimen.Color.ToString();
                txtForm.Text = specimen.Form.ToString();
                txtWeight.Text = specimen.Weight.ToString();
                txtOrigin.Text = specimen.Origin.ToString();

                selectedSpecimen = specimen;
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
            }
        }


        private void ShowSpecimen() {
            // DataTable aTable = DBEngin.GetTable("select * from Book");
            DataTable aTable = Specimen.GetTableWithClassification();
            dataGridView1.DataSource = aTable;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Form1_Load(object sender, EventArgs e) {
            ShowSpecimen();
        }



        private void BtnSaveSpecimen_Click(object sender, EventArgs e) {
            //txtCommonName.Text, txtColor.Text, txtForm.Text, txtWeight.Text, txtOrigin.Text
            selectedSpecimen.CommonName = txtCommonName.Text;
            selectedSpecimen.Color = txtColor.Text;
            selectedSpecimen.Form = txtForm.Text;
            selectedSpecimen.Weight = txtWeight.Text;
            selectedSpecimen.Origin = txtOrigin.Text;

            selectedSpecimen.Save();
            ShowSpecimen();
        }

        private void BtnDeleteSpecimen_Click(object sender, EventArgs e) {
            selectedSpecimen.Delete();
            ShowSpecimen();
        }


        private void TxtSearch_TextChanged(object sender, EventArgs e) {
            dataGridView1.DataSource = Specimen.Search("CommonName like '%" + txtSearch.Text.Trim() + "%'");
        }
    }
}
