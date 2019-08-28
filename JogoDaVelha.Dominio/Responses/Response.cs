namespace JogoDaVelha.Dominio.Responses
{
    public class Response
    {
        public bool PartidaFinalizada { get; set; }
        public string Winner { get; set; }
        public bool DeuEmpate { get; set; }
        public bool JogadaRealizadaComSucesso { get; set; }
    }
}
