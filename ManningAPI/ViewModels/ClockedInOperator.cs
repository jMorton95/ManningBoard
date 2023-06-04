﻿using ManningApi.Models;

namespace ManningApi.ViewModels
{
    public class ClockedInOperator
    {
        public Operator? CurrentOperator { get; set; }
        public string? JsonWebToken { get; set; }
        public ClockedInOperator(Operator currentOperator, string jsonWebToken)
        {
            CurrentOperator = currentOperator;
            JsonWebToken = jsonWebToken;
        }


    }
}
