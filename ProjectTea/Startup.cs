﻿using Owin;

namespace ProjectTea
{
    public class Startup
    {
       
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}