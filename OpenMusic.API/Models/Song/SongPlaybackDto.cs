﻿using System.ComponentModel;
using System.Text.Json.Serialization;

namespace OpenMusic.API.Models.Song
{
    public class SongPlaybackDto : BaseDto
    {
        public string Title { get; set; }
        public string SongUrl { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string? ArtistName { get; set; }
        public string? ArtistId { get; set; }
        public string? AlbumTitle { get; set; }
        public int? AlbumId { get; set; }
    }
}
