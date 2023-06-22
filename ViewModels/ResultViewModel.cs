namespace NewCard.ViewModels
{
    public class ResultViewModel<T>
    {

        public T Dados { get; private set; }

        public List<string> Erros { get; private set; } = new List<string>();


        public ResultViewModel(T dados, List<string> erros)
        {
            Dados = dados;
            Erros = erros;
        }

        public ResultViewModel(T dados)
        {
            Dados = dados;
        }

        public ResultViewModel(List<string> erros)
        {
            Erros = erros;
        }

        public ResultViewModel(string error)
        {
            Erros.Add(error);
        }
    }
}


