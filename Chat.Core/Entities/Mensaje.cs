namespace Chat.Core.Entities
{
    public class Mensaje
    {
        public int Id { get; set; }
        public string? Texto { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int SalaId { get; set; }
        public Sala? Sala { get; set; }
    }
}
