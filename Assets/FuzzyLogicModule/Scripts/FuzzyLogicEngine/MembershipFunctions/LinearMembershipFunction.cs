﻿using FuzzyLogicEngine.Variables;
using System;

namespace FuzzyLogicEngine.MembershipFunctions
{
    [Serializable]
    public class LinearMembershipFunction : TrapezoidMembershipFunction
    {
        // constructors:
        public LinearMembershipFunction(VariableName name, VariableValue value,
                                          float a, float b)
            : base(name, value, a, b, b, b, 0f, 1f, 1f)
        {
        }

        public LinearMembershipFunction(VariableName name, VariableValue value,
                                          float a, float b, float preValue, float postValue)
            : base(name, value, a, b, b, b, preValue, postValue, postValue)
        {
        }
    }
}
