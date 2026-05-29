using cadastroEvento.Models; // para usar a classe Evento

namespace cadastroEvento
{
    // página principal com o formulário de cadastro do evento
    public partial class MainPage : ContentPage
    {
        // propriedade que armazena o evento sendo preenchido no formulário
        private Evento _evento;

        public MainPage()
        {
            InitializeComponent(); // carrega os componentes do xaml

            // cria uma nova instância do evento para binding
            _evento = new Evento();
            // define o BindingContext da página como o objeto evento
            BindingContext = _evento;
        }

        // método executado toda vez que a página aparece na tela
        protected override void OnAppearing()
        {
            base.OnAppearing(); // chama o método base

            // cria um novo evento com valores padrão
            _evento = new Evento();
            // atualiza o BindingContext para limpar todos os campos do formulário
            BindingContext = _evento;
        }

        // método chamado ao clicar no botão cadastrar
        private async void BtnCadastrar_Clicked(object sender, EventArgs e)
        {
            // valida se o nome foi preenchido
            if (string.IsNullOrWhiteSpace(_evento.Nome))
            {
                // exibe alerta pedindo para preencher o nome
                await DisplayAlert("validação", "preencha o nome do evento.", "ok");
                return; // interrompe o cadastro
            }

            // valida se a data de término é maior ou igual à data de início
            if (_evento.DataTermino <= _evento.DataInicio)
            {
                // exibe alerta sobre data inválida
                await DisplayAlert("validação", "a data de término deve ser posterior à data de início.", "ok");
                return; // interrompe o cadastro
            }

            // valida se o número de participantes é maior que zero
            if (_evento.NumeroParticipantes <= 0)
            {
                // exibe alerta pedindo participantes válidos
                await DisplayAlert("validação", "informe um número de participantes válido.", "ok");
                return;
            }

            // valida se o local foi preenchido
            if (string.IsNullOrWhiteSpace(_evento.Local))
            {
                // exibe alerta pedindo o local
                await DisplayAlert("validação", "preencha o local do evento.", "ok");
                return;
            }

            // valida se o custo por participante é maior que zero
            if (_evento.CustoPorParticipante <= 0)
            {
                // exibe alerta pedindo custo válido
                await DisplayAlert("validação", "informe um custo por participante válido.", "ok");
                return;
            }

            // navega para a página de resumo passando o evento como parâmetro
            // usa shell.current.navigation para push no shell
            await Shell.Current.Navigation.PushAsync(new ResumoPage(_evento));
        }
    }
}
