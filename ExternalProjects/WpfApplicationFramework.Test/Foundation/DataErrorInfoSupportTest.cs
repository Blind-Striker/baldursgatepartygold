﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Waf.Foundation;
using System.ComponentModel.DataAnnotations;
using System.Waf.UnitTesting;

namespace Test.Waf.Foundation
{
    [TestClass]
    public class DataErrorInfoSupportTest
    {
        [TestMethod]
        public void InvalidArgumentsTest()
        {
            AssertHelper.ExpectedException<ArgumentNullException>(() => new DataErrorInfoSupport(null));

            DataErrorInfoSupport dataErrorInfoSupport = new DataErrorInfoSupport(new MockEntity());
            string message;
            AssertHelper.ExpectedException<ArgumentException>(() => message = dataErrorInfoSupport["InvalidMember"]);
        }
        
        [TestMethod]
        public void ValidateTest()
        {
            MockEntity mockEntity = new MockEntity();
            DataErrorInfoSupport dataErrorInfoSupport = new DataErrorInfoSupport(mockEntity);
            
            Assert.AreEqual("The Firstname field is required.", dataErrorInfoSupport["Firstname"]);
            Assert.AreEqual("The Lastname field is required.", dataErrorInfoSupport["Lastname"]);
            Assert.AreEqual("", dataErrorInfoSupport["Email"]);
            Assert.AreEqual("The Firstname field is required." + Environment.NewLine + "The Lastname field is required.", 
                dataErrorInfoSupport.Error);

            mockEntity.Firstname = "Harry";
            mockEntity.Lastname = "Potter";
            Assert.AreEqual("", dataErrorInfoSupport["Lastname"]);
            Assert.AreEqual("", dataErrorInfoSupport.Error);

            mockEntity.Email = "InvalidEmailAddress";
            Assert.AreEqual("", dataErrorInfoSupport["Lastname"]);
            Assert.AreEqual(@"The field Email must match the regular expression '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$'.", 
                dataErrorInfoSupport["Email"]);
            Assert.AreEqual(@"The field Email must match the regular expression '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$'.", 
                dataErrorInfoSupport.Error);
        }



        private class MockEntity
        {
            [Required, StringLength(30)]
            public string Firstname { get; set; }

            [Required, StringLength(30)]
            public string Lastname { get; set; }

            [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$")]
            public string Email { get; set; }
        }
    }
}
