using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System;
namespace BLL.Test
{
    [TestClass]
    public class StadiumTests
    {
        [TestMethod]
        public void Default_Constructor_Should_return_Default_Medical_Card()
        {
            FootballStadium footballPlayer = new FootballStadium(10, 100, StadiumName.Luzhniki);
            int expected = 10;
            Assert.AreEqual(expected, footballPlayer._numberSeats);
        }

        [TestMethod]
        public void Default_Constructor_Should_return_Default_Medical_Card2()
        {
            FootballStadium footballPlayer = new FootballStadium(10, 100, StadiumName.Luzhniki);
            int expected = 100;
            Assert.AreEqual(expected, footballPlayer._priceSeat);
        }
        [TestMethod]
        public void Default_Constructor_Should_return_Default_Medical_Card3()
        {
            FootballStadium footballPlayer = new FootballStadium(10, 100, StadiumName.Luzhniki);
            StadiumName expected = StadiumName.Luzhniki;
            Assert.AreEqual(expected, footballPlayer._nameStadion);
        }
        [TestMethod]
        public void IsMatch_after_Initialize_Should_return_true()
        {
            FootballStadium footballPlayer = new FootballStadium(10, 100, StadiumName.Luzhniki);
            FieldCollection fields = new FieldCollection(1);
            fields.Add("Number of seats", 10);
            fields.Add("Price of seats", 100);
            fields.Add("Name Stadium", StadiumName.Luzhniki);

            footballPlayer.Initialize(fields);

            bool Expected = true;
            Assert.AreEqual(Expected, footballPlayer.IsMatch(fields));
        }

        [TestMethod]
        public void Equals_Shoud_return_false_by_type()
        {
            FootballStadium footballPlayer = new FootballStadium(10, 100, StadiumName.Luzhniki);
            object obj = new FootballStadium();
            bool Expected = false;
            Assert.AreEqual(Expected, footballPlayer.Equals(obj));
        }





        [TestMethod]
        public void GetDemonstrationString_should_be_equal()
        {
            FootballStadium footballPlayer = new FootballStadium(10, 100, StadiumName.Luzhniki);
            string Expected = $"Name Stadium - {footballPlayer._nameStadion}\n" +
                $"Number of seats - {footballPlayer._numberSeats}\n" +
                $"Price of seats - {footballPlayer._priceSeat}\n";
            Assert.AreEqual(Expected, footballPlayer.GetDemonstrationString());
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
            FootballStadium footballPlayer = new FootballStadium(10, 100, StadiumName.Luzhniki);
            SerializationInfo info = new SerializationInfo(footballPlayer.GetType(), new System.Runtime.Serialization.FormatterConverter());
            StreamingContext context = new StreamingContext();
            footballPlayer.GetObjectData(info, context);
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
            FootballStadium footballPlayer = new FootballStadium(10, 100, StadiumName.Luzhniki);
            FieldCollection fieldCollection = new FieldCollection(2);
            fieldCollection.Add("Number of seats", 100);
            fieldCollection.Add("Price of seats", "Hello");
            fieldCollection.Add("Name Stadium", StadiumName.Luzhniki);

            bool Expected = true;
            Assert.AreEqual(Expected, footballPlayer.IsMatch(fieldCollection));
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

            string path = "C:\\НАУ\\ООП\\CourseWork\\CourseWork_Football\\PL\\bin\\Debug\\net5.0\\footballStadium.txt";
            DataContext _context = new DataContext();
            FootballStadium[] patients = _context.Deserialize(path).To<FootballStadium>();
            FootballStadium patient1 = patients[0];
            string Expected = $"Name Stadium - {StadiumName.Luzhniki}\n" + $"Number of seats - {100}\n" + $"Price of seats - {10}\n";
            Assert.AreEqual(Expected, patient1.GetDemonstrationString());
        }


        [TestMethod]
        public void IsMatch_return_true_with_invalid_Surname8()
        {

            FootballStadium footballPlayer = new FootballStadium(10, 100, StadiumName.Luzhniki);
            FieldCollection fieldCollection = new FieldCollection(6);
            fieldCollection.Add("Number of seats", 200);
            fieldCollection.Add("Price of seats", 251 );
            footballPlayer.Change(fieldCollection);
            object obj = new FootballGame();
            bool Expected = false;
            Assert.AreEqual(Expected, footballPlayer.Equals(obj));

        }






    }
}
