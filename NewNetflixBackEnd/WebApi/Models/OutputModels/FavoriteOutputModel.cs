using Microsoft.AspNetCore.Mvc;

namespace WebApi.Models.OutputModels
{
    public class FavoriteOutputModel 
    {
        public int FavoritesId { get; set; }
        public int? UsrId { get; set; }
        public int? MvId { get; set; }
        public int? SeId { get; set; }
    }
}
