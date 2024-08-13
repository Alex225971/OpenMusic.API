# OpenMusic.API

## A simple API allowing users to upload songs, artists, albums, playlists
Intended to be used by my future front-end Angular, Vue, React and Blazor projects

### Project goals
- [x] Use Microsoft ASP.NET Identity & JWTs
- [ ] Provide end points for users to like songs and artists
- [ ] Allow users to make  and follow playlists
- [ ] Allow admins to add albums/songs
- [x] Store uploaded songs on cloud service (possibly locally during development)
- [x] Playback of audio files

##Running this project
This project has no front end yet, I will be making these in separate projects in future. 
To get the API running on your machine you will need a Cloudinary account.
- Open the project in Visual Studio
- Right click the API project and click "manage user secrets"
- Include the following configurations in your user secrets file
```
"CloudinarySettings": {
  "CloudName": "<your cloud name>",
  "ApiKey": "<your api key>",
  "ApiSecret": "<your api secret>"
}
```
- Press F5 to run the project and take a look at the swagger documentation
