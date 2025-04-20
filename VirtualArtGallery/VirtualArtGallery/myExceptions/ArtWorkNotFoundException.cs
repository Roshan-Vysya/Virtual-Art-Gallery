using System;

namespace myexceptions
{
    public class ArtWorkNotFoundException : Exception
    {
        public ArtWorkNotFoundException() : base("Artwork not found.") { }

        public ArtWorkNotFoundException(string message) : base(message) { }
    }
}