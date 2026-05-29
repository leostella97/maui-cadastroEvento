using cadastroEvento.Models; // para usar a classe Evento

namespace cadastroEvento
{
    // página que exibe o resumo completo do evento cadastrado
    public partial class ResumoPage : ContentPage
    {
        // campo que guarda a referência do evento recebido
        private Evento _evento;

        // construtor que recebe o objeto evento preenchido na mainpage
        public ResumoPage(Evento evento)
        {
            InitializeComponent(); // carrega os componentes do xaml

            // armazena o evento recebido
            _evento = evento;

            // preenche os labels com os dados formatados do evento
            CarregarDados();
        }

        // método que atribui os valores do evento aos labels na tela
        private void CarregarDados()
        {
            // exibe o nome do evento
            lblNome.Text = _evento.Nome;

            // exibe a data de início formatada no padrão brasileiro
            lblDataInicio.Text = _evento.DataInicio.ToString("dd/MM/yyyy");

            // exibe a data de término formatada no padrão brasileiro
            lblDataTermino.Text = _evento.DataTermino.ToString("dd/MM/yyyy");

            // exibe a duração em dias usando o timespan calculado pela model
            // acessa a propriedade duracao que retorna um timespan
            lblDuracao.Text = $"{_evento.Duracao.Days} dia(s)";

            // exibe o número de participantes
            lblParticipantes.Text = _evento.NumeroParticipantes.ToString("N0");

            // exibe o local do evento
            lblLocal.Text = _evento.Local;

            // exibe o custo por participante formatado como moeda
            lblCustoPorParticipante.Text = _evento.CustoPorParticipante.ToString("C");

            // exibe o custo total calculado (participantes * custo por participante)
            lblCustoTotal.Text = _evento.CustoTotal.ToString("C");
        }

        // método chamado ao clicar no botão novo evento
        private async void BtnNovoEvento_Clicked(object sender, EventArgs e)
        {
            // volta para a página anterior (mainpage com formulário limpo)
            // como a mainpage cria um novo evento no construtor, o formulário estará limpo
            await Navigation.PopAsync();
        }
    }
}
