﻿
namespace Nancy.Conventions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Nancy.Session;

    public class DefaultCultureConventions : IConvention
    {
        public void Initialise(NancyConventions conventions)
        {
            this.ConfigureDefaultConventions(conventions);

        }

        public Tuple<bool, string> Validate(NancyConventions conventions)
        {
            if (conventions.CultureConventions == null)
            {
                return Tuple.Create(false, "The culture conventions cannot be null.");
            }

            return (conventions.CultureConventions.Count > 0) ?
               Tuple.Create(true, string.Empty) :
               Tuple.Create(false, "The culture conventions cannot be empty.");
        }


        private void ConfigureDefaultConventions(NancyConventions conventions)
        {
            conventions.CultureConventions = new List<Func<NancyContext, CultureInfo>>(6)
            {
                BuiltInCultureConventions.FormCulture,
                BuiltInCultureConventions.PathCulture,
                BuiltInCultureConventions.HeaderCulture,
                BuiltInCultureConventions.SessionCulture,
                BuiltInCultureConventions.CookieCulture,
                BuiltInCultureConventions.ThreadCulture
            };

        }

    }
}
