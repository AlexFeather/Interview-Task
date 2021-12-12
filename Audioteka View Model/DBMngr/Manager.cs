using DBMngr.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBMngr
{
    public class Manager
    {
        public GenresController GenresCtrl { get; set; }
        public AuthorsController AuthorsCtrl { get; set; }
        public AlbumsController AlbumsCtrl { get; set; }
        public SongsController SongsCtrl { get; set; }

        public void ControllersStart()
        {
            GenresCtrl = new GenresController();
            AuthorsCtrl = new AuthorsController();
            AlbumsCtrl = new AlbumsController();
            SongsCtrl = new SongsController();

            GenresCtrl.InititalSequence();
            AuthorsCtrl.InitialSequence();
            AlbumsCtrl.InitialSequence();
            SongsCtrl.InitialSequence();
        }
    }
}
