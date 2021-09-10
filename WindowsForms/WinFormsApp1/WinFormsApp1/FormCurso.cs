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
    public partial class FCurso : Form
    {

        private static SqlConnection con;
        public FCurso()
        {
            InitializeComponent();
        }

        private void FCurso_Load(object sender, EventArgs e)
        {
            Connection c = new Connection();
            con = c.Conectar();
            //MessageBox.Show("Sistema Conectado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Controle();
        }

        private void FCurso_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "" || txtCodigo.Text == "")
            {
                MessageBox.Show("Campo descrição do Curso obrigatório", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ControlCurso curso = new ControlCurso();
                DadosCurso dadosCurso = new DadosCurso();


                dadosCurso.SetIdCurso(int.Parse(txtCodigo.Text));
                dadosCurso.SetDescCurso(txtDescricao.Text);
                dadosCurso.SetDuracaoCurso(int.Parse(txtDuracao.Text));
                dadosCurso.SetValorCurso(double.Parse(txtValor.Text));

                curso.InserirCurso(con, dadosCurso.GetIdCurso(), dadosCurso.GetDescCurso(), dadosCurso.GetDuracaoCurso(), dadosCurso.GetValorCurso());
                Controle();
            }
        }

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            if (txtDescricao.Text == " " || txtCodigo.Text == "")
            {
                MessageBox.Show("Campo descrição do Curso obrigatório", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ControlCurso control = new ControlCurso();
                DadosCurso dadosCurso = new DadosCurso();

                dadosCurso.SetIdCurso(int.Parse(txtCodigo.Text));
                dadosCurso.SetDescCurso(txtDescricao.Text);
                dadosCurso.SetDuracaoCurso(int.Parse(txtDuracao.Text));
                dadosCurso.SetValorCurso(double.Parse(txtValor.Text));
                control.AlterarCurso(con, dadosCurso.GetDescCurso(), dadosCurso.GetDuracaoCurso(),
                                          dadosCurso.GetValorCurso(), dadosCurso.GetIdCurso());
            }
            Controle();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ControlCurso control = new ControlCurso();
            DadosCurso dadosCurso = new DadosCurso();

            dadosCurso.SetIdCurso(int.Parse(txtCodigo.Text));
            dadosCurso = control.PesquisarCurso(con, dadosCurso.GetIdCurso(), dadosCurso);
            if (dadosCurso.GetDescCurso() != null)
            {
                txtCodigo.Text = dadosCurso.GetIdCurso().ToString();
                txtDescricao.Text = dadosCurso.GetDescCurso();
                txtDuracao.Text = dadosCurso.GetDuracaoCurso().ToString();
                txtValor.Text = dadosCurso.GetValorCurso().ToString();
            }
            else
            {
                MessageBox.Show("Curso não encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Controle();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ControlCurso curso = new ControlCurso();
            DadosCurso dadosCurso = new DadosCurso();

            dadosCurso.SetIdCurso(int.Parse(txtCodigo.Text));
            curso.ExcluirCurso(con, dadosCurso.GetIdCurso());
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            btnInserir.Enabled = false;
            btnCancelar.Enabled = true;
            btnGravar.Enabled = true;
            btnAlterar.Enabled = true;
            btnPesquisar.Enabled = true;
            btnExcluir.Enabled = true;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Controle();
        }

        private void Controle()
        {
            txtCodigo.Clear();
            txtDescricao.Clear();
            txtDuracao.Clear();
            txtValor.Clear();

            btnInserir.Enabled = true;
            btnCancelar.Enabled = false;
            btnGravar.Enabled = false;
            btnAlterar.Enabled = false;
            btnPesquisar.Enabled = false;
            btnExcluir.Enabled = false;
        }
    }
}
