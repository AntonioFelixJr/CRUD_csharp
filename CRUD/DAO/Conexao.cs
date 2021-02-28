using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUD.DAO
{
    class Conexao
    {
        private SqlConnection conn;

        public Conexao()
        {
            this.abrir();
        }

        public bool execute(string comandoSql)
        {
            try
            {
                SqlCommand command = new SqlCommand(comandoSql, this.conn);
                command.ExecuteNonQuery();

            } catch (Exception e)
            {
                Console.WriteLine(comandoSql+"\n" + e.ToString());
                return false;
            } finally
            {
                this.conn.Close();
            }

            return true;
        }

        public DataTable executeERetorne(string comandoSql)
        {
            SqlCommand command = new SqlCommand(comandoSql, this.conn);
            SqlDataAdapter adp = new SqlDataAdapter(command);

            DataTable dataTable = new DataTable();
            adp.Fill(dataTable);

            this.conn.Close();

            return dataTable;
        }

        private bool abrir()
        {
            string connetionString;
            connetionString = @"Data Source=DESKTOP-V7TQEBS;Initial Catalog=db_products;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connetionString);
            try
            {
                conn.Open();
                this.conn = conn;
            } catch (Exception e)
            {

                MessageBox.Show(e.ToString());
                return false;
            }

            return true;
        }
    }
}
