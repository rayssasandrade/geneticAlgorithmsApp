﻿using System;
using System.Collections.Generic;

namespace geneticAlgorithmsApp.src.Models
{
    public class Professor 
    {
        public string Id { get; set; }
        public String Nome { get; set; }
        public List<Turma> Turmas { get; set; }
    }
}