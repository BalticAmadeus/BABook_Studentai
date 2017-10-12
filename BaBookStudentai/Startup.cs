using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using BaBookStudentai.Models;
using BaBookStudentai.Entities;

[assembly: OwinStartup(typeof(BaBookStudentai.Startup))]

namespace BaBookStudentai
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
