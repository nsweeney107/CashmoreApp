using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CashmoreApp.Models;
using CashmoreApp.Data;

namespace CashmoreApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CashmoreAppContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any Entities.
            if (context.Entities.Any())
            {
                return;   // DB has been seeded
            }

            // Add the Entities
            var entities = new Entity[]
            {
                // Hospital
                new Entity { EntityName = "Your Hospital", EntityAddress1 = "123 Main Street", EntityAddress2="", EntityCity = "Big City", EntityState = "IL", EntityZipcode = "61104",
                    EntityCountry = "USA", EntityPhoneNumber ="8881231234", EntityType = EntityTypes.Hospital },
                // Vender1
                new Entity { EntityName = "Vendor 1", EntityAddress1 = "12345 1st Street", EntityAddress2="", EntityCity = "Big City", EntityState = "IL", EntityZipcode = "61114",
                    EntityCountry = "USA", EntityPhoneNumber ="8888888888", EntityType = EntityTypes.Vendor },
                // Vendor2
                new Entity { EntityName = "Vendor 2", EntityAddress1 = "432 West Street", EntityAddress2="Suite 103", EntityCity = "Medium City", EntityState = "WI", EntityZipcode = "55555",
                    EntityCountry = "USA", EntityPhoneNumber ="7777777777", EntityType = EntityTypes.Vendor },
                // Vendor3
                new Entity { EntityName = "Vendor 3", EntityAddress1 = "444 4th Street", EntityAddress2="Suite 444", EntityCity = "Large City", EntityState = "CA", EntityZipcode = "11111",
                    EntityCountry = "USA", EntityPhoneNumber ="5555555555", EntityType = EntityTypes.Vendor }
            };

            foreach (Entity e in entities)
            {
                context.Entities.Add(e);
            }
            context.SaveChanges();

            //Add Users
            // Load the entities for easier access when mapping users
            var hospital = entities.Single( e => e.EntityName == "Your Hospital");
            var vendorOne = entities.Single( e => e.EntityName == "Vendor 1");
            var vendorTwo = entities.Single( e => e.EntityName == "Vendor 2");
            var vendorThree = entities.Single( e => e.EntityName == "Vendor 3");

            var users = new User[]
            {
                new User { UserFirstName = "Leader 1", UserLastName = "Hospital", UserEmail = "l1@hospital.org", UserPassword = "password", UserAccessLevel = Access.FullAccess, 
                    EntityID = hospital.EntityID },
                new User { UserFirstName = "Leader 2", UserLastName = "Hospital", UserEmail = "l2@hospital.org", UserPassword = "password", UserAccessLevel = Access.FullAccess,
                    EntityID = hospital.EntityID },
                new User { UserFirstName = "User 1", UserLastName = "Hospital", UserEmail = "u1@hospital.org", UserPassword = "password", UserAccessLevel = Access.ReadOnly,
                    EntityID = hospital.EntityID },
                new User { UserFirstName = "Leader 1", UserLastName = "Vendor 1", UserEmail = "l1@vendor1.com", UserPassword = "password", UserAccessLevel = Access.FullAccess,
                    EntityID = vendorOne.EntityID },
                new User { UserFirstName = "Leader 1", UserLastName = "Vendor 2", UserEmail = "l1@vendor2.com", UserPassword = "password", UserAccessLevel = Access.FullAccess,
                    EntityID = vendorTwo.EntityID },
                new User { UserFirstName = "Leader 1", UserLastName = "Vendor 3", UserEmail = "l1@vendor3.com", UserPassword = "password", UserAccessLevel = Access.FullAccess,
                    EntityID = vendorThree.EntityID }
            };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();


            // Map Users to Entities
            // Hospital
            // var hospital = entities.Single( e => e.EntityName == "Your Hospital");
            // var hospitalUsers = users.Where(u => u.UserLastName == "Hospital");
            // foreach(User u in hospitalUsers)
            // {
            //     hospital.EntityUsers.Add(u);
            // }
            // context.SaveChanges();
            // // Vendor 1
            // var vendorOne = entities.Single( e => e.EntityName == "Vendor 1");
            // var vendorOneUsers = users.Single(u => u.UserLastName == "Vendor 1");
            // vendorOne.EntityUsers.Add(vendorOneUsers);
            // context.SaveChanges();
            // // Vendor 2
            // var vendorTwo = entities.Single( e => e.EntityName == "Vendor 2");
            // var vendorTwoUsers = users.Single(u => u.UserLastName == "Vendor 2");
            // vendorTwo.EntityUsers.Add(vendorTwoUsers);
            // context.SaveChanges();
            // // Vendor 1
            // var vendorThree = entities.Single( e => e.EntityName == "Vendor 3");
            // var vendorThreeUsers = users.Single(u => u.UserLastName == "Vendor 3");
            // vendorThree.EntityUsers.Add(vendorThreeUsers);
            // context.SaveChanges();


            // Add some Contracts
            var contracts = new Contract[]
            {
                // Fully Completed Contract
                new Contract{ ContractProductLine = "Ultrasound U9", ContractPurchaseOrder = "C123782", ContractStatus = "Active", ContractStartDate = DateTime.Parse("2017-03-02"),
                    ContractEndDate = DateTime.Parse("2018-03-01"), ContractValue = 60000m },
                // One Signature Contract
                new Contract{ ContractProductLine = "Medical Supplies", ContractPurchaseOrder = "N/A", ContractStatus = "Active", ContractStartDate = DateTime.Parse("2012-11-01"),
                    ContractEndDate = DateTime.Parse("2017-10-30"), ContractValue = 50000000m },
                // No Signatures Contract
                new Contract{ ContractProductLine = "MA for Ultrasound 9", ContractPurchaseOrder = "987621", ContractStatus = "Active", ContractStartDate = DateTime.Parse("2018-03-01"),
                    ContractEndDate = DateTime.Parse("2021-02-28"), ContractValue = 30000m }
            };

            foreach (Contract c in contracts)
            {
                context.Contracts.Add(c);
            }
            context.SaveChanges();


            // Add Entities to Contracts
            var contractOne = contracts.Single( c => c.ContractProductLine == "Ultrasound U9");
            var contractTwo = contracts.Single( c => c.ContractProductLine == "Medical Supplies");
            var contractThree = contracts.Single( c => c.ContractProductLine == "MA for Ultrasound 9");

            var entityContracts = new EntityToContract[]
            {
                // Contract 1
                new EntityToContract { EntityID = hospital.EntityID, ContractID = contractOne.ContractID },
                new EntityToContract { EntityID = vendorOne.EntityID, ContractID = contractOne.ContractID },
                // Contract 2
                new EntityToContract { EntityID = hospital.EntityID, ContractID = contractTwo.ContractID },
                new EntityToContract { EntityID = vendorTwo.EntityID, ContractID = contractTwo.ContractID },
                // Contract 3
                new EntityToContract { EntityID = hospital.EntityID, ContractID = contractThree.ContractID },
                new EntityToContract { EntityID = vendorOne.EntityID, ContractID = contractThree.ContractID }
            };

            foreach (EntityToContract etc in entityContracts)
            {
                context.EntityContracts.Add(etc);
            }
            context.SaveChanges();
            // var contractOne = contracts.Single( c => c.ContractProductLine == "Ultrasound U9");
            // contractOne.ContractEntities.Add(hospital);
            // contractOne.ContractEntities.Add(vendorOne);

            // var contractTwo = contracts.Single( c => c.ContractProductLine == "Medical Supplies");
            // contractTwo.ContractEntities.Add(hospital);
            // contractTwo.ContractEntities.Add(vendorTwo);

            // var contractThree = contracts.Single( c => c.ContractProductLine == "MA for Ultrasound 9");
            // contractThree.ContractEntities.Add(hospital);
            // contractThree.ContractEntities.Add(vendorOne);

            // context.SaveChanges();


            // Add Signatures to Contracts
            // Grab the leaders to map to signatures
            var hospitalUsers = users.Where(u => u.UserLastName == "Hospital");
            var hospitalLeader = hospitalUsers.Single( u => u.UserFirstName == "Leader 1");
            var vendorOneUsers = users.Single(u => u.UserLastName == "Vendor 1");
            var vendorTwoUsers = users.Single(u => u.UserLastName == "Vendor 2");
            var vendorThreeUsers = users.Single(u => u.UserLastName == "Vendor 3");
            
            // Contract One has everything signed 
            var contractOneSignatures = new Signatures[]
            {
                new Signatures{ ContractID = contractOne.ContractID, ContractType = ContractTypes.CaptialContract, HospitalSignature = hospitalLeader, VendorSignature = vendorOneUsers },
                new Signatures{ ContractID = contractOne.ContractID, ContractType = ContractTypes.MaintenanceAgreementContract, HospitalSignature = hospitalLeader, VendorSignature = vendorOneUsers },
                new Signatures{ ContractID = contractOne.ContractID, ContractType = ContractTypes.NetworkAccessContract, HospitalSignature = hospitalLeader, VendorSignature = vendorOneUsers },
                new Signatures{ ContractID = contractOne.ContractID, ContractType = ContractTypes.BAAContract, HospitalSignature = hospitalLeader, VendorSignature = vendorOneUsers },
                new Signatures{ ContractID = contractOne.ContractID, ContractType = ContractTypes.SecurityRiderContract, HospitalSignature = hospitalLeader, VendorSignature = vendorOneUsers },
                new Signatures{ ContractID = contractOne.ContractID, ContractType = ContractTypes.SecurityAssessmentContract, HospitalSignature = hospitalLeader, VendorSignature = vendorOneUsers }
            };

            foreach (Signatures s in contractOneSignatures)
            {
                context.Signatures.Add(s);
            }
            context.SaveChanges();

            // Contract 2 has everything signed from the hospital side
            var contractTwoSignatures = new Signatures[]
            {
                new Signatures{ ContractID = contractTwo.ContractID, ContractType = ContractTypes.SupplyContract, HospitalSignature = hospitalLeader },
                new Signatures{ ContractID = contractTwo.ContractID, ContractType = ContractTypes.MinorEquipmentContract, HospitalSignature = hospitalLeader },
                new Signatures{ ContractID = contractTwo.ContractID, ContractType = ContractTypes.ProductUsageContract, HospitalSignature = hospitalLeader }
            };

            foreach (Signatures s in contractTwoSignatures)
            {
                context.Signatures.Add(s);
            } 
            context.SaveChanges();

            // Contract 3 we will add signatures as a test, so no signatures are needed            
        }
    }
}

//             var students = new Student[]
//             {
//                 new Student { FirstMidName = "Carson",   LastName = "Alexander",
//                     EnrollmentDate = DateTime.Parse("2010-09-01") },
//                 new Student { FirstMidName = "Meredith", LastName = "Alonso",
//                     EnrollmentDate = DateTime.Parse("2012-09-01") },
//                 new Student { FirstMidName = "Arturo",   LastName = "Anand",
//                     EnrollmentDate = DateTime.Parse("2013-09-01") },
//                 new Student { FirstMidName = "Gytis",    LastName = "Barzdukas",
//                     EnrollmentDate = DateTime.Parse("2012-09-01") },
//                 new Student { FirstMidName = "Yan",      LastName = "Li",
//                     EnrollmentDate = DateTime.Parse("2012-09-01") },
//                 new Student { FirstMidName = "Peggy",    LastName = "Justice",
//                     EnrollmentDate = DateTime.Parse("2011-09-01") },
//                 new Student { FirstMidName = "Laura",    LastName = "Norman",
//                     EnrollmentDate = DateTime.Parse("2013-09-01") },
//                 new Student { FirstMidName = "Nino",     LastName = "Olivetto",
//                     EnrollmentDate = DateTime.Parse("2005-09-01") }
//             };

//             foreach (Student s in students)
//             {
//                 context.Students.Add(s);
//             }
//             context.SaveChanges();

//             var instructors = new Instructor[]
//             {
//                 new Instructor { FirstMidName = "Kim",     LastName = "Abercrombie",
//                     HireDate = DateTime.Parse("1995-03-11") },
//                 new Instructor { FirstMidName = "Fadi",    LastName = "Fakhouri",
//                     HireDate = DateTime.Parse("2002-07-06") },
//                 new Instructor { FirstMidName = "Roger",   LastName = "Harui",
//                     HireDate = DateTime.Parse("1998-07-01") },
//                 new Instructor { FirstMidName = "Candace", LastName = "Kapoor",
//                     HireDate = DateTime.Parse("2001-01-15") },
//                 new Instructor { FirstMidName = "Roger",   LastName = "Zheng",
//                     HireDate = DateTime.Parse("2004-02-12") }
//             };

//             foreach (Instructor i in instructors)
//             {
//                 context.Instructors.Add(i);
//             }
//             context.SaveChanges();

//             var departments = new Department[]
//             {
//                 new Department { Name = "English",     Budget = 350000,
//                     StartDate = DateTime.Parse("2007-09-01"),
//                     InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },
//                 new Department { Name = "Mathematics", Budget = 100000,
//                     StartDate = DateTime.Parse("2007-09-01"),
//                     InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },
//                 new Department { Name = "Engineering", Budget = 350000,
//                     StartDate = DateTime.Parse("2007-09-01"),
//                     InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },
//                 new Department { Name = "Economics",   Budget = 100000,
//                     StartDate = DateTime.Parse("2007-09-01"),
//                     InstructorID  = instructors.Single( i => i.LastName == "Kapoor").ID }
//             };

//             foreach (Department d in departments)
//             {
//                 context.Departments.Add(d);
//             }
//             context.SaveChanges();

//             var courses = new Course[]
//             {
//                 new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3,
//                     DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
//                 },
//                 new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3,
//                     DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
//                 },
//                 new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3,
//                     DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
//                 },
//                 new Course {CourseID = 1045, Title = "Calculus",       Credits = 4,
//                     DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
//                 },
//                 new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4,
//                     DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
//                 },
//                 new Course {CourseID = 2021, Title = "Composition",    Credits = 3,
//                     DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
//                 },
//                 new Course {CourseID = 2042, Title = "Literature",     Credits = 4,
//                     DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
//                 },
//             };

//             foreach (Course c in courses)
//             {
//                 context.Courses.Add(c);
//             }
//             context.SaveChanges();

//             var officeAssignments = new OfficeAssignment[]
//             {
//                 new OfficeAssignment {
//                     InstructorID = instructors.Single( i => i.LastName == "Fakhouri").ID,
//                     Location = "Smith 17" },
//                 new OfficeAssignment {
//                     InstructorID = instructors.Single( i => i.LastName == "Harui").ID,
//                     Location = "Gowan 27" },
//                 new OfficeAssignment {
//                     InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID,
//                     Location = "Thompson 304" },
//             };

//             foreach (OfficeAssignment o in officeAssignments)
//             {
//                 context.OfficeAssignments.Add(o);
//             }
//             context.SaveChanges();

//             var courseInstructors = new CourseAssignment[]
//             {
//                 new CourseAssignment {
//                     CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
//                     InstructorID = instructors.Single(i => i.LastName == "Kapoor").ID
//                     },
//                 new CourseAssignment {
//                     CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
//                     InstructorID = instructors.Single(i => i.LastName == "Harui").ID
//                     },
//                 new CourseAssignment {
//                     CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
//                     InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
//                     },
//                 new CourseAssignment {
//                     CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
//                     InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
//                     },
//                 new CourseAssignment {
//                     CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
//                     InstructorID = instructors.Single(i => i.LastName == "Fakhouri").ID
//                     },
//                 new CourseAssignment {
//                     CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
//                     InstructorID = instructors.Single(i => i.LastName == "Harui").ID
//                     },
//                 new CourseAssignment {
//                     CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
//                     InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
//                     },
//                 new CourseAssignment {
//                     CourseID = courses.Single(c => c.Title == "Literature" ).CourseID,
//                     InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
//                     },
//             };

//             foreach (CourseAssignment ci in courseInstructors)
//             {
//                 context.CourseAssignments.Add(ci);
//             }
//             context.SaveChanges();

//             var enrollments = new Enrollment[]
//             {
//                 new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Alexander").ID,
//                     CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
//                     Grade = Grade.A
//                 },
//                     new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Alexander").ID,
//                     CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
//                     Grade = Grade.C
//                     },
//                     new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Alexander").ID,
//                     CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
//                     Grade = Grade.B
//                     },
//                     new Enrollment {
//                         StudentID = students.Single(s => s.LastName == "Alonso").ID,
//                     CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
//                     Grade = Grade.B
//                     },
//                     new Enrollment {
//                         StudentID = students.Single(s => s.LastName == "Alonso").ID,
//                     CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
//                     Grade = Grade.B
//                     },
//                     new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Alonso").ID,
//                     CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
//                     Grade = Grade.B
//                     },
//                     new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Anand").ID,
//                     CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
//                     },
//                     new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Anand").ID,
//                     CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
//                     Grade = Grade.B
//                     },
//                 new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Barzdukas").ID,
//                     CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
//                     Grade = Grade.B
//                     },
//                     new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Li").ID,
//                     CourseID = courses.Single(c => c.Title == "Composition").CourseID,
//                     Grade = Grade.B
//                     },
//                     new Enrollment {
//                     StudentID = students.Single(s => s.LastName == "Justice").ID,
//                     CourseID = courses.Single(c => c.Title == "Literature").CourseID,
//                     Grade = Grade.B
//                     }
//             };

//             foreach (Enrollment e in enrollments)
//             {
//                 var enrollmentInDataBase = context.Enrollments.Where(
//                     s =>
//                             s.Student.ID == e.StudentID &&
//                             s.Course.CourseID == e.CourseID).SingleOrDefault();
//                 if (enrollmentInDataBase == null)
//                 {
//                     context.Enrollments.Add(e);
//                 }
//             }
//             context.SaveChanges();