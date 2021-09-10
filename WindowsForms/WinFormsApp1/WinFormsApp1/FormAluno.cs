using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FAluno : Form
    {
        private static SqlConnection con;

        public FAluno()
        {
            InitializeComponent();
        }

        private void FAluno_Load(object sender, EventArgs e)
        {
            Connection c = new Connection();
            con = c.Conectar();
            //MessageBox.Show("Sistema Conectado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Controle();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            btnInserir.Enabled = false;
            btnGravar.Enabled = true;
            btnCancelar.Enabled = true;
            btnAlterar.Enabled = true;
            btnCancelar.Enabled = true;
            btnPesquisar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (txtMatricula.Text == "" || txtNome.Text == "" || txtCpf.Text == "" || txtCurso.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ControlAluno aluno = new ControlAluno();
                DadosAluno dadosAluno = new DadosAluno();

                dadosAluno.SetMat(int.Parse(txtMatricula.Text));
                dadosAluno.SetNome(txtNome.Text);
                dadosAluno.SetCPF(txtCpf.Text);
                dadosAluno.SetEmail(txtEmail.Text);
                dadosAluno.SetTelefone(txtTelefone.Text);
                dadosAluno.SetCidade(txtCidade.Text);
                dadosAluno.SetUf(txtUf.Text);
                dadosAluno.SetIdCurso(int.Parse(txtCurso.Text));

                aluno.InserirMatricula(con, dadosAluno.GetMat(), dadosAluno.GetNome(), dadosAluno.GetCPF(), dadosAluno.GetEmail(),
                                       dadosAluno.GetTelefone(), dadosAluno.GetCidade(), dadosAluno.GetUf(), dadosAluno.GetIdCurso());

                Controle();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ControlAluno aluno = new ControlAluno();
            DadosAluno dadosAluno = new DadosAluno();

            dadosAluno.SetMat(int.Parse(txtMatricula.Text));
            dadosAluno = aluno.PesquisarAluno(con, dadosAluno.GetMat(), dadosAluno);
            if (dadosAluno.GetNome() != null)
            {
                txtMatricula.Text = dadosAluno.GetMat().ToString();
                txtNome.Text = dadosAluno.GetNome();
                txtCpf.Text = dadosAluno.GetCPF();
                txtEmail.Text = dadosAluno.GetEmail();
                txtTelefone.Text = dadosAluno.GetTelefone();
                txtCidade.Text = dadosAluno.GetCidade();
                txtUf.Text = dadosAluno.GetUf();
                txtCurso.Text = dadosAluno.GetIdCurso().ToString();
            }
            else
            {
                MessageBox.Show("Matrícula não encontrada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Controle();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtMatricula.Text == "" || txtNome.Text == "" || txtCpf.Text == "" || txtCurso.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ControlAluno aluno = new ControlAluno();
                DadosAluno dadosAluno = new DadosAluno();

                dadosAluno.SetMat(int.Parse(txtMatricula.Text));
                dadosAluno.SetNome(txtNome.Text);
                dadosAluno.SetCPF(txtCpf.Text);
                dadosAluno.SetEmail(txtEmail.Text);
                dadosAluno.SetTelefone(txtTelefone.Text);
                dadosAluno.SetCidade(txtCidade.Text);
                dadosAluno.SetUf(txtUf.Text);
                dadosAluno.SetIdCurso(int.Parse(txtCurso.Text));

                aluno.AlterarMatricula(con, dadosAluno.GetNome(), dadosAluno.GetCPF(), dadosAluno.GetEmail(), dadosAluno.GetTelefone(),
                                       dadosAluno.GetCidade(), dadosAluno.GetUf(), dadosAluno.GetIdCurso(), dadosAluno.GetMat());               
                Controle();
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ControlAluno aluno = new ControlAluno();
            DadosAluno dadosAluno = new DadosAluno();

            dadosAluno.SetMat(int.Parse(txtMatricula.Text));
            aluno.ExcluirAluno(con, dadosAluno.GetMat());
            Controle();
        }
       
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Controle();
        }

        private void Controle()
        {
            txtMatricula.Clear();
            txtNome.Clear();
            txtCpf.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtCidade.Clear();
            txtUf.Clear();
            txtCurso.Clear();
            txtMatricula.Select();

            btnInserir.Enabled = true;
            btnGravar.Enabled = false;
            btnCancelar.Enabled = false;
            btnAlterar.Enabled = false;
            btnCancelar.Enabled = false;
            btnPesquisar.Enabled = false;
            btnExcluir.Enabled = false;

        }
    }
}
