using System.Collections.Generic;
using WebApplication3.Models;
using WebApplication3.Models.Home;

namespace WebApplication3.ViewModels
{
    public class HomeVM
    {
        public AboutImg AboutImg { get; set; }

        public AboutText AboutText { get; set; }    

        public ExpertTitle ExpertTitle { get; set; } 
        public List<ExpertPerson> ExpertPerson { get; set; }

        public Background Backgrounds { get; set; } 

        public List<BlogContent> BlogContents { get; set; }
         
        public BlogTitle BlogTitles { get; set; }
        public List<PersonsAbout> PersonsAbouts { get; set; }   
        public List<SliderImgIcons> SliderImgIcons { get; set; }

        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }
    }
}
