﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test2
{
    public static class HttpCookieCollectionExtensions
    {
        public static string Language(this HttpCookieCollection cookies)
        {
                
            return cookies["Language"]?.Value;
        }
    }
}