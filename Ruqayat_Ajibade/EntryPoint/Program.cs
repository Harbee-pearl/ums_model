using System;
using ums_model;

namespace EntryPoint
{
    class Program
    {
        static void Main(string[] args)
        {

            
            UserUI user = new UserUI();
            user.ReadFileAtStartAsync();
            user.UI();

            
        }
    }
}
