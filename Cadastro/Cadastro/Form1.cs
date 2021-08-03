using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro
{
    public partial class Form1 : Form
    {
        List<Pessoa> pessoas;

        public Form1()
        {
            InitializeComponent();

            pessoas = new List<Pessoa>();

            this.comboEC.Items.Add("Casado");
            this.comboEC.Items.Add("Solteiro");
            this.comboEC.Items.Add("Viuvo");
            this.comboEC.Items.Add("Separado");

            this.comboEC.SelectedIndex = 0;

            this.radioM.Checked = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int index = -1; // novo cadastro
            char sexo = 'M';
            
            foreach (Pessoa pessoa in pessoas)
            {
                if (pessoa.Nome == this.txtNome.Text)
                {
                    index = pessoas.IndexOf(pessoa);
                }
            }

            if (string.IsNullOrEmpty(this.txtNome.Text))
            {
                MessageBox.Show("Preencha o campo Nome.");
                this.txtNome.Focus();
                return;
            }
            if (this.txtTelefone.Text.Equals("(  )      -"))
            {
                MessageBox.Show("Preencha o campo Telefone.");
                this.txtTelefone.Focus();
                return;
            }

            if (this.radioM.Checked) sexo = 'M';
            if (this.radioF.Checked) sexo = 'F';
            if (this.radioO.Checked) sexo = 'O';

            Pessoa p = new Pessoa();
            p.Nome = this.txtNome.Text;
            p.DataNascimento = this.txtData.Text;
            p.EstadoCivil = this.comboEC.SelectedItem.ToString();
            p.Telefone = this.txtTelefone.Text;
            p.CasaPropria = checkCasa.Checked;
            p.Veiculo = checkVeiculo.Checked;
            p.Sexo = sexo;

            if (index < 0)
            {
                pessoas.Add(p);
            } 
            else
            {
                pessoas[index] = p;
            }

            this.btnLimpar_Click(this.btnLimpar, EventArgs.Empty);
            this.Listar();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int indice = lista.SelectedIndex;
            pessoas.RemoveAt(indice);
            this.Listar();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.txtNome.Text = "";
            this.txtData.Text = "";
            this.txtData.Text = "";
            this.comboEC.SelectedIndex = 0;
            this.txtTelefone.Text = "";
            this.checkCasa.Checked = false;
            this.checkVeiculo.Checked = false;
            this.radioM.Checked = true;
            this.radioF.Checked = false;
            this.radioO.Checked = false;
            this.txtNome.Focus();

        }

        private void Listar()
        {
            lista.Items.Clear();

            foreach(Pessoa p in pessoas)
            {
                lista.Items.Add(p);
            }

        }

        private void lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = lista.SelectedIndex;
            Pessoa p = pessoas[indice];

            this.txtNome.Text = p.Nome;
            this.txtData.Text = p.DataNascimento;
            this.comboEC.SelectedItem = p.EstadoCivil;
            this.txtTelefone.Text = p.Telefone;
            this.checkCasa.Checked = p.CasaPropria;
            this.checkVeiculo.Checked = p.Veiculo;
            
            switch (p.Sexo)
            {
                case 'M':
                    this.radioM.Checked = true;
                    break;
                case 'F':
                    this.radioF.Checked = true;
                    break;
                case 'O':
                    this.radioO.Checked = true;
                    break;
            }

        }
    }
}
