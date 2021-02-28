using System;
using System.Windows.Forms;
using CRUD.Model.Categoria;
using CRUD.Controller.ProdutoController;
using System.Globalization;
using System.Data;

namespace CRUD.View
{
    public partial class GerenciarProduto : Form
    {
        private int IdProduto;
        public GerenciarProduto()
        {
            InitializeComponent();
        }

        private void GerenciarProduto_Load(object sender, EventArgs e)
        {
            this.CarregarTabela();
            this.CarregarCategoria();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;

            int categoriaId = int.Parse(cboCategoria.SelectedValue.ToString());
            int quantidade = int.Parse(txtQuantidade.Text);
            double valor = double.Parse(txtValor.Text);


            _ = new ProdutoController(nome, categoriaId, quantidade, valor);

            this.CarregarTabela();
        }

        private void CarregarTabela()
        {
            dtgProdutos.AutoGenerateColumns = true;
            ProdutoController produtoController = new ProdutoController();
            
            DataTable produtos = produtoController.GetProdutos();

            dtgProdutos.Rows.Clear();
            dtgProdutos.Refresh();

            for (int i = 0; i < produtos.Rows.Count; i++)
            {
                dtgProdutos.Rows.Add(produtos.Rows[i].ItemArray);
            }
        }

        private void CarregarCategoria()
        {
            Categoria categoria = new Categoria();
            cboCategoria.DataSource = categoria.GetCategorias();
            cboCategoria.DisplayMember = "nome";
            cboCategoria.ValueMember = "id";
        }

        private void dtgProdutos_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dtgProdutos.SelectedRows.Count == 1)
            {
                this.btnEditar.Enabled = true;
                this.btnExcluir.Enabled = true;
            }
            else
            {
                this.btnEditar.Enabled = false;
                this.btnExcluir.Enabled = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.btnEditar.Text == "Editar")
            {
                DataGridViewRow item = this.dtgProdutos.SelectedRows[0];
                this.IdProduto = int.Parse(item.Cells[0].Value.ToString());
                txtNome.Text = item.Cells[1].Value.ToString();
                txtQuantidade.Text = item.Cells[3].Value.ToString();
                txtValor.Text = item.Cells[4].Value.ToString().Replace(',', '.');
                cboCategoria.Text = item.Cells[2].Value.ToString();
                this.btnEditar.Text = "Atualizar";
                this.btnCancelar.Enabled = true;
            }
            else
            {

                MessageBox.Show("Atualizar o id = " + this.IdProduto.ToString());
                this.btnCancelar.Enabled = false;

                string nome = this.txtNome.Text;
                int categoriaId = int.Parse(this.cboCategoria.SelectedValue.ToString());
                int quantidade = int.Parse(this.txtQuantidade.Text);
                double valor = double.Parse(this.txtValor.Text.ToString(), CultureInfo.InvariantCulture);

                _ = new ProdutoController(this.IdProduto, nome, categoriaId, quantidade, valor);

                this.limpar();
                this.CarregarTabela();
            }
        }

        private void limpar()
        {
            this.txtNome.Clear();
            this.txtQuantidade.Clear();
            this.txtValor.Clear();
            this.cboCategoria.SelectedIndex = 0;
            this.IdProduto = 0;
            this.btnEditar.Text = "Editar";
            this.dtgProdutos.ClearSelection();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpar();
            this.btnCancelar.Enabled = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DataGridViewRow item = this.dtgProdutos.SelectedRows[0];
            this.IdProduto = int.Parse(item.Cells[0].Value.ToString());
            MessageBox.Show("Excluir o id = " + this.IdProduto.ToString());

            _ = new ProdutoController(this.IdProduto);

            this.limpar();
            this.CarregarTabela();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
