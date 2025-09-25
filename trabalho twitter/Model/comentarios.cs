namespace twitter.model
{
    public record class Comentarios
    {
        public int QuantifyLikes { get; set; } = 0; 
        public required string Texto { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}