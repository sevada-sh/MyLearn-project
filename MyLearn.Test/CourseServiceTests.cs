using MyLearn.Application.Services;
using MyLearn.Domain.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Test
{
    public class CourseServiceTests
    {
        CourseService _courseservice;

        [Test]
        public void Search_Works()
        {
            //Arrange

            var search = "Asp.net core";
            var courses = new List<Course>()
            {
                new Course{CourseName="asp.net core"},
            };


            //Act

            var SearchedCourse = _courseservice.Search(search);


            //Assert

            Assert.That(SearchedCourse, Is.EqualTo(courses.Where(s => s.CourseName == search)));

        }
    }
}
