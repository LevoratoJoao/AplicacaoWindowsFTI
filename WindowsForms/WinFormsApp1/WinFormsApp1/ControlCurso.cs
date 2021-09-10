using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class ControlCurso
    {
        public void InserirCurso(SqlConnection con, int id, string nome, int duracao, double valor)
        {
            string query = "INSERT INTO CURSO VALUES (@IDCURSO, @DESCRICAO, @PERIODO, @VALOR)";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.Parameters.Add(new SqlParameter("@IDCURSO", id));
                cmd.Parameters.Add(new SqlParameter("@DESCRICAO", nome));
                cmd.Parameters.Add(new SqlParameter("@PERIODO", duracao));
                cmd.Parameters.Add(new SqlParameter("@VALOR", valor));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Curso registrado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro no banco de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void AlterarCurso(SqlConnection con, string descricao, int duracao, double valor, int id)
        {
            string query = "UPDATE CURSO\nSET DESCRICAO = @DESCRICAO,\nPERIODO = @PERIODO,\nVALOR = @VALOR\nWHERE IDCURSO = @IDCURSO";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.Parameters.Add(new SqlParameter("@DESCRICAO", descricao));
                cmd.Parameters.Add(new SqlParameter("@PERIODO", duracao));
                cmd.Parameters.Add(new SqlParameter("@VALOR", valor));
                cmd.Parameters.Add(new SqlParameter("@IDCURSO", id));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Curso alterado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro no banco de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DadosCurso PesquisarCurso(SqlConnection con, int id, DadosCurso curso)
        {
            string query = "SELECT * FROM CURSO WHERE IDCURSO = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader;
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    curso.SetIdCurso(int.Parse(reader[0].ToString()));
                    curso.SetDescCurso(reader[1].ToString());
                    curso.SetDuracaoCurso(int.Parse(reader[2].ToString()));
                    curso.SetValorCurso(double.Parse(reader[3].ToString()));
                    reader.Close();
                } 
            }
            catch(Exception)
            {
                MessageBox.Show("Erro ao pesquisar curso", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return curso;
        } 

        public void ExcluirCurso(SqlConnection con, int id)
        {
            string query = "DELETE FROM CURSO WHERE IDCURSO = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            int ret = cmd.ExecuteNonQuery();
            if (ret == 0)
            {
                MessageBox.Show("Curso excluido com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ao excluir curso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
