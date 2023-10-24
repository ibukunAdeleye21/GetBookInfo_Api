//namespace BookInfo.API
//{
//    public class UserRegistration
//    {
//        private readonly UserService _userService;
//        public UserRegistration(UserService userService)
//        {
//            _userService = userService;
//        }

//        public void RegisterUser()
//        {
//            Console.Write("Enter username: ");
//            string username = Console.ReadLine();

//            Console.Write("Enter password: ");
//            string password = Console.ReadLine();

//            // Register the user
//            _userService.CreateUser(username, password).Wait();  // Wait for the task to complete

//            Console.WriteLine("User registered successfully!");
//        }
//    }
//}
//}
