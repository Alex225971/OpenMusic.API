# OpenMusic.API

## A simple API allowing users to upload songs, artists, albums, playlists
Intended to be used by my future front-end Angular, Vue, React and Blazor projects

### Project goals
- [x] Use Microsoft ASP.NET Identity & JWTs
- [ ] Provide end points for users to like songs and artists
- [x] Allow users to make playlists
- [ ] Allow users to follow playlists
- [x] Allow admins to add albums/songs
- [x] Store uploaded songs on cloud service (possibly locally during development)
- [x] Playback of audio files

## Running this project
~~This project has no front end yet, I will be making these in separate projects in future.~~\
The first (Vue) front end consuming this API can be found [here](https://github.com/Alex225971/OpenMusic.Vue)

### Requirements
- A SQL database (can be hosted or local using [SQL Server Express](https://www.microsoft.com/en-gb/download/details.aspx?id=101064))
To get the API running on your machine you will need to download the repository, create a cloudinary account and find your Cloud Name, API Key and API Secret. Then:
- Open the project in Visual Studio
- Right click the API project and click "manage user secrets"
- Include the following configurations in your user secrets file
```
"CloudinarySettings": {
  "CloudName": "<your cloud name>",
  "ApiKey": "<your api key>",
  "ApiSecret": "<your api secret>"
},
"JwtSettings": {
  "Key": "<a jwt secret of your choice>"
},
"ConnectionStrings": {
  "OpenMusicDbConnection": "<your sql database connection string>"
}
```
- Press F5 to run the project and take a look at the swagger documentation
