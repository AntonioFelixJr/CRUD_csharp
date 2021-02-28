using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD.DAO;

namespace CRUD.Model.Categoria
{
    class Categoria
    {
        private Conexao conexao;

        public Categoria()
        {
            this.conexao = new Conexao();
        }

        public DataTable GetCategorias()
        {
            return this.conexao.executeERetorne("SELECT * FROM categoria ORDER BY nome");
        }
    }
}
