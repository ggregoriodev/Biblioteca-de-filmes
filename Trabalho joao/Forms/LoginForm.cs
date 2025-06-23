using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_joao.Forms;
using Trabalho_joao.Models;
using Trabalho_joao.Repository;

namespace Crud
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string senha = textBox2.Text;

            UsuarioRepository repo = new UsuarioRepository();
           
            Usuario usuario = repo.BuscarPorEmailSenha(email, senha);

            if (usuario != null)
            {
              
                MessageBox.Show($"Bem-vindo, {usuario.Nome}!");
                MainForm listafilmes = new MainForm(usuario);
               listafilmes.ShowDialog();

            }
            else
            {
                MessageBox.Show("Email ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnCadastrar_click(object sender, EventArgs e)
        {
            CadastroForm cadastro = new CadastroForm();
            cadastro.ShowDialog();
        }

    }
}
