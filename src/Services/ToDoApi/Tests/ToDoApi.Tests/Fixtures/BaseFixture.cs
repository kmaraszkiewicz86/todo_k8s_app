﻿using AutoFixture;
using AutoFixture.AutoNSubstitute;

namespace ToDoApi.Tests.Fixtures
{
    public class BaseFixture : Fixture
    {
        protected BaseFixture()
        {
            Customize(new AutoNSubstituteCustomization());
            Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => Behaviors.Remove(b));
            Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }
}
