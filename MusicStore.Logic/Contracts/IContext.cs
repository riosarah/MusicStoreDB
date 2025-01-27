using Microsoft.EntityFrameworkCore;

namespace MusicStore.Logic.Contracts
{
    public interface IContext : IDisposable
    {
        DbSet<DataObjects.Album> AlbumSet { get; set; }
        DbSet<DataObjects.Artist> ArtistSet { get; set; }
        DbSet<DataObjects.Genre> GenreSet { get; set; }
        DbSet<DataObjects.Track> TrackSet { get; set; }

        int SaveChanges();
    }
}