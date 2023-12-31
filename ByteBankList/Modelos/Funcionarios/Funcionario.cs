﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankList.Modelos.Funcionarios
{
    public abstract class Funcionario
    {
        public static int TotalFuncionarios { get; private set; }
        public string Nome { get; set; }
        public string CPF { get; private set; }
        public double Salario { get; protected set; }

        public Funcionario(double salario, string cpf)
        {
            Console.WriteLine("Criando FUNCIONÁRIO");

            CPF = cpf;
            Salario = salario;

            TotalFuncionarios++;
        }

        public abstract void AumentarSalario();
        internal protected abstract double GetBonificacao();
    }
}
