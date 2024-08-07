﻿using OpenMusic.API.Models.Artist;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMusic.API.Models.Song
{
    public class SongCreateDto
    {
        public required string Title { get; set; }
        public required string SongUrl { get; set; }
        [JsonConverter(typeof(DateOnlyConverter))]
        public string? ReleaseDate { get; set; }
        public int? AlbumId { get; set; }
        public string? AlbumTitle { get; set; }
    }
}
