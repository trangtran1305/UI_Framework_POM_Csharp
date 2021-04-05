using Assignment02.reporter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment02.actions.commons
{
    class Assertion
    {
        public static void True(bool condition, string failureMessage, string successMessage)
        {
            try
            {
                Assert.True(condition, failureMessage);
                HtmlReporter.Pass(successMessage);

            }
            catch (Exception e)
            {
                HtmlReporter.Fail(failureMessage);
                throw e;

            }

        }
        public static void Equals(Object actual, Object expected, string failureMessage, string successMessage)
        {
            try
            {
                Assert.AreEqual(actual, expected, failureMessage);
                HtmlReporter.Pass(successMessage);
            }
            catch(Exception e)
            {
                HtmlReporter.Fail(failureMessage);
                throw e;
            }
        }
        public static void Constains(string actual, string expected, string failureMessage, string successMessage) 
        {
            try
            {
                Assert.True(actual.Contains(expected),failureMessage);
                HtmlReporter.Pass(successMessage);
            }
            catch(Exception e)
            {
                HtmlReporter.Fail(failureMessage);
                throw e;
            }
        }
    }

}
