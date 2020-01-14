﻿using System;
using System.Collections.Generic;
using AutoStep.Elements;

namespace AutoStep.Tests.Builders
{

    public class ScenarioOutlineBuilder : BaseBuilder<ScenarioOutlineElement>, IStepCollectionBuilder<ScenarioOutlineElement>
    {
        public ScenarioOutlineBuilder(string name, int line, int column, bool relativeToTextContent = false)
            : base(relativeToTextContent)
        {
            Built = new ScenarioOutlineElement
            {
                SourceLine = line,
                SourceColumn = column,
                Name = name
            };
        }
        
        public ScenarioOutlineBuilder Description(string description)
        {
            Built.Description = description;

            return this;
        }

        public ScenarioOutlineBuilder Examples(int line, int column, Action<ExampleBuilder> cfg)
        {
            var newExample = new ExampleBuilder(line, column, RelativeToTextContent);

            cfg(newExample);

            Built.AddExample(newExample.Built);

            return this;
        }
    }


}
