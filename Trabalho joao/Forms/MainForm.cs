using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_joao.Models;
using Trabalho_joao.Repository;

namespace Trabalho_joao.Forms
{
    public partial class MainForm : Form
    {
        private Usuario usuarioLogado;
        public MainForm( Usuario usuario)
        {
            InitializeComponent();
            usuarioLogado = usuario;
            FilmeRepository repo = new FilmeRepository();
            List<Filme> filmes = repo.ListarTodos();

            dgvFilmes.DataSource = filmes;
            


        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            FilmeRepository repo = new FilmeRepository();
            CadastroFilmeForm cadastrofilme = new CadastroFilmeForm(usuarioLogado);
            cadastrofilme.ShowDialog();
            dgvFilmes.DataSource = repo.ListarTodos();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            FilmeRepository repo = new FilmeRepository();
            if (dgvFilmes.CurrentRow == null)
            {
                MessageBox.Show("Por favor, selecione um filme para atualizar.");
                return;
            }
            Filme filmeSelecionado = (Filme)dgvFilmes.CurrentRow.DataBoundItem;
            UpdateFilmeForm updateFilme = new UpdateFilmeForm(filmeSelecionado);
            updateFilme.ShowDialog();
            dgvFilmes.DataSource = repo.ListarTodos();

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (dgvFilmes.CurrentRow != null)
            {
                Filme filmeSelecionado = (Filme)dgvFilmes.CurrentRow.DataBoundItem;


            
                
                    FilmeRepository repo = new FilmeRepository();
                    bool sucesso = repo.Deletar(filmeSelecionado.Id);

                    if (sucesso)
                    {
                        MessageBox.Show("Filme excluído com sucesso!");
                        
                        dgvFilmes.DataSource = repo.ListarTodos();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir o filme.");
                    }
                }
            }
           
            
            }
        }

    
    
