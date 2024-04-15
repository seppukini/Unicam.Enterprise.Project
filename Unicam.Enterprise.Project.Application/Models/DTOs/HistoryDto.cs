using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Enterprise.Project.Application.Models.DTOs
{
    public class HistoryDto
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public int UserId { get; init; }
        public int userRoleId { get; }
        public int pageIndex { get; }
        public int pageSize { get; }
    } 
}
