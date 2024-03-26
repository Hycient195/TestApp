using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestApp.Mocking
{
    public class VideoServiceExercise
    {
        public string ReadVideoTitle(IFileReader fileReader)
        {
            var str = fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";

            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv(IVideoRepository videoRepository)
        {
            var videoIds = new List<int>();

            // var videoRepository = new VideoRepository();
            var videos = videoRepository.GetUnprocessedVideos();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
    }

    /*public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }*/
}