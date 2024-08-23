using API.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Playlist;
using OpenMusic.API.Repositories;
using System.Security.Claims;

namespace OpenMusic.API.Controllers
{
    public class PlaylistsController : BaseApiController
    {
        private readonly OpenMusicDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPlaylistRepository _playlistRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public PlaylistsController(UserManager<ApplicationUser> userManager, OpenMusicDbContext dbContext, IMapper mapper, IPlaylistRepository playlistRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _playlistRepository = playlistRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlaylistPlaybackDto>>> GetPlaylistsForUserAsync(string creatorId)
        {
            return Ok(await _playlistRepository.GetUserPlaylistsAsync(creatorId));
        }

        [HttpPost]
        public async Task<ActionResult<PlaylistCreateDto>> CreatePlaylistAsync(PlaylistCreateDto playlistDto)
        {
            var creatorId = User.FindFirstValue("uid");
            var playlist = _mapper.Map<Playlist>(playlistDto);

            if (creatorId == null) 
            {
                return BadRequest("You must be logged in to create a playlist, something probably went wrong with login");
            }

            if (creatorId != null)
            { 
                playlist.CreatorId = creatorId;
            }
            
            await _playlistRepository.AddAsync(playlist);

            return CreatedAtAction("CreatePlaylistAsync", new { id = playlist.Id }, playlist);
        }
    }
}
