﻿using System;
using System.Collections.Generic;
// using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestApp.Mocking
{
    public class VideoService_DI_Property
    {
        public IFileReader FileReader { get; set; }

        public VideoService_DI_Property()
        {
            FileReader = new FileReader();
        }

        public string ReadVideoTitle()
        {
            var str = FileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        /* public string GetUnprocessedVideosAsCsv()
         {
             var videoIds = new List<int>();

             using (var context = new VideoContext())
             {
                 var videos = 
                     (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();

                 foreach (var v in videos)
                     videoIds.Add(v.Id);

                 return String.Join(",", videoIds);
             }
         }*/
    }

    /*public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }*/
}