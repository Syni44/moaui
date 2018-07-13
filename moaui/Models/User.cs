using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;

namespace moaui.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [JsonProperty]
        private int UserID { get; set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public int Age { get; private set; }

        [JsonProperty]
        public string FavoriteBands { get; private set; }

        [JsonProperty]
        public string Skills { get; private set; }

        [JsonProperty]
        public int YearsPlaying { get; private set; }

        public User(string name, int age, string favoriteBands,
            string skills, int yearsPlaying) {

            Name = new String(name.TrimStart().RemoveUnnecessarySpace().ToArray());
            Age = age;
            FavoriteBands = favoriteBands;
            Skills = skills;
            YearsPlaying = yearsPlaying;

            // we don't want names with numbers or symbols (barring ., -, and spaces?)
            if (!Regex.IsMatch(Name, @"^[a-zA-Z -\.]+$")) {
                MessageBox.Show($"Error -- Name must contain only -, ., letters and spaces.");
            }
            else {
                UserID = Properties.Settings.Default.UserID;
                Properties.Settings.Default.UserID++;

                //// TODO: Clean this up!
                //// for debugging back to 0.
                //Properties.Settings.Default.UserID = 0;
                //UserID = Properties.Settings.Default.UserID;

                Properties.Settings.Default.Save();
                MessageBox.Show($"User {Name} created successfully! {{userid:{ UserID.IDFormatting() }}}, { Skills }...");
                NotifyPropertyChanged();
            }
        }
    }
}
