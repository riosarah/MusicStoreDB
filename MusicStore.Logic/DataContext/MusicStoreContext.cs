using Microsoft.EntityFrameworkCore;
using MusicStore.Logic.Contracts;
using MusicStore.Logic.DataObjects;

namespace MusicStore.Logic.DataContext
{
    /// <summary>
    /// Represents the data context for the Music Store application.
    /// </summary>
    public sealed class MusicStoreContext : DbContext, IContext
    {
        #region Properties
        private static string ConnectionString = "data source = MusicStore.db";
        /// <summary>
        /// Gets or sets the collection of genres.
        /// </summary>
        public DbSet<DataObjects.Genre> GenreSet { get; set; }

        /// <summary>
        /// Gets or sets the collection of artists.
        /// </summary>
        public DbSet<DataObjects.Artist> ArtistSet { get; set; }

        /// <summary>
        /// Gets or sets the collection of albums.
        /// </summary>
        public DbSet<DataObjects.Album> AlbumSet { get; set; }

        /// <summary>
        /// Gets or sets the collection of tracks.
        /// </summary>
        public DbSet<DataObjects.Track> TrackSet { get; set; }

        #endregion Properties

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicStoreContext"/> class.
        /// </summary>
        public MusicStoreContext()
        {
        }

        #region methods
        ///// <summary>
        ///// Saves changes to the data context.
        ///// </summary>
        ///// <returns>Returns the count of saved items.</returns>
        //public int SaveChanges()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }


        //int IContext.SaveChanges()
        //{
        //    throw new NotImplementedException();
        //}

        #endregion methods
    }
}
