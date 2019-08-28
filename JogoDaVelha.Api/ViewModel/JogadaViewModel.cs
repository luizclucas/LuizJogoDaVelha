using System;

namespace JogoDaVelha.Api.ViewModel
{
    public class JogadaViewModel
    {
        public Guid Id { get; set; }
        public string Player { get; set; }
        public Position Position { get; set; }      
    }
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
