using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class ControlAluno
    {
        public void InserirMatricula (SqlConnection con, int mat, string nome, string cpf, string email, string telefone, string cidade, string uf, int codigo)
        {
            string query = "INSERT INTO ALUNO VALUES (@MAT, @NOME, @CPF, @EMAIL, @TELEFONE, @CIDADE, @UF, @IDCURSO)";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.Parameters.Add(new SqlParameter("@MAT", mat));
                cmd.Parameters.Add(new SqlParameter("@NOME", nome));
                cmd.Parameters.Add(new SqlParameter("@CPF", cpf));
                cmd.Parameters.Add(new SqlParameter("@EMAIL", email));
                cmd.Parameters.Add(new SqlParameter("@TELEFONE", telefone));
                cmd.Parameters.Add(new SqlParameter("@CIDADE", cidade));
                cmd.Parameters.Add(new SqlParameter("@UF", uf));
                cmd.Parameters.Add(new SqlParameter("@IDCURSO", codigo));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Matrícula registrada com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro no banco de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public DadosAluno PesquisarAluno (SqlConnection con, int mat, DadosAluno aluno)
        {
            string query = "SELECT * FROM ALUNO WHERE MAT = '" + mat + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader;
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    aluno.SetMat(int.Parse(reader[0].ToString()));
                    aluno.SetNome(reader[1].ToString());
                    aluno.SetCPF(reader[2].ToString());
                    aluno.SetEmail(reader[3].ToString());
                    aluno.SetTelefone(reader[4].ToString());
                    aluno.SetCidade(reader[5].ToString());
                    aluno.SetUf(reader[6].ToString());
                    aluno.SetIdCurso(int.Parse(reader[7].ToString()));
                    reader.Close();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Erro ao pesquisar matrícula", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return aluno;
        }

        public void AlterarMatricula (SqlConnection con, string nome, string cpf, string email, string telefone, string cidade, string uf, int codigo, int mat)
        {
            string query = "UPDATE ALUNO\nSET NOME = @NOME,\nCPF = @CPF,\nEMAIL = @EMAIL,\nTELEFONE = @TELEFONE," +
                           "CIDADE = @CIDADE,\nUF = @UF,\nIDCURSO = @IDCURSO\nWHERE MAT = @MAT";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.Parameters.Add(new SqlParameter("@MAT", mat));
                cmd.Parameters.Add(new SqlParameter("@NOME", nome));
                cmd.Parameters.Add(new SqlParameter("@CPF", cpf));
                cmd.Parameters.Add(new SqlParameter("@EMAIL", email));
                cmd.Parameters.Add(new SqlParameter("@TELEFONE", telefone));
                cmd.Parameters.Add(new SqlParameter("@CIDADE", cidade));
                cmd.Parameters.Add(new SqlParameter("@UF", uf));
                cmd.Parameters.Add(new SqlParameter("@IDCURSO", codigo));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Matrícula alterada com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro no banco de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExcluirAluno (SqlConnection con, int mat)
        {
            string query = "DELETE FROM ALUNO WHERE MAT = '" + mat + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            int ret = cmd.ExecuteNonQuery();

            if (ret == 0)
            {
                MessageBox.Show("Matrícula excluida com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ao excluir matrícula", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
