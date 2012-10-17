using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerTodoApp.Controllers;
using PowerTodoApp.Models;
using System.Linq;
using Moq;

namespace PowerTodoApp.Tests.Controllers
{
    [TestClass]
    public class IssuesControllerTest
    {
        [TestMethod]
        public void IndexListIsSorted()
        {
            // Arrange
            var mocks = new Mock<IIssueRepository>();
            var issueList = (new [] { new Issue { Title = "a", Priority = 2 }, new Issue { Title = "b", Priority = 1 } }).AsQueryable();
            mocks.SetupGet(repo => repo.All).Returns(issueList);

            IssuesController controller = new IssuesController(mocks.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            var issues = result.Model as IEnumerable<Issue>;

            // Assert
            Assert.AreEqual(issues.OrderBy(issue => issue.Priority).First(), issues.First());
        }
    }
}
