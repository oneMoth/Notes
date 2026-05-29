using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notes;

namespace Notes.Tests
{
    [TestClass]
    public class DataManagerTests
    {
        private string _testFile = "notes.json";

        [TestInitialize]
        public void Setup()
        {
            if (File.Exists(_testFile))
            {
                File.Delete(_testFile);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(_testFile))
            {
                File.Delete(_testFile);
            }
        }

        [TestMethod]
        public void SaveAndLoad_ShouldPreserveNotes()
        {
            // Arrange
            var notes = new List<Note>
            {
                new Note 
                { 
                    Title = "Test Note", 
                    Text = "Test Description", 
                    Priority = "Высокий",
                    IsCompleted = false,
                    ReminderDate = new DateTime(2025, 1, 1)
                }
            };

            // Act
            DataManager.Save(notes);
            var loadedNotes = DataManager.Load();

            // Assert
            Assert.AreEqual(1, loadedNotes.Count);
            Assert.AreEqual("Test Note", loadedNotes[0].Title);
            Assert.AreEqual("Высокий", loadedNotes[0].Priority);
            Assert.IsFalse(loadedNotes[0].IsCompleted);
        }

        [TestMethod]
        public void SaveAndLoad_CompletedState_ShouldBePreserved()
        {
            // Arrange
            var notes = new List<Note>
            {
                new Note 
                { 
                    Title = "Incomplete Note", 
                    IsCompleted = false
                },
                new Note 
                { 
                    Title = "Completed Note", 
                    IsCompleted = true
                }
            };

            // Act
            DataManager.Save(notes);
            var loadedNotes = DataManager.Load();

            // Assert
            Assert.AreEqual(2, loadedNotes.Count);
            
            var incompleteNote = loadedNotes.Find(n => n.Title == "Incomplete Note");
            Assert.IsNotNull(incompleteNote);
            Assert.IsFalse(incompleteNote.IsCompleted, "Note should be marked as incomplete");

            var completedNote = loadedNotes.Find(n => n.Title == "Completed Note");
            Assert.IsNotNull(completedNote);
            Assert.IsTrue(completedNote.IsCompleted, "Note should be marked as completed");
        }
    }
}