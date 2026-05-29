using System.ComponentModel; // necessário para INotifyPropertyChanged
using System.Runtime.CompilerServices; // necessário para CallerMemberName

namespace cadastroEvento.Models
{
    // classe modelo que representa um evento, implementa INotifyPropertyChanged para binding
    public class Evento : INotifyPropertyChanged
    {
        // evento exigido pela interface INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        // método auxiliar para disparar o evento de mudança de propriedade
        private void OnPropertyChanged([CallerMemberName] string nomePropriedade = "")
        {
            // se houver assinantes, invoca o evento passando o nome da propriedade
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
        }

        // campo privado para armazenar o nome do evento
        private string _nome = string.Empty;
        // propriedade pública com notificação de mudança
        public string Nome
        {
            get => _nome;
            set
            {
                // só atualiza se o valor for diferente
                if (_nome != value)
                {
                    _nome = value;
                    OnPropertyChanged(); // notifica a view
                }
            }
        }

        // campo privado para armazenar a data de início
        private DateTime _dataInicio = DateTime.Today;
        public DateTime DataInicio
        {
            get => _dataInicio;
            set
            {
                if (_dataInicio != value)
                {
                    _dataInicio = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Duracao)); // recalcula duração
                }
            }
        }

        // campo privado para armazenar a data de término
        private DateTime _dataTermino = DateTime.Today.AddDays(1);
        public DateTime DataTermino
        {
            get => _dataTermino;
            set
            {
                if (_dataTermino != value)
                {
                    _dataTermino = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Duracao)); // recalcula duração
                }
            }
        }

        // campo privado para armazenar o número de participantes
        private int _numeroParticipantes;
        public int NumeroParticipantes
        {
            get => _numeroParticipantes;
            set
            {
                if (_numeroParticipantes != value)
                {
                    _numeroParticipantes = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(CustoTotal)); // recalcula custo total
                }
            }
        }

        // campo privado para armazenar o local do evento
        private string _local = string.Empty;
        public string Local
        {
            get => _local;
            set
            {
                if (_local != value)
                {
                    _local = value;
                    OnPropertyChanged();
                }
            }
        }

        // campo privado para armazenar o custo por participante
        private decimal _custoPorParticipante;
        public decimal CustoPorParticipante
        {
            get => _custoPorParticipante;
            set
            {
                if (_custoPorParticipante != value)
                {
                    _custoPorParticipante = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(CustoTotal)); // recalcula custo total
                }
            }
        }

        // propriedade somente leitura que calcula a duração usando TimeSpan
        // subtrai a data de início da data de término para obter a diferença
        public TimeSpan Duracao => DataTermino - DataInicio;

        // propriedade somente leitura que calcula o custo total do evento
        // multiplica o número de participantes pelo custo por participante
        public decimal CustoTotal => NumeroParticipantes * CustoPorParticipante;
    }
}
