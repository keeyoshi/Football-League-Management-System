﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBConnection : DbContext
    {
        public DBConnection()
            : base("name=DBConnection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<fixture> fixtures { get; set; }
        public virtual DbSet<league> leagues { get; set; }
        public virtual DbSet<player> players { get; set; }
        public virtual DbSet<player_record> player_record { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<tbl_news> tbl_news { get; set; }
        public virtual DbSet<team> teams { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<league_team> league_team { get; set; }
    
        public virtual ObjectResult<st_getLoginDetails_Result> st_getLoginDetails(string user, string pass)
        {
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<st_getLoginDetails_Result>("st_getLoginDetails", userParameter, passParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> st_getRolesWRTuser(string user)
        {
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("st_getRolesWRTuser", userParameter);
        }
    
        public virtual ObjectResult<string> st_gettRolesWRTuser(string user)
        {
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("st_gettRolesWRTuser", userParameter);
        }
    }
}
