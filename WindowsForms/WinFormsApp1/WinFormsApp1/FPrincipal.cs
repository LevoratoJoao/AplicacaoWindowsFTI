using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FPrincipal : Form
    {
        public FPrincipal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCurso curso = new FCurso();
            curso.ShowDialog();

        }

        private void FPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void alunoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FAluno aluno = new FAluno();
            aluno.ShowDialog();
            
        }
    }
}
