using Caliburn.Micro;
using moaui.Models;
using Newtonsoft.Json;
using System;
using System.IO;

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

            // TODO: deserialize / "load" currently existing users here
            //

            SerializeUser(newUser);
        }

        public UserViewModel() { }

        /// <summary>
        /// Serializes the User objects into .json
        /// </summary>
        /// <param name="user"></param>
        private void SerializeUser(User user) {
            // TODO: format JSON prettyprint style
            File.WriteAllText(GetPath(@"users.json"), JsonConvert.SerializeObject(user));

            using (StreamWriter file = File.CreateText(GetPath(@"users.json"))) {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, user);
            }
        }

        #region Helpers

        /// <summary>
        /// Points the the current executing assembly, making the path straightforward.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetPath(string path)
            => String.Join(System.Reflection.Assembly.GetExecutingAssembly().Location, path);

        #endregion
    }
}
