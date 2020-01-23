﻿using AutoStep.Elements;
using AutoStep.Elements.ReadOnly;

namespace AutoStep.Execution.Contexts
{

    public class ScenarioContext : StepCollectionContext
    {
        internal ScenarioContext(IScenarioInfo scenario, VariableSet example)
        {
            Scenario = scenario;
            Variables = example;
        }

        public IScenarioInfo Scenario { get; }

        public VariableSet Variables { get; }
    }
}
