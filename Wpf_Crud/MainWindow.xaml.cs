using System.Windows;
using System.Windows.Controls;
using Wpf_Crud.Models;
using Wpf_Crud.Services;

namespace Wpf_Crud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PessoaService _pessoaService = new PessoaService();
        private Pessoa? _pessoaSelecionada;

        public MainWindow()
        {
            InitializeComponent();
            CarregarPessoas();
        }

        private void CarregarPessoas()
        {
            dgPessoas.ItemsSource = _pessoaService.GetAll();
        }

        private void dgPessoas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _pessoaSelecionada = (Pessoa)dgPessoas.SelectedItem;

            if (_pessoaSelecionada != null)
            {
                txtNome.Text = _pessoaSelecionada.Nome;
                txtIdade.Text = _pessoaSelecionada.Idade.ToString();
            }
        }

        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtNome.Text) || !int.TryParse(txtIdade.Text, out int idade))
            {
                MessageBox.Show("Preencha os campos corretamente.");
                return;
            }
            _pessoaService.Add(new Models.Pessoa
            {
                Nome = txtNome.Text,
                Idade = idade
            });
            CarregarPessoas();
            txtNome.Clear();
            txtIdade.Clear();

        }
        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            _pessoaSelecionada = (Pessoa)dgPessoas.SelectedItem;
            if (_pessoaSelecionada == null)
            {
                MessageBox.Show("Selecione um registro para editar.");
                return;
            }

            _pessoaSelecionada.Nome = txtNome.Text;
            _pessoaSelecionada.Idade = int.Parse(txtIdade.Text);

            _pessoaService.Update(_pessoaSelecionada);
            CarregarPessoas();
        }

        private void Excluir_Click(object sender, RoutedEventArgs e)
        {
            if (_pessoaSelecionada == null)
            {
                MessageBox.Show("Selecione um registro para excluir.");
                return;
            }

            _pessoaService.Delete(_pessoaSelecionada.Id);
            CarregarPessoas();
        }
    }
}