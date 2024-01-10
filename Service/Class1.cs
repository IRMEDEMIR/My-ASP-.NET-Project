using Film.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Film.Service
{
    public class IncelemelerService
    {
        internal string GetFilmName(int? filmId)
        {
            using (var context = new yettiEntities2())
            {
                var film = context.Filmlers.FirstOrDefault(f => f.film_id == filmId);
                return film?.baslik;
                
            }
        }
    }
}