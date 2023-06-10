using System.Text.Json;
using System.Text.Json.Serialization;

namespace FIDE_ID_Finder.Model
{
    public struct Player
    {
        public Player()
        {
        }

        public string Id { get; set; } = "";

        public string Name { get; set; } = "";

        public string Surname { get; set; } = "";

        [JsonIgnore]
        public string Fullname
        {
            get => Surname + ", " + Name;
            set
            {
                var parted = value.Split(", ");
                if (parted.Length > 0)
                {
                    Surname = parted[0];
                }

                if (parted.Length > 1)
                {
                    Name = parted[1];
                }
            }
        }

        public string Fed { get; set; } = "";

        public string Title { get; set; } = "";

        public string Birthday { get; set; } = "";

        public string Rating { get; set; } = "0";

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
