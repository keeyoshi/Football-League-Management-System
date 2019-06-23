//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FootballLeague
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class league
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public league()
        {
            this.fixtures = new HashSet<fixture>();
            this.league_team = new HashSet<league_team>();
            this.teams = new HashSet<team>();
            this.users = new HashSet<user>();
        }
        [Key]
        public int league_id { get; set; }

        [Display(Name = "League Name")]
        [Required(ErrorMessage = "Name Required")]
        public string league_name { get; set; }

        [Display(Name = "League Type")]
        [Required(ErrorMessage = "Type Required")]
        public string league_type { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Date Required")]
        [DataType(DataType.Date)]
        public System.DateTime start_date { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "Date Required")]
        [DataType(DataType.Date)]
        public System.DateTime end_date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fixture> fixtures { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<league_team> league_team { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<team> teams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }
    }
}