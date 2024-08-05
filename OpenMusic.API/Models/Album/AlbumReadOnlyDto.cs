﻿namespace OpenMusic.API.Models.Album
{
    public class AlbumReadOnlyDto
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string? Genre { get; set; }
        public string ArtistName { get; set; }
    }
}
