﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manning.Api.Models
{
    public class OperatorCompletedTraining : BaseModel
    {
        [Required, RegularExpression(@"^[0-9]{6}$")]
        public int TrainerClockCardNumber { get; set; }
        [ForeignKey("OperatorID")]
        public int OperatorID { get; set; }
        [ForeignKey("TrainingRequirementID")]
        public int TrainingRequirementID { get; set; }
    }
}
