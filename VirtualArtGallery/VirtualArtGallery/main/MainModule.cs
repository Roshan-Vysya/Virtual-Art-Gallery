using System;
using System.Collections.Generic;
using entity;
using dao;

namespace main
{
    class MainModule
    {
        static void Main(string[] args)
        {
            // Initialize the service
            CrimeAnalysisServiceImpl service = new CrimeAnalysisServiceImpl();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Virtual Art Gallery Menu ===");
                Console.WriteLine("1. Add Artwork");
                Console.WriteLine("2. Update Artwork");
                Console.WriteLine("3. Remove Artwork");
                Console.WriteLine("4. Get Artwork by ID");
                Console.WriteLine("5. Search Artworks");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    Console.ReadLine();
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            AddArtwork(service);
                            break;
                        case 2:
                            UpdateArtwork(service);
                            break;
                        case 3:
                            RemoveArtwork(service);
                            break;
                        case 4:
                            GetArtworkById(service);
                            break;
                        case 5:
                            SearchArtworks(service);
                            break;
                        case 6:
                            Console.WriteLine("Exiting the program. Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        static void AddArtwork(CrimeAnalysisServiceImpl service)
        {
            Console.Clear();
            Console.WriteLine("=== Add Artwork ===");

            Artwork newArtwork = new Artwork();

            Console.Write("Enter Title: ");
            newArtwork.Title = Console.ReadLine();

            Console.Write("Enter Description: ");
            newArtwork.Description = Console.ReadLine();

            Console.Write("Enter Creation Date (yyyy-mm-dd) or leave blank: ");
            string creationDateInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(creationDateInput))
                newArtwork.CreationDate = DateTime.Parse(creationDateInput);

            Console.Write("Enter Medium: ");
            newArtwork.Medium = Console.ReadLine();

            Console.Write("Enter Image URL: ");
            newArtwork.ImageUrl = Console.ReadLine();

            Console.Write("Enter Artist ID: ");
            newArtwork.ArtistID = int.Parse(Console.ReadLine());

            if (service.AddArtwork(newArtwork))
                Console.WriteLine("Artwork added successfully!");
            else
                Console.WriteLine("Failed to add artwork.");
        }

        static void UpdateArtwork(CrimeAnalysisServiceImpl service)
        {
            Console.Clear();
            Console.WriteLine("=== Update Artwork ===");

            Console.Write("Enter Artwork ID to update: ");
            int artworkId = int.Parse(Console.ReadLine());

            Artwork existingArtwork = service.GetArtworkById(artworkId);

            Console.WriteLine($"Current Title: {existingArtwork.Title}");
            Console.Write("Enter New Title (or press Enter to keep current): ");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrEmpty(newTitle))
                existingArtwork.Title = newTitle;

            Console.WriteLine($"Current Description: {existingArtwork.Description}");
            Console.Write("Enter New Description (or press Enter to keep current): ");
            string newDescription = Console.ReadLine();
            if (!string.IsNullOrEmpty(newDescription))
                existingArtwork.Description = newDescription;

            Console.WriteLine($"Current Creation Date: {existingArtwork.CreationDate}");
            Console.Write("Enter New Creation Date (yyyy-mm-dd) (or press Enter to keep current): ");
            string newCreationDateInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(newCreationDateInput))
                existingArtwork.CreationDate = DateTime.Parse(newCreationDateInput);

            Console.WriteLine($"Current Medium: {existingArtwork.Medium}");
            Console.Write("Enter New Medium (or press Enter to keep current): ");
            string newMedium = Console.ReadLine();
            if (!string.IsNullOrEmpty(newMedium))
                existingArtwork.Medium = newMedium;

            Console.WriteLine($"Current Image URL: {existingArtwork.ImageUrl}");
            Console.Write("Enter New Image URL (or press Enter to keep current): ");
            string newImageUrl = Console.ReadLine();
            if (!string.IsNullOrEmpty(newImageUrl))
                existingArtwork.ImageUrl = newImageUrl;

            Console.WriteLine($"Current Artist ID: {existingArtwork.ArtistID}");
            Console.Write("Enter New Artist ID (or press Enter to keep current): ");
            string newArtistIdInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(newArtistIdInput))
                existingArtwork.ArtistID = int.Parse(newArtistIdInput);

            if (service.UpdateArtwork(existingArtwork))
                Console.WriteLine("Artwork updated successfully!");
            else
                Console.WriteLine("Failed to update artwork.");
        }

        static void RemoveArtwork(CrimeAnalysisServiceImpl service)
        {
            Console.Clear();
            Console.WriteLine("=== Remove Artwork ===");

            Console.Write("Enter Artwork ID to remove: ");
            int artworkId = int.Parse(Console.ReadLine());

            if (service.RemoveArtwork(artworkId))
                Console.WriteLine("Artwork removed successfully!");
            else
                Console.WriteLine("Failed to remove artwork.");
        }

        static void GetArtworkById(CrimeAnalysisServiceImpl service)
        {
            Console.Clear();
            Console.WriteLine("=== Get Artwork by ID ===");

            Console.Write("Enter Artwork ID: ");
            int artworkId = int.Parse(Console.ReadLine());

            Artwork artwork = service.GetArtworkById(artworkId);

            Console.WriteLine("=== Artwork Details ===");
            Console.WriteLine($"ID: {artwork.ArtworkID}");
            Console.WriteLine($"Title: {artwork.Title}");
            Console.WriteLine($"Description: {artwork.Description}");
            Console.WriteLine($"Creation Date: {artwork.CreationDate}");
            Console.WriteLine($"Medium: {artwork.Medium}");
            Console.WriteLine($"Image URL: {artwork.ImageUrl}");
            Console.WriteLine($"Artist ID: {artwork.ArtistID}");
        }

        static void SearchArtworks(CrimeAnalysisServiceImpl service)
        {
            Console.Clear();
            Console.WriteLine("=== Search Artworks ===");

            Console.Write("Enter keyword to search: ");
            string keyword = Console.ReadLine();

            List<Artwork> artworks = service.SearchArtworks(keyword);

            Console.WriteLine("=== Search Results ===");
            foreach (var artwork in artworks)
            {
                Console.WriteLine($"ID: {artwork.ArtworkID}, Title: {artwork.Title}, Description: {artwork.Description}");
            }

            if (artworks.Count == 0)
                Console.WriteLine("No artworks found matching the keyword.");
        }
    }
}