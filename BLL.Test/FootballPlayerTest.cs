using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System;
namespace BLL.Test
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Default_Constructor_Should_return_Default_Medical_Card()
        {
            FootballPlayer footballPlayer = new FootballPlayer("Dima", "Yefimchuk", System.DateTime.Parse("2003 01 12"), Status.good, Health.healthy, "1000");
            string expected = "Dima";
            Assert.AreEqual(expected, footballPlayer._name);
        }

        [TestMethod]
        public void Param_Constructor_Should_return_Default_Medical_Card()
        {
            FootballPlayer person = new FootballPlayer("Dima", "Yefimchuk", System.DateTime.Parse("2003 01 12"), Status.good, Health.healthy, "1000");
            string Expected = "Dima" + "Yefimchuk" + System.DateTime.Parse("2003 01 12") + Status.good + Health.healthy + "1000";
            Assert.AreEqual(Expected, person._name + person._surname + person._born + person._status + person._health + person._salary);
        }

        [TestMethod]
        public void IsMatch_after_Initialize_Should_return_true()
        {
            FootballPlayer person = new FootballPlayer("Dima", "Yefimchuk", System.DateTime.Parse("2003 01 12"), Status.good, Health.healthy, "1000");
            FieldCollection fields = new FieldCollection(1);
            fields.Add("Name", "Dima");
            fields.Add("Surname", "Yefimchuk");
            fields.Add("Born", System.DateTime.Parse("2003 01 12"));
            fields.Add("Status", Status.good);
            fields.Add("Health", Health.healthy);
            fields.Add("Salary", "2");
            person.Initialize(fields);

            bool Expected = true;
            Assert.AreEqual(Expected, person.IsMatch(fields));
        }

        [TestMethod]
        public void Equals_Shoud_return_false_by_type()
        {
            FootballPlayer person = new FootballPlayer("Dima", "Yefimchuk", System.DateTime.Parse("2003 01 12"), Status.good, Health.healthy, "1000");
            object obj = new object();
            FootballPlayer footballPlayer = new FootballPlayer();
            bool Expected = false;
            Assert.AreEqual(Expected, person.Equals(footballPlayer));
        }

        

       

        [TestMethod]
        public void GetDemonstrationString_should_be_equal()
        {
            FootballPlayer person = new FootballPlayer("Dima", "Yefimchuk", System.DateTime.Parse("2003 01 12"), Status.good, Health.healthy, "1000");
            string Expected = $"Name: {person._name}\n"
                + $"Surname: {person._surname}\n"
                + $"Salary: {person._salary}\n"
                + $"Status: {person._status}\n"
                + $"Born: {person._born}\n"
                + $"Health: {person._health}\n";
            Assert.AreEqual(Expected, person.GetDemonstrationString());
        }


        [TestMethod]
        public void IsMatch_return_false_with_invalid_fields()
        {
            FootballPlayer person = new FootballPlayer("Dima", "Yefimchuk", System.DateTime.Parse("2003 01 12"), Status.good, Health.healthy, "1000");
            object obj = new object();
            FieldCollection fieldCollection = new FieldCollection(3);
            fieldCollection.Add("Invalid", "Invalid");
            bool Expected = false;
            Assert.AreEqual(Expected, person.IsMatch(fieldCollection));
        }

        [TestMethod]
        public void IsMatch_return_false_with_default_fileds()
        {
            FootballPlayer person = new FootballPlayer("Dima", "Yefimchuk", System.DateTime.Parse("2003 01 12"), Status.good, Health.healthy, "1000");
            FieldCollection fieldCollection = new FieldCollection(3);
            bool Expected = false;
            Assert.AreEqual(Expected, person.IsMatch(fieldCollection));
        }

        [TestMethod]
        public void GetObjectData_Test()
        {
            FootballPlayer person = new FootballPlayer("Dima", "Yefimchuk", System.DateTime.Parse("2003 01 12"), Status.good, Health.healthy, "1000");
            SerializationInfo info = new SerializationInfo(person.GetType(), new System.Runtime.Serialization.FormatterConverter());
            StreamingContext context = new StreamingContext();
            person.GetObjectData(info, context);
        }

        [TestMethod]
        public void IsMatch_return_false_with_invalid_Name()
        {
            FootballPlayer person = new FootballPlayer("1", "2", System.DateTime.Parse("2003 01 12"), Status.cantPlay, Health.healthy, "2");
            FieldCollection fieldCollection = new FieldCollection(3);
            fieldCollection.Add("Name", "Invalid");
            bool Expected = false;
            Assert.AreEqual(Expected, person.IsMatch(fieldCollection));
        }

        [TestMethod]
        public void IsMatch_return_false()
        {
            FootballPlayer person = new FootballPlayer("1", "2", System.DateTime.Parse("2003 01 12"), Status.cantPlay, Health.healthy, "2");
            FieldCollection fieldCollection = new FieldCollection(6);
            fieldCollection.Add("Name", "Invalid");
            fieldCollection.Add("Surname", "Invalid");
            fieldCollection.Add("Born", System.DateTime.Parse("2003 01 12"));
            fieldCollection.Add("Status", Status.cantPlay);
            fieldCollection.Add("Health", Health.healthy);
            fieldCollection.Add("Salary", "2");
            
            bool Expected = false;
            Assert.AreEqual(Expected, person.IsMatch(fieldCollection));
        }

        [TestMethod]
        public void IsMatch_return_true_with_invalid_Surname()
        {
            FootballPlayer person = new FootballPlayer("1", "2", System.DateTime.Parse("2003 01 12"), Status.cantPlay, Health.healthy, "2");
            FieldCollection fieldCollection = new FieldCollection(3);
            fieldCollection.Add("Name", "Nikolay");
            fieldCollection.Add("Surname", "Chernenkyi");
            bool Expected = false;
            Assert.AreEqual(Expected, person.IsMatch(fieldCollection));
        }

        [TestMethod]
        public void IsMatch_return_true_with_invalid_Surname2()
        {
           
            string path = "C:\\мюс\\нно\\CourseWork\\CourseWork_Football\\PL\\bin\\Debug\\net5.0\\footballPlayer.txt";
            DataContext _context = new DataContext();
            FootballPlayer[] patients = _context.Deserialize(path).To<FootballPlayer>();
            FootballPlayer patient1 = patients[0];
            string Expected = $"Name: Dima\n" + $"Surname: Yefimchuk\n" + $"Salary: 2\n" + $"Status: {Status.cantPlay}\n" + $"Born: { System.DateTime.Parse("2003 01 12")}\n" + $"Health: {Health.sick}\n";
            Assert.AreEqual(Expected, patient1.GetDemonstrationString());
        }

        [TestMethod]
        public void IsMatch_return_true_with_invalid_Surname8()
        {

            FootballPlayer person = new FootballPlayer("Dima", "Yefimchuk", System.DateTime.Parse("2003 01 12"), Status.good, Health.healthy, "1000");
            FieldCollection fieldCollection = new FieldCollection(6);
            fieldCollection.Add("Name", "Dimad");
            fieldCollection.Add("Surname", "Yefimchukd");
            fieldCollection.Add("Salary", "12200");
            fieldCollection.Add("Status", Status.damaged);
            fieldCollection.Add("Health", Health.sick);
            fieldCollection.Add("Born", System.DateTime.Parse("2004 01 12"));
            person.Change(fieldCollection);
            object obj = new FootballGame();
            bool Expected = false;
            Assert.AreEqual(Expected, person.Equals(obj));

        }







    }
}
