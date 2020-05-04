﻿using ConsensusScheduler.BizLogic.Abstractions.Interfaces.DALInterfaces;
using ConsensusScheduler.BizLogic.Aggregates;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace Test.BizLogic.Aggregates
{
    [ExcludeFromCodeCoverage]
    public class SchedUserAggregateTests
    {
        private static Mock<ISchedUserRepository> GetRepositoryMock()
        {
            var repoMock = new Mock<ISchedUserRepository>(MockBehavior.Loose);            
            return repoMock;
        }

        [Fact]
        public void CtorFailsOnNullRepository()
        {
            Assert.Throws<ArgumentNullException>(() => new SchedUserAggregate(null));
        }
    }
}
