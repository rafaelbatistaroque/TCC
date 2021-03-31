﻿using Colaborador.Domain.ValueObjects;

namespace Colaborador.Business.Models
{
    public class ColaboradorModel
    {
        public int Id { get; set; }
        public ColaboradorNome Nome { get; set; }
        public ColaboradorCPF ColaboradorCPF { get; set; }
        public ColaboradorFuncao Funcao { get; set; }
    }
}