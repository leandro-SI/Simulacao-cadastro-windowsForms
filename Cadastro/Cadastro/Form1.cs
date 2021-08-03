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
                    index = pessoas.IndexOf(p);
                }
            }

            if (string.IsNullOrEmpty(this.txtNome.Text))
            {
                MessageBox.Show("Preencha o campo Nome.");
                this.txtNome.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtTelefone.Text))
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

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

        }

        private void Listar()
        {
            this.lista.Items.Clear();

            foreach(Pessoa p in pessoas)
            {
                this.lista.Items.Add(p);
            }
        }
    }
}
