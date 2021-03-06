﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoomsAndFurniture.Web.Queries.DatabaseInitialization {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class MainDbInitializationQueries {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MainDbInitializationQueries() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("RoomsAndFurniture.Web.Queries.DatabaseInitialization.MainDbInitializationQueries", typeof(MainDbInitializationQueries).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to create table if not exists Room (
        ///    Id int autoincrement not null,
        ///    CreateDate datetime not null,
        ///    Name varchar(20) not null,
        ///    constraint PF_Room primary key (Id)
        ///)
        ///
        ///create table if not exists Furniture (
        ///    Id int autoincrement not null,
        ///    Date datetime not null,
        ///    Type varchar(20) not null,
        ///    Count int not null,
        ///    RoomId int not null,
        ///    constraint PF_Furniture primary key (Id),
        ///    constraint FK_Furniture_RoomId_Room_Id foreign key (RoomId) references Room(Id)
        ///)
        ///
        ///cre [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CreateMainDatabaseSql {
            get {
                return ResourceManager.GetString("CreateMainDatabaseSql", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        internal static string InitialDataSql {
            get {
                return ResourceManager.GetString("InitialDataSql", resourceCulture);
            }
        }
    }
}
