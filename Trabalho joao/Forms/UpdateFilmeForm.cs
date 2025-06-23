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
    public partial class UpdateFilmeForm : Form
    {
        private Filme filmeOriginal;

        public UpdateFilmeForm(Filme filme)
        {
            InitializeComponent();
            filmeOriginal = filme;

            // Preenche os campos com os dados do filme
            textBox1.Text = filme.Titulo;
            textBox2.Text = filme.Genero;
            textBox3.Text = filme.AnoLancamento.ToString();
            textBox4.Text = filme.Diretor;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
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
                Id = filmeOriginal.Id, 
                Titulo = titulo,
                Genero = genero,
                AnoLancamento = ano,
                Diretor = diretor,
                UsuarioId = filmeOriginal.UsuarioId // Mantém o vínculo com o usuário
            };

            FilmeRepository repo = new FilmeRepository();
            bool sucesso = repo.Atualizar(novoFilme);

            if (sucesso)
            {
                MessageBox.Show("Filme atualizado com sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao atualizar o filme.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
