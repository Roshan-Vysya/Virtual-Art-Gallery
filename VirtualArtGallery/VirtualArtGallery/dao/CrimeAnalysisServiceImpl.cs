using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using entity;
using util;

namespace dao
{
    public class CrimeAnalysisServiceImpl : IVirtualArtGallery
    {
        // Static connection variable
        private static SqlConnection connection;

        // Constructor
        public CrimeAnalysisServiceImpl()
        {
            try
            {
                // Fetch connection string using DBPropertyUtil and establish the connection
                string connectionString = DBPropertyUtil.GetConnectionString();
                connection = new SqlConnection(connectionString);

                connection.Open();
                Console.WriteLine("Database connection established successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error establishing database connection: {ex.Message}");
                throw;
            }
        }


        // Add the missing method implementation for GetUserFavoriteArtworks
        public List<Artwork> GetUserFavoriteArtworks(int userId)
        {
            List<Artwork> favoriteArtworks = new List<Artwork>();
            try
            {
                string query = "SELECT a.ArtworkID, a.Title, a.Description, a.CreationDate, a.Medium, a.ImageURL, a.ArtistID " +
                               "FROM Artwork a " +
                               "INNER JOIN UserFavorites uf ON a.ArtworkID = uf.ArtworkID " +
                               "WHERE uf.UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            favoriteArtworks.Add(new Artwork
                            {
                                ArtworkID = (int)reader["ArtworkID"],
                                Title = reader["Title"].ToString(),
                                Description = reader["Description"]?.ToString(),
                                CreationDate = reader["CreationDate"] as DateTime?,
                                Medium = reader["Medium"]?.ToString(),
                                ImageUrl = reader["ImageURL"]?.ToString(),
                                ArtistID = (int)reader["ArtistID"]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user favorite artworks: {ex.Message}");
            }
            return favoriteArtworks;
        }



        //implementation for RemoveArtworkFromFavorite
        public bool RemoveArtworkFromFavorite(int userId, int artworkId)
        {
            try
            {
                string query = "DELETE FROM UserFavorites WHERE UserID = @UserID AND ArtworkID = @ArtworkID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@ArtworkID", artworkId);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing artwork from favorites: {ex.Message}");
                return false;
            }
        }



        //implementation for AddArtworkToFavorite
        public bool AddArtworkToFavorite(int userId, int artworkId)
        {
            try
            {
                string query = "INSERT INTO UserFavorites (UserID, ArtworkID) VALUES (@UserID, @ArtworkID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@ArtworkID", artworkId);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding artwork to favorites: {ex.Message}");
                return false;
            }
        }


        // Add Artwork
        public bool AddArtwork(Artwork artwork)
        {
            try
            {
                string query = "INSERT INTO Artwork (Title, Description, CreationDate, Medium, ImageURL, ArtistID) " +
                               "VALUES (@Title, @Description, @CreationDate, @Medium, @ImageURL, @ArtistID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", artwork.Title);
                    command.Parameters.AddWithValue("@Description", artwork.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CreationDate", artwork.CreationDate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Medium", artwork.Medium ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ImageURL", artwork.ImageUrl ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ArtistID", artwork.ArtistID);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding artwork: {ex.Message}");
                return false;
            }
        }

        // Update Artwork
        public bool UpdateArtwork(Artwork artwork)
        {
            try
            {
                string query = "UPDATE Artwork SET Title = @Title, Description = @Description, CreationDate = @CreationDate, " +
                               "Medium = @Medium, ImageURL = @ImageURL, ArtistID = @ArtistID WHERE ArtworkID = @ArtworkID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ArtworkID", artwork.ArtworkID);
                    command.Parameters.AddWithValue("@Title", artwork.Title);
                    command.Parameters.AddWithValue("@Description", artwork.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CreationDate", artwork.CreationDate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Medium", artwork.Medium ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ImageURL", artwork.ImageUrl ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ArtistID", artwork.ArtistID);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating artwork: {ex.Message}");
                return false;
            }
        }

        // Remove Artwork
        public bool RemoveArtwork(int artworkID)
        {
            try
            {
                string query = "DELETE FROM Artwork WHERE ArtworkID = @ArtworkID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ArtworkID", artworkID);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing artwork: {ex.Message}");
                return false;
            }
        }

        // Get Artwork by ID
        public Artwork GetArtworkById(int artworkID)
        {
            try
            {
                string query = "SELECT * FROM Artwork WHERE ArtworkID = @ArtworkID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ArtworkID", artworkID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Artwork
                            {
                                ArtworkID = (int)reader["ArtworkID"],
                                Title = reader["Title"].ToString(),
                                Description = reader["Description"]?.ToString(),
                                CreationDate = reader["CreationDate"] as DateTime?,
                                Medium = reader["Medium"]?.ToString(),
                                ImageUrl = reader["ImageURL"]?.ToString(),
                                ArtistID = (int)reader["ArtistID"]
                            };
                        }
                        else
                        {
                            throw new myexceptions.ArtWorkNotFoundException($"Artwork with ID {artworkID} not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching artwork by ID: {ex.Message}");
                throw;
            }
        }

        // Search Artworks
        public List<Artwork> SearchArtworks(string keyword)
        {
            List<Artwork> artworks = new List<Artwork>();
            try
            {
                string query = "SELECT * FROM Artwork WHERE Title LIKE @Keyword OR Description LIKE @Keyword";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            artworks.Add(new Artwork
                            {
                                ArtworkID = (int)reader["ArtworkID"],
                                Title = reader["Title"].ToString(),
                                Description = reader["Description"]?.ToString(),
                                CreationDate = reader["CreationDate"] as DateTime?,
                                Medium = reader["Medium"]?.ToString(),
                                ImageUrl = reader["ImageURL"]?.ToString(),
                                ArtistID = (int)reader["ArtistID"]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching artworks: {ex.Message}");
            }
            return artworks;
        }
    }
}