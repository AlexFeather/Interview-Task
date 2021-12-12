using DBMngr.Controllers;
using DBMngr.Objects;
using DBMngr.Repository;

namespace DBMngr
{
    public static class Program
    {
        public static Manager mng = new Manager();
        static void Main(string[] args)
        {
            mng.ControllersStart();
        }
    }
}
