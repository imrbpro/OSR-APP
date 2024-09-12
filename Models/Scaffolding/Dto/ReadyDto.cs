using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.dto
{
    public class ReadyDto
    {
        public string? DealNo { get; set; } = "";
        public string? DealNoTo { get; set; } = "";
        public string? DealDate { get; set; } = "";
        public string? DealDateTo { get; set; } = "";
        public string? ValueDate { get; set; } = "";
        public string? ValueDateTo { get; set; } = "";
        public string? BrCode { get; set; } = "";
        public string? Ccy { get; set; } = "";
        public string? PortFolio { get; set; } = "";
        public string? Trader { get; set; } = "";
        public string? Customer { get; set; } = ""; 
        public string? Ps { get; set; } = "";
        public int? OrderBy { get; set; } = 0;
    }
}
