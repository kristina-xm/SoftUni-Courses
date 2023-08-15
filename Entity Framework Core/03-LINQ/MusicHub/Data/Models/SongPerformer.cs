namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;
public class SongPerformer
{
    //    •	SongId – integer, Primary Key
    //•	Song – the performer's Song (required)
    //•	PerformerId – integer, Primary Key
    //•	Performer – the Song's Performer (required)

    [ForeignKey(nameof(Song))]
    public int SongId { get; set; }

    public virtual Song Song { get; set; } = null!;


    [ForeignKey(nameof(Performer))]
    public int PerformerId { get; set; }

    public virtual Performer Performer { get; set; } = null!;
}
