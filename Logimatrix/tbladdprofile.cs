//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Logimatrix
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public partial class tbladdprofile
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string ProfileImage { get; set; }

        public HttpPostedFileBase ImageFile{ get; set; }
    }
}
