using System;
using System.IO;
using System.Windows.Forms;

namespace BusquedaRecursiva
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvFolders.Columns.Add("Files", "Folders and files");
            dgvFolders.Columns[0].Width = 1000;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Selected folder: " + dialog.SelectedPath, "Folder Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                FileRevision(dialog.SelectedPath);
                MessageBox.Show("If nothing is displayed in the 'DataGridView', this might be due to an inaccessible folder.");
            }
        }

        public void FileRevision(string mainFolder)
        {
            if (string.IsNullOrEmpty(mainFolder))
            {
                MessageBox.Show("Main folder is empty");
                return;
            }

            foreach (string subFolder in Directory.GetDirectories(mainFolder))
            {
                dgvFolders.Rows.Add("> " + subFolder.PadRight(15));
                Console.WriteLine("\n " + subFolder);

                foreach (string file in Directory.GetFiles(subFolder))
                {
                    dgvFolders.Rows.Add(file);
                    Console.WriteLine(file);
                }

                FileRevision(subFolder);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
