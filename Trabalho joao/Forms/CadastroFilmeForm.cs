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
    public partial class CadastroFilmeForm : Form
    {
        private int usuarioId;

        public CadastroFilmeForm(Usuario usuariologado)
        {
            InitializeComponent();
            usuarioId = usuariologado.Id;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string titulo = textBox1.Text.Trim();
            string genero = textBox2.Text.Trim();

            int ano;
            if (!int.TryParse(textBox3.Text, out ano))
            {
                MessageBox.Show("Por favor, insira um ano válido.");
                return;
            }

            string diretor = textBox4.Text.Trim();


            Filme novoFilme = new Filme
            {
                Titulo = titulo,
                Genero = genero,
                AnoLancamento = ano,
                Diretor = diretor,
                UsuarioId = usuarioId
            };

            FilmeRepository repo = new FilmeRepository();
            bool sucesso = repo.Inserir(novoFilme);

            if (sucesso)
            {
                MessageBox.Show("Filme cadastrado com sucesso!");
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar o filme.");
            }
        }
    }
}

