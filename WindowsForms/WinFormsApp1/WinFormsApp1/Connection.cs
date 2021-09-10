using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class Connection
    {

        static string ConexaoString = "DATA SOURCE=JOAOVITOR; INITIAL CATALOG=Prova; Trusted_Connection=True";

        static SqlConnection con;

        public SqlConnection Conectar()
        {
            con = new SqlConnection(ConexaoString);

            try
            {
                con.Open();
                //MessageBox.Show("Sistema Conectado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao tentar conectar com banco de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return con;
        }
        public void fechar()
        {
            con = new SqlConnection(ConexaoString);

            try
            {
                con.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao conectar no banco..." + e.Message);
            }
        }
    }
}
