using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using Newtonsoft.Json;
using System.Threading;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Manages interactions between the FrmMediatek user interface and the data access layer.
    /// </summary>
    public class MediaController
    {
        /// <summary>
        /// Provides access to the database methods.
        /// </summary>
        private readonly DataAccessLayer dataAccess;

        /// <summary>
        /// Initializes a new instance of the controller using a singleton of the data access class.
        /// </summary>
        public MediaController()
        {
            dataAccess = DataAccessLayer.GetInstance();
        }

        /// <summary>
        /// Retrieves all genre categories from the database.
        /// </summary>
        /// <returns>A list of genre categories.</returns>
        public List<Category> RetrieveAllGenres()
        {
            return dataAccess.FetchAllGenres();
        }

        /// <summary>
        /// Retrieves all books from the database.
        /// </summary>
        /// <returns>A list of books.</returns>
        public List<Book> RetrieveAllBooks()
        {
            return dataAccess.FetchAllBooks();
        }

        /// <summary>
        /// Retrieves all DVDs from the database.
        /// </summary>
        /// <returns>A list of DVDs.</returns>
        public List<DVD> RetrieveAllDVDs()
        {
            return dataAccess.FetchAllDVDs();
        }

        /// <summary>
        /// Retrieves all magazines from the database.
        /// </summary>
        /// <returns>A list of magazines.</returns>
        public List<Magazine> RetrieveAllMagazines()
        {
            return dataAccess.FetchAllMagazines();
        }

        /// <summary>
        /// Retrieves all shelf categories from the database.
        /// </summary>
        /// <returns>A list of shelf categories.</returns>
        public List<Category> RetrieveAllShelves()
        {
            return dataAccess.FetchAllShelves();
        }

        /// <summary>
        /// Retrieves all target audience categories from the database.
        /// </summary>
        /// <returns>A list of audience categories.</returns>
        public List<Category> RetrieveAllAudiences()
        {
            return dataAccess.FetchAllAudiences();
        }

        /// <summary>
        /// Retrieves all copies of a specific magazine identified by its ID.
        /// </summary>
        /// <param name="magazineId">The ID of the magazine for which copies are being retrieved.</param>
        /// <returns>A list of magazine copies.</returns>
        public List<Copy> RetrieveCopiesByMagazine(string magazineId)
        {
            return dataAccess.FetchCopiesByMagazine(magazineId);
        }

        /// <summary>
        /// Adds a new copy of a magazine to the database.
        /// </summary>
        /// <param name="copy">The magazine copy to add.</param>
        /// <returns>Whether the operation was successful.</returns>
        public bool AddMagazineCopy(Copy copy)
        {
            return dataAccess.AddCopy(copy);
        }

        /// <summary>
        /// Adds a new book to the database with specified details.
        /// </summary>
        /// <param name="book">The book to create, including details.</param>
        /// <returns>True if the book was successfully created, false otherwise.</returns>
        public bool AddBook(Book book)
        {
            return dataAccess.AddNewBook(book);
        }

        /// <summary>
        /// Updates details of an existing book in the database.
        /// </summary>
        /// <param name="book">The book with updated details to modify in the database.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        public bool ModifyBook(Book book)
        {
            return dataAccess.ModifyExistingBook(book);
        }

        /// <summary>
        /// Removes a book from the database using its ID.
        /// </summary>
        /// <param name="book">The book to remove.</param>
        /// <returns>True if the book was successfully removed, false otherwise.</returns>
        public bool RemoveBook(Book book)
        {
            return dataAccess.RemoveBook(book);
        }

        /// <summary>
        /// Adds a new DVD to the database, detailing its attributes.
        /// </summary>
        /// <param name="dvd">The DVD to add.</param>
        /// <returns>True if the DVD was successfully created, false otherwise.</returns>
        public bool AddDVD(DVD dvd)
        {
            return dataAccess.AddNewDVD(dvd);
        }

        /// <summary>
        /// Updates details of an existing DVD in the database.
        /// </summary>
        /// <param name="dvd">The DVD with updated details to modify in the database.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        public bool ModifyDVD(DVD dvd)
        {
            return dataAccess.ModifyExistingDVD(dvd);
        }

        /// <summary>
        /// Removes a DVD from the database using its ID.
        /// </summary>
        /// <param name="dvd">The DVD to remove.</param>
        /// <returns>True if the DVD was successfully removed, false otherwise.</returns>
        public bool RemoveDVD(DVD dvd)
        {
            return dataAccess.RemoveDVD(dvd);
        }

        /// <summary>
        /// Adds a new magazine to the database, detailing its attributes.
        /// </summary>
        /// <param name="magazine">The magazine to add.</param>
        /// <returns>True if the magazine was successfully created, false otherwise.</returns>
        public bool AddMagazine(Magazine magazine)
        {
            return dataAccess.AddNewMagazine(magazine);
        }

        /// <summary>
        /// Updates details of an existing magazine in the database.
        /// </summary>
        /// <param name="magazine">The magazine with updated details to modify in the database.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        public bool ModifyMagazine(Magazine magazine)
        {
            return dataAccess.ModifyExistingMagazine(magazine);
        }

        /// <summary>
        /// Removes a magazine from the database using its ID.
        /// </summary>
        /// <param name="magazine">The magazine to remove.</param>
        /// <returns>True if the magazine was successfully removed, false otherwise.</returns>
        public bool RemoveMagazine(Magazine magazine)
        {
            return dataAccess.RemoveMagazine(magazine);
        }
    }
}