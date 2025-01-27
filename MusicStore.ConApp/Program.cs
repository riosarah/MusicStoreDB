using Microsoft.EntityFrameworkCore;
using MusicStore.Logic.DataContext;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Linq;


namespace MusicStore.ConApp
{
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(/*string[] args*/)
        {
            string input = string.Empty;
            Logic.Contracts.IContext context = Logic.DataContext.Factory.CreateContext();

            while (!input.Equals("x", StringComparison.CurrentCultureIgnoreCase))
            {
                int index = 1;
                Console.Clear();
                Console.WriteLine("MusicStore");
                Console.WriteLine("==========================================");

                Console.WriteLine($"{nameof(PrintGenres),-25}....{index++}");
                Console.WriteLine($"{nameof(QueryGenres),-25}....{index++}");
                Console.WriteLine($"{nameof(AddGenre),-25}....{index++}");
                Console.WriteLine($"{nameof(DeleteGenre),-25}....{index++}");
                Console.WriteLine($"{nameof(PrintArtists),-25}....{index++}");
                Console.WriteLine($"{nameof(QueryArtists),-25}....{index++}");
                Console.WriteLine($"{nameof(AddArtist),-25}....{index++}");
                Console.WriteLine($"{nameof(DeleteArtist),-25}....{index++}");
                Console.WriteLine($"{nameof(PrintAlbums),-25}....{index++}");
                Console.WriteLine($"{nameof(QueryAlbums),-25}....{index++}");
                Console.WriteLine($"{nameof(AddAlbum),-25}....{index++}");
                Console.WriteLine($"{nameof(DeleteAlbum),-25}....{index++}");
                Console.WriteLine($"{nameof(PrintTracks),-25}....{index++}");
                Console.WriteLine($"{nameof(AddTracks),-25}....{index++}");
                Console.WriteLine($"{nameof(DeleteTracks),-25}....{index++}");
                Console.WriteLine($"{nameof(QueryTracks),-25}....{index++}");

                Console.WriteLine();
                Console.WriteLine($"Exit...............x");
                Console.Write("Your choice: ");

                input = Console.ReadLine()!;
                if (Int32.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            PrintGenres(context);
                            Console.WriteLine();
                            Console.Write("Continue with Enter...");
                            Console.ReadLine();
                            break;
                        case 2:
                            QueryGenres(context);
                            Console.WriteLine();
                            Console.Write("Continue with Enter...");
                            Console.ReadLine();
                            break;
                        case 3:
                            AddGenre(context);
                            break;
                        case 4:
                            DeleteGenre(context);
                            break;
                        case 5:
                            PrintArtists(context);
                            Console.WriteLine();
                            Console.Write("Continue with Enter...");
                            Console.ReadLine();
                            break;
                        case 6:
                            QueryArtists(context);
                            Console.WriteLine();
                            Console.Write("Continue with Enter...");
                            Console.ReadLine();
                            break;
                        case 7:
                            AddArtist(context);
                            break;
                        case 8:
                            DeleteArtist(context);
                            break;
                        case 9:
                            PrintAlbums(context);
                            Console.WriteLine();
                            Console.Write("Continue with Enter...");
                            Console.ReadLine();
                            break;
                        case 10:
                            QueryAlbums(context);
                            Console.WriteLine();
                            Console.Write("Continue with Enter...");
                            Console.ReadLine();
                            break;
                        case 11:
                            AddAlbum(context);
                            break;
                        case 12:
                            DeleteAlbum(context);
                            break;
                        case 13:
                            PrintTracks(context);
                            Console.WriteLine();
                            Console.Write("Continue with Enter...");
                            Console.ReadLine();
                            break;
                        case 14:
                            QueryTracks(context);
                            Console.WriteLine();
                            Console.Write("Continue with Enter...");
                            Console.ReadLine();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
       

        /// <summary>
        /// Prints all genres in the context.
        /// </summary>
        /// <param name="context">The music store context.</param>
        private static void PrintGenres(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Genres:");
            Console.WriteLine("-------");            
            foreach (var item in context.GenreSet)
            {
                Console.WriteLine($"{item.Name}");
            }
        }

        /// <summary>
        /// Queries genres based on a user-provided condition.
        /// </summary>
        /// <param name="context">The music store context.</param>
        private static void QueryGenres(Logic.Contracts.IContext context)
        {

            Console.WriteLine();
            Console.WriteLine("Query Genres:");
            Console.WriteLine("----------");
            Console.Write("Query: ");
            var query = Console.ReadLine()!;
            try
            {
                foreach (var item in context.GenreSet.AsQueryable().Where(query).Include(e => e.Tracks))//Extension method{                Console.WriteLine($"{item}");
                {
                    Console.WriteLine(item);
                    foreach (var customer in item.Tracks)
                    {
                        Console.WriteLine($" \t {customer}");
                    }
                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        /// <summary>
        /// Adds a new genre to the context.
        /// </summary>
        /// <param name="context">The music store context.</param>
        private static void AddGenre(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Genres:");
            Console.WriteLine("-------");

            Console.WriteLine("Genre name: ");
            var genreNew = new MusicStore.Logic.DataObjects.Genre();
            genreNew.Name = Console.ReadLine();
            Console.WriteLine("Genre tracks: ");
            Console.WriteLine("Start input of tracks - end with [x].");
            genreNew.Tracks = new List<MusicStore.Logic.DataObjects.Track>();
            string input = null;
            while(input != "x")
            {
                Console.WriteLine("New track:");
                input = Console.ReadLine();
                var track = context.TrackSet.FirstOrDefault(e => e.Title == input);
                if (track != null)
                {
                    try
                    {
                        genreNew.Tracks.Add(track);
                        Console.WriteLine(track + " added successfully");
                        context.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.Write("Continue with enter");
                        Console.ReadKey();
                    }
                }
            }
            context.GenreSet.Add(genreNew);
            context.SaveChanges();
        }

        /// <summary>
        /// Deletes a genre from the context.
        /// </summary>
        /// <param name="context">The music store context.</param>
        private static void DeleteGenre(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Delete Genre:");
            Console.WriteLine("-------------");
            Console.WriteLine("Name [256]: ");
            var name = Console.ReadLine();
            var entity = context.GenreSet.FirstOrDefault(e => e.Name == name);
            if (entity != null)
            {
                try
                {
                    context.GenreSet.Remove(entity);
                    context.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.Write("Continue with enter");
                    Console.ReadKey();
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Prints all artists in the context.
        /// </summary>
        /// <param name="context">The music store context.</param>
        private static void PrintArtists(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Artists:");
            Console.WriteLine("-------");
            foreach (var item in context.ArtistSet)
            {
                Console.WriteLine($"{item.Name}");
            }
        }

        /// <summary>
        /// Queries artists based on a user-provided condition.
        /// </summary>
        /// <param name="context">The music store context.</param>
        private static void QueryArtists(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Query Artists:");
            Console.WriteLine("----------");
            Console.Write("Artist Name: ");
            var query = Console.ReadLine()!;
            try
            {
                foreach (var item in context.ArtistSet.AsQueryable().Where(query).Include(e => e.Name))//Extension method{                Console.WriteLine($"{item}");
                {
                    Console.WriteLine(item);
                    foreach (var albums in item.Albums)
                    {
                        Console.WriteLine($" \t {albums}");
                    }
                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        /// <summary>
        /// Adds a new artist to the context.
        /// </summary>
        /// <param name="context">The music store context.</param>
        private static void AddArtist(Logic.Contracts.IContext context)
        {

            Console.WriteLine();
            Console.WriteLine("Add Artist:");
            Console.WriteLine("-------");

            Console.WriteLine("Artist name: ");
            var artistNew = new MusicStore.Logic.DataObjects.Artist();
            artistNew.Name = Console.ReadLine();
            Console.WriteLine("Start input of albums - end with [x].");
            artistNew.Albums = new List<MusicStore.Logic.DataObjects.Album>();
            string input = string.Empty;
            while (input != "x")
            {
                Console.WriteLine("New Album:");
                input = Console.ReadLine();
                var track = context.AlbumSet.FirstOrDefault(e => e.Title == input);
                if (track != null)
                {
                    try
                    {
                        artistNew.Albums.Add(track);
                        context.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.Write("Continue with enter");
                        Console.ReadKey();
                    }
                }
            }
            context.ArtistSet.Add(artistNew);
            context.SaveChanges();
        }

        /// <summary>
        /// Deletes an artist from the context.
        /// </summary>
        /// <param name="context">The music store context.</param>
        private static void DeleteArtist(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Delete artist:");
            Console.WriteLine("-------------");
            Console.WriteLine("Name [256]: ");
            var name = Console.ReadLine();
            var entity = context.ArtistSet.FirstOrDefault(e => e.Name == name);
            if (entity != null)
            {
                try
                {
                    context.ArtistSet.Remove(entity);
                    context.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.Write("Continue with enter");
                    Console.ReadKey();
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Prints all albums in the context.
        /// </summary>
        /// <param name="context">The music store context.</param>
        private static void PrintAlbums(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Albums:");
            Console.WriteLine("-------");
            foreach (var item in context.AlbumSet)
            {
                Console.WriteLine($"{item.Title}");
            }
        }

        /// <summary>
        /// Queries albums based on a user-provided condition.
        /// </summary>
        /// <param name="context">The music store context.</param>
        private static void QueryAlbums(Logic.Contracts.IContext context)
        {


            Console.WriteLine();
            Console.WriteLine("Query Album:");
            Console.WriteLine("----------");
            var query = Console.ReadLine()!;
            try
            {
                foreach (var item in context.AlbumSet.AsQueryable().Where(query).Include(e => e.Title))//Extension method{                Console.WriteLine($"{item}");
                {
                    Console.WriteLine(item);
                    foreach (var tracks in item.Tracks)
                    {
                        Console.WriteLine($" \t {tracks}");
                    }
                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        /// <summary>
        /// Adds a new album to the context.
        /// </summary>
        /// <param name="context">The music store context.</param>
        private static void AddAlbum(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Add Album:");
            Console.WriteLine("-------------");
            var album = new Logic.DataObjects.Album();
            Console.WriteLine("Title: ");
            album.Title = Console.ReadLine()!;
            Console.WriteLine("Tracks - end input with [x]:");
            string input = string.Empty;
            while(input != "x")
            {
                Console.WriteLine("Track name:");
                input = Console.ReadLine();
                var track = context.TrackSet.FirstOrDefault(e => e.Title == input);
                if (track != null)
                {
                    try
                    {
                        album.Tracks.Add(track);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.Write("Continue with enter");
                        Console.ReadKey();
                    }
                }
            }
            context.AlbumSet.Add(album);
            context.SaveChanges();
        }

        /// <summary>
        /// Deletes an album from the context.
        /// </summary>
        /// <param name="context">The music store context.</param>
        private static void DeleteAlbum(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Delete album:");
            Console.WriteLine("-------------");
            Console.WriteLine("Name [256]: ");
            var title = Console.ReadLine();
            var entity = context.AlbumSet.FirstOrDefault(e => e.Title == title);
            if (entity != null)
            {
                try
                {
                    context.AlbumSet.Remove(entity);
                    context.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.Write("Continue with enter");
                    Console.ReadKey();
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Prints all tracks in the context.
        /// </summary>
        /// <param name="context">The music store context.</param>
        private static void PrintTracks(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Tracks:");
            Console.WriteLine("-------");
            foreach (var item in context.TrackSet)
            {
                Console.WriteLine($"{item.Title}");
            }
        }
        private static void DeleteTracks(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Delete tracks:");
            Console.WriteLine("-------------");
            Console.WriteLine("Name [256]: ");
            var title = Console.ReadLine();
            var entity = context.TrackSet.FirstOrDefault(e => e.Title == title);
            if (entity != null)
            {
                try
                {
                    context.TrackSet.Remove(entity);
                    context.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.Write("Continue with enter");
                    Console.ReadKey();
                }
            }
            context.SaveChanges();
        }

        private static void AddTracks(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Add tracks:");
            Console.WriteLine("-------------");
            Console.WriteLine("Name [256]: ");
            var title = Console.ReadLine();
            var entity = context.TrackSet.FirstOrDefault(e => e.Title == title);
            if (entity == null)
            {
                try
                {
                    context.TrackSet.Add(entity);
                    context.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.Write("Continue with enter");
                    Console.ReadKey();
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Queries tracks based on a user-provided condition.
        /// </summary>
        /// <param name="context">The music store context.</param>
        private static void QueryTracks(Logic.Contracts.IContext context)
        {


            Console.WriteLine();
            Console.WriteLine("Query Tracks:");
            Console.WriteLine("----------");
            var query = Console.ReadLine()!;
            try
            {
                foreach (var item in context.TrackSet.AsQueryable().Where(query).Include(e => e.Title))//Extension method{                Console.WriteLine($"{item}");
                {
                    Console.WriteLine(item);                    
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
