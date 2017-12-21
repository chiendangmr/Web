using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Models.AdministratorViewModels
{
    public partial class GroupViewModel
    {
        public GroupViewModel()
        {
        }

        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "ParentId")]
        public Guid? ParentId { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên nhóm tài khoản")]
        [Display(Name = "Nhóm tài khoản")]
        public string Name { get; set; }
    }
}
