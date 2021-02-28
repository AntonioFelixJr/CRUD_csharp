using CRUD.DAO;
using System;
using System.Data;
using System.Globalization;

namespace CRUD.Model
{
    class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public int Quantidade { get; private set; }
        public int Categoria { get; private set; }
        public double Preco { get; private set; }

        public Produto() {}

        public Produto(int id)
        {
            this.Id = id;
        }

        public Produto (string nome, int categoria, int quantidade, double preco)
        {
            this.Nome = nome;
            this.Categoria = categoria;
            this.Quantidade = quantidade;
            this.Preco = preco;
        }
        public Produto(int id, string nome, int categoria, int quantidade, double preco)
        {
            this.Id = id;
            this.Nome = nome;
            this.Categoria = categoria;
            this.Quantidade = quantidade;
            this.Preco = preco;
        }
        public DataTable GetAll()
        {
            Conexao conexao = new Conexao();

            return conexao.executeERetorne(
                "SELECT p.id AS id, p.nome AS nome, c.nome AS categoria, p.quantidade AS quantidade, p.preco AS preco" +
                " FROM produto p " +
                "INNER JOIN categoria c ON c.id = p.categoria_id " +
                "ORDER BY id DESC");

        }

        public bool Save()
        {
            Conexao conexao = new Conexao();

            return conexao.execute($"INSERT INTO produto (nome, categoria_id, quantidade, preco) VALUES ('{this.Nome}', {this.Categoria}, {this.Quantidade}, {this.Preco})");
        }
        public bool Update()
        {
            Conexao conexao = new Conexao();
            try
            {

                return conexao.execute($"UPDATE produto SET nome = '{this.Nome}', categoria_id = {this.Categoria}, quantidade = {this.Quantidade}, preco = {this.Preco.ToString("F2", CultureInfo.InvariantCulture)} " +
                                        $" WHERE id = {this.Id}");

            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
        public bool Delete()
        {
            Conexao conexao = new Conexao();

            return conexao.execute($"DELETE FROM produto WHERE id = {this.Id}");
        }
    }
}
