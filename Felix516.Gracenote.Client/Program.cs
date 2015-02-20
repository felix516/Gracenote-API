using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using Felix516.Gracenote.API;
using Felix516.Gracenote.API.Entites;

namespace Felix516.Gracenote.API
{
    /// <summary>
    /// A basic sample client showing various API uses and features
    /// </summary>
    public class Program
    {
        private const string CLIENT_ID = "Insert Your Client ID Here";
        private const string O_BROTHER_GN_ID = "15145216-E6E0EB71C036B10B0C1158CE602C5FAC";
        private const string O_BROTHER_TOC = "150 20512 30837 50912 64107 78357 90537 110742 126817 144657 153490 160700 175270 186830 201800 218010 237282 244062 262600 272929";
        private const string MULTI_RESULT_TOC = "150 15832 40427 66507 86977 112825 150285 177882 194987 208700 224312 238707 257440 294680";

        private static GracenoteClient gc;

        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="args">No command line arguments are used</param>
        static void Main(string[] args)
        {
            string userId = GetUserId();
            Auth warg = new Auth(CLIENT_ID, userId);
            gc = new GracenoteClient(warg, GracenoteClient.Language.ENGLISH, GracenoteClient.Country.US);
            GetSingleAlbumFromGnId();
            GetSingleAlbumFromToc();
            GetSingleAlbumFromTocWithArt();
            GetMultipleAlbumsFromToc();
            Console.Read();
        }

        /// <summary>
        /// Checks if file exists that specifies an already generated userID.
        /// If file does not exist, Registers a UserId and writes it to a 
        /// file to be used with subsequent launches.
        /// </summary>
        /// <returns>string containing the UserId</returns>
        static string GetUserId()
        {
            string returned;
            try
            {
                using (StreamReader s = new StreamReader(File.OpenRead("user.txt")))
                {
                    returned = s.ReadLine();
                    s.Close();
                    return returned;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("User file not found, creating it now");
                Console.WriteLine();
                returned = Auth.GenerateUserId(CLIENT_ID);
                using (StreamWriter sw = new StreamWriter(File.OpenWrite("user.txt")))
                {
                    sw.WriteLine(returned);
                    sw.Close();
                }
                return returned;
            }
        }

        /// <summary>
        /// Retrives an Album using its Gracenote ID
        /// </summary>
        static void GetSingleAlbumFromGnId()
        {
            Console.WriteLine("Getting single album using Gracenote ID");
            Response r = gc.Album_Fetch(O_BROTHER_GN_ID);
            Album a = r.Albums[0];
            Console.WriteLine("Album : {0}",a.Title);
            Console.WriteLine("Album : {0}",a.Artist);
            Console.WriteLine("Tracks:");
            foreach (Track t in a.Tracks)
            {
                Console.WriteLine(t.Title);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Gets an Album using its Table of Contents Offsets
        /// The option SINGLE_BEST tells gracenote to pick the 
        /// most relavent result if multiple are found.
        /// </summary>
        static void GetSingleAlbumFromToc()
        {
            Console.WriteLine("Getting single album using disc table of contents");
            Response r = gc.Album_ToC(Query_Toc.Modes.SINGLE_BEST, MULTI_RESULT_TOC);
            Album a = r.Albums[0];

            Console.WriteLine("Album : {0}",a.Title);
            Console.WriteLine("Artist : {0}",a.Artist);
            Console.WriteLine("Tracks:");
            foreach (Track t in a.Tracks)
            {
                Console.WriteLine(t.Title);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Gets an Album using its Table of Contents Offsets
        /// The option SINGLE_BEST_COVER tells gracenote to pick the 
        /// most relavent result if multiple are found, and requests
        /// a link to a coverart Image.
        /// </summary>
        static void GetSingleAlbumFromTocWithArt()
        {
            Console.WriteLine("Getting single album with cover art");
            Response r = gc.Album_ToC(Query_Toc.Modes.SINGLE_BEST_COVER, O_BROTHER_TOC);
            Album a = r.Albums[0];

            Console.WriteLine("Album : {0}",a.Title);
            Console.WriteLine("Artist : {0}",a.Artist);
            Console.WriteLine("Cover art located at : \n{0}",a.CoverartUrl);
            Console.WriteLine();


        }

        /// <summary>
        /// Gets an Album using its Table of Contents Offsets
        /// The option NONE tells gracenote to list all relevent
        /// Albums, so multiple results are possible.
        /// </summary>
        static void GetMultipleAlbumsFromToc()
        {
            Console.WriteLine("Getting multiple results from Table of Contents Lookup");
            Response r = gc.Album_ToC(Query_Toc.Modes.NONE, MULTI_RESULT_TOC);

            Console.WriteLine("Albums:");

            foreach (Album a in r.Albums)
            {
                Console.WriteLine("{0} by {1}", a.Title, a.Artist);
            }
            Console.WriteLine();
        }
    }
}
