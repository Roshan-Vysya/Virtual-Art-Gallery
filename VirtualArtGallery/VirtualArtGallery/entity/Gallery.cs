namespace entity
{
    public class Gallery
    {
        private int galleryID;
        private string name;
        private string description;
        private string location;
        private int curator;
        private string openingHours;

        // Default Constructor
        public Gallery() { }

        // Parameterized Constructor
        public Gallery(int galleryID, string name, string description, string location, int curator, string openingHours)
        {
            this.galleryID = galleryID;
            this.name = name;
            this.description = description;
            this.location = location;
            this.curator = curator;
            this.openingHours = openingHours;
        }

        // Getters and Setters
        public int GalleryID { get => galleryID; set => galleryID = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Location { get => location; set => location = value; }
        public int Curator { get => curator; set => curator = value; }
        public string OpeningHours { get => openingHours; set => openingHours = value; }
    }
}