using twitter.model;

var creator = new Creator
{
    Id = Guid.NewGuid(),
    Nome = "TemSprite"
};

var tweet = new Tweet
{
    Id = Guid.NewGuid(),
    Texto = "NAUM AGUENTO MAUIS",
    Creator = creator
};


var comentariox = new twitter.model.Comentarios
{
    Id = Guid.NewGuid(),
    Texto = "Yo também",
    QuantifyLikes = 2
};

tweet.Comentarios?.Add(comentariox);


Console.WriteLine(creator.Id+" "+ tweet.Creator.Nome);
Console.WriteLine(tweet.Id +" "+ tweet.Texto);

foreach (var comentario in tweet.Comentarios!)
{
    Console.WriteLine(comentario);
}
