using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Model;

namespace CRUD.Controller.ProdutoController
{
    class ProdutoController
    {
        private string nome;
        private int quantidade = 1;

        public ProdutoController() {}

        public ProdutoController(int id)
        {
            this.Delete(new Produto(id));
        }

        public ProdutoController (string nome, int categoria, int quantidade, double valor)
        {
            this.nome = nome.Trim(); 
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            this.nome = ti.ToTitleCase(this.nome);

            if(quantidade > 1)
            {
                this.quantidade = quantidade;
            }


            this.Store(new Produto(nome, categoria, quantidade, valor));
        }

        public ProdutoController(int id, string nome, int categoria, int quantidade, double valor)
        {
            this.nome = nome.Trim();
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            this.nome = ti.ToTitleCase(this.nome);

            if (quantidade > 1)
            {
                this.quantidade = quantidade;
            }


            this.Update(new Produto(id, nome, categoria, quantidade, valor));
        }

        public bool Store(Produto produto)
        {
            return produto.Save();
        }

        public bool Update(Produto produto)
        {
            return produto.Update();
        }
        public bool Delete(Produto produto)
        {
            return produto.Delete();
        }
        public DataTable GetProdutos()
        {
            Produto produto = new Produto();
            return produto.GetAll();
        }

    }
}
