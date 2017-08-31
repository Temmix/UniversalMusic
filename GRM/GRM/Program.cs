using System; 
using GRM.Helpers;
using Ninject;
using System.Reflection;
using GRM.Interface;

namespace GRM
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var partnerFactory = kernel.Get<IPartnerRepository>(); 
            var musicFactory = kernel.Get<IMusicRepository>();  
            var shouldContinue = true;

            while (shouldContinue)
            {
                Console.WriteLine();
                Console.WriteLine("Enter the reference data");

                var userInput = Console.ReadLine().Split(' ');
                var partnerName = userInput[0];

                var date = Provider.ProvideDate(userInput); 
                var partner = partnerFactory.Get(partnerName);
                var musicList = DTOConverter.Convert(musicFactory.Get(partner.Usage, date), partner.Usage);

                Console.WriteLine();
                Console.WriteLine("Artist | Title | Usage | StartDate | EndDate");
                foreach (var music in musicList)
                {
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4}", music.Artist, music.Title,
                                        music.Usage, music.StartDate, music.EndDate);
                }

                Console.WriteLine();
                Console.WriteLine("Hit Enter key to try again or other keys to Quit");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                shouldContinue = keyInfo.Key == ConsoleKey.Enter;
            }
        }
    }
}
