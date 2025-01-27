﻿namespace MusicStore.Logic.Contracts
{
    /// <summary>
    /// Represents a music genre with an identifiable ID and a name.
    /// </summary>
    public interface IGenre : IIdentifiable
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name of the genre.
        /// </summary>
        string Name { get; set; }
        #endregion Properties

        #region Navigation Properties
        /// <summary>
        /// Gets or sets the tracks in the album.
        /// </summary>
        List<DataObjects.Track> Tracks { get; set; }
        #endregion Navigation Properties
    }
}
