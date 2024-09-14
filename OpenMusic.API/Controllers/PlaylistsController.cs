using API.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Playlist;
using OpenMusic.API.Repositories;
using OpenMusic.API.Services;
using System.Security.Claims;

namespace OpenMusic.API.Controllers
{
    public class PlaylistsController : BaseApiController
    {
        private readonly OpenMusicDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPlaylistRepository _playlistRepository;
        private readonly ISongRepository _songRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPhotoService _photoService;

        public PlaylistsController(UserManager<ApplicationUser> userManager, OpenMusicDbContext dbContext, IMapper mapper, IPlaylistRepository playlistRepository, ISongRepository songRepository, IPhotoService photoService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _playlistRepository = playlistRepository;
            _songRepository = songRepository;
            _photoService = photoService;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<List<PlaylistPlaybackDto>>> GetPlaylistsForUserAsync(string creatorId)
        {
            var playlist = await _playlistRepository.GetUserPlaylistsAsync(creatorId);
            return Ok(playlist);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<PlaylistPlaybackDto>> GetPlaylistAsync(int id)
        {
            var playlist = await _playlistRepository.GetPlaylistForPlaybackAsync(id);
            var creatorId = User.FindFirstValue("uid");

            if (playlist == null)
            {
                return NotFound();
            }
            if(creatorId != playlist.CreatorId)
            {
                return NotFound();
            }

            var playlistDetailed = _mapper.Map<PlaylistPlaybackDto>(playlist);

            return playlistDetailed;
        }


        //[Authorize(Roles = "User,Admin")]
        [HttpPost]
        public async Task<ActionResult<PlaylistCreateDto>> CreatePlaylistAsync([FromForm] PlaylistCreateDto playlistDto, IFormFile image)
        {
            var creatorId = User.FindFirstValue("uid");
            var playlist = _mapper.Map<Playlist>(playlistDto);

            //Adding the image to cloudinary and setting image url
            if (image != null)
            {
                var result = await _photoService.AddPhotoAsync(image);
                if (result.Error != null) return BadRequest(result.Error.Message);

                playlist.ImageUrl = result.SecureUrl.AbsoluteUri;
                playlist.ImagePublicId = result.PublicId;
            }

            if (creatorId == null)
            {
                return BadRequest("You must be logged in to create a playlist, something probably went wrong with login");
            }

            if (creatorId != null)
            {
                playlist.CreatorId = creatorId;
            }

            await _playlistRepository.AddAsync(playlist);

            return StatusCode(201, playlist);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> EditPlaylistAsync(int id, [FromBody] PlaylistUpdateDto? playlistDto, int songId)
        {
            var creatorId = User.FindFirstValue("uid");
            var playlist = await _playlistRepository.GetAsync(id);

            if (id != playlist.Id) return BadRequest();
            if (playlist == null) return NotFound();

            var song = await _songRepository.GetAsync(songId);

            _mapper.Map(playlistDto, playlist);

            playlist.Songs.Add(song);

            try
            {
                await _playlistRepository.UpdateAsync(playlist);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [Authorize(Roles = "User,Admin")]
        [HttpDelete]
        public async Task<ActionResult> DeletePlaylistAsync(int id)
        {
            var playlist = await _dbContext.Playlists.FindAsync(id);

            if (playlist == null)
            {
                return NotFound();
            }

            if (playlist.ImageUrl == null) return BadRequest("Could not find a photo associated with this playlist, file not deleted");

            var result = await _photoService.DeletePhotoAsync(playlist.ImagePublicId);
            if (result.Error != null) return BadRequest(result.Error.Message);

            await _playlistRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
