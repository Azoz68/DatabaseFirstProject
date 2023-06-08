//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseFirstProject.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Users
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "���� ����� ��� ��������")]
        [Display(Name = "��� ��������")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "���� ����� ��� ��������")]
        [Display(Name = "���� ������")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "���� ����� ��� ��������")]
        [Display(Name = "���� ������")]
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("Password", ErrorMessage = "��� �� ������ ���� ������")]
        public string RePassword { get; set; }
    }
}
