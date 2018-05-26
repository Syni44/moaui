using Caliburn.Micro;
using moaui.Models;

namespace moaui.ViewModels
{
    class UserViewModel : Screen
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string FavoriteBands { get; set; }
        public string Skills { get; set; }
        public int YearsPlaying { get; set; }

        public UserViewModel(string name, int age, string bands, string skills, int years) {
            Name = name;
            Age = age;
            FavoriteBands = bands;
            Skills = skills;
            YearsPlaying = years;

            var newUser = new User(Name, Age, FavoriteBands, Skills, YearsPlaying);
        }

        public UserViewModel() { }
    }
}
