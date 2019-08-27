using PagedList;
using test2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test2.ViewModels.Default
{
    public class DefaultViewModel
    {
        public List<SliderTopTB>  sliderTop { get; set; }
        public HowWeAreTB howWeAre { get; set; }
        public List<AttorneyTB> attorney{ get; set; }
        public AttorneyTB attorneySingle { get; set; }
        public List<Article> article { get; set; }
        public Article articleOne { get; set; }
        public IPagedList<Article> ArticleList { get; set; }
        public List<AreasOfActivity> areasOfActivity { get; set; }
        public BasicInfo basicInfo { get; set; }
        public NewsTB newsImage { get; set; }
        public ServicesTB servicesImage { get; set; }
        public AreasOfActivity areasOfDetail { get; set; }
        public AboutUsTB AboutImage { get; set; }


    }
}