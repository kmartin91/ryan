using System;

namespace alexkidd
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (GameFunc game = new GameFunc())
            {
                game.Run();
            }
        }
    }
#endif
}

