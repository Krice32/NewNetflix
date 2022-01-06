using Microsoft.AspNetCore.Mvc;

namespace WebApi.Models.InputModels
{
    public class FavoriteInputModel
    {
        public int FavoritesId { get; set; }
        public int? UsrId { get; set; }
        public int? MvId { get; set; }
        public int? SeId { get; set; }
    }
}
