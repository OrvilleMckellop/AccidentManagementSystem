using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentManagementSystem.Dtos.Claim
{
    public class CreateClaimDto
    {
        public DateTime DateFiled { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public int AccidentID { get; set; }
    }
}