using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System;
namespace BLL.Test
{
    [TestClass]
    public class GameTests
    {

        [TestMethod]
        public void Default_Constructor_Should_return_Default_Medical_Card()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            System.DateTime expected = DateTime.Parse("2003 01 12");
            Assert.AreEqual(expected, footballPlayer.DateOfEvent);
        }

        [TestMethod]
        public void Default_Constructor_Should_return_Default_Medical_Card2()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            PlaceGame expected = PlaceGame.Athens;
            Assert.AreEqual(expected, footballPlayer._placeGame);
        }
        [TestMethod]
        public void Default_Constructor_Should_return_Default_Medical_Card3()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            Teams expected = Teams.Barselona;
            Assert.AreEqual(expected, footballPlayer._team1);
        }
        [TestMethod]
        public void Default_Constructor_Should_return_Default_Medical_Card4()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            Teams expected = Teams.LiverPool;
            Assert.AreEqual(expected, footballPlayer._team2);
        }
        [TestMethod]
        public void Default_Constructor_Should_return_Default_Medical_Card5()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            int expected = 1000;
            Assert.AreEqual(expected, footballPlayer._numberOfspectators);
        }
        [TestMethod]
        public void IsMatch_after_Initialize_Should_return_true()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            FieldCollection fields = new FieldCollection(6);
            fields.Add("Date of Event", DateTime.Parse("2003 01 12"));
            fields.Add("Place game", PlaceGame.Athens);
            fields.Add("Number of spectators", 100);
            fields.Add("Team One", Teams.Barselona);
            fields.Add("Team Two", Teams.LiverPool);
            footballPlayer.Initialize(fields);
            bool Expected = true;
            Assert.AreEqual(Expected, footballPlayer.IsMatch(fields));
        }
        [TestMethod]
        public void IsMatch_after_Initialize_Should_return_true2()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2022 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            FieldCollection fields = new FieldCollection(6);
            fields.Add("Date of Event", DateTime.Parse("2022 01 12"));
            fields.Add("Place game", PlaceGame.Athens);
            fields.Add("Number of spectators", 100);
            fields.Add("Team One", Teams.Barselona);
            fields.Add("Team Two", Teams.LiverPool);
            footballPlayer.Initialize(fields);
            bool Expected = true;
            Assert.AreEqual(Expected, footballPlayer.IsMatch(fields));
        }

        [TestMethod]
        public void IsMatch_after_Initialize_Should_return_true3()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2022 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            FieldCollection fields = new FieldCollection(6);
            fields.Add("Date of Event", DateTime.Parse("2022 01 12"));
            fields.Add("Place game", PlaceGame.Athens);
            fields.Add("Number of spectators", 100);
            fields.Add("Team One", Teams.Barselona);
            fields.Add("Team Two", Teams.LiverPool);
            fields.Add("Win", Teams.Barselona);
            footballPlayer.Initialize(fields);
            bool Expected = true;
            Assert.AreEqual(Expected, footballPlayer.IsMatch(fields));
        }
        [TestMethod]
        public void IsMatch_after_Initialize_Should_return_true5()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2022 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            FieldCollection fields = new FieldCollection(6);
            fields.Add("Date of Event", DateTime.Parse("2020 01 12"));
            fields.Add("Place game", PlaceGame.Athens);
            fields.Add("Number of spectators", 100);
            fields.Add("Team One", Teams.Barselona);
            fields.Add("Team Two", Teams.LiverPool);
            fields.Add("Win", Teams.LiverPool);
            fields.Add(footballPlayer._resultGame, $"{0} : {2}");
            footballPlayer.Initialize(fields);
            bool Expected = true;
            Assert.AreEqual(Expected, footballPlayer.IsMatch(fields));
        }
        [TestMethod]
        public void IsMatch_after_Initialize_Should_return_true4()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2022 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            FieldCollection fields = new FieldCollection(6);
            fields.Add("Date of Event", DateTime.Parse("2020 01 12"));
            fields.Add("Place game", PlaceGame.Athens);
            fields.Add("Number of spectators", 200);
            fields.Add("Team One", Teams.Barselona);
            fields.Add("Team Two", Teams.LiverPool);
            fields.Add("Win", Teams.Barselona);
            fields.Add(footballPlayer._resultGame, $"{2} : {0}");
            footballPlayer.Initialize(fields);
            bool Expected = true;
            Assert.AreEqual(Expected, footballPlayer.IsMatch(fields));
        }

        [TestMethod]
        public void Equals_Shoud_return_false_by_type()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            object obj = new FootballGame();
            bool Expected = false;
            Assert.AreEqual(Expected, footballPlayer.Equals(obj));
        }





        [TestMethod]
        public void GetDemonstrationString_should_be_equal()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            string Expected = $"Team One - {footballPlayer._team1} = = = " +
                $"Team Two - {footballPlayer._team2}\n"
            + $"Date of Event: {footballPlayer._dateOfEvent}\n"
                + $"Place game: {footballPlayer._placeGame}\n"
                + $"Number of spectators: {footballPlayer._numberOfspectators}\n"
                + $"Result game: {footballPlayer._resultGame}\n"
                + $"Win: {footballPlayer.Win}\n"
                + $"Players :  \n ";

            Assert.AreEqual(Expected, footballPlayer.GetDemonstrationString());
        }


        [TestMethod]
        public void IsMatch_return_false_with_invalid_fields()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            object obj = new object();
            FieldCollection fieldCollection = new FieldCollection(3);
            fieldCollection.Add("Invalid", "Invalid");
            bool Expected = false;
            Assert.AreEqual(Expected, footballPlayer.IsMatch(fieldCollection));
        }

        [TestMethod]
        public void IsMatch_return_false_with_default_fileds()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            FieldCollection fieldCollection = new FieldCollection(3);
            bool Expected = false;
            Assert.AreEqual(Expected, footballPlayer.IsMatch(fieldCollection));
        }

        [TestMethod]
        public void GetObjectData_Test()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            SerializationInfo info = new SerializationInfo(footballPlayer.GetType(), new System.Runtime.Serialization.FormatterConverter());
            StreamingContext context = new StreamingContext();
            footballPlayer.GetObjectData(info, context);
        }

        [TestMethod]
        public void IsMatch_return_false_with_invalid_Name()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            FieldCollection fieldCollection = new FieldCollection(3);
            fieldCollection.Add("Name", "Invalid");
            bool Expected = false;
            Assert.AreEqual(Expected, footballPlayer.IsMatch(fieldCollection));
        }

        [TestMethod]
        public void IsMatch_return_false()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            FieldCollection fieldCollection = new FieldCollection(6);
            fieldCollection.Add("Date of Event", DateTime.Parse("2002 01 12"));
            fieldCollection.Add("Place game", PlaceGame.Athens);
            fieldCollection.Add("Number of spectators", 100);
            fieldCollection.Add("Team One", Teams.Barselona);
            fieldCollection.Add("Team Two", Teams.LiverPool);
            bool Expected = true;
            Assert.AreEqual(Expected, footballPlayer.IsMatch(fieldCollection));
        }

        [TestMethod]
        public void IsMatch_return_true_with_invalid_Surname()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            FieldCollection fieldCollection = new FieldCollection(3);
            fieldCollection.Add("Name", "Nikolay");
            fieldCollection.Add("Surname", "Chernenkyi");
            bool Expected = false;
            Assert.AreEqual(Expected, footballPlayer.IsMatch(fieldCollection));
        }

        [TestMethod]
        public void IsMatch_return_true_with_invalid_Surname2()
        {
            string path = "C:\\НАУ\\ООП\\CourseWork\\CourseWork_Football\\PL\\bin\\Debug\\net5.0\\footballGame.txt";
            DataContext _context = new DataContext();
            FootballGame[] patients = _context.Deserialize(path).To<FootballGame>();
            FootballGame patient1 = patients[0];
            string Expected = $"Team One - {Teams.Arsenal} = = = " + $"Team Two - {Teams.Barselona}\n" + $"Date of Event: { System.DateTime.Parse("2003 01 12")}\n" + $"Place game: {PlaceGame.Kiyv}\n" + $"Number of spectators: {1000}\n" + $"Result game: 2 : 6\n" + $"Win: Barselona\n" + $"Players :  \n ";
            Assert.AreEqual(Expected, patient1.GetDemonstrationString());
        }
              [TestMethod]
        public void IsMatch_return_true_with_invalid_Surname6()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            FootballPlayer footballPlayer2 = new FootballPlayer("Dima", "Yefimchuk", System.DateTime.Parse("2003 01 12"), Status.good, Health.healthy, "1000");
         
            footballPlayer.AddOffer(footballPlayer2);
            FootballGame footballGame = footballPlayer;
            Assert.AreEqual(footballPlayer, footballGame);
        }
        [TestMethod]
        public void IsMatch_return_true_with_invalid_Surname7()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
            FootballPlayer footballPlayer2 = new FootballPlayer("Dima", "Yefimchuk", System.DateTime.Parse("2003 01 12"), Status.good, Health.healthy, "1000");
 
            footballPlayer.DeleteOffer(footballPlayer2);
            FootballGame footballGame = footballPlayer;
            Assert.AreEqual(footballPlayer, footballGame);
        }
        [TestMethod]
        public void IsMatch_return_true_with_invalid_Surname8()
        {
            FootballGame footballPlayer = new FootballGame(DateTime.Parse("2003 01 12"), PlaceGame.Athens, 1000, Teams.Barselona, Teams.LiverPool);
          
            FieldCollection fieldCollection = new FieldCollection(6);
            fieldCollection.Add("Date of Event", DateTime.Parse("2002 01 12"));
            fieldCollection.Add("Place game", PlaceGame.Moscow);
            fieldCollection.Add("Number of spectators", 1200);
            footballPlayer.GetDemonstrationString();
            
            footballPlayer.Change(fieldCollection);
            object obj = new FootballGame();
            bool Expected = false;
            Assert.AreEqual(Expected, footballPlayer.Equals(obj));

        }






    }
}
