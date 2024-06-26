<<<<<<< HEAD:DiamondShopSystem.Business/Dtos/QueryProductDto.cs
﻿namespace DiamondShopSystem.Business.Dtos
=======
﻿
namespace DiamondShopSystem.Common.Dtos
>>>>>>> hung_lesson_19_6_2024:DiamondShopSystem.Common/Dtos/QueryProductDto.cs
{
    public class QueryProductDto
    {
        public string ProductName { get; set; } = string.Empty;

        public int DiamondSettingId { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal? LowerPrice { get; set; }
        public decimal? UpperPrice { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Terms { get; set; } = string.Empty;

        public int SideStoneId { get; set; }

        public int SideStoneAmount { get; set; }

        public int MainDiamondId { get; set; }
    }
}
