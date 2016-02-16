using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace ventana
{
    public partial class Form1 : Form
    {
        string selif = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            rtxtTexto.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            rtxtTexto.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            rtxtTexto.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String col = comboBox1.SelectedItem.ToString();
            switch (col)
            {
                case "Rojo": rtxtTexto.SelectionBackColor = Color.Red; break;
                case "Verde": rtxtTexto.SelectionBackColor = Color.Green; break;
                case "Amarillo": rtxtTexto.SelectionBackColor = Color.Yellow; break;
                case "Azul": rtxtTexto.SelectionBackColor = Color.Blue; break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Rojo");
            comboBox1.Items.Add("Verde");
            comboBox1.Items.Add("Azul");
            comboBox1.Items.Add("Amarillo");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sfdSave.Title = "Guarda tu Archivo";
            sfdSave.Filter = "Archivos txt |*.txt";
            if (sfdSave.ShowDialog() == DialogResult.OK)
            
                MessageBox.Show(sfdSave.FileName);
                rtxtTexto.SaveFile(sfdSave.FileName);
            
            rtxtTexto.Text = "";
        }

        private  void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog Bat = new OpenFileDialog();
            Bat.Title = "Selecciona el Archivo a Abrir";
            Bat.Filter = "Documentos txt|*.txt";
            if(Bat.ShowDialog() == DialogResult.OK)
            {
                selif = Bat.FileName;

                using (StreamReader SR = new StreamReader(selif))
                {
                    rtxtTexto.Text = SR.ReadToEnd();
                }
            }
        }
    }
}
