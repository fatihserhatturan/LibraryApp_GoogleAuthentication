using System.Collections.Generic;

namespace LibraryApp.Models
{
    public class Singleton
    {
        private Singleton() { }

        private static Singleton _instance;
        public int studentNo;
        public List<Book> books;

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
                _instance.studentNo = 0;
                _instance.books  = new List<Book>();

            }
            return _instance;
        }
    }
}
