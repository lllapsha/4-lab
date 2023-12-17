using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace WebApplication2.Controllers
{
    public class MusicCatalogController : ApiController
    {
        public Catalog catalog = new Catalog();

        public MusicCatalogController()
        {
            catalog.AddTrack(new Track { Title = "Song1", Author = "Artist1" });
            catalog.AddTrack(new Track { Title = "Song2", Author = "Artist2" });
            catalog.AddTrack(new Track { Title = "Song3", Author = "Artist1" });
        }

        // GET api/musiccatalog
        [HttpGet]
        public IHttpActionResult GetMusicCatalog()
        {
            return Json<IEnumerable<Track>>(catalog.AllTracks.ToList());
        }

        [HttpGet]
        public IHttpActionResult GetTracksByArtist(string artist)
        {
            var tracks = catalog.AllTracks.Where(t => t.Author.Contains(artist)).ToArray();
            return Json<IEnumerable<Track>>(tracks);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Post([FromBody] Track track)
        {
            catalog.AddTrack(track);
            return Json<IEnumerable<Track>>(catalog.AllTracks.ToList());
        }

        // PUT api/musiccatalog/Song1
        [System.Web.Http.HttpPut]
        public IHttpActionResult Put(string title, [FromBody] Track updatedTrack)
        {
            var existingTrack = catalog.AllTracks.FirstOrDefault(t => t.Title == title);
            if (existingTrack == null)
            {
                return NotFound();
            }

            existingTrack.Title = updatedTrack.Title;
            existingTrack.Author = updatedTrack.Author;

            return Json<IEnumerable<Track>>(catalog.AllTracks);
        }

        [HttpDelete]
        public IHttpActionResult DeleteTrack(string title)
        {
            var track = catalog.AllTracks.FirstOrDefault(t => t.Title == title);

            if (track == null)
            {
                return NotFound(); 
            }

            catalog.RemoveTrack(track);
            return Json<IEnumerable<Track>>(catalog.AllTracks);
        }
    }
}
