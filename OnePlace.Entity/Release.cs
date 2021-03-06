//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnePlace.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Release
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Release()
        {
            this.ReleaseDates = new HashSet<ReleaseDate>();
            this.ReleaseChangeSets = new HashSet<ReleaseChangeSet>();
            this.ReleaseExternalServices = new HashSet<ReleaseExternalService>();
            this.ReleaseSitecorePackages = new HashSet<ReleaseSitecorePackage>();
            this.ReleaseTFSFilePaths = new HashSet<ReleaseTFSFilePath>();
        }
    
        public System.Guid ReleaseID { get; set; }
        public string ReleaseTitle { get; set; }
        public string Region { get; set; }
        public System.Guid ProjectID { get; set; }
        public string DeploymentType { get; set; }
        public bool RequireBuild { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Notification { get; set; }
        public string Comment { get; set; }
        public string Reviewer { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReleaseDate> ReleaseDates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReleaseChangeSet> ReleaseChangeSets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReleaseExternalService> ReleaseExternalServices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReleaseSitecorePackage> ReleaseSitecorePackages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReleaseTFSFilePath> ReleaseTFSFilePaths { get; set; }
    }
}
