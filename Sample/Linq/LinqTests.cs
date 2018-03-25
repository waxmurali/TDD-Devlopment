using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Linq
{
    [TestFixture]
    public class LinqTests
    {
        //Show files in a directory in a order basked on filesize

        [Test]
        public void Given_A_Directory_Display_Files_In_DescendingOrder_BasedOnFileSize()
        {
            //Arrange
            var directoryPath = @"D:\Music\Tamil\NewTamilTracks";
            var fileHandler = new FileHandler(directoryPath);
            var expectedList = new List<string>{"naan.mp3","maru.mp3","visiri.mp3"};

            //Act
            var resultList = fileHandler.GetFilesInAscByFileSize();

            //Assert
            Assert.IsTrue(resultList.SequenceEqual(expectedList),"Actual and expected list does not match");
        }

        [Test]
        public void Given_A_ListOfMovies_ListOnly_Movies_After_2000()
        {
            //Arrange
            var expectedMovies = new List<string>(){"The Dark Knight","Coco"};
            var movies = new Movies();
            
            //Act
            var actualResult = movies.GetAllMovies().Where(m => m.Year > 2000).
                OrderByDescending(m=>m.Title).Select(m => m.Title);

            //Expected
            Assert.IsTrue(expectedMovies.SequenceEqual(actualResult));
        }
    }

    public class FileHandler
    {
        private string _directoryPath;

        public FileHandler(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public List<string> GetFilesInAscByFileSize()
        {
            var query = from file in new DirectoryInfo(_directoryPath).GetFiles()
                        orderby file.Length descending
                        select file;

            //var queryMethod = new DirectoryInfo(_directoryPath).GetFiles()
            //                .OrderByDescending(f=>f.Length).Take(5);

            var fileNamesBySize = new List<string>();
            fileNamesBySize.AddRange(query.Select(f => f.Name.ToLower()));
            return fileNamesBySize;
        }
    }

    public class Movies
    {
        public IEnumerable<Movie> GetAllMovies()
        {
            return new List<Movie>()
            {
                new Movie(){Rating = 9,Title = "The Dark Knight",Year = 2014},
                new Movie(){Rating = 8,Title = "Coco",Year = 2018},
                new Movie(){Rating = 7,Title = "Tomb Raider",Year = 1999},
                new Movie(){Rating = 6,Title = "Pulp Fiction",Year = 1992},
                new Movie(){Rating = 8,Title = "The Godfather",Year = 1972},
            };
        }
    }

    public class Movie
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        public int Year { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
