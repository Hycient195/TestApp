using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Mocking
{
    public class VideoService_DI_Constructor
    {
        private IFileReader _fileReader;

        public VideoService_DI_Constructor(IFileReader fileReader = null)
        {
            _fileReader = fileReader ?? new FileReader(); // Checks if fileReader was received as argument, and uses it, else creates a new fileReader
        }

        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }
    }
}

/* This exercise deals with dependency injection in testing */