using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.HelperModels
{
    public class OsebeFormatted
    {
        public int st { get; set; }
        public IQueryable<oseba> seznam { get; set;}

        public OsebeFormatted(int st, IQueryable<oseba> seznam)
        {
            this.st = st;
            this.seznam = seznam;
        }
    }
}