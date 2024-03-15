using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prova
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BLL.conecta();
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BLL.desconecta();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Limpar os ListBox
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            // Exibir no textBox2 o nome do cliente cujo CNPJ foi digitado no textBox1
            Cliente.setCNPJ(textBox1.Text);
            VendaCliente.setCNPJ(textBox1.Text);

            BLL.validaCNPJ();
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                textBox2.Text = Cliente.getNome();
            
            VendaCliente.setCNPJ(textBox1.Text); // Define o CNPJ com base no TextBox
            
            List<string> datasVendas = BLL.consultaVendasClienteData("data"); // Chama o método modificado
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
            }

            else
            {
                foreach (string data in datasVendas)
                {
                    listBox1.Items.Add(data); // Adiciona cada data ao ListBox
                }
            }
            
            List<string> toneladasVendidas = BLL.consultaVendasClienteData("toneladas"); // Chama o método modificado
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
            }

            else
            {
                foreach (string tonelada in toneladasVendidas)
                {
                        listBox2.Items.Add(tonelada); // Adiciona cada tonelada ao ListBox
                }

                // Somar os valores das toneladas vendidas
                double total = 0;
                foreach (string tonelada in toneladasVendidas)
                {
                    total += Convert.ToDouble(tonelada);
                }

                textBox3.Text = total.ToString();
            }

            List<string> valorVendas = BLL.consultaVendasClienteData("valor"); // Chama o método modificado
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
            }

            else
            {
                foreach (string valor in valorVendas)
                {
                    listBox3.Items.Add(valor); // Adiciona cada valor ao ListBox
                }

                
                // Somar os valores das vendas
                double total = 0;
                foreach (string valor in valorVendas)
                {
                    total += Convert.ToDouble(valor.Replace(",00",""));
                }

                // Procura o ponto e pega a string até o ponto
                textBox4.Text = total.ToString()+",00";
                
            }   

        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    string query = "SELECT * FROM TabClientes";
        //    DatabaseOperations.GetAll(dataGridView1,query);


        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    string query = "SELECT * FROM TabVendasCliente";
        //    DatabaseOperations.GetAll(dataGridView2, query);
        //}
    }
}
