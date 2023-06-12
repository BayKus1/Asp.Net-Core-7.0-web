using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.DTO
{
    public class SessionInfo
    {
        public int UserId { get; set; }

        public byte[] PictureData { get; set; }

        public string PictureUrl { get; set; }

        public int UserRoleId { get; set; }

        public short? UnıtId { get; set; }  

        public string ProgramId { get; set; }

        public int RoleId { get; set; } 

        public string UserFullName { get; set; }

        public string RoleName { get; set; }

        public bool HasManyRoles { get; set; }
    }
}
