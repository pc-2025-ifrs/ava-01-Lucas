namespace twitter.model
{
    public record  class Creator
    {
        public required string Nome { get; set; }
        public required Guid Id { get; set; }
    }
}