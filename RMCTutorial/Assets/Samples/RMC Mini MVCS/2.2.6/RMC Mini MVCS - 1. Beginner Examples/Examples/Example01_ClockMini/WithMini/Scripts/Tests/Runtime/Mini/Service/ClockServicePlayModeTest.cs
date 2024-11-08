using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace RMC.Mini.Samples.Clock.WithMini.Mini.Service
{
    /// <summary>
    /// This Unit Test validates that code executes as expected.
    /// </summary>
    [Category("RMC.Mini.Samples.Clock")]
    public class ClockServicePlayModeTest
    {

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void TimeDelay_Is0_WhenNotLoaded()
        {
            // Arrange
            IContext context = new Context();
            ClockService clockService = new ClockService();

            // Act
            clockService.Initialize(context);

            // Assert
            Assert.That(clockService.TimeDelay, Is.EqualTo(0));
        }


        [UnityTest]
        public IEnumerator TimeDelay_Is3_WhenLoaded()
        {
            // Arrange
            IContext context = new Context();
            ClockService clockService = new ClockService();

            int timeDelay = 0;
            bool isLoaded = false;
            clockService.Initialize(context);
            clockService.OnLoaded.AddListener(() =>
            {
                timeDelay = clockService.TimeDelay;
                isLoaded = true;
            });

            // Act
            clockService.Load();
            yield return new WaitUntil(() => isLoaded == true);

            // Assert
            Assert.That(timeDelay, Is.EqualTo(1000));
        }


    }
}