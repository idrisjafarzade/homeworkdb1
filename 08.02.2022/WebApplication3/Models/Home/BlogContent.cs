using System;

namespace WebApplication3.Models.Home
{
    public class BlogContent
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string ImgName { get; set; }   
        
        public DateTime dateTime { get; set; }
        public string Text { get; set; }
    }
}
