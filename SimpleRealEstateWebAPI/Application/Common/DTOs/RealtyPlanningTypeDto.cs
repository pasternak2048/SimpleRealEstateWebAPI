using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.DTOs
{
    public class RealtyPlanningTypeDto
    {
        public Guid Id { get; set; }
        public PlanningTypeDto PlanningType { get; set; }

    }
}
