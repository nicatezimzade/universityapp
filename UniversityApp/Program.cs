using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Group> groupContext = new List<Group>();

            string Progresbar = "Hi dear Bashir teacher, Good luck to give me good point";
            var title = "";
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int i = 0; i < Progresbar.Length; i++)
                {
                    title += Progresbar[i];
                    Console.Title = title;
                    Thread.Sleep(100);
                }
                title = "";

                Console.WriteLine("Menu: Add group - 1 | Add student - 2 | Add student mark - 3 | View student list - 4 | Find student - 5 | Delete group - 6 | exit");
                Console.ResetColor();

                string userResponse = Console.ReadLine();

                if (userResponse.ToLower() == "exit")
                {
                    break;
                }

                int selection;
                bool selectionIsValid = int.TryParse(userResponse, out selection);

                if (selectionIsValid && selection >= 1 && selection <= 6)
                {
                    switch (selection)
                    {
                        case (int)AppMenuSelection.AddGroup:

                            Console.Write("Enter group name: ");
                            string groupName = Console.ReadLine();
                            if (string.IsNullOrEmpty(groupName))
                            {
                                Console.WriteLine("Group name invalid.");
                                break;
                            }

                            Console.Write("Enter group max count: ");

                            string userChoise = Console.ReadLine();
                            int maxstudentcount;
                            bool choiseIsValid = int.TryParse(userChoise, out maxstudentcount);
                            if (!choiseIsValid)
                            {
                                Console.WriteLine("Max count invalid.");
                                break;
                            }

                            Group newGroup = new Group(groupName, maxstudentcount);

                            if (groupContext.Contains(newGroup))
                            {
                                Console.WriteLine("Group already exists.");
                                break;
                            }

                            groupContext.Add(newGroup);
                            Console.WriteLine("Group added successfully.");

                            break;
                        case (int)AppMenuSelection.AddStudent:
                            if (groupContext.Count <= 0)
                            {
                                Console.WriteLine("Add a group first.");
                                break;
                            }

                            Console.Write("Enter student name: ");
                            string studentName = Console.ReadLine();
                            if (string.IsNullOrEmpty(studentName))
                            {
                                Console.WriteLine("Student name invalid.");
                                break;
                            }

                            Console.Write("Enter student surname: ");
                            string studentSurname = Console.ReadLine();
                            if (string.IsNullOrEmpty(studentName))
                            {
                                Console.WriteLine("Student surname invalid.");
                                break;
                            }

                            Console.Write("Enter student age: ");
                            int studentAge = Convert.ToInt32(Console.ReadLine());
                            if (studentAge < 0 && studentAge > 200)
                            {
                                Console.WriteLine("Student age invalid");
                                break;
                            }


                            Console.Write("Enter student points count: ");
                            string userCountResponse = Console.ReadLine();
                            int pointscount;
                            bool userCountResponseIsValid = int.TryParse(userCountResponse, out pointscount);
                            if (!userCountResponseIsValid)
                            {
                                Console.WriteLine("Points count invalid.");
                                break;
                            }

                            Console.Write("Enter student points: ");

                            List<int> points = new List<int>(pointscount);
                            for (int i = 1; i < pointscount; i++)
                            {
                                points[i] = Convert.ToInt32(Console.ReadLine());
                                if (points[i] > 100 && points[i] < 0)
                                {
                                    Console.WriteLine("Student points invalid");
                                    break;
                                }
                            }
                            int average = 0;
                            foreach (int item in points)
                            {
                                int sum = 0;
                                sum += item;
                                average = sum / points.Count;
                            }

                            foreach (Group item in groupContext)
                            {
                                Console.WriteLine(item);
                            }

                            Console.Write("Enter the id of the group that you want to add the student to: ");
                            int studentGroupId;
                            bool studentGroupIdIsInvalid = int.TryParse(Console.ReadLine(), out studentGroupId);
                            if (studentGroupIdIsInvalid)
                            {
                                Console.WriteLine("Group id invalid.");
                                break;
                            }

                            Group groupToAddStudentTo = null;

                            foreach (Group item in groupContext)
                            {
                                if (item.Id == studentGroupId)
                                {
                                    groupToAddStudentTo = item;
                                }
                            }

                            if (groupToAddStudentTo == null)
                            {
                                Console.WriteLine("Group does not exist.");
                                break;
                            }

                            Student newStudent = new Student(studentName, studentSurname, studentAge, average);

                            if (groupToAddStudentTo.AddStudent(newStudent))
                            {
                                Console.WriteLine("Student added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Student already exists.");
                            }

                            break;

                        case (int)AppMenuSelection.AddStudentMark:
                            Console.Write("Enter the id of the group you want to add points to the student: ");
                            string userGroupIdChoise = Console.ReadLine();
                            int markAddedStudentGroupId;
                            bool markAddedStudentGroupIdIsValid = int.TryParse(userGroupIdChoise, out markAddedStudentGroupId);
                            if (!markAddedStudentGroupIdIsValid)
                            {
                                Console.WriteLine("Group id invalid");
                                break;
                            }

                            Group groupToAddStudentMarkTo = null;

                            foreach (Group item in groupContext)
                            {
                                if (item.Id == markAddedStudentGroupId)
                                {
                                    groupToAddStudentMarkTo = item;
                                }
                            }

                            if (groupToAddStudentMarkTo == null)
                            {
                                Console.WriteLine("Group does not exist.");
                                break;
                            }

                            Console.Write("Enter the id of student whom you want to add mark: ");
                            string userIdChoise = Console.ReadLine();
                            int markAddedStudentId;
                            bool markAddedStudentIdIsValid = int.TryParse(userIdChoise, out markAddedStudentId);
                            if (!markAddedStudentIdIsValid)
                            {
                                Console.WriteLine("Student does not exist");
                                break;
                            }

                            Console.Write("Enter mark: ");
                            string enteredMark = Console.ReadLine();
                            int studentMark;
                            bool enteredMarkIsValid = int.TryParse(enteredMark, out studentMark);
                            if (!enteredMarkIsValid && studentMark < 0 && studentMark > 100)
                            {
                                Console.WriteLine("Mark invalid");
                            }

                            List<int> Marks = new List<int>();
                            Marks.Add(studentMark);
                            break;
                        case (int)AppMenuSelection.ViewStudentList:
                            foreach (Group item in groupContext)
                            {
                                item.PrintAllStudents();
                            }
                            break;
                        case (int)AppMenuSelection.FindStudent:
                            Console.Write("Enter query: ");
                            string usersQuery = Console.ReadLine();
                            if (string.IsNullOrEmpty(usersQuery))
                            {
                                Console.WriteLine("Query invalid.");
                                break;
                            }

                            foreach (Group item in groupContext)
                            {
                                item.SearchAndPrintStudents(usersQuery);
                            }

                            break;
                        case (int)AppMenuSelection.DeleteGroup:

                            foreach (Group item in groupContext)
                            {
                                Console.WriteLine(item);
                            }

                            Console.Write("Enter the id of the country that you want to delete: ");
                            int deleteGroupId;
                            bool deleteGroupIdIsInvalid = int.TryParse(Console.ReadLine(), out deleteGroupId);
                            if (deleteGroupIdIsInvalid)
                            {
                                Console.WriteLine("Country id invalid.");
                                break;
                            }

                            Group groupToDelete = null;

                            foreach (Group item in groupContext)
                            {
                                if (item.Id == deleteGroupId)
                                {
                                    groupToDelete = item;
                                }
                            }

                            if (groupToDelete == null)
                            {
                                Console.WriteLine("Group does not exist.");
                                break;
                            }

                            groupContext.Remove(groupToDelete);

                            Console.WriteLine("Group deleted successfully.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid menu selection.");
                }
            }

        }
    }
}
