
using HW_week_12.Entitis;
using HW_week_12.Repository;
using HW_week_12.Service;
using System.Net.Http.Headers;
IDutyService _Service = new DutyService();
IUserService _userService = new UserService();

User();
void User()
{
    while (true)
    {
        Console.WriteLine("1. Login ");
        Console.WriteLine("2. Register");
        Console.Write("Choice Option: ");

        int option = int.Parse(Console.ReadLine());
        CheckOption(option);
    }
    void CheckOption(int option)
    {
        switch (option)
        {
            case 1:
                Console.Write("Enter UserName: ");
                var username = Console.ReadLine();
                Console.Write("Enter Passsword: ");
                var password = Console.ReadLine();
                _userService.Login(username, password);            
                DutyMenu();
                break;
            case 2:
                Console.Write("Enter UserName: ");
                var userName = Console.ReadLine();
                Console.Write("Enter Passsword: ");
                var Password = Console.ReadLine();
                Console.Write("Enter Email: ");
                var email = Console.ReadLine();
                var user = new User
                {
                    UserName = userName,
                    Password = Password,
                    Email = email
                };
                var result = _userService.Register(user);
                DutyMenu();
                break;
            default:
                Console.WriteLine("Wrong Number!!!");
                break;

        }
    }
}

void DutyMenu()
{
    while (true)
    {
        Console.WriteLine("1. Add New Duty");
        Console.WriteLine("2. Show All Duties");
        Console.WriteLine("3. Update Duties");
        Console.WriteLine("4. Delet Duties");
        Console.WriteLine("5. Change Status");
        Console.WriteLine("6. Search Duties");
        Console.Write("Chioce Option: ");

        int output = int.Parse(Console.ReadLine());
        CheckOutPut(output);
    }

    void CheckOutPut(int output)
    {
        switch (output)
        {
            case 1:
                Console.Write("Enter UserId: ");
                var userId = int.Parse(Console.ReadLine());
                Console.Write("Enter Title: ");
                var title = Console.ReadLine();
                Console.Write("Enter Time To Done: ");
                var timeToDone = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter Order: ");
                var order = int.Parse(Console.ReadLine());
                Console.Write("Enter State (1: InPending, 2: Done, 3: Cancelled): ");
                var state = Convert.ToInt32(Console.ReadLine());
                _Service.Add(userId, title, timeToDone, order, (State)state);

                break;
            case 2:
                foreach (var item in _Service.GetAll())
                {
                    Console.WriteLine(item.Id + "=" + item.Title + "|" + item.TimeToDone + "|" + item.Order + "|" + item.State);

                }
                break;
            case 3:
                foreach (var item in _Service.GetAll())
                {
                    Console.WriteLine(item.Id + "=" + item.Title + "|" + item.TimeToDone + "|" + item.Order + "|" + item.State);
                }
                Console.Write("Enter Id: ");
                var id = int.Parse(Console.ReadLine());

                Console.Write("Enter Title: ");
                var title2 = Console.ReadLine();
                Console.Write("Enter Time To Done: ");
                var timeToDone2 = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter Order: ");
                var order2 = int.Parse(Console.ReadLine());
                Console.Write("Enter State: ");
                var state2 = Convert.ToInt32(Console.ReadLine());
                _Service.Update(id, title2, timeToDone2, order2, (State)state2);
                break;
            case 4:
                foreach (var item in _Service.GetAll())
                {
                    Console.WriteLine(item.Id + "=" + item.Title + "|" + item.TimeToDone + "|" + item.Order + "|" + item.State);
                }
                Console.Write("Enter Id: ");
                var deletId = int.Parse(Console.ReadLine());
                var result = _Service.Delete(deletId);
                Console.WriteLine(result.ResultText);
                break;
            case 5:
                Console.Write("Enter Id: ");
                var ChangeId = int.Parse(Console.ReadLine());
                Console.Write("Enter State (1: InPending, 2: Done, 3: Cancelled): ");
                var changeState = int.Parse(Console.ReadLine());
                var result2 = _Service.ChangeStatus(ChangeId, (State)changeState);
                Console.WriteLine(result2.ResultText);
                break;
            case 6:
                Console.Write("Enter Title: ");
                var searchTitle = Console.ReadLine();
                var duties = _Service.Search(searchTitle);
                foreach (var item in duties)
                {
                    Console.WriteLine(item.Title + "|" + item.TimeToDone);
                }
                break;
            default:
                Console.WriteLine("wrong Number");
                break;
        }

    }
}


//var users = new List<User>()
//    {
//        new User() { Id = 1, Name = "pedram", Age = 20},
//        new User() { Id = 2, Name = "pedram", Age = 25},
//        new User() { Id = 3, Name = "pedram", Age = 30},
//        new User() { Id = 4, Name = "pedram", Age = 35},
//        new User() { Id = 5, Name = "pedram", Age = 18},
//        new User() { Id = 6, Name = "pedram", Age = 29},

//    };

//var result = users
//    .GroupBy(x => x.Age)
//    .Select(group => new
//    {
//        key = group.Key,
//        value = group.Count()
//    });
//public class User
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public int Age { get; set; }
//}