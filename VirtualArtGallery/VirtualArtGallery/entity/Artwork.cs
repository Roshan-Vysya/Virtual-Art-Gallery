namespace entity
{
    public class Artwork
    {
        private int artworkID;
        private string title;
        private string description;
        private DateTime? creationDate;
        private string medium;
        private string imageUrl;
        private int artistID;

        // Default Constructor
        public Artwork() { }

        // Parameterized Constructor
        public Artwork(int artworkID, string title, string description, DateTime? creationDate, string medium, string imageUrl, int artistID)
        {
            this.artworkID = artworkID;
            this.title = title;
            this.description = description;
            this.creationDate = creationDate;
            this.medium = medium;
            this.imageUrl = imageUrl;
            this.artistID = artistID;
        }

        // Getters and Setters
        public int ArtworkID { get => artworkID; set => artworkID = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public DateTime? CreationDate { get => creationDate; set => creationDate = value; }
        public string Medium { get => medium; set => medium = value; }
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        public int ArtistID { get => artistID; set => artistID = value; }
    }
}