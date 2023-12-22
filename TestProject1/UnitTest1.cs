using NUnit.Framework;
using WebApplication2;
using WebApplication2.Controllers;

namespace WebApplication2.Tests
{
    [TestFixture]
    public class MusicCatalogControllerTests
    {
        [Test]
        public void GetMusicCatalog_ReturnsAllTracks()
        {
            var controller = new MusicCatalogController();
            var result = controller.GetMusicCatalog();
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetTracksByArtist_ReturnsTracksByArtist()
        {
            var controller = new MusicCatalogController();
            var artistName = "Artist1";
            var result = controller.GetTracksByArtist(artistName);
            Assert.IsNotNull(result);
        }

        [Test]
        public void Post_AddsTrackToCatalog()
        {
            var controller = new MusicCatalogController();
            var newTrack = new Track { Title = "Song", Author = "Artist" };
            var result = controller.Post(newTrack);
            Assert.IsNotNull(result);
        }

        [Test]
        public void Put_UpdatesExistingTrack()
        {
            var controller = new MusicCatalogController();
            var existingTrackTitle = "Song1";
            var updatedTrack = new Track { Title = "UpdatedSong", Author = "UpdatedArtist" };
            var result = controller.Put(existingTrackTitle, updatedTrack);
            Assert.IsNotNull(result);
        }

        [Test]
        public void DeleteTrack_RemovesTrackFromCatalog()
        {
            var controller = new MusicCatalogController();
            var trackTitleToDelete = "Song1";
            var result = controller.DeleteTrack(trackTitleToDelete);
            Assert.IsNotNull(result);
        }
    }
}