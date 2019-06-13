using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShmotStore.Models
{
    public enum OrderStatus
    {
        [Display(Name = "На удержании")]
        OnHold,
        [Display(Name = "Выполняется")]
        InProcessing,
        [Display(Name = "Выполнен")]
        Completed
    }
}