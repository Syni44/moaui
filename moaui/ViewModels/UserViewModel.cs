using Caliburn.Micro;
using moaui.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

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

        #region constructor

        public UserViewModel(string name, int age, string bands, string skills, int years) {
            Name = name;
            Age = age;
            FavoriteBands = bands;
            Skills = skills;
            YearsPlaying = years;

            var newUser = new User(Name, Age, FavoriteBands, Skills, YearsPlaying);

            string jsonPath = GetPath(@"../../users.json");

            if (!File.Exists(jsonPath)) {
                using (new FileStream(jsonPath, FileMode.Open, FileAccess.Read)) {
                    File.Create(jsonPath);
                }               
            }

            var json = File.ReadAllText(jsonPath);
            List<User> userList;

            // deserialize list
            // if the json is jsonArray (contains at least one User entry)...
            if (json.StartsWith("[")) {
                userList = JsonConvert.DeserializeObject<List<User>>(json);
            }
            // if the json contains no users...
            else {
                userList = new List<User>();
            }

            // add new user to list
            userList.Add(newUser);

            // (re-)serialize list
            SerializeUserList(userList);
        }

        public UserViewModel() { }

        #endregion

        /// <summary>
        /// Serializes the User objects into .json
        /// </summary>
        /// <param name="user"></param>
        private void SerializeUserList(List<User> userList) {
            // TODO: The UserID values don't increment properly (they are counting previous users each time
            //       a new one is added)

            string jsonPath = GetPath(@"../../users.json");
            string rawJsonString = JsonConvert.SerializeObject(userList, new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            string formattedJsonString;

            using (StreamWriter file = File.CreateText(jsonPath)) {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, userList);
            }

            using (new FileStream(jsonPath, FileMode.Open, FileAccess.ReadWrite)) {
                formattedJsonString = JToken.Parse(rawJsonString).ToString(Formatting.Indented);                
            }

            File.WriteAllText(jsonPath, formattedJsonString);

            MessageBox.Show($"User { Name } created successfully! {{ debug:skills: { Skills }... }}");
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
